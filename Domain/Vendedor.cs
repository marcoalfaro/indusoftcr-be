using System.Collections.Generic;
using Domain.Base;

namespace Domain
{
    public class Vendedor: CompanyEntity
    {
        public Vendedor()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }
        
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Beeper { get; set; }

        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
