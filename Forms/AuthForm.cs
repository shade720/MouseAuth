using MouseAuth.BusinessLogicLayer;
using MouseAuth.BusinessLogicLayer.Models;

namespace MouseAuth.Forms;

public partial class AuthForm : Form
{
    private readonly TestForm _testForm;
    private readonly MouseAuthentication _mouseAuthentication;

    private const string MessageBoxSuccessText = "Вы успешно аутентифицированы!";
    private const string MessageBoxFailedText = "Аутентификация провалена!";

    public AuthForm(TestForm testForm, MouseAuthentication mouseAuthentication)
    {
        InitializeComponent();
        _testForm = testForm;
        _mouseAuthentication = mouseAuthentication;
        Canvas.Controls.Add(_testForm);
    }

    private void AuthForm_Load(object sender, EventArgs e)
    {
        _testForm.Show();
        _testForm.OnTestCompleted += OnTestCompleted;
    }

    private void AuthForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _testForm.OnTestCompleted -= OnTestCompleted;
    }


    private void OnTestCompleted(MouseUsageParameters result)
    {
        StartTest.Visible = true;
        StopTest.Visible = false;

        var isTestPassedSuccess = _mouseAuthentication.Authenticate(result);

        var message = isTestPassedSuccess
            ? MessageBoxSuccessText
            : MessageBoxFailedText;

        MessageBox.Show(message, @"Тест завершен!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        if (!isTestPassedSuccess)
            return;
        DialogResult = DialogResult.OK;
        Close();
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
}