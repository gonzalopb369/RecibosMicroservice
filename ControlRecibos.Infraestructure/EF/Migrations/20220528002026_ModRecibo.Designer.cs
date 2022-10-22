﻿// <auto-generated />
using System;
using ControlRecibos.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControlRecibos.Infraestructure.EF.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    [Migration("20220528002026_ModRecibo")]
    partial class ModRecibo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControlRecibos.Infraestructure.EF.ReadModel.ReciboReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ACuenta")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("aCuenta");

                    b.Property<string>("CodigoReserva")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("codigoReserva");

                    b.Property<string>("Concepto")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("concepto");

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("DateTime")
                        .HasColumnName("fechaPago");

                    b.Property<decimal>("MontoTotal")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("montoTotal");

                    b.Property<string>("NombrePasajero")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("nombrePasajero");

                    b.Property<int>("NroRecibo")
                        .HasColumnType("int")
                        .HasColumnName("nroRecibo");

                    b.Property<decimal>("Saldo")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("saldo");

                    b.HasKey("Id");

                    b.ToTable("Recibo");
                });
#pragma warning restore 612, 618
        }
    }
}
