namespace BrianMcKenna_SD4B_SOA_CA2.Models;

public class WeightLogForUpdatingDto
{
    public Guid BoxerId { get; set; }
    
    public decimal Weight { get; set; }
    
    public string? WeighDate { get; set; }
    public Guid VerifiedByTrainerId { get; set; }
}