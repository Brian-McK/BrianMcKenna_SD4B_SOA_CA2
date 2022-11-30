using BrianMcKenna_SD4B_SOA_CA2.Entities;

namespace BrianMcKenna_SD4B_SOA_CA2.Services;

public interface IWeightLogRepository: IDisposable
{
    Task<IEnumerable<WeightLog>> GetAllWeightLogsAsync();
    Task<WeightLog?> GetWeightLogByIdAsync(Guid id);
    Task InsertWeightLogAsync(WeightLog weightLog);
    Task DeleteWeightLogAsync(Guid id);
    Task UpdateWeightLogAsync(WeightLog weightLog);
    bool WeightLogExists(Guid id);
}