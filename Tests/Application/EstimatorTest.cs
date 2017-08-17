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
		private Estimator estimator;
		private Cotizacion cot;
		private Mock<Cotizacion> cotMock;


		[TestInitialize]
		public void TestInitialize()
		{
			//cot = new Cotizacion
			//{
			//	Altura = 1,
			//	Base = 1,
			//	Cantidad = 1,
			//	Rendimiento = 1,
			//	Empresa = new Empresa { EmpresaConfig = new EmpresaConfig() },
			//	Material = new Material { Base = 1, Altura = 1 }
			//};
			cotMock = new Mock<Cotizacion>();
			cotMock.Setup(x => x.Altura).Returns(1);
			cotMock.Setup(x => x.Base).Returns(1);
			cotMock.Setup(x => x.Cantidad).Returns(1);
			cotMock.Setup(x => x.Material).Returns(new Material { Base = 1, Altura = 1 });
			cotMock.Setup(x => x.Empresa).Returns(new Empresa { EmpresaConfig = new EmpresaConfig() });

			cot = cotMock.Object;
			estimator = new Estimator(cot);
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void Validate_NullCot_ExceptionThrown()
		{
			cot = null;
			var dummy = new Estimator(cot);
		}

		[TestMethod, ExpectedException(typeof(ArgumentException))]
		public void Validate_NullMaterial_ExceptionThrown()
		{
			cotMock.Setup(x => x.Material).Returns((Material)null);
			var dummy = new Estimator(cot);
		}

		[TestMethod]
		public void Estimate_EstimateAll_AllMethodsCalled()
		{
			//	Use mocks to check calls to all methods
		}
		
		[TestMethod]
		public void CalcularRendimientos_SinDesperdicio_RendimientoExacto()
		{
			cotMock.Setup(x => x.Altura).Returns(1);
			cotMock.Setup(x => x.Base).Returns(2);
			cot.Material.Base = 10;
			cot.Material.Altura = 20;

			estimator.CalcularRendimientos();

			Assert.AreEqual(100, cot.Rendimiento);
		}

		[TestMethod]
		public void CalcularRendimientos_ConDesperdicio_RendimientoRedondeado()
		{
			cotMock.Setup(x => x.Altura).Returns(1);
			cotMock.Setup(x => x.Base).Returns(3);
			cot.Material.Base = 10;
			cot.Material.Altura = 20;

			estimator.CalcularRendimientos();

			Assert.AreEqual(60, cot.Rendimiento);
		}

		[TestMethod]
		public void CalcularRendimientos_SinDesperdicio_LargoYAnchoExacto()
		{
			cotMock.Setup(x => x.Base).Returns(1);
			cotMock.Setup(x => x.Altura).Returns(2);
			cotMock.Setup(x => x.Cantidad).Returns(100);
			cot.Material.Base = 10;
			cot.Material.Altura = 20;

			estimator.CalcularRendimientos();

			Assert.AreEqual(10, cot.DivLargo);
			Assert.AreEqual(10, cot.DivAncho);
			AssertEqualDecimal(1, cot.Laminas);
		}

		[TestMethod]
		public void CalcularRendimientos_ConDesperdicio_LargoYAnchoRedondeado()
		{
			cotMock.Setup(x => x.Base).Returns(1);
			cotMock.Setup(x => x.Altura).Returns(3);
			cotMock.Setup(x => x.Cantidad).Returns(100);
			cot.Material.Base = 10;
			cot.Material.Altura = 20;

			estimator.CalcularRendimientos();

			AssertEqualDecimal(6.66m, cot.DivLargo);
			AssertEqualDecimal(10, cot.DivAncho);
			AssertEqualDecimal(1.66m, cot.Laminas);
		}

		[TestMethod]
		public void CalcularRendimientos_OrientacionInvertida_LargoYAnchoRedondeado()
		{
			cotMock.Setup(x => x.Base).Returns(3);
			cotMock.Setup(x => x.Altura).Returns(5);
			cotMock.Setup(x => x.Cantidad).Returns(100);
			cot.Material.Base = 10;
			cot.Material.Altura = 30;
			
			estimator.CalcularRendimientos();

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
