using AgendaSis.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaSis.Infra.Mapeamento
{
    public class GeneroMapping : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable(@"Genero")
                 .HasKey(h => h.Id);

            builder
                .Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder
                .Property(p => p.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
