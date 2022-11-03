using CompetitionAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CompetitionAppApi;

public class CompetitionAppDbContext :DbContext 
{
    public CompetitionAppDbContext(DbContextOptions options):base(options)
    {
        
    }

    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Competitor> Competitors { get; set; }
    public DbSet<Lap> Laps { get; set; }
}