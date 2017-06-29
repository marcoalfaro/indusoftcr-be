using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }

        public int Id { get; set; }
        public int Empresaid { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Contactonombre { get; set; }
        public string Contactotelefono { get; set; }
        public string Contactoextension { get; set; }
        public string Contactocorreo { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
