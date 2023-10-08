using FitnessApp.Utilities.DatabaseInfo;

namespace FitnessApp.Utilities.Authentication;

public static class ValidationCommand
{
    public static bool Validate(string? username, string? password)
    {
        bool isInvalidUserName = string.IsNullOrWhiteSpace(username) || username.Length > DbOptions.MaxUsernameInputLength;
        bool isInvalidPassword = string.IsNullOrWhiteSpace(password) || password.Length > DbOptions.MaxPasswordInputLength;

        return !(isInvalidUserName || isInvalidPassword);
    }
}
