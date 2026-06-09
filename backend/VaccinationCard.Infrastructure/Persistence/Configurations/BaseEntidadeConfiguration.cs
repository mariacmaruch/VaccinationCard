using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationCard.Domain.Entities;

namespace VaccinationCard.Infrastructure.Persistence.Configurations
{
    public static class BaseEntidadeConfiguration
    {
        public static void ConfigureBaseEntidade<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseEntidade
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Identificador)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(x => x.Criado);

            builder.Property(x => x.Alterado);

            builder.Property(x => x.Deletado);
        }
    }
}
