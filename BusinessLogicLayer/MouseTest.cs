using MouseAuth.BusinessLogicLayer.Models;
using Timer = System.Windows.Forms.Timer;

namespace MouseAuth.BusinessLogicLayer;

public class MouseTest
{
    private readonly int _buttonsCount;
    public int Duration { get; }

    public MouseTest(
        int buttonsCount, 
        int duration)
    {
        _buttonsCount = buttonsCount;
        Duration = duration;
        _testTimer.Interval = 1000;
        _testTimer.Tick += TestTimerOnTick;
    }

    #region StartAndStop

    /// <summary>
    /// Публичный интерфейс класса. Здесь находятся методы по запуску и остановке теста, а также
    /// событие завершения теста, на которое подписываются клиенты класса и узнают результаты теста.
    /// </summary>

    public delegate void OnTestCompleted(MouseUsageParameters result);
    public event OnTestCompleted? OnTestCompletedEvent;

    public delegate void OnTimerTick (int currentSecond);
    public event OnTimerTick? OnTimerTickEvent;

    public void StartTest()
    {
        _testTimer.Enabled = true;
        _testTimer.Start();
        _currentTimeSeconds = Duration;
        _isTestRunning = true;
        _clickCount = 0;
    }

    public void StopTest()
    {
        _testTimer.Stop();
        _testTimer.Enabled = false;
        _currentTimeSeconds = Duration;
        _isTestRunning = false;

        if (_distancesBetweenClicks.Count == 0 ||
            _movementTimeList.Count == 0 ||
            _pressingTimeList.Count == 0 ||
            _speedsBetweenClicks.Count == 0 ||
            _delayBetweenEnterAndClick.Count == 0) return;

        _speedsBetweenClicks.RemoveAll(x => x == 0);
        _distancesBetweenClicks.Clear();
        _movementTimeList.Clear();
        _delayBetweenEnterAndClick.Clear();
        _speedsBetweenClicks.Clear();
        _clickCount = 0;
        _pressingTimeList.Clear();
    }

    #endregion

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
        if (_currentTimeSeconds == 0)
        {
            var result = new MouseUsageParameters
            {
                AverageDistance = _distancesBetweenClicks.Average(),
                AverageMovementTime = _movementTimeList.Skip(1).Average(),
                AveragePressTime = _pressingTimeList.Average(),
                AverageSpeed = _speedsBetweenClicks.Skip(1).Average(),
                ClickFrequency = _clickCount / (double)Duration,
                MaxSpeed = _speedsBetweenClicks.Skip(1).Max(),
                MinSpeed = _speedsBetweenClicks.Skip(1).Min(),
                PressingDelayAverageTime = _delayBetweenEnterAndClick.Average()
            };
            OnTestCompletedEvent?.Invoke(result);
        }
        OnTimerTickEvent?.Invoke(_currentTimeSeconds);
    }

    #endregion

    #region GetNextButtonIndex

    public int? GetNextButtonIndex(int currentButtonIndex)
    {
        if (!_isTestRunning)
            return null;
        return RandomNumber(currentButtonIndex);
    }

    private int RandomNumber(int except)
    {
        var range = Enumerable.Range(0, _buttonsCount).Where(i => except != i);
        var rand = new Random();
        var index = rand.Next(0, _buttonsCount - 1);
        return range.ElementAt(index);
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

    public void RegisterClick()
    {
        if (!_isTestRunning)
            return;
        var distance = EvaluateDistance();
        _speedsBetweenClicks.Add(Math.Sqrt(distance) / (_timeBetweenClicks.ElapsedMilliseconds / (double)1000));
        _movementTimeList.Add(_timeBetweenClicks.ElapsedMilliseconds / (double)1000);
        _timeBetweenClicks.Restart();
        PressingSensor();
        _clickCount++;
    }

    #endregion

    #region DistanceBetweenClicks

    /// <summary>
    /// Область, в которой рассчитывается и сохраняется дистанция, пройденная мышью, от клика
    /// до клика.
    /// </summary>

    private readonly List<double> _distancesBetweenClicks = new();
    private readonly Queue<Point> _mouseMovePath = new();

    public void RegisterNewCursorReplacement(Point location)
    {
        if (!_isTestRunning) 
            return;
        _mouseMovePath.Enqueue(location);
    }

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

    #endregion

    #region DelayBetweenEnterAndClick

    /// <summary>
    /// Область, в которой рассчитывается время между наведением мыши на
    /// кнопку и нажатием на неё.
    /// </summary>

    private readonly List<double> _delayBetweenEnterAndClick = new();
    private readonly System.Diagnostics.Stopwatch _delayTimer = new();

    public void RegisterHover()
    {
        if (!_isTestRunning)
            return;
        _delayTimer.Start();
    }

    private void PressingSensor()
    {
        _delayBetweenEnterAndClick.Add(_delayTimer.ElapsedMilliseconds / (double)1000);
        _delayTimer.Reset();
    }

    #endregion

    #region PressingTime

    /// <summary>
    /// Область в которой рассчитывается время нажатия на кнопку.
    /// </summary>
    private readonly List<double> _pressingTimeList = new();
    private readonly System.Diagnostics.Stopwatch _pressingTimer = new();

    public void RegisterMouseUp()
    {
        _pressingTimeList.Add(_pressingTimer.ElapsedMilliseconds / (double)1000);
        _pressingTimer.Reset();
    }

    public void RegisterMouseDown()
    {
        _pressingTimer.Start();
    }

    #endregion
}