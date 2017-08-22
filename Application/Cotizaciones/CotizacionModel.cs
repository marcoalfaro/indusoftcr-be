using System;
using Application.Base;
using Domain.Base;

namespace Application.Cotizaciones
{
	public class CotizacionModel : CompanyModel
	{
		public ListItem Empresa { get; set; }
		public ListItem Cliente { get; set; }
		public ListItem Usuario { get; set; }
		public ListItem Vendedor { get; set; }
		public ListItem Material { get; set; }
		public ListItemMonto TipoCambio { get; set; }
		public ListItem Linea { get; set; }
		public DateTime? Fecha { get; set; }
		public decimal? PrecioUnitario { get; set; }
		public decimal? Subtotal { get; set; }
		public decimal? Porcentaje { get; set; }
		public decimal? TotalUsd { get; set; }
		public decimal? TotalCol { get; set; }
		public int? Cantidad { get; set; }
		public decimal? Montaje { get; set; }
		public decimal? Base { get; set; }
		public decimal? Altura { get; set; }
		public decimal? Tintas { get; set; }
		public decimal? Cubrimiento { get; set; }
		public decimal? Troquel { get; set; }
		public decimal? Doblez { get; set; }
		public decimal? Cuatricromia { get; set; }
		public decimal? Otro { get; set; }
		public decimal? PorcEvento { get; set; }
		public bool? Aplicada { get; set; }
		public DateTime? FecAplicada { get; set; }
		public DateTime? FecRegistro { get; set; }
		public string NumPedido { get; set; }
		public decimal? PrecioMaterial { get; set; }
		public decimal? PrecioTintas { get; set; }
		public decimal? PrecioArte { get; set; }
		public decimal? PrecioImpresion { get; set; }
		public decimal? PrecioMolde { get; set; }
		public decimal? PrecioCorte { get; set; }
		public decimal? PrecioPositivo { get; set; }
		public decimal? PrecioSolvente { get; set; }
		public decimal? Rendimiento { get; set; }
		public decimal? Laminas { get; set; }
		public string Observacion { get; set; }
		public decimal? DivLargo { get; set; }
		public decimal? DivAncho { get; set; }
	}
}
