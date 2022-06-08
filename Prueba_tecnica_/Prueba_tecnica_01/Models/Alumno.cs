using System;
using System.Collections.Generic;

namespace Prueba_tecnica_01.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            MateriasxAlumnos = new HashSet<MateriasxAlumno>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public virtual ICollection<MateriasxAlumno> MateriasxAlumnos { get; set; }
    }
}
