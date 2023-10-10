namespace MouseAuth.BusinessLogicLayer.Models.Abstractions;

internal interface ICalibrationResultsRepository
{
    public CalibrationResults? ReadCalibrationResults();
    public void SaveCalibrationResults(CalibrationResults calibrationResults);
    public void DeleteCalibrationResults();
}