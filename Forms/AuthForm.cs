using System.Text.Json;
using MouseAuth.BusinessLogicLayer.Models;

namespace MouseAuth.Forms;

public partial class AuthForm : Form
{
    private readonly MouseUsageParameters _averageResult;
    private readonly MouseUsageParameters _resultsSpread;
    private readonly TestForm _testForm;

    public AuthForm()
    {
        InitializeComponent();
        _testForm = new TestForm();
        _testForm.TopLevel = false;
        _testForm.AutoScroll = true;
        Canvas.Controls.Add(_testForm);
        _testForm.Show();
        _testForm.OnTestCompleted += OnTestCompleted;
        _averageResult = JsonSerializer.Deserialize<MouseUsageParameters>(File.ReadAllText(Program.AverageResultsFilepath))!;
        _resultsSpread = JsonSerializer.Deserialize<MouseUsageParameters>(File.ReadAllText(Program.ResultsSpreadFilepath))!;
    }

    private void OnTestCompleted(MouseUsageParameters result)
    {
        const string messageBoxSuccessText = "Вы успешно аутентифицированы!";
        const string messageBoxFailedText = "Аутентификация провалена!";
        StartTest.Visible = true;
        StopTest.Visible = false;
        MessageBox.Show(IsLegitUser(result) ? messageBoxSuccessText : messageBoxFailedText, @"Тест завершен!");
    }


    private bool IsLegitUser(MouseUsageParameters results)
    {
        if (Math.Abs(_averageResult.AverageDistance - results.AverageDistance) > _resultsSpread.AverageDistance) return false;
        if (Math.Abs(_averageResult.AverageMovementTime - results.AverageMovementTime) > _resultsSpread.AverageMovementTime) return false;
        if (Math.Abs(_averageResult.AveragePressTime - results.AveragePressTime) > _resultsSpread.AveragePressTime) return false;
        if (Math.Abs(_averageResult.AverageSpeed - results.AverageSpeed) > _resultsSpread.AverageSpeed) return false;
        if (Math.Abs(_averageResult.ClickFrequency - results.ClickFrequency) > _resultsSpread.ClickFrequency) return false;
        if (Math.Abs(_averageResult.MinSpeed - results.MinSpeed) > _resultsSpread.MinSpeed) return false;
        if (Math.Abs(_averageResult.MaxSpeed - results.MaxSpeed) > _resultsSpread.MaxSpeed) return false;
        if (Math.Abs(_averageResult.PressingDelayAverageTime - results.PressingDelayAverageTime) > _resultsSpread.PressingDelayAverageTime) return false;
        return true;
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

    private void AuthForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.ExitThread();
    }
}