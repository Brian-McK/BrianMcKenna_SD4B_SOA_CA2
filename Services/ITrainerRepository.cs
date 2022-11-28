using BrianMcKenna_SD4B_SOA_CA2.Entities;

namespace BrianMcKenna_SD4B_SOA_CA2.Services;

public interface ITrainerRepository: IDisposable
{
    Task<IEnumerable<Trainer>> GetAllTrainersAsync();
    Task<Trainer> GetTrainerByIdAsync(Guid id);
    Task InsertTrainerAsync(Trainer trainer);
    Task DeleteTrainerAsync(Guid id);
    Task UpdateTrainerAsync(Trainer trainer);
    Task Save();
}