using BrianMcKenna_SD4B_SOA_CA2.Entities;
using BrianMcKenna_SD4B_SOA_CA2.Models;
using Microsoft.EntityFrameworkCore;

namespace BrianMcKenna_SD4B_SOA_CA2.Services;

public class TrainerRepository: ITrainerRepository, IDisposable
{
    private readonly BoxingClubContext _boxingClubContext;

    public TrainerRepository(BoxingClubContext context)
    {
        _boxingClubContext = context;
    }
    
    public async Task<IEnumerable<Trainer>> GetAllTrainersAsync()
    {
        return await _boxingClubContext.Trainers.ToListAsync();
    }

    public async Task<Trainer?> GetTrainerByIdAsync(Guid id)
    {
        var trainer = await _boxingClubContext.Trainers.FindAsync(id);

        return trainer;
    }
    
    public async Task InsertTrainerAsync(Trainer trainer)
    {
        await _boxingClubContext.Trainers.AddAsync(trainer);

        await SaveAsync();
    }
    
    public async Task DeleteTrainerAsync(Guid id)
    {
        var trainer = await _boxingClubContext.Trainers.FindAsync(id);

        if (trainer != null) _boxingClubContext.Trainers.Remove(trainer);
        
        await SaveAsync();
    }
    
    public async Task UpdateTrainerAsync(Trainer trainer)
    {
        _boxingClubContext.Entry(trainer).State = EntityState.Modified;
        
        try
        {
            await SaveAsync();
        }
        catch (DbUpdateConcurrencyException exception)
        {
            if (!TrainerExists(trainer.Id))
            {
                throw new Exception(exception.Message);
            }
        }
    }

    public async Task SaveAsync()
    {
        await _boxingClubContext.SaveChangesAsync();
    }

    private bool _disposed = false;
    
    private async Task Dispose(bool disposing)
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
    
    public bool TrainerExists(Guid id)
    {
        return (_boxingClubContext.Trainers?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}