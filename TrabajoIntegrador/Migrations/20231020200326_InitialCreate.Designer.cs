﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechServicesApp.DataAccess;

#nullable disable

namespace TechServicesApp.Migrations
{
    [DbContext(typeof(TechServicesAppDbContext))]
    [Migration("20231020200326_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrabajoIntegrador.Models.Proyecto", b =>
                {
                    b.Property<int>("CodProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProyecto"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodProyecto");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("TrabajoIntegrador.Models.Servicio", b =>
                {
                    b.Property<int>("CodServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodServicio"));

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<double>("ValorHora")
                        .HasColumnType("float");

                    b.HasKey("CodServicio");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("TrabajoIntegrador.Models.Trabajo", b =>
                {
                    b.Property<int>("CodTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodTrabajo"));

                    b.Property<int>("CantHoras")
                        .HasColumnType("int");

                    b.Property<int>("CodProyecto")
                        .HasColumnType("int");

                    b.Property<int>("CodServicio")
                        .HasColumnType("int");

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorHora")
                        .HasColumnType("float");

                    b.HasKey("CodTrabajo");

                    b.HasIndex("CodProyecto");

                    b.HasIndex("CodServicio");

                    b.ToTable("Trabajos");
                });

            modelBuilder.Entity("TrabajoIntegrador.Models.Usuario", b =>
                {
                    b.Property<int>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUsuario"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("CodUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TrabajoIntegrador.Models.Trabajo", b =>
                {
                    b.HasOne("TrabajoIntegrador.Models.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("CodProyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoIntegrador.Models.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("CodServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Servicio");
                });
#pragma warning restore 612, 618
        }
    }
}
