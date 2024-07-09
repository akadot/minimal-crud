using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Domain.Entities;

public class Vehicle : Base
{
    [Required]
    [StringLength(150)]
    public string Name { get; set; } = default!;
    
    [Required]
    [StringLength(100)]
    public string Model { get; set; } = default!;
    
    public int Year { get; set; } = default!;
}