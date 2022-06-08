using System;
using System.Collections.Generic;

namespace Prueba_tecnica_01.Models
{
    public partial class Maestro
    {
        public Maestro()
        {
            Materia = new HashSet<Materia>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public virtual ICollection<Materia> Materia { get; set; }
    }
}
