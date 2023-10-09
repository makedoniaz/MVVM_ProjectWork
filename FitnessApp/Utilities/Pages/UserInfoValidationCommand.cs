using FitnessApp.Utilities.DatabaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
