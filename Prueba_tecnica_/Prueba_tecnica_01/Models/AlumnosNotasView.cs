using System;
using System.Collections.Generic;

namespace Prueba_tecnica_01.Models
{
    public partial class AlumnosNotasView
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? IdMateria { get; set; }
        public double? Calificacion1 { get; set; }
        public double? Calificacion2 { get; set; }
        public double? Calificacion3 { get; set; }
    }
}
