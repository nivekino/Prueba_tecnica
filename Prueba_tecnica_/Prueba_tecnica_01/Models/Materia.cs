using System;
using System.Collections.Generic;

namespace Prueba_tecnica_01.Models
{
    public partial class Materia
    {
        public Materia()
        {
            MateriasxAlumnos = new HashSet<MateriasxAlumno>();
        }

        public int Id { get; set; }
        public string? NombreMateria { get; set; }
        public int? IdProfesor { get; set; }

        public virtual Maestro? IdProfesorNavigation { get; set; }
        public virtual ICollection<MateriasxAlumno> MateriasxAlumnos { get; set; }
    }
}
