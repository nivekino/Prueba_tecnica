using System;
using System.Collections.Generic;

namespace Prueba_tecnica_01.Models
{
    public partial class MateriasxAlumno
    {
        public int Id { get; set; }
        public int? IdMateria { get; set; }
        public int? IdAlumno { get; set; }
        public double? Calificacion1 { get; set; }
        public double? Calificacion2 { get; set; }
        public double? Calificacion3 { get; set; }

        public virtual Alumno? IdAlumnoNavigation { get; set; }
        public virtual Materia? IdMateriaNavigation { get; set; }
    }
}
