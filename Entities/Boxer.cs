using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrianMcKenna_SD4B_SOA_CA2.Models;

namespace BrianMcKenna_SD4B_SOA_CA2.Entities;

public class Boxer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string? FirstName { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string? Surname { get; set; }
    
    [Required]
    public DateTime DateOfBirth { get; set; }
    
}