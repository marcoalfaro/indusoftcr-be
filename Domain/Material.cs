using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Material
    {
        public Material()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }

        public int Id { get; set; }
        public int Empresaid { get; set; }
        public string Nombre { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Base { get; set; }
        public string Codigoinventario { get; set; }
        public decimal? Costoinventario { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
