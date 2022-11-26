using BrianMcKenna_SD4B_SOA_CA2.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrianMcKenna_SD4B_SOA_CA2.Models;

public class BoxingClubContext : DbContext
{
    public BoxingClubContext (DbContextOptions<BoxingClubContext> options)
        : base(options)
    {
    }
    
    public DbSet<Boxer>? Boxers { get; set; }
    public DbSet<Trainer>? Trainers { get; set; }
    public DbSet<WeightLog>? WeightLogs { get; set; }
}