using System;
using Application.Base;
using Domain;
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
		public decimal PrecioUnitario { get; set; }
		public decimal Subtotal { get; set; }
		public decimal Porcentaje { get; set; }
		public decimal TotalUsd { get; set; }
		public decimal TotalCol { get; set; }
		public int Cantidad { get; set; }
		public decimal Montaje { get; set; }
		public decimal Base { get; set; }
		public decimal Altura { get; set; }
		public decimal Tintas { get; set; }
		public decimal Cubrimiento { get; set; }
		public decimal Troquel { get; set; }
		public decimal Doblez { get; set; }
		public decimal Cuatricromia { get; set; }
		public decimal Otro { get; set; }
		public decimal PorcEvento { get; set; }
		public bool Aplicada { get; set; }
		public DateTime? FecAplicada { get; set; }
		public DateTime? FecRegistro { get; set; }
		public string NumPedido { get; set; }
		public decimal PrecioMaterial { get; set; }
		public decimal PrecioTintas { get; set; }
		public decimal PrecioArte { get; set; }
		public decimal PrecioImpresion { get; set; }
		public decimal PrecioMolde { get; set; }
		public decimal PrecioCorte { get; set; }
		public decimal PrecioPositivo { get; set; }
		public decimal PrecioSolvente { get; set; }
		public decimal Rendimiento { get; set; }
		public decimal Laminas { get; set; }
		public string Observacion { get; set; }
		public decimal DivLargo { get; set; }
		public decimal DivAncho { get; set; }

		public override void UpdateEntityFields(ApplicationEntity entity)
		{
			var cot = (Cotizacion)entity;
			//cot.UsuarioId = Usuario.Id;		// se saca de la sesion
			cot.MaterialId = Material?.Id;
			cot.ClienteId = Cliente?.Id;
			cot.VendedorId = Vendedor?.Id;
			cot.LineaId = Linea?.Id;
			//cot.TipoCambio.Id = TipoCambio.Id;  // Se pone en el server
			cot.Altura = Altura;
			cot.Aplicada = Aplicada;
			cot.Base = Base;
			cot.Cantidad = Cantidad;
			cot.Cuatricromia = Cuatricromia;
			cot.DivAncho = DivAncho;
			cot.DivLargo = DivLargo;
			cot.Cubrimiento = Cubrimiento;
			cot.Doblez = Doblez;
			cot.FecAplicada = FecAplicada;
			cot.FecRegistro = FecRegistro;
			cot.Fecha = Fecha;
			cot.Laminas = Laminas;
			cot.Montaje = Montaje;
			cot.NumPedido = NumPedido;
			cot.Observacion = Observacion;
			cot.Otro = Otro;
			cot.PorcEvento = PorcEvento;
			cot.Porcentaje = Porcentaje;
			cot.PrecioArte = PrecioArte;
			cot.PrecioCorte = PrecioCorte;
			cot.PrecioImpresion = PrecioImpresion;
			cot.PrecioMaterial = PrecioMaterial;
			cot.PrecioMolde = PrecioMolde;
			cot.PrecioPositivo = PrecioPositivo;
			cot.PrecioSolvente = PrecioSolvente;
			cot.PrecioTintas = PrecioTintas;
			cot.PrecioUnitario = PrecioUnitario;
			cot.Rendimiento = Rendimiento;
			cot.Subtotal = Subtotal;
			cot.TotalCol = TotalCol;
			cot.TotalUsd = TotalUsd;
			cot.Doblez = Doblez;
			cot.Troquel = Troquel;
			cot.Tintas = Tintas;
			base.UpdateEntityFields(cot);
		}
	}
}
