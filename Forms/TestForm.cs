using System.Runtime.InteropServices;
using MouseAuth.BusinessLogicLayer.Models;
using Timer = System.Windows.Forms.Timer;

namespace MouseAuth.Forms;

public partial class TestForm : Form
{
    private readonly Bitmap _filled = Properties.Resources.Filled;
    private readonly Bitmap _empty = Properties.Resources.Empty;
    private const int TestTime = 10;

    public TestForm()
    {
        InitializeComponent();
        _testTimer.Interval = 1000;
        _testTimer.Tick += TestTimerOnTick;
        _timeBetweenClicks.Start();
        _pressingTimer.Start();
        _buttons.Add(Button1);
        _buttons.Add(Button2);
        _buttons.Add(Button3);
        _buttons.Add(Button4);
        _buttons.Add(Button5);
    }

    #region TestTimer
    /// <summary>
    /// Область работы с таймером по центру экрана. Здесь происходит обработка тиков таймера теста и остановка теста по таймеру.
    /// </summary>

    private readonly Timer _testTimer = new();
    private int _currentTimeSeconds;
    private bool _isTestRunning;
    private void TestTimerOnTick(object? sender, EventArgs e)
    {
        _currentTimeSeconds--;
        TimerLabel.Text = _currentTimeSeconds.ToString();
        if (_currentTimeSeconds == 0)
            StopTest(true);
    }

    #endregion

    #region Public
    /// <summary>
    /// Публичный интерфейс класса. Здесь находятся методы по запуску и остановке теста, а также
    /// событие завершения теста, на которое подписываются клиенты класса и узнают результаты теста.
    /// </summary>

    public delegate void TestCompleted(MouseUsageParameters result);
    public event TestCompleted? OnTestCompleted;

    public void StartTest()
    {
        _testTimer.Enabled = true;
        _testTimer.Start();
        _currentTimeSeconds = TestTime;
        _isTestRunning = true;
        _clickCount = 0;
        Button5.Enabled = true;
        Button5.BackgroundImage = _filled;
    }

    public void StopTest(bool isSaveNeeded)
    {
        ResetFocus(TimerLabel);
        _testTimer.Stop();
        _testTimer.Enabled = false;
        _currentTimeSeconds = TestTime;
        TimerLabel.Text = _currentTimeSeconds.ToString();
        _isTestRunning = false;

        if (_distancesBetweenClicks.Count == 0 ||
            _movementTimeList.Count == 0 ||
            _pressingTimeList.Count == 0 ||
            _speedsBetweenClicks.Count == 0 ||
            _delayBetweenEnterAndClick.Count == 0) return;
        _speedsBetweenClicks.RemoveAll(x => x == 0);

        var result = new MouseUsageParameters
        {
            AverageDistance = _distancesBetweenClicks.Average(),
            AverageMovementTime = _movementTimeList.Skip(1).Average(),
            AveragePressTime = _pressingTimeList.Average(),
            AverageSpeed = _speedsBetweenClicks.Skip(1).Average(),
            ClickFrequency = _clickCount / (double)TestTime,
            MaxSpeed = _speedsBetweenClicks.Skip(1).Max(),
            MinSpeed = _speedsBetweenClicks.Skip(1).Min(),
            PressingDelayAverageTime = _delayBetweenEnterAndClick.Average()
        };
        if(isSaveNeeded)
            OnTestCompleted?.Invoke(result);

        foreach (var button in _buttons)
        {
            button.Enabled = false;
            button.BackgroundImage = _empty;
        }

        _distancesBetweenClicks.Clear();
        _movementTimeList.Clear();
        _delayBetweenEnterAndClick.Clear();
        _speedsBetweenClicks.Clear();
        _clickCount = 0;
        _pressingTimeList.Clear();
    }

    #endregion

    #region SpeedMovementTimeAndDistance
    /// <summary>
    /// Область которая содержит код по получению данных о скорости мыши
    /// между кликами, времени между кликами, а также дистанции пройденной
    /// мышью между кликами. Также здесь подсчитывается количество кликов.
    /// </summary>

    private readonly List<double> _speedsBetweenClicks = new();
    private readonly List<double> _movementTimeList = new();
    private readonly System.Diagnostics.Stopwatch _timeBetweenClicks = new();
    private int _clickCount;

    /// <summary>
    /// Метод, который срабатывает при нажатии кнопки с номером buttonNum.
    /// Фиксирует время между кликами, дистанцию, а также скорость движения
    /// мыши между кликами, после чего открывает следующую кнопку.
    /// </summary>
    /// <param name="buttonNum"></param>
    private void ButtonClickHandler(int buttonNum)
    {
        ResetFocus(TimerLabel);
        NextButton(buttonNum);
        var distance = EvaluateDistance();
        _speedsBetweenClicks.Add(Math.Sqrt(distance) / (_timeBetweenClicks.ElapsedMilliseconds / (double)1000));
        _movementTimeList.Add(_timeBetweenClicks.ElapsedMilliseconds / (double)1000);
        _timeBetweenClicks.Restart();
        PressingSensor();
        _clickCount++;
    }

    #region SelectNextButton
    /// <summary>
    /// Область, которая содержит код по выбору следующей кнопки
    /// </summary>

