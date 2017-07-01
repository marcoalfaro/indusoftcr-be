using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class TipoCambio
    {
        public TipoCambio()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }

        public int Id { get; set; }
        public int Empresaid { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
