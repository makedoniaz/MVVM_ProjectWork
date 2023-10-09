namespace FitnessApp.Utilities.DatabaseInfo;

static class DbOptions
{
    public static string ConnectionString = "Server = localhost; Database=FitnessDb; TrustServerCertificate=True; Trusted_Connection=True;";
    public static int MaxUsernameInputLength = 100;
    public static int MaxPasswordInputLength = 100;

    public static double MinCurrentWeight = 30;
    public static double MaxCurrentWeight = 200;

    public static double MinTargetWeight = 30;
    public static double MaxTargetWeight = 200;
}
