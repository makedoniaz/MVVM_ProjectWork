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
    public double Calories { get; set; }

    [Range(0, 1000)]
    public double Protein { get; set; }

    [Range(0, 1000)]
    public double Carbs { get; set; }

    [Range(0, 1000)]
    public double Fats { get; set; }
}
