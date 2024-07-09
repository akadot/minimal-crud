using System.ComponentModel.DataAnnotations;
using MinimalApi.Domain.Enums;

namespace MinimalApi.Domain.Entities;

public class Administrator : Base
{
    [Required]
    [StringLength(255)]
    public string Email { get; set; } = default!;
    
    [Required]
    [StringLength(50)]
    public string Password { get; set; } = default!;
    
    [Required]
    [StringLength(10)]
    public EProfile Profile { get; set; } = default!;
}