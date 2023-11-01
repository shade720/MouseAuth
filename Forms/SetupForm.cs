using MouseAuth.BusinessLogicLayer;
using MouseAuth.BusinessLogicLayer.Models;
using MouseAuth.BusinessLogicLayer.Models.Abstractions;

namespace MouseAuth.Forms;

public partial class SetupForm : Form
{
    private readonly TestForm _testForm;
    private readonly IFormFactory _formFactory;
    private readonly CalibrationManager _calibrationManager;

    public SetupForm(
        TestForm testForm,
        IFormFactory formFactory,
        CalibrationManager calibrationManager)
    {
        InitializeComponent();
        _calibrationManager = calibrationManager;
        _testForm = testForm;
        _formFactory = formFactory;
        Canvas.Controls.Add(_testForm);
    }

    private void SetupForm_Load(object sender, EventArgs e)
    {
        _testForm.Show();
        _testForm.OnTestCompleted += OnTestCompleted;
        TestsCountLabel.Text = _calibrationManager.TestsToPass.ToString();
    }

    private void SetupForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _testForm.OnTestCompleted -= OnTestCompleted;
    }

    private void StartTest_Click(object sender, EventArgs e)
    {
        StartTest.Visible = false;
        StopTest.Visible = true;
        _testForm.StartTest();
    }

    private void StopTest_Click(object sender, EventArgs e)
    {
        StartTest.Visible = true;
        StopTest.Visible = false;
        _testForm.StopTest();
    }

    private void OptionsLinkLabel_MouseClick(object sender, MouseEventArgs e)
    {
        _formFactory.CreateOptionsForm().Show();
    }

    private void OnTestCompleted(MouseUsageParameters parameters)
    {
        _calibrationManager.RegisterTestResults(parameters);
        TestingPartLabel.Text = (_calibrationManager.TestsPassed + 1).ToString();
        StartTest.Visible = true;
        StopTest.Visible = false;

        if (!_calibrationManager.IsCalibrationPassed)
            return;

        TestingPartLabel.Text = _calibrationManager.TestsToPass.ToString();
        var calibrationResults = _calibrationManager.GetCalibrationResults();
        _calibrationManager.SaveCalibrationResults(calibrationResults);
        ShowResultsToUser(calibrationResults);
        Close();
        DialogResult = DialogResult.OK;
    }

    private static void ShowResultsToUser(CalibrationResults calibrationResults)
    {
        const string beginningText = "Параметры использования мыши сгенерированы. Данные сохранены и будут использованы для дальнейший аутентификации.";
        var parametersText =
            $"AverageDistance: {calibrationResults.AverageParameters.AverageDistance}\r\nAverageMovementTime: {calibrationResults.AverageParameters.AverageMovementTime}\r\nAveragePressTime: {calibrationResults.AverageParameters.AveragePressTime}\r\nMinSpeed: {calibrationResults.AverageParameters.MinSpeed}\r\nAverageSpeed: {calibrationResults.AverageParameters.AverageSpeed}\r\n MaxSpeed: {calibrationResults.AverageParameters.MaxSpeed}\r\nClickFrequency: {calibrationResults.AverageParameters.ClickFrequency}\r\nPressingDelayAverageTime: {calibrationResults.AverageParameters.PressingDelayAverageTime}\r\n";
        //var endText = $"Параметры сохранены в:\r\n{Program.AverageResultsFilepath}\r\n{Program.ResultsSpreadFilepath}";
        MessageBox.Show(string.Join("\r\n", beginningText, parametersText/*, endText*/), @"Тест завершен!");
    }
}