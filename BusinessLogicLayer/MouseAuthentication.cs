using MouseAuth.BusinessLogicLayer.Models;
using MouseAuth.BusinessLogicLayer.Models.Abstractions;

namespace MouseAuth.BusinessLogicLayer;

public class MouseAuthentication
{
    private readonly ICalibrationResultsRepository _calibrationResultsRepository;

    public MouseAuthentication(
        ICalibrationResultsRepository calibrationResultsRepository)
    {
        _calibrationResultsRepository = calibrationResultsRepository;
    }

    public bool Authenticate(MouseUsageParameters parameters)
    {
        var parametersToCompare = _calibrationResultsRepository.ReadCalibrationResults();

        if (parametersToCompare is null)
            return false;

        var averageParameters = parametersToCompare.AverageParameters;
        var parametersSpread = parametersToCompare.ParametersSpread;

        return !(Math.Abs(averageParameters.AverageDistance - parameters.AverageDistance) > parametersSpread.AverageDistance || 
                 Math.Abs(averageParameters.AverageMovementTime - parameters.AverageMovementTime) > parametersSpread.AverageMovementTime ||
                 Math.Abs(averageParameters.AveragePressTime - parameters.AveragePressTime) > parametersSpread.AveragePressTime ||
                 Math.Abs(averageParameters.AverageSpeed - parameters.AverageSpeed) > parametersSpread.AverageSpeed ||
                 Math.Abs(averageParameters.ClickFrequency - parameters.ClickFrequency) > parametersSpread.ClickFrequency ||
                 Math.Abs(averageParameters.MinSpeed - parameters.MinSpeed) > parametersSpread.MinSpeed ||
                 Math.Abs(averageParameters.MaxSpeed - parameters.MaxSpeed) > parametersSpread.MaxSpeed ||
                 Math.Abs(averageParameters.PressingDelayAverageTime - parameters.PressingDelayAverageTime) > parametersSpread.PressingDelayAverageTime);
    }
}