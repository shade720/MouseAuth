using System.Text.Json;
using MouseAuth.BusinessLogicLayer.Models;

namespace MouseAuth.Forms;

public partial class SetupForm : Form
{
    private readonly TestForm _testForm;
    private readonly List<MouseUsageParameters> _testResults;

    /// <summary>
    /// Число тестов, которые предстоит пройти для калибровки.
    /// </summary>
    private const int TestsCount = 3;

    public SetupForm()
    {
        InitializeComponent();
        _testResults = new List<MouseUsageParameters>();
        _testForm = new TestForm();
        _testForm.TopLevel = false;
        _testForm.AutoScroll = true;
        Canvas.Controls.Add(_testForm);
        _testForm.Show();
        _testForm.OnTestCompleted += OnTestCompleted;
        TestsCountLabel.Text = TestsCount.ToString();
    }

    private MouseUsageParameters GetAverageResult() => new()
    {
        AverageDistance = _testResults.Average(x => x.AverageDistance),
        AverageMovementTime = _testResults.Average(x => x.AverageMovementTime),
        AveragePressTime = _testResults.Average(x => x.AveragePressTime),
        AverageSpeed = _testResults.Average(x => x.AverageSpeed),
        ClickFrequency = _testResults.Average(x => x.ClickFrequency),
        MaxSpeed = _testResults.Average(x => x.MaxSpeed),
        MinSpeed = _testResults.Average(x => x.MinSpeed),
        PressingDelayAverageTime = _testResults.Average(x => x.PressingDelayAverageTime),
    };
    private MouseUsageParameters GetResultsSpread() => new()
    {
        AverageDistance = _testResults.Max(x => x.AverageDistance) - _testResults.Min(x => x.AverageDistance),
        AverageMovementTime = _testResults.Max(x => x.AverageMovementTime) - _testResults.Min(x => x.AverageMovementTime),
        AveragePressTime = _testResults.Max(x => x.AveragePressTime) - _testResults.Min(x => x.AveragePressTime),
        AverageSpeed = _testResults.Max(x => x.AverageSpeed) - _testResults.Min(x => x.AverageSpeed),
        ClickFrequency = _testResults.Max(x => x.ClickFrequency) - _testResults.Min(x => x.ClickFrequency),
        MaxSpeed = _testResults.Max(x => x.MaxSpeed) - _testResults.Min(x => x.MaxSpeed),
        MinSpeed = _testResults.Max(x => x.MinSpeed) - _testResults.Min(x => x.MinSpeed),
        PressingDelayAverageTime = _testResults.Max(x => x.PressingDelayAverageTime) - _testResults.Min(x => x.PressingDelayAverageTime),
    };

    private void OnTestCompleted(MouseUsageParameters result)
    {
        _testResults.Add(result);
        TestingPartLabel.Text = (_testResults.Count + 1).ToString();
        StartTest.Visible = true;
        StopTest.Visible = false;
        if (_testResults.Count < TestsCount)
            return;
        SaveResults();
        new AuthForm().Show();
        Hide();
    }

    private void SaveResults()
    {
        var averageResult = GetAverageResult();
        var resultsSpread = GetResultsSpread();
        File.WriteAllText(Program.AverageResultsFilepath, JsonSerializer.Serialize(averageResult));
        File.WriteAllText(Program.ResultsSpreadFilepath, JsonSerializer.Serialize(resultsSpread));
        const string beginningText = "Параметры использования мыши сгенерированы. Данные сохранены и будут использованы для дальнейший аутентификации.";
        var parametersText =
            $"AverageDistance: {averageResult.AverageDistance}\r\nAverageMovementTime: {averageResult.AverageMovementTime}\r\nAveragePressTime: {averageResult.AveragePressTime}\r\nMinSpeed: {averageResult.MinSpeed}\r\nAverageSpeed: {averageResult.AverageSpeed}\r\n MaxSpeed: {averageResult.MaxSpeed}\r\nClickFrequency: {averageResult.ClickFrequency}\r\nPressingDelayAverageTime: {averageResult.PressingDelayAverageTime}\r\n";
        var endText = $"Параметры сохранены в:\r\n{Program.AverageResultsFilepath}\r\n{Program.ResultsSpreadFilepath}";
        MessageBox.Show(string.Join("\r\n", beginningText, parametersText, endText), @"Тест завершен!");
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
        _testForm.StopTest(false);
    }

    private void OptionsLinkLabel_MouseClick(object sender, MouseEventArgs e)
    {
        var optionsForm = new OptionsForm();
        optionsForm.Show();
    }
}