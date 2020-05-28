using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroPrestamos.Entidades
{
    public class Prestamo
    {
        [Key]
        public int IdPersona { get; set; }
        public int IdPrestamo { get; set; }
        public double Monto { get; set; }
        public double Balance { get; set; }
        public string ConceptoPrestamo { get; set; }
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;

    }
}
