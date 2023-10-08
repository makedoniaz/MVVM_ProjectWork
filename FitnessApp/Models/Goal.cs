using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models;

public class Goal
{
    [Key]
    public int Id { get; set; }

    [MaxLength(500)]
    public string Text { get; set; }

    public required User User { get; set; }

    public int UserId { get; set; }

    public override string ToString()
    {
        return $"{Text} {UserId}";
    }
}
