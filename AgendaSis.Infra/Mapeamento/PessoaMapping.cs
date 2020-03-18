using AgendaSis.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaSis.Infra.Mapeamento
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable(@"Pessoa")
                 .HasKey(h => h.Id);
            builder
                .Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            builder
                .Property(d => d.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(300);
            builder
                .Property(d => d.Telefone)
                .HasColumnName("Telefone")
                .IsRequired()
                .HasMaxLength(16);
            builder
                .Property(d => d.Endereco)
                .HasColumnName("Endereco")
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(d => d.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(30);
            builder
                .HasDiscriminator<string>("TipoPessoa")
                .HasValue<PessoaFisica>("PF")
                .HasValue<PessoaJuridica>("PJ");
        }
    }
}
