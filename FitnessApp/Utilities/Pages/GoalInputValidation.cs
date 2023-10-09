using FitnessApp.Utilities.DatabaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Utilities.Pages;

public static class GoalInputValidation
{
    public static bool ValidateGoalInput(string? goalInputText)
    {
        bool isInvalidGoalInput = string.IsNullOrWhiteSpace(goalInputText) || goalInputText.Length > DbOptions.MaxGoalInputLength;

        return !isInvalidGoalInput;
    }
}
