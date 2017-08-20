using System;
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
			CalcularPrecioMolde();
			CalcularPrecioSolvente();
			CalcularPrecioCorte();
			CalcularPrecioImpresion();
			CalcularSubtotal();
			CalcularTotalCol();
			CalcularTotalUsd();
			CalcularPrecioUnitario();
		}

		private void Validate()
		{
			if (cot == null)
				throw new ArgumentException("Cotizacion cannot be Null");

			if (cot.Material == null)
				throw new ArgumentException("Material cannot be Null");
		}

		public virtual void CalcularRendimientos()
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

		public virtual void CalcularPrecioMaterial()
		{
			cot.PrecioMaterial = cot.Laminas * AgregarPorcentaje(cot.Material.CostoInventario, config.ImpuestoVenta);
		}

		public virtual void CalcularPrecioTintas()
		{
			cot.PrecioTintas = cot.Altura * cot.Base * cot.Empresa.EmpresaConfig.PrecioTinta * (cot.Cubrimiento / 100) * cot.Cantidad;
		}

		public virtual void CalcularPrecioArte()
		{
			var costoArte = cot.Empresa.EmpresaConfig.PrecioArte;
			cot.PrecioArte = Math.Max(cot.Tintas * costoArte, costoArte);
		}

		public virtual void CalcularPrecioPositivo()
		{
			const int minPrecioPositivo = 2000;
			var costoPositivo = cot.Empresa.EmpresaConfig.PrecioPositivo;
			cot.PrecioPositivo = Math.Max(cot.Altura * cot.Base * cot.Montaje * costoPositivo * cot.Tintas, minPrecioPositivo);
		}

		public virtual void CalcularPrecioMolde()
		{
			var costoMolde = cot.Empresa.EmpresaConfig.PrecioMolde;
			cot.PrecioMolde = Math.Max(costoMolde * cot.Tintas, costoMolde);
		}

		public virtual void CalcularPrecioSolvente()
		{
			var costoSolvente = cot.Empresa.EmpresaConfig.PrecioSolvente;
			cot.PrecioSolvente = Math.Max(costoSolvente * cot.Tintas, costoSolvente);
		}

		public virtual void CalcularPrecioCorte()
		{
			var costoCorte = cot.Empresa.EmpresaConfig.PrecioCorte;
			cot.PrecioCorte =  Math.Max(costoCorte * (cot.Cantidad / 1000m), costoCorte);
		}

		public virtual void CalcularPrecioImpresion()
		{
			var costoHoraImpresion = cot.Empresa.EmpresaConfig.PrecioHoraImpresion;
			var costoVelocidad = cot.Empresa.EmpresaConfig.PrecioVelocidad;
			cot.PrecioImpresion = Math.Max((cot.Cantidad / cot.Montaje * cot.Tintas) / costoVelocidad * costoHoraImpresion, costoHoraImpresion);
		}

		public virtual void CalcularSubtotal()
		{
			var suma = cot.PrecioMaterial +
			           cot.PrecioTintas +
					   cot.PrecioArte +
					   cot.PrecioPositivo +
					   cot.PrecioMolde +
					   cot.PrecioSolvente +
					   cot.PrecioCorte +
					   cot.PrecioImpresion +
					   cot.Troquel +
					   cot.Doblez +
					   cot.Cuatricromia +
					   cot.Otro;
			cot.Subtotal = Math.Round(suma, 2);
		}

		public virtual void CalcularTotalCol()
		{
			var sinEvento = AgregarPorcentaje(cot.Subtotal, cot.Empresa.EmpresaConfig.Utilidad);
			cot.TotalCol = cot.PorcEvento > 0 ? AgregarPorcentaje(sinEvento, cot.PorcEvento) : sinEvento;
		}

		public virtual void CalcularTotalUsd()
		{
			cot.TotalUsd = cot.TotalCol / cot.TipoCambio.Monto;
		}

		public virtual void CalcularPrecioUnitario()
		{
			cot.PrecioUnitario = cot.TotalCol / cot.Cantidad;
		}

		private decimal AgregarPorcentaje(decimal monto, decimal porcentaje)
		{
			return monto + (monto * porcentaje / 100);
		}
	}
}
