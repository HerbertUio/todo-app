using System;
using uab.server.Entities.Entities;

namespace uab.server.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public SexoEnum Sexo { get; set; }
    }
}
