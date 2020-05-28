using Microsoft.EntityFrameworkCore;
using RegistroPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPrestamos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Prestamos> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Prestamo.db");
        }
    }
}
