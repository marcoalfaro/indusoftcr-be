using Application.Base;

namespace Application.EmpresaConfigs
{
	public class EmpresaConfigModel : CompanyModel
	{	
		public string Cedula { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }
		public decimal Utilidad { get; set; }
		public decimal Impuestoventa { get; set; }
		public decimal PrecioMolde { get; set; }
		public decimal PrecioTinta { get; set; }
		public decimal PrecioPositivo { get; set; }
		public decimal PrecioArte { get; set; }
		public decimal PrecioSolvente { get; set; }
		public decimal PrecioCorte { get; set; }
		public decimal PrecioVelocidad { get; set; }
		public decimal PrecioHoraImpresion { get; set; }
	}
}
