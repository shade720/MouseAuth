using System.Runtime.InteropServices;
using MouseAuth.BusinessLogicLayer;
using MouseAuth.BusinessLogicLayer.Models;

namespace MouseAuth.Forms;

public partial class TestForm : Form
{
    private readonly MouseTest _testModule;

    private readonly Bitmap _filled = Properties.Resources.Filled;
    private readonly Bitmap _empty = Properties.Resources.Empty;

    private readonly List<Button> _buttons = new();

    public TestForm(MouseTest testModule)
    {
        InitializeComponent();
        _testModule = testModule;
    }

    private void TestForm_Load(object sender, EventArgs e)
    {
        _buttons.Add(Button1);
        _buttons.Add(Button2);
        _buttons.Add(Button3);
        _buttons.Add(Button4);
        _buttons.Add(Button5);

        _testModule.OnTimerTickEvent += TestTimerOnTick;
        _testModule.OnTestCompletedEvent += OnTestCompletedEventHandler;
    }

    private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _testModule.OnTimerTickEvent -= TestTimerOnTick;
        _testModule.OnTestCompletedEvent -= OnTestCompletedEventHandler;
    }

    public delegate void TestCompleted(MouseUsageParameters result);
    public event TestCompleted? OnTestCompleted;

    public void StartTest()
    {
        _testModule.StartTest();
        Button5.Enabled = true;
        Button5.BackgroundImage = _filled;
    }

    public void StopTest()
    {
        ResetFocus(TimerLabel);
        _testModule.StopTest();
        TimerLabel.Text = _testModule.Duration.ToString();
        foreach (var button in _buttons)
        {
            button.Enabled = false;
            button.BackgroundImage = _empty;
        }
    }

    private void ButtonClickHandler(int currentButtonIndex)
    {
        ResetFocus(TimerLabel);
        _testModule.RegisterClick();
        var nextButtonIndex = _testModule.GetNextButtonIndex(currentButtonIndex);
        if (nextButtonIndex is not null)
            SwitchButtons(currentButtonIndex, nextButtonIndex.Value);
    }

    private void SwitchButtons(int currentButtonNum, int nextButton)
    {
        _buttons[currentButtonNum].Enabled = false;
        _buttons[currentButtonNum].BackgroundImage = _empty;
        _buttons[nextButton].Enabled = true;
        _buttons[nextButton].BackgroundImage = _filled;
    }

    private void TestTimerOnTick(int currentSecond) =>
        TimerLabel.Text = currentSecond.ToString();

    private void MainForm_MouseMove(object sender, MouseEventArgs e) =>
        _testModule.RegisterNewCursorReplacement(e.Location);

    private void Button1_Click(object sender, EventArgs e) => ButtonClickHandler(0);
    private void Button2_Click(object sender, EventArgs e) => ButtonClickHandler(1);
    private void Button3_Click(object sender, EventArgs e) => ButtonClickHandler(2);
    private void Button4_Click(object sender, EventArgs e) => ButtonClickHandler(3);
    private void Button5_Click(object sender, EventArgs e) => ButtonClickHandler(4);

    private void Button1_MouseHover(object sender, EventArgs e) => _testModule.RegisterHover();
    private void Button2_MouseHover(object sender, EventArgs e) => _testModule.RegisterHover();
    private void Button3_MouseHover(object sender, EventArgs e) => _testModule.RegisterHover();
    private void Button4_MouseHover(object sender, EventArgs e) => _testModule.RegisterHover();
    private void Button5_MouseHover(object sender, EventArgs e) => _testModule.RegisterHover();

    private void Button1_MouseDown(object sender, MouseEventArgs e) => _testModule.RegisterMouseDown();
    private void Button1_MouseUp(object sender, MouseEventArgs e) => _testModule.RegisterMouseUp();
    private void Button2_MouseDown(object sender, MouseEventArgs e) => _testModule.RegisterMouseDown();
    private void Button2_MouseUp(object sender, MouseEventArgs e) => _testModule.RegisterMouseUp();
    private void Button3_MouseDown(object sender, MouseEventArgs e) => _testModule.RegisterMouseDown();
    private void Button3_MouseUp(object sender, MouseEventArgs e) => _testModule.RegisterMouseUp();
    private void Button4_MouseDown(object sender, MouseEventArgs e) => _testModule.RegisterMouseDown();
    private void Button4_MouseUp(object sender, MouseEventArgs e) => _testModule.RegisterMouseUp();
    private void Button5_MouseDown(object sender, MouseEventArgs e) => _testModule.RegisterMouseDown();
    private void Button5_MouseUp(object sender, MouseEventArgs e) => _testModule.RegisterMouseUp();

    #region Focus

    [DllImport("user32.dll")]
    private static extern void SetFocus(IntPtr handle);

    /// <summary>
    /// Функция, которая снимает фокус с кнопки, в результате чего стираются границы кнопки.
    /// </summary>
    /// <param name="sender"></param>
    private static void ResetFocus(IWin32Window sender) => SetFocus(sender.Handle);

    #endregion

    private void OnTestCompletedEventHandler(MouseUsageParameters result)
    {
        StopTest();
        OnTestCompleted?.Invoke(result);
    }
}