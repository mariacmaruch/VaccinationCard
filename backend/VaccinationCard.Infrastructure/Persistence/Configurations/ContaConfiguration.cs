using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationCard.Domain.Entities;

namespace VaccinationCard.Infrastructure.Persistence.Configurations
{
    public class ContaConfiguration : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ConfigureBaseEntidade();

            builder.ToTable("Conta");

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.CpfCnpj)
                .IsRequired()
                .HasMaxLength(14);

            builder.HasMany(x => x.Vacinacoes)
                .WithOne(x => x.Conta)
                .HasForeignKey(x => x.ContaId);
        }
    }
}
