using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Domain.Entities;

public class Administrator : Base
{
    [Required]
    [StringLength(255)]
    public string Email { get; set; } = default!;
    
    [StringLength(50)]
    public string Password { get; set; } = default!;
    
    [StringLength(10)]
    public string Profile { get; set; } = default!;
}