    private readonly List<Button> _buttons = new();
    private void NextButton(int currentButtonNum)
    {
        _buttons[currentButtonNum].Enabled = false;
        _buttons[currentButtonNum].BackgroundImage = _empty;
        var nextButtonIndex = RandomNumber(currentButtonNum);
        _buttons[nextButtonIndex].Enabled = true;
        _buttons[nextButtonIndex].BackgroundImage = _filled;
    }
    private static int RandomNumber(int except)
    {
        var range = Enumerable.Range(0, 5).Where(i => except != i);
        var rand = new Random();
        var index = rand.Next(0, 4);
        return range.ElementAt(index);
    }

    #endregion

    #region DistanceBetweenClicks
    /// <summary>
    /// Область, в которой рассчитывается и сохраняется дистанция, пройденная мышью, от клика
    /// до клика.
    /// </summary>

    private readonly List<double> _distancesBetweenClicks = new();
    private readonly Queue<Point> _mouseMovePath = new();

    /// <summary>
    /// Рассчитывает дистанцию, пройденную мышью по списку пройденных точек.
    /// </summary>
    /// <returns>Возвращает дистанцию в пикселях.</returns>
    private double EvaluateDistance()
    {
        if (_mouseMovePath.Count == 0)
            return 0;
        var startPoint = _mouseMovePath.Dequeue();
        var distance = 0.0;
        for (var i = 0; i < _mouseMovePath.Count; i++)
        {
            var point = _mouseMovePath.Dequeue();
            distance += Math.Sqrt(Math.Pow(startPoint.X - point.X, 2) + Math.Pow(startPoint.Y - point.Y, 2));
            startPoint = point;
        }
        _distancesBetweenClicks.Add(distance);
        _mouseMovePath.Clear();
        return distance;
    }

    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
        if (!_isTestRunning) return;
        _mouseMovePath.Enqueue(e.Location);
    }

    #endregion

    #region ClickHandlers

    private void Button1_Click(object sender, EventArgs e) => ButtonClickHandler(0);
    private void Button2_Click(object sender, EventArgs e) => ButtonClickHandler(1);
    private void Button3_Click(object sender, EventArgs e) => ButtonClickHandler(2);
    private void Button4_Click(object sender, EventArgs e) => ButtonClickHandler(3);
    private void Button5_Click(object sender, EventArgs e) => ButtonClickHandler(4);

    #endregion

    [DllImport("user32.dll")]
    private static extern void SetFocus(IntPtr handle);
    /// <summary>
    /// Функция, которая снимает фокус с кнопки, в результате чего стираются границы кнопки.
    /// </summary>
    /// <param name="sender"></param>
    private static void ResetFocus(IWin32Window sender) => SetFocus(sender.Handle);

    #endregion

    #region DelayBetweenEnterAndClick
    /// <summary>
    /// Область, в которой рассчитывается время между наведением мыши на
    /// кнопку и нажатием на неё.
    /// </summary>

    private readonly List<double> _delayBetweenEnterAndClick = new();
    private readonly System.Diagnostics.Stopwatch _delayTimer = new();

    private void PressingSensor()
    {
        _delayBetweenEnterAndClick.Add(_delayTimer.ElapsedMilliseconds / (double)1000);
        _delayTimer.Reset();
    }

    private void Button1_MouseHover(object sender, EventArgs e) => _delayTimer.Start();
    private void Button2_MouseHover(object sender, EventArgs e) => _delayTimer.Start();
    private void Button3_MouseHover(object sender, EventArgs e) => _delayTimer.Start();
    private void Button4_MouseHover(object sender, EventArgs e) => _delayTimer.Start();
    private void Button5_MouseHover(object sender, EventArgs e) => _delayTimer.Start();

    #endregion

    #region PressingTime
    /// <summary>
    /// Область в которой рассчитывается время нажатия на кнопку.
    /// </summary>

    private readonly List<double> _pressingTimeList = new();
    private readonly System.Diagnostics.Stopwatch _pressingTimer = new();

    private void SaveAndResetPressWatchTimer()
    {
        _pressingTimeList.Add(_pressingTimer.ElapsedMilliseconds / (double)1000);
        _pressingTimer.Reset();
    }

    private void Button1_MouseDown(object sender, MouseEventArgs e) => _pressingTimer.Start();
    private void Button1_MouseUp(object sender, MouseEventArgs e) => SaveAndResetPressWatchTimer();
    private void Button2_MouseDown(object sender, MouseEventArgs e) => _pressingTimer.Start();
    private void Button2_MouseUp(object sender, MouseEventArgs e) => SaveAndResetPressWatchTimer();
    private void Button3_MouseDown(object sender, MouseEventArgs e) => _pressingTimer.Start();
    private void Button3_MouseUp(object sender, MouseEventArgs e) => SaveAndResetPressWatchTimer();
    private void Button4_MouseDown(object sender, MouseEventArgs e) => _pressingTimer.Start();
    private void Button4_MouseUp(object sender, MouseEventArgs e) => SaveAndResetPressWatchTimer();
    private void Button5_MouseDown(object sender, MouseEventArgs e) => _pressingTimer.Start();
    private void Button5_MouseUp(object sender, MouseEventArgs e) => SaveAndResetPressWatchTimer();

    #endregion
}