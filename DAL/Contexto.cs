using Microsoft.EntityFrameworkCore;
using SistemaVentas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet <Clientes> Clientes { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<DeudaClientes> Deudas { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<NotasCreditos> NotasCreditos { get; set; }
        public DbSet<Cobros> Cobros { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = SitemaVentas.db");
        }
    }
}
