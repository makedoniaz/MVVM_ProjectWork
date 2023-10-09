using FitnessApp.Utilities.DatabaseInfo;

namespace FitnessApp.Utilities.Pages;

public static class MealInputValidationCommand
{
    public static bool ValidateMealInput(string? mealName, double mealCaloriesAmount)
    {
        bool isInvalidMealName = string.IsNullOrWhiteSpace(mealName) || mealName.Length > DbOptions.MaxMealNameInputLength;
        bool isInvalidCaloriesAmount = mealCaloriesAmount < 0 || mealCaloriesAmount > DbOptions.MaxMealCaloriesAmount;

        return !(isInvalidMealName || isInvalidCaloriesAmount);
    }
}
