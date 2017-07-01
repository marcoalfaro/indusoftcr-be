using System.Collections.Generic;
using Domain.Base;

namespace Domain
{
    public class Cliente: BaseEntity
    {
        public Cliente()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }

        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string ContactoNombre { get; set; }
        public string ContactoTelefono { get; set; }
        public string ContactoExtension { get; set; }
        public string ContactoCorreo { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
