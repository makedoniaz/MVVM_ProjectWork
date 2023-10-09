using FitnessApp.Utilities.DatabaseInfo;

namespace FitnessApp.Utilities.Authentication;

public static class AuthenticationValidationCommand
{
    public static bool ValidateCredentials(string? username, string? password)
    {
        bool isInvalidUserName = string.IsNullOrWhiteSpace(username) || username.Length > DbOptions.MaxUsernameInputLength;
        bool isInvalidPassword = string.IsNullOrWhiteSpace(password) || password.Length > DbOptions.MaxPasswordInputLength;

        return !(isInvalidUserName || isInvalidPassword);
    }

    public static bool ValidateUserInfo(double currentWeight, double targetWeight)
    {
        bool isInvalidCurrentWeight = currentWeight < DbOptions.MinCurrentWeight || currentWeight > DbOptions.MaxCurrentWeight;
        bool isInvalidTargetWeight = targetWeight < DbOptions.MinTargetWeight || targetWeight > DbOptions.MaxTargetWeight;

        return !(isInvalidCurrentWeight || isInvalidTargetWeight);
    }
}
