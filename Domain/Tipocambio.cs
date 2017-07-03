using System;
using System.Collections.Generic;
using Domain.Base;

namespace Domain
{
    public class TipoCambio: CompanyEntity
    {
        public TipoCambio()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }
        
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
