using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models;

public class Meal
{
    [Key]
    public int Id { get; set; }

    [MaxLength(500)]
    public required string Name { get; set; }

    [Range(0, 2000)]
    public double CaloriesAmount { get; set; }

    public DateTime? CreationDate { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }
}
