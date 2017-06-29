using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Linea
    {
        public int Id { get; set; }
        public int Empresaid { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
