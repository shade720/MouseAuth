using System.Windows.Forms.VisualStyles;
using MouseAuth.BusinessLogicLayer.Models.Abstractions;

namespace MouseAuth.Forms;

public partial class ControlForm : Form
{
    private readonly IFormFactory _formFactory;
    private readonly IOptionsRepository _optionsRepository;
    private readonly ICalibrationResultsRepository _calibrationResultsRepository;

    public ControlForm(
        IFormFactory formFactory,
        IOptionsRepository optionsRepository,
        ICalibrationResultsRepository calibrationResultsRepository)
    {
        InitializeComponent();
        _formFactory = formFactory;
        _optionsRepository = optionsRepository;
        _calibrationResultsRepository = calibrationResultsRepository;
    }

    private void ControlForm_Load(object sender, EventArgs e)
    {
        if (!Worker.IsBusy)
            Worker.RunWorkerAsync();
        NotifyIcon.ContextMenuStrip = new ContextMenuStrip();
        NotifyIcon.ContextMenuStrip.Items.Add("Выход", null, MenuExit_Click);
    }

    private void MenuExit_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        if (_calibrationResultsRepository.ReadCalibrationResults() is null)
        {
            _formFactory.CreateSetupForm().ShowDialog();
        }
        else
        {
            var dialogResult = MessageBox.Show(
                    @"Удалить сохраненные биометрические данные?",
                    @"Отладка",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                _calibrationResultsRepository.DeleteCalibrationResults();
                _formFactory.CreateSetupForm().ShowDialog();
            }
        }

        var options = _optionsRepository.ReadOptions();
        if (options is null)
        {
            var optionsDialogResult = _formFactory.CreateOptionsForm().ShowDialog();
            if (optionsDialogResult == DialogResult.OK)
                options = _formFactory.CreateOptionsForm().CurrentOptions;
            else
            {
                MessageBox.Show(@"Неверная конфигурация", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        while (!Worker.CancellationPending)
        {
            var dialogResult = _formFactory.CreateAuthForm().ShowDialog();
            if (dialogResult != DialogResult.OK)
                continue;
            Thread.Sleep(options!.ReverificationPeriodSeconds * 1000);
        }
    }

    private void ControlForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Worker.CancelAsync();
    }
}