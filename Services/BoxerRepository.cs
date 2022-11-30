using BrianMcKenna_SD4B_SOA_CA2.Entities;
using BrianMcKenna_SD4B_SOA_CA2.Models;
using Microsoft.EntityFrameworkCore;

namespace BrianMcKenna_SD4B_SOA_CA2.Services;


public class BoxerRepository: IBoxerRepository, IDisposable
{
    private readonly BoxingClubContext _boxingClubContext;

    public BoxerRepository(BoxingClubContext context)
    {
        _boxingClubContext = context;
    }
    
    public async Task<IEnumerable<Boxer>> GetAllBoxersAsync()
    {
        return await _boxingClubContext.Boxers.ToListAsync();
    }
    
    public async Task<Boxer?> GetBoxerByIdAsync(Guid id)
    {
        var boxer = await _boxingClubContext.Boxers.FindAsync(id);

        return boxer;
    }
    
    public async Task InsertBoxerAsync(Boxer boxer)
    {
        await _boxingClubContext.Boxers.AddAsync(boxer);

        await SaveAsync();
    }
    
    public async Task DeleteBoxerAsync(Guid id)
    {
        var boxer = await _boxingClubContext.Boxers.FindAsync(id);

        if (boxer != null) _boxingClubContext.Boxers.Remove(boxer);

        await SaveAsync();
    }
    
    public async Task UpdateBoxerAsync(Boxer boxer)
    {
        _boxingClubContext.Entry(boxer).State = EntityState.Modified;
        
        try
        {
            await SaveAsync();
        }
        catch (DbUpdateConcurrencyException exception)
        {
            if (!BoxerExists(boxer.Id))
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
    
    private bool BoxerExists(Guid id)
    {
        return (_boxingClubContext.Boxers?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}