using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationCard.Domain.Entities;

namespace VaccinationCard.Infrastructure.Persistence.Configurations
{
    public class VacinaConfiguration : IEntityTypeConfiguration<Vacina>
    {
        public void Configure(EntityTypeBuilder<Vacina> builder)
        {
            builder.ToTable("Vacina");

            builder.ConfigureBaseEntidade();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
