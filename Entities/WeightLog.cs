using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrianMcKenna_SD4B_SOA_CA2.Models;
using Microsoft.EntityFrameworkCore;

namespace BrianMcKenna_SD4B_SOA_CA2.Entities;

public class WeightLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [ForeignKey("Boxer")]
    public Guid BoxerId { get; set; }
    
    [Precision(18,2)]
    public decimal Weight { get; set; }
    
    public DateTime WeighDateTime { get; set; }
    
    [ForeignKey("Trainer")]
    public Guid VerifiedByTrainerId { get; set; }
}