using System;

namespace uab.server.Entities
{
    public class TodoAppModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Visible { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int IdUsuario { get; set; }
    }
}
