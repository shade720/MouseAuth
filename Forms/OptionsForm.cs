using MouseAuth.BusinessLogicLayer.Models;
using MouseAuth.BusinessLogicLayer.Models.Abstractions;

namespace MouseAuth.Forms;

public partial class OptionsForm : Form
{
    private readonly IOptionsRepository _optionsRepository;
    public Options CurrentOptions { get; private set; }

    public OptionsForm(IOptionsRepository optionsRepository)
    {
        InitializeComponent();
        _optionsRepository = optionsRepository;
    }

    private void OptionsForm_Load(object sender, EventArgs e)
    {
        var options = _optionsRepository.ReadOptions();
        if (options is null)
        {
            ReverificationPeriodComboBox.SelectedIndex = 3;
            var newOptions = new Options
            {
                ReverificationPeriodSeconds = int.Parse(ReverificationPeriodComboBox.SelectedItem.ToString())
            };
            _optionsRepository.WriteOptions(newOptions);
            CurrentOptions = newOptions;
        }
        else
        {
            CurrentOptions = options;
            var savedPeriod = options.ReverificationPeriodSeconds;
            ReverificationPeriodComboBox.SelectedIndex = ReverificationPeriodComboBox.FindStringExact(savedPeriod.ToString());
        }
    }

    private void SaveOptionsButton_Click(object sender, EventArgs e)
    {
        var options = new Options
        {
            ReverificationPeriodSeconds = int.Parse(ReverificationPeriodComboBox.SelectedItem.ToString())
        };
        CurrentOptions = options;
        _optionsRepository.WriteOptions(options);
        DialogResult = DialogResult.OK;
        Close();
    }
}