using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrianMcKenna_SD4B_SOA_CA2.Entities;

public class Trainer
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string? FirstName { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string? Surname { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
}