using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models;

public class UserInfo
{
    [Key]
    public int Id { get; set; }

    [Range(0, 200)]
    public double CurrentWeight { get; set; }

    [Range(0, 200)]
    public double TargetWeight { get; set; }

    [Range(0, 15000)]
    public double CaloriesToConsume { get; set; }

    public User? User { get; set; }

    public int UserId { get; set; }
}
