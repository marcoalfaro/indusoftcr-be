using System;
using System.Diagnostics.CodeAnalysis;
using Application.Cotizaciones;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Application
{
	[TestClass]
	[SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
	public class EstimatorTest
	{
		private Estimator estimator;
		private Cotizacion cotizacion;

		[TestInitialize]
		public void TestInitialize()
		{
			estimator = new Estimator();
			cotizacion = new Cotizacion
			{
				Altura = 1,
				Base = 1,
				Cantidad = 1,
				Rendimiento = 1,
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig() },
				Material = new Material { Base = 1, Altura = 1 }
			};

		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void Estimate_ValidateNullCot_ExceptionThrown()
		{
			cotizacion = null;
			estimator.Estimate(cotizacion);
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void Estimate_ValidateNullMaterial_ExceptionThrown()
		{
			cotizacion.Material = null;
			estimator.Estimate(cotizacion);
		}

		[TestMethod]
		public void Estimate_RendimientosSinDesperdicio_RendimientoExacto()
		{
			cotizacion.Base = 1;
			cotizacion.Altura = 2;
			cotizacion.Material = new Material { Base = 10, Altura = 20 };

			estimator.Estimate(cotizacion);

			Assert.AreEqual(100, cotizacion.Rendimiento);
		}

		[TestMethod]
		public void Estimate_RendimientosConDesperdicio_RendimientoRedondeado()
		{
			cotizacion.Base = 1;
			cotizacion.Altura = 3;
			cotizacion.Material = new Material { Base = 10, Altura = 20 };

			estimator.Estimate(cotizacion);

			Assert.AreEqual(60, cotizacion.Rendimiento);
		}

		[TestMethod]
		public void Estimate_RendimientosSinDesperdicio_LargoYAnchoExacto()
		{
			cotizacion.Base = 1;
			cotizacion.Altura = 2;
			cotizacion.Cantidad = 100;
			cotizacion.Material = new Material { Base = 10, Altura = 20 };

			estimator.Estimate(cotizacion);

			Assert.AreEqual(10, cotizacion.DivLargo);
			Assert.AreEqual(10, cotizacion.DivAncho);
			Assert.AreEqual(1, cotizacion.Laminas);
		}

		[TestMethod]
		public void CalcularRendimientos_ConDesperdicio_LargoYAnchoRedondeado()
		{
			cotizacion.Base = 1;
			cotizacion.Altura = 3;
			cotizacion.Cantidad = 100;
			cotizacion.Material = new Material { Base = 10, Altura = 20 };

			estimator.Estimate(cotizacion);

			AssertEqualDecimal(6.66m, cotizacion.DivLargo);
			AssertEqualDecimal(10, cotizacion.DivAncho);
			AssertEqualDecimal(1.66m, cotizacion.Laminas);
		}

		[TestMethod]
		public void CalcularRendimientos_OrientacionInvertida_LargoYAnchoRedondeado()
		{
			cotizacion.Base = 3;
			cotizacion.Altura = 5;
			cotizacion.Cantidad = 100;
			cotizacion.Material = new Material { Base = 10, Altura = 30 };

			estimator.Estimate(cotizacion);

			AssertEqualDecimal(2, cotizacion.DivLargo);
			AssertEqualDecimal(10, cotizacion.DivAncho);
			AssertEqualDecimal(5, cotizacion.Laminas);
		}

		[TestMethod]
		public void CalcularPrecioMaterial()
		{
			cotizacion.Empresa.EmpresaConfig.ImpuestoVenta = 10m;
			cotizacion.Material = new Material { CostoInventario = 100, Base = 1, Altura = 1 };
			cotizacion.Laminas = 5;

			// Idea: Use cotizacionMock 

			estimator.Estimate(cotizacion);

			Assert.AreEqual(550, cotizacion.PrecioMaterial);
		}

		#region Helpers

		private static void AssertEqualDecimal(decimal expected, decimal actual)
		{
			const float delta = 0.01f;
			var expectedFloat = (float)expected;
			var actualFloat = (float)actual;

			Assert.AreEqual(expectedFloat, actualFloat, delta);
		}

		#endregion

	}
}
