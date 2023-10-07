using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public required string Username { get; set; }

    [MaxLength(100)]
    public required string Password { get; set; }
}
