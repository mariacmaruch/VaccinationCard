using Microsoft.EntityFrameworkCore;
using VaccinationCard.Domain.Entities;

namespace VaccinationCard.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Conta> Conta { get; set; }
    }
}
