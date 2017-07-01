using System.Collections.Generic;
using Domain.Base;

namespace Domain
{
    public sealed class Empresa: BaseEntity
    {
        public Empresa()
        {
            Cliente = new HashSet<Cliente>();
            Cotizacion = new HashSet<Cotizacion>();
            Linea = new HashSet<Linea>();
            Material = new HashSet<Material>();
            Precio = new HashSet<Precio>();
            Tipocambio = new HashSet<TipoCambio>();
            Usuario = new HashSet<Usuario>();
            Vendedor = new HashSet<Vendedor>();
        }
		
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public ICollection<Cliente> Cliente { get; set; }
        public ICollection<Cotizacion> Cotizacion { get; set; }
        public EmpresaConfig EmpresaConfig { get; set; }
        public ICollection<Linea> Linea { get; set; }
        public ICollection<Material> Material { get; set; }
        public ICollection<Precio> Precio { get; set; }
        public ICollection<TipoCambio> Tipocambio { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
        public ICollection<Vendedor> Vendedor { get; set; }
    }
}
