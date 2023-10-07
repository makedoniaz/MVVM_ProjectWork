using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [MaxLength(500)]
    public required string Name { get; set; }

    // per 100 gramms

    [Range(0, 2000)]
    public double CaloriesAmount { get; set; }

    [Range(0, 1000)]
    public double ProteinAmount { get; set; }

    [Range(0, 1000)]
    public double CarbsAmount { get; set; }

    [Range(0, 1000)]
    public double FatsAmount { get; set; }
}
