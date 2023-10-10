namespace FitnessApp.Utilities.Calories;

public static class CaloriesCalculator
{
    public static double CalculateCalories(double currentWeight, double targetWeight)
    {
        double factor = targetWeight > currentWeight ? 300 : (targetWeight == currentWeight ? 0 : -300);

        return ((currentWeight * 13.75) + 900) * 1.3 + factor;
    }
}
