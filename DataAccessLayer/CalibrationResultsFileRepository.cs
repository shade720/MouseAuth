using System.Text.Json;
using MouseAuth.BusinessLogicLayer.Models;
using MouseAuth.BusinessLogicLayer.Models.Abstractions;

namespace MouseAuth.DataAccessLayer;

internal class CalibrationResultsFileRepository : ICalibrationResultsRepository
{
    private const string AverageResultsJson = "average-results.json";
    private const string ResultsSpreadJson = "results-spread.json";

    private readonly string _averageResultsFilepath;
    private readonly string _resultsSpreadFilepath;

    public CalibrationResultsFileRepository(string filepath)
    {
        _averageResultsFilepath = Path.Combine(filepath, AverageResultsJson);
        _resultsSpreadFilepath = Path.Combine(filepath, ResultsSpreadJson);
    }

    public CalibrationResults? ReadCalibrationResults()
    {
        if (!File.Exists(_averageResultsFilepath) || !File.Exists(_resultsSpreadFilepath))
            return null;

        var calibrationResult = new CalibrationResults
        {
            AverageParameters = JsonSerializer.Deserialize<MouseUsageParameters>(File.ReadAllText(_averageResultsFilepath))!,
            ParametersSpread = JsonSerializer.Deserialize<MouseUsageParameters>(File.ReadAllText(_resultsSpreadFilepath))!
        };

        return calibrationResult;
    }

    public void SaveCalibrationResults(CalibrationResults calibrationResults)
    {
        File.WriteAllText(Program.AverageResultsFilepath, JsonSerializer.Serialize(_averageResultsFilepath));
        File.WriteAllText(Program.ResultsSpreadFilepath, JsonSerializer.Serialize(_resultsSpreadFilepath));
    }

    public void DeleteCalibrationResults()
    {
        File.Delete(_averageResultsFilepath);
        File.Delete(_resultsSpreadFilepath);
    }
}