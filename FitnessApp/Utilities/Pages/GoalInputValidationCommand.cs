using FitnessApp.Utilities.DatabaseInfo;

namespace FitnessApp.Utilities.Pages;

public static class GoalInputValidationCommand
{
    public static bool ValidateGoalInput(string? goalInputText)
    {
        bool isInvalidGoalInput = string.IsNullOrWhiteSpace(goalInputText) || goalInputText.Length > DbOptions.MaxGoalInputLength;

        return !isInvalidGoalInput;
    }
}
