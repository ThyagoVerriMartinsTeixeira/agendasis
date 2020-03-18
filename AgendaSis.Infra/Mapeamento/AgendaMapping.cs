using AgendaSis.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaSis.Infra.Mapeamento
{
    public class AgendaMapping : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder
                .Property(p => p.Data)
                .HasColumnName("Data")
                .IsRequired();
            builder
                .Property(p => p.HoraInicio)
                .HasColumnName("HoraInicio")
                .IsRequired();
            builder
                .Property(p => p.HoraFim)
                .HasColumnName("HoraFim")
                .IsRequired();
            builder
                .Property(p => p.QuantidadePessoas)
                .HasColumnName("QuantidadePessoas")
                .IsRequired();
            builder
                .Property(p => p.PessoaId)
                .HasColumnName("PessoaId")
                .IsRequired();
            builder
                .Property(p => p.SalaId)
                .HasColumnName("SalaId")
                .IsRequired();
            builder
                .HasOne(h => h.Pessoa)
                .WithMany()
                .HasForeignKey(h => h.PessoaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(h => h.Sala)
                .WithMany()
                .HasForeignKey(h => h.SalaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
