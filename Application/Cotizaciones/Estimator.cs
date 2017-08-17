using System;
using System.Collections.Generic;
using CloneExtensions;
using Domain;

namespace Application.Cotizaciones
{
	public class Estimator
	{
		private readonly Cotizacion cot;
		private readonly EmpresaConfig config;

		public Estimator(Cotizacion cotizacion)
		{
			cot = cotizacion;
			config = cotizacion?.Empresa?.EmpresaConfig;
			Validate();
		}

		public void Estimate()
		{
			CalcularRendimientos();
			CalcularPrecioMaterial();
			CalcularPrecioTintas();
			CalcularPrecioArte();
			CalcularPrecioPositivo();

			//PrecioMolde = cotizador.CalcularPrecioMolde(precio.Molde);
			//PrecioSolvente = cotizador.CalcularPrecioSolvente(precio.Solvente);
			//PrecioCorte = cotizador.CalcularPrecioCorte(precio.Corte);
			//PrecioImpresion = cotizador.CalcularPrecioImpresion(precio);
			//Subtotal = cotizador.CalcularSubtotal();
			//TotalCol = cotizador.CalcularTotalCol();
			//TotalUsd = cotizador.CalcularTotalUsd();
			//PrecioUnitario = cotizador.CalcularPrecioUnitario();

		}

		private void Validate()
		{
			if (cot == null)
				throw new ArgumentException("Cotizacion cannot be Null");

			if (cot.Material == null)
				throw new ArgumentException("Material cannot be Null");
		}

		public void CalcularRendimientos()
		{
			var materialBaseEntreAltura = cot.Material.Base / cot.Altura;
			var materialAlturaEntreBase = cot.Material.Altura / cot.Base;
			var materialAlturaEntreAltura = cot.Material.Altura / cot.Altura;
			var materialBaseEntreBase = cot.Material.Base / cot.Base;

			decimal rendimiento1 = (int)materialBaseEntreAltura * (int)materialAlturaEntreBase;
			decimal rendimiento2 = (int)materialAlturaEntreAltura * (int)materialBaseEntreBase;

			if (rendimiento1 > rendimiento2)
			{
				cot.DivLargo = materialBaseEntreAltura;
				cot.DivAncho = materialAlturaEntreBase;
				cot.Rendimiento = rendimiento1;
			}
			else
			{
				cot.DivLargo = materialAlturaEntreAltura;
				cot.DivAncho = materialBaseEntreBase;
				cot.Rendimiento = rendimiento2;
			}
			cot.Laminas = cot.Cantidad / cot.Rendimiento;
		}

		public void CalcularPrecioMaterial()
		{
			cot.PrecioMaterial = cot.Laminas * AgregarPorcentaje(cot.Material.CostoInventario, config.ImpuestoVenta);
		}

		public void CalcularPrecioTintas()
		{
			cot.PrecioTintas = cot.Altura * cot.Base * cot.Empresa.EmpresaConfig.PrecioTinta * (cot.Cubrimiento / 100) * cot.Cantidad;
		}

		public void CalcularPrecioArte()
		{
			var costoArte = cot.Empresa.EmpresaConfig.PrecioArte;
			cot.PrecioArte = Math.Max(cot.Tintas * costoArte, costoArte);
		}

		public void CalcularPrecioPositivo()
		{
			const int minPrecioPositivo = 2000;
			var costoPositivo = cot.Empresa.EmpresaConfig.PrecioPositivo;
			cot.PrecioPositivo = Math.Max(cot.Altura * cot.Base * cot.Montaje * costoPositivo * cot.Tintas, minPrecioPositivo);
		}

		//public decimal CalcularPrecioArte(decimal precioArte)
		//{
		//	return Math.Max(context.Tintas * precioArte, precioArte);
		//}


		//public decimal CalcularPrecioUnitario()
		//   {
		//    return context.TotalCol / context.Cantidad;
		//   }

		//   public decimal CalcularTotalCol()
		//   {
		//    var sinEvento = AgregarPorcentaje(context.Subtotal, context.Empresa.Utilidad);
		//    return context.Evento ? AgregarPorcentaje(sinEvento, context.PorcEvento) : sinEvento;
		//   }

		//   public decimal CalcularTotalUsd()
		//   {
		//    return context.TotalCol / context.TipoCambio.Monto;
		//   }

		//   public decimal CalcularSubtotal()
		//   {
		//    var suma = context.PrecioMaterial +
		//               context.PrecioTintas +
		//               context.PrecioArte +
		//               context.PrecioPositivo +
		//               context.PrecioMolde +
		//               context.PrecioSolvente +
		//               context.PrecioCorte +
		//               context.PrecioImpresion +
		//               context.Troquel +
		//               context.Doblez +
		//               context.Cuatricromia +
		//               context.Otro;
		//    return Math.Round(suma, 2);
		//   }

		//   public decimal CalcularPrecioCorte(decimal precioCorte)
		//   {
		//    return Math.Max(precioCorte * (context.Cantidad / 1000m), precioCorte);
		//   }

		//   public decimal CalcularPrecioSolvente(decimal precioSolvente)
		//   {
		//    return Math.Max(precioSolvente * context.Tintas, precioSolvente);
		//   }

		//   public decimal CalcularPrecioMolde(decimal precioMolde)
		//   {
		//    return Math.Max(precioMolde * context.Tintas, precioMolde);
		//   }




		//   public decimal CalcularPrecioImpresion(Precio precio)
		//   {
		//    return Math.Max((context.Cantidad / context.Montaje * context.Tintas) / precio.Velocidad * precio.HoraImpresion
		//	    , precio.HoraImpresion);
		//   }

		public decimal AgregarPorcentaje(decimal monto, decimal porcentaje)
		{
			return monto + (monto * porcentaje / 100);
		}
	}
}
