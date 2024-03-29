namespace BrianMcKenna_SD4B_SOA_CA2.Models;

public class WeightLogDto
{
    public Guid Id { get; set; }
    
    public Guid BoxerId { get; set; }
    
    public decimal Weight { get; set; }
    
    public string? WeighDate { get; set; }
    
    public string? WeighTime { get; set; }
    
    public Guid VerifiedByTrainerId { get; set; }
    
}