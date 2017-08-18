using System;
using System.Diagnostics.CodeAnalysis;
using Application.Cotizaciones;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.Application
{
	[TestClass]
	[SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
	public class EstimatorTest
	{

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void Validate_NullCot_ExceptionThrown()
		{
			var dummy = new Estimator(null);
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void Validate_NullMaterial_ExceptionThrown()
		{
			var cot = new Cotizacion();
			var dummy = new Estimator(cot);
		}

		[TestMethod]
		public void Estimate_EstimateAll_AllMethodsCalled()
		{
			var cotizacion = new Mock<Cotizacion>();
			cotizacion.Setup(x => x.Material).Returns(new Material());
			cotizacion.Setup(x => x.Empresa).Returns(new Empresa { EmpresaConfig = new EmpresaConfig { PrecioVelocidad = 1 } });
			cotizacion.Setup(x => x.TipoCambio).Returns(new TipoCambio { Monto = 1 });
			cotizacion.Setup(x => x.Altura).Returns(1);
			cotizacion.Setup(x => x.Base).Returns(1);
			cotizacion.Setup(x => x.Rendimiento).Returns(1);
			cotizacion.Setup(x => x.Montaje).Returns(1);
			cotizacion.Setup(x => x.Cantidad).Returns(1);

			var mock = new Mock<Estimator>(cotizacion.Object);

			mock.Object.Estimate();

			mock.Verify(x => x.CalcularRendimientos(), Times.Once);
			mock.Verify(x => x.CalcularPrecioMaterial(), Times.Once);
			mock.Verify(x => x.CalcularPrecioTintas(), Times.Once);
			mock.Verify(x => x.CalcularPrecioArte(), Times.Once);
			mock.Verify(x => x.CalcularPrecioPositivo(), Times.Once);
			mock.Verify(x => x.CalcularPrecioMolde(), Times.Once);
			mock.Verify(x => x.CalcularPrecioSolvente(), Times.Once);
			mock.Verify(x => x.CalcularPrecioCorte(), Times.Once);
			mock.Verify(x => x.CalcularPrecioImpresion(), Times.Once);
			mock.Verify(x => x.CalcularSubtotal(), Times.Once);
			mock.Verify(x => x.CalcularTotalCol(), Times.Once);
			mock.Verify(x => x.CalcularTotalUsd(), Times.Once);
			mock.Verify(x => x.CalcularPrecioUnitario(), Times.Once);
		}

		[TestMethod]
		public void CalcularRendimientos_SinDesperdicio_RendimientoExacto()
		{
			var cotization = new Cotizacion
			{
				Altura = 1,
				Base = 2,
				Material = new Material { Base = 10, Altura = 20 }
			};

			var instance = new Estimator(cotization);
			instance.CalcularRendimientos();

			Assert.AreEqual(100, cotization.Rendimiento);
		}

		[TestMethod]
		public void CalcularRendimientos_ConDesperdicio_RendimientoRedondeado()
		{
			var cot = new Cotizacion
			{
				Altura = 1,
				Base = 3,
				Material = new Material { Base = 10, Altura = 20 }
			};
			var instance = new Estimator(cot);

			instance.CalcularRendimientos();

			Assert.AreEqual(60, cot.Rendimiento);
		}

		[TestMethod]
		public void CalcularRendimientos_SinDesperdicio_LargoYAnchoExacto()
		{
			var cot = new Cotizacion
			{
				Altura = 2,
				Base = 1,
				Cantidad = 100,
				Material = new Material { Base = 10, Altura = 20 }
			};
			var instance = new Estimator(cot);

			instance.CalcularRendimientos();

			Assert.AreEqual(10, cot.DivLargo);
			Assert.AreEqual(10, cot.DivAncho);
			AssertEqualDecimal(1, cot.Laminas);
		}

		[TestMethod]
		public void CalcularRendimientos_ConDesperdicio_LargoYAnchoRedondeado()
		{
			var cot = new Cotizacion
			{
				Base = 1,
				Altura = 3,
				Cantidad = 100,
				Material = new Material { Base = 10, Altura = 20 }
			};
			var instance = new Estimator(cot);

			instance.CalcularRendimientos();

			AssertEqualDecimal(6.66m, cot.DivLargo);
			AssertEqualDecimal(10, cot.DivAncho);
			AssertEqualDecimal(1.66m, cot.Laminas);
		}

		[TestMethod]
		public void CalcularRendimientos_OrientacionInvertida_LargoYAnchoRedondeado()
		{
			var cot = new Cotizacion
			{
				Base = 3,
				Altura = 5,
				Cantidad = 100,
				Material = new Material { Base = 10, Altura = 30 }
			};
			var instance = new Estimator(cot);

			instance.CalcularRendimientos();

			AssertEqualDecimal(2, cot.DivLargo);
			AssertEqualDecimal(10, cot.DivAncho);
			AssertEqualDecimal(5, cot.Laminas);
		}

		[TestMethod]
		public void CalcularPrecioMaterial()
		{
			var cotizacion = new Cotizacion
			{
				Altura = 1,
				Base = 1,
				Cubrimiento = 2,
				Cantidad = 1,
				Laminas = 5,
				Material = new Material { CostoInventario = 100, Base = 1, Altura = 1 },
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { ImpuestoVenta = 10m } }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioMaterial();

			Assert.AreEqual(550, cotizacion.PrecioMaterial);
		}

		[TestMethod]
		public void CalcularPrecioTintas()
		{
			var cotizacion = new Cotizacion
			{
				Altura = 10,
				Base = 20,
				Cubrimiento = 2,
				Cantidad = 5,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioTinta = 10m } }
			};

			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioTintas();

			Assert.AreEqual(200, cotizacion.PrecioTintas);
		}

		[TestMethod]
		public void CalcularPrecioArte_TintasMenora1_RetornaPrecioArte()
		{
			var cotizacion = new Cotizacion
			{
				Tintas = 0.5m,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioArte = 10m } }
			};

			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioArte();

			Assert.AreEqual(10, cotizacion.PrecioArte);
		}

		[TestMethod]
		public void CalcularPrecioArte_TintasMayora1_RetornaPrecioArtePorTintas()
		{
			var cotizacion = new Cotizacion
			{
				Tintas = 5,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioArte = 10m } }
			};

			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioArte();

			Assert.AreEqual(50, cotizacion.PrecioArte);
		}

		[TestMethod]
		public void CalcularPrecioPositivo_ResultadoMayorA2000_RetornaMultiplicacion()
		{
			var cotizacion = new Cotizacion
			{
				Base = 10,
				Altura = 10,
				Montaje = 2,
				Tintas = 2,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioPositivo = 10m } }
			};

			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioPositivo();

			Assert.AreEqual(4000, cotizacion.PrecioPositivo);
		}

		[TestMethod]
		public void CalcularPrecioPositivo_ResultadoMenorA2000_Retorna2000()
		{
			var cotizacion = new Cotizacion
			{
				Base = 1,
				Altura = 1,
				Montaje = 1,
				Tintas = 1,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioPositivo = 10m } }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioPositivo();

			Assert.AreEqual(2000m, cotizacion.PrecioPositivo);
		}

		[TestMethod]
		public void CalcularPrecioMolde_TintasMenora1_RetornaPrecioMolde()
		{
			var cotizacion = new Cotizacion
			{
				Tintas = 0.5m,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioMolde = 10m } }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioMolde();

			Assert.AreEqual(10, cotizacion.PrecioMolde);
		}

		[TestMethod]
		public void CalcularPrecioMolde_TintasMayora1_RetornaPrecioMoldePorTintas()
		{
			var cotizacion = new Cotizacion
			{
				Tintas = 5,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioMolde = 10m } }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioMolde();

			Assert.AreEqual(50, cotizacion.PrecioMolde);
		}

		[TestMethod]
		public void CalcularPrecioSolvente_TintasMenora1_RetornaPrecioSolvente()
		{
			var cotizacion = new Cotizacion
			{
				Tintas = 0.5m,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioSolvente = 10m } }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioSolvente();

			Assert.AreEqual(10, cotizacion.PrecioSolvente);
		}

		[TestMethod]
		public void CalcularPrecioSolvente_TintasMayora1_RetornaPrecioSolventePorTintas()
		{
			var cotizacion = new Cotizacion
			{
				Tintas = 5,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioSolvente = 10m } }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioSolvente();

			Assert.AreEqual(50, cotizacion.PrecioSolvente);
		}

		[TestMethod]
		public void CalcularPrecioCorte_PrecioCorteMenorA1_RetornaPrecioCorte()
		{
			var cotizacion = new Cotizacion
			{
				Cantidad = 100,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioCorte = 10m } }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioCorte();

			Assert.AreEqual(10, cotizacion.PrecioCorte);
		}

		[TestMethod]
		public void CalcularPrecioCorte_PrecioCorteMayorA1_RetornaMultiplicacion()
		{
			var cotizacion = new Cotizacion
			{
				Cantidad = 5000,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioCorte = 10m } }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioCorte();

			Assert.AreEqual(50, cotizacion.PrecioCorte);
		}

		[TestMethod]
		public void CalcularPrecioImpresion_MenorHoraImpresion_HoraImpresion()
		{
			var cotizacion = new Cotizacion
			{
				Cantidad = 10,
				Montaje = 10,
				Tintas = 2,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioVelocidad = 10, PrecioHoraImpresion = 1000 } }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioImpresion();

			Assert.AreEqual(1000, cotizacion.PrecioImpresion);
		}

		[TestMethod]
		public void CalcularPrecioImpresion_MayorHoraImpresion_HoraImpresion()
		{
			var cotizacion = new Cotizacion
			{
				Cantidad = 10,
				Montaje = 10,
				Tintas = 2,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { PrecioVelocidad = 1, PrecioHoraImpresion = 100 } }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioImpresion();

			Assert.AreEqual(200, cotizacion.PrecioImpresion);
		}

		[TestMethod]
		public void CalcularSubTotal()
		{
			var cotizacion = new Cotizacion
			{
				PrecioMaterial = 1,
				PrecioTintas = 2,
				PrecioArte = 3,
				PrecioPositivo = 4,
				PrecioMolde = 5,
				PrecioSolvente = 6,
				PrecioCorte = 7,
				PrecioImpresion = 8,
				Troquel = 9,
				Doblez = 10,
				Cuatricromia = 11,
				Otro = 12.567m,
				Material = new Material()
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularSubtotal();

			Assert.AreEqual(78.57m, cotizacion.Subtotal);
		}

		[TestMethod]
		public void CalcularTotalCol_SinEvento_UtilidadAgregada()
		{
			var cotizacion = new Cotizacion
			{
				Subtotal = 100,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { Utilidad = 20 } },
				PorcEvento = 0
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularTotalCol();

			Assert.AreEqual(120, cotizacion.TotalCol);
		}

		[TestMethod]
		public void CalcularTotalCol_ConEvento_UtilidadYEventoAgregados()
		{
			var cotizacion = new Cotizacion
			{
				Subtotal = 100,
				Material = new Material(),
				Empresa = new Empresa { EmpresaConfig = new EmpresaConfig { Utilidad = 20 } },
				PorcEvento = 10
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularTotalCol();

			Assert.AreEqual(132, cotizacion.TotalCol);
		}

		[TestMethod]
		public void CalcularTotalUsd()
		{
			const decimal totalCol = 5000;
			var cotizacion = new Cotizacion
			{
				TotalCol = totalCol,
				Material = new Material(),
				TipoCambio = new TipoCambio { Monto = 500 }
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularTotalUsd();

			Assert.AreEqual(10, cotizacion.TotalUsd);
		}

		[TestMethod]
		public void CalcularPrecioUnitario()
		{
			var cotizacion = new Cotizacion
			{
				TotalCol = 100,
				Cantidad = 5,
				Material = new Material()
			};
			var instance = new Estimator(cotizacion);

			instance.CalcularPrecioUnitario();

			Assert.AreEqual(20, cotizacion.PrecioUnitario);
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
