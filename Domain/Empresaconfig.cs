using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class EmpresaConfig
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public decimal Utilidad { get; set; }
        public decimal Impuestoventa { get; set; }
        public decimal Preciomolde { get; set; }
        public decimal Preciotinta { get; set; }
        public decimal Preciopositivo { get; set; }
        public decimal Precioarte { get; set; }
        public decimal Preciosolvente { get; set; }
        public decimal Preciocorte { get; set; }
        public decimal Preciovelocidad { get; set; }
        public decimal Preciohoraimpresion { get; set; }

        public virtual Empresa IdNavigation { get; set; }
    }
}
