using System.Collections.Generic;
using Domain.Base;

namespace Domain
{
    public sealed class Material: BaseEntity
    {
        public Material()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }
        
        public int Empresaid { get; set; }
        public string Nombre { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Base { get; set; }
        public string Codigoinventario { get; set; }
        public decimal? Costoinventario { get; set; }
        public bool Activo { get; set; }

        public ICollection<Cotizacion> Cotizacion { get; set; }
        public Empresa Empresa { get; set; }
    }
}
