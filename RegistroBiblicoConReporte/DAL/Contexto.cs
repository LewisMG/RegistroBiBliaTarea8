using RegistroBiblicoConReporte.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace RegistroBiblicoConReporte.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Libros> Libro { get; set; }

        public Contexto() : base("ConStr")
        { }
    }
}
