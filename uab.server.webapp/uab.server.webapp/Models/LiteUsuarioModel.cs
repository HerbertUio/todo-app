using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uab.server.webapp.Models
{
    public class LiteUsuarioModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public LiteGeneroModel Sexo { get; set; }
    }
}