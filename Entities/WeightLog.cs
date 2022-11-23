using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrianMcKenna_SD4B_SOA_CA2.Entities;

public class WeightLog
{
    [Key]
    public Guid Id { get; set; }
    
    [Key]
    [ForeignKey("Boxer")]
    [Column(Order=1)]
    public Guid BoxerId { get; set; }
    
    [Required]
    public decimal Weight { get; set; }
    
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime WeighDateTime { get; set; }
    
    [Required]
    [ForeignKey("Trainer")]
    [Column(Order=3)]
    public Guid VerifiedByTrainerId { get; set; }
    
}