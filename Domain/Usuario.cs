using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }

        public int Id { get; set; }
        public int Empresaid { get; set; }
        public string Nombre { get; set; }
        public string Nombreusuario { get; set; }
        public string Clave { get; set; }
        public bool Cotizar { get; set; }
        public bool Borrar { get; set; }
        public bool Crear { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
