using NuGet.Packaging.Signing;

namespace BrianMcKenna_SD4B_SOA_CA2.Entities;

public class WeightLog
{
    public int Id { get; set; }
    
    public Boxer BoxerId { get; set; }
    
    public decimal Weight { get; set; }
    
    public Timestamp Timestamp { get; set; }
    
    public Trainer VerifiedByTrainer { get; set; }
}