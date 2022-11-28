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
    
    public async Task<Boxer> GetBoxersByIdAsync(Guid id)
    {
        return await _boxingClubContext.Boxers.FindAsync(id);
    }
    
    public async Task InsertBoxerAsync(Boxer boxer)
    {
        await _boxingClubContext.Boxers.AddAsync(boxer);
    }
    
    public async Task DeleteBoxerAsync(Guid id)
    {
        var boxer = await _boxingClubContext.Boxers.FindAsync(id);

        if (boxer != null) _boxingClubContext.Boxers.Remove(boxer);
    }
    
    public async Task UpdateBoxerAsync(Boxer boxer)
    {
        _boxingClubContext.Entry(boxer).State = EntityState.Modified;
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