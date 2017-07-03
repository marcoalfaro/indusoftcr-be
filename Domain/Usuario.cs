using System.Collections.Generic;
using Domain.Base;

namespace Domain
{
    public class Usuario: CompanyEntity
    {
        public Usuario()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }
        
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public bool Cotizar { get; set; }
        public bool Borrar { get; set; }
        public bool Crear { get; set; }

        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
