﻿using System;
using Domain;

namespace Application.Cotizaciones
{
	public class Estimator
	{
		private Cotizacion cot;
		private EmpresaConfig config;


		public void Estimate(Cotizacion cotizacion)
		{
			cot = cotizacion;
			config = cotizacion?.Empresa?.EmpresaConfig;
			Validate();
			CalcularRendimientos();
			CalcularPrecioMaterial();

			//PrecioTintas = cotizador.CalcularPrecioTintas(precio.Tinta);
			//PrecioArte = cotizador.CalcularPrecioArte(precio.Arte);
			//PrecioPositivo = cotizador.CalcularPrecioPositivo(precio.Positivo);
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

		//   public decimal CalcularPrecioPositivo(decimal precioPositivo)
		//   {
		//    const int minPrecioPositivo = 2000;
		//    return Math.Max(context.Altura * context.Base * context.Montaje * precioPositivo * context.Tintas, minPrecioPositivo);
		//   }

		//   public decimal CalcularPrecioArte(decimal precioArte)
		//   {
		//    return Math.Max(context.Tintas * precioArte, precioArte);
		//   }

		//   public decimal CalcularPrecioTintas(decimal precioTinta)
		//   {
		//    return context.Altura * context.Base * precioTinta * (context.Cubrimiento / 100) * context.Cantidad;
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