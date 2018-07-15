using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroBiblicoConReporte.Entidades
{
    public class Libros
    {
        [Key]
        public int TipoId { get; set; }
        public int LibroId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Siglas { get; set; }

        public Libros()
        {
        }
    }
}
