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
        public DbSet<Vacina> Vacina { get; set; }
        public DbSet<Vacinacao> Vacinacao { get; set; }

    }
}
