using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationCard.Domain.Entities;

namespace VaccinationCard.Infrastructure.Persistence.Configurations
{
    public class VacinacaoConfiguration : IEntityTypeConfiguration<Vacinacao>
    {
        public void Configure(EntityTypeBuilder<Vacinacao> builder)
        {
            builder.ToTable("Vacinacao");

            builder.ConfigureBaseEntidade();

            builder.Property(x => x.ContaId)
                .IsRequired();

            builder.Property(x => x.VacinaId)
                .IsRequired();

            builder.Property(x => x.Dose)
                .IsRequired();

            builder.Property(x => x.DataAplicacao)
                .IsRequired();

            builder.HasOne(x => x.Conta)
                .WithMany(x => x.Vacinacoes)
                .HasForeignKey(x => x.ContaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Vacina)
                .WithMany()
                .HasForeignKey(x => x.VacinaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
