namespace FitnessApp.Utilities.DatabaseInfo;

static class DbOptions
{
    public static string ConnectionString = "Server = localhost; Database=FitnessDb; TrustServerCertificate=True; Trusted_Connection=True;";
    public static int MaxUsernameInputLength = 100;
    public static int MaxPasswordInputLength = 100;
}
