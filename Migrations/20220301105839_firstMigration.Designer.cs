﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaMigracion.Models;

namespace PracticaMigracion.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220301105839_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PracticaMigracion.Models.Equipos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaDeCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("PracticaMigracion.Models.Jugadores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("Id_EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pasaporte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sexo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Id_EquipoId");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("PracticaMigracion.Models.TablaDeEstado", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FechaDeCreacion")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("JugadoresId")
                        .HasColumnType("int");

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("JugadoresId");

                    b.ToTable("TablaDeEstado");
                });

            modelBuilder.Entity("PracticaMigracion.Models.Jugadores", b =>
                {
                    b.HasOne("PracticaMigracion.Models.Equipos", "Id_Equipo")
                        .WithMany("Jugadores")
                        .HasForeignKey("Id_EquipoId");

                    b.Navigation("Id_Equipo");
                });

            modelBuilder.Entity("PracticaMigracion.Models.TablaDeEstado", b =>
                {
                    b.HasOne("PracticaMigracion.Models.Jugadores", null)
                        .WithMany("id_Estado")
                        .HasForeignKey("JugadoresId");
                });

            modelBuilder.Entity("PracticaMigracion.Models.Equipos", b =>
                {
                    b.Navigation("Jugadores");
                });

            modelBuilder.Entity("PracticaMigracion.Models.Jugadores", b =>
                {
                    b.Navigation("id_Estado");
                });
#pragma warning restore 612, 618
        }
    }
}
