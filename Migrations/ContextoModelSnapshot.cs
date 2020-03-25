﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaVentas.DAL;

namespace SistemaVentas.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("SistemaVentas.Entidades.Articulos", b =>
                {
                    b.Property<int>("ArticulosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Costo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Existencia")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.HasKey("ArticulosId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("SistemaVentas.Entidades.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreCategoria")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("SistemaVentas.Entidades.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SistemaVentas.Entidades.Cobros", b =>
                {
                    b.Property<int>("CobroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.HasKey("CobroId");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("SistemaVentas.Entidades.CobrosDetalles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CobroId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CobrosId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CobrosId");

                    b.ToTable("CobrosDetalles");
                });

            modelBuilder.Entity("SistemaVentas.Entidades.NotasCreditos", b =>
                {
                    b.Property<int>("NotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NotaId");

                    b.ToTable("NotasCreditos");
                });

            modelBuilder.Entity("SistemaVentas.Entidades.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Clave")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaVentas.Entidades.VentaDetalles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VentaId");

                    b.ToTable("VentaDetalles");
                });

            modelBuilder.Entity("SistemaVentas.Entidades.Ventas", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<float>("Monto")
                        .HasColumnType("REAL");

                    b.Property<string>("TipoPago")
                        .HasColumnType("TEXT");

                    b.HasKey("VentaId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("SistemaVentas.Entidades.CobrosDetalles", b =>
                {
                    b.HasOne("SistemaVentas.Entidades.Cobros", null)
                        .WithMany("Detalle")
                        .HasForeignKey("CobrosId");
                });

            modelBuilder.Entity("SistemaVentas.Entidades.VentaDetalles", b =>
                {
                    b.HasOne("SistemaVentas.Entidades.Ventas", null)
                        .WithMany("Detalle")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
