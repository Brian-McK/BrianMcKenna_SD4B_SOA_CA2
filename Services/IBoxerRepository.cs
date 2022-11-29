using BrianMcKenna_SD4B_SOA_CA2.Entities;
namespace BrianMcKenna_SD4B_SOA_CA2.Services;

public interface IBoxerRepository: IDisposable
{
    Task<IEnumerable<Boxer>> GetAllBoxersAsync();
    Task<Boxer?> GetBoxerByIdAsync(Guid id);
    Task InsertBoxerAsync(Boxer boxer);
    Task DeleteBoxerAsync(Guid id);
    Task UpdateBoxerAsync(Boxer boxer);
    Task SaveAsync();
}