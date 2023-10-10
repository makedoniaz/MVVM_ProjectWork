using FitnessApp.Utilities.DatabaseInfo;

namespace FitnessApp.Utilities.Pages;

public class UserInfoValidationCommand
{
    public static bool ValidateUserInfo(double currentWeight, double targetWeight)
    {
        bool isInvalidCurrentWeight = currentWeight < DbOptions.MinCurrentWeight || currentWeight > DbOptions.MaxCurrentWeight;
        bool isInvalidTargetWeight = targetWeight < DbOptions.MinTargetWeight || targetWeight > DbOptions.MaxTargetWeight;

        return !(isInvalidCurrentWeight || isInvalidTargetWeight);
    }
}
