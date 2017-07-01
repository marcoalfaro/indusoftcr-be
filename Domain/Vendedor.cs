﻿using System.Collections.Generic;
using Domain.Base;

namespace Domain
{
    public class Vendedor: BaseEntity
    {
        public Vendedor()
        {
            Cotizacion = new HashSet<Cotizacion>();
        }

        public int Empresaid { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Beeper { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
