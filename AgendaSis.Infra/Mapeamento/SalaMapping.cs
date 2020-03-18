using AgendaSis.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaSis.Infra.Mapeamento
{
    public class SalaMapping : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable(@"Sala")
                .HasKey(h => h.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(300);

            builder
                .Property(p => p.Andar)
                .HasColumnName("Andar")
                .IsRequired();

            builder
                .Property(p => p.Capacidade)
                .HasColumnName("Capacidade")
                .IsRequired();
        }
    }
}
