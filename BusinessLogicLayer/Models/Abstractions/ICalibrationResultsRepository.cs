namespace MouseAuth.BusinessLogicLayer.Models.Abstractions;

public interface ICalibrationResultsRepository
{
    public CalibrationResults? ReadCalibrationResults();
    public void SaveCalibrationResults(CalibrationResults calibrationResults);
    public void DeleteCalibrationResults();
}