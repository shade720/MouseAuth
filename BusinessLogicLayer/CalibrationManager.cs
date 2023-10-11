using MouseAuth.BusinessLogicLayer.Models;
using MouseAuth.BusinessLogicLayer.Models.Abstractions;

namespace MouseAuth.BusinessLogicLayer;

public class CalibrationManager
{
    public int TestsToPass { get; }
    public int TestsPassed => _testResults.Count;
    public bool IsCalibrationPassed => TestsPassed == TestsToPass;

    private readonly List<MouseUsageParameters> _testResults;
    private readonly ICalibrationResultsRepository _calibrationResultsRepository;

    public CalibrationManager(
        int testsToPass,
        ICalibrationResultsRepository calibrationResultsRepository)
    {
        _calibrationResultsRepository = calibrationResultsRepository;
        TestsToPass = testsToPass;
        _testResults = new List<MouseUsageParameters>();
    }

    public void RegisterTestResults(MouseUsageParameters parameters)
    {
        _testResults.Add(parameters);
    }

    public CalibrationResults GetCalibrationResults()
    {
        var averageResult = GetAverageResult();
        var resultsSpread = GetResultsSpread();

        var calibrationResults = new CalibrationResults
        {
            AverageParameters = averageResult,
            ParametersSpread = resultsSpread
        };

        _testResults.Clear();
        return calibrationResults;
    }

    public void SaveCalibrationResults(CalibrationResults results)
    {
        _calibrationResultsRepository.SaveCalibrationResults(results);
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
}