using Domain.Base;

namespace Domain
{
    public class EmpresaConfig: ApplicationEntity
	{
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public decimal Utilidad { get; set; }
        public decimal ImpuestoVenta { get; set; }
        public decimal PrecioMolde { get; set; }
        public decimal PrecioTinta { get; set; }
        public decimal PrecioPositivo { get; set; }
        public decimal PrecioArte { get; set; }
        public decimal PrecioSolvente { get; set; }
        public decimal PrecioCorte { get; set; }
        public decimal PrecioVelocidad { get; set; }
        public decimal PrecioHoraImpresion { get; set; }

        public virtual Empresa IdNavigation { get; set; }
    }
}
