using BrianMcKenna_SD4B_SOA_CA2.Entities;
using BrianMcKenna_SD4B_SOA_CA2.Models;
using Microsoft.EntityFrameworkCore;

namespace BrianMcKenna_SD4B_SOA_CA2.Services;

public class WeightLogRepository: IWeightLogRepository, IDisposable
{
    private readonly BoxingClubContext _boxingClubContext;

    public WeightLogRepository(BoxingClubContext context)
    {
        _boxingClubContext = context;
    }
    
    public async Task<IEnumerable<WeightLog>> GetAllWeightLogsAsync()
    {
        return await _boxingClubContext.WeightLogs.ToListAsync();
    }
    
    public async Task<WeightLog> GetWeightLogByIdAsync(Guid id)
    {
        return await _boxingClubContext.WeightLogs.FindAsync(id);
    }
    
    public async Task InsertWeightLogAsync(WeightLog weightLog)
    {
        await _boxingClubContext.WeightLogs.AddAsync(weightLog);
    }
    
    public async Task DeleteWeightLogAsync(Guid id)
    {
        var weightLog = await _boxingClubContext.WeightLogs.FindAsync(id);

        if (weightLog != null) _boxingClubContext.WeightLogs.Remove(weightLog);
    }
    
    public async Task UpdateWeightLogAsync(WeightLog weightLog)
    {
        _boxingClubContext.Entry(weightLog).State = EntityState.Modified;
        
        await _boxingClubContext.SaveChangesAsync();
    }

    public async Task Save()
    {
        await _boxingClubContext.SaveChangesAsync();
    }

    private bool _disposed = false;
    
    protected virtual async Task Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                await _boxingClubContext.DisposeAsync();
            }
        }
        _disposed = true;
    }

    public async void Dispose()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }
}