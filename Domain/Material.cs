using System.Collections.Generic;
using Domain.Base;

namespace Domain
{
    public sealed class Material: CompanyEntity
	{
        public Material()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }
        
        public string Nombre { get; set; }
        public decimal Altura { get; set; }
        public decimal Base { get; set; }
        public string CodigoInventario { get; set; }
        public decimal CostoInventario { get; set; }

        public ICollection<Cotizacion> Cotizacion { get; set; }
        public Empresa Empresa { get; set; }
    }
}
