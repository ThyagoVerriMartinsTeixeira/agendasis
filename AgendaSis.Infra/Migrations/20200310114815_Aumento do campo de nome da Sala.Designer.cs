﻿// <auto-generated />
using AgendaSis.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgendaSis.Infra.Migrations
{
    [DbContext(typeof(MeuContexto))]
    [Migration("20200310114815_Aumento do campo de nome da Sala")]
    partial class AumentodocampodenomedaSala
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

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
#pragma warning restore 612, 618
        }
    }
}
