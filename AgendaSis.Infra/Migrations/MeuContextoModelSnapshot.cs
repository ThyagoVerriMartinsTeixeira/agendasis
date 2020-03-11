﻿// <auto-generated />
using System;
using AgendaSis.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgendaSis.Infra.Migrations
{
    [DbContext(typeof(MeuContexto))]
    partial class MeuContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AgendaSis.Domain.Entidades.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnName("Data")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("HoraFim")
                        .HasColumnName("HoraFim")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnName("HoraInicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PessoaId")
                        .HasColumnName("PessoaId")
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadePessoas")
                        .HasColumnName("QuantidadePessoas")
                        .HasColumnType("integer");

                    b.Property<int>("SalaId")
                        .HasColumnName("SalaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.HasIndex("SalaId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("AgendaSis.Domain.Entidades.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("AgendaSis.Domain.Entidades.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnName("Endereco")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("character varying(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnName("Telefone")
                        .HasColumnType("character varying(16)")
                        .HasMaxLength(16);

                    b.Property<string>("TipoPessoa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");

                    b.HasDiscriminator<string>("TipoPessoa").HasValue("Pessoa");
                });

            modelBuilder.Entity("AgendaSis.Domain.Entidades.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Andar")
                        .HasColumnName("Andar")
                        .HasColumnType("integer");

                    b.Property<int>("Capacidade")
                        .HasColumnName("Capacidade")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("character varying(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("AgendaSis.Domain.Entidades.PessoaFisica", b =>
                {
                    b.HasBaseType("AgendaSis.Domain.Entidades.Pessoa");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("character varying(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DataNascimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("GeneroId")
                        .HasColumnName("GeneroId")
                        .HasColumnType("integer");

                    b.HasIndex("GeneroId");

                    b.HasDiscriminator().HasValue("PF");
                });

            modelBuilder.Entity("AgendaSis.Domain.Entidades.PessoaJuridica", b =>
                {
                    b.HasBaseType("AgendaSis.Domain.Entidades.Pessoa");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnName("CNPJ")
                        .HasColumnType("character varying(14)")
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnName("DataAbertura")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnName("RazaoSocial")
                        .HasColumnType("character varying(300)")
                        .HasMaxLength(300);

                    b.HasDiscriminator().HasValue("PJ");
                });

            modelBuilder.Entity("AgendaSis.Domain.Entidades.Agenda", b =>
                {
                    b.HasOne("AgendaSis.Domain.Entidades.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AgendaSis.Domain.Entidades.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AgendaSis.Domain.Entidades.PessoaFisica", b =>
                {
                    b.HasOne("AgendaSis.Domain.Entidades.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
