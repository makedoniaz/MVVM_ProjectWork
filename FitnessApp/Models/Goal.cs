using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models;

public class Goal
{
    [Key]
    public int Id { get; set; }

    [MaxLength(500)]
    public string Text { get; set; }

    public User User { get; set; }

    public int UserId { get; set; }
}
