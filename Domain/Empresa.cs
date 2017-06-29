using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Empresa
    {
        public Empresa()
        {
            Cliente = new HashSet<Cliente>();
            Cotizacion = new HashSet<Cotizacion>();
            Linea = new HashSet<Linea>();
            Material = new HashSet<Material>();
            Precio = new HashSet<Precio>();
            Tipocambio = new HashSet<Tipocambio>();
            Usuario = new HashSet<Usuario>();
            Vendedor = new HashSet<Vendedor>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Empresaconfig Empresaconfig { get; set; }
        public virtual ICollection<Linea> Linea { get; set; }
        public virtual ICollection<Material> Material { get; set; }
        public virtual ICollection<Precio> Precio { get; set; }
        public virtual ICollection<Tipocambio> Tipocambio { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Vendedor> Vendedor { get; set; }
    }
}
