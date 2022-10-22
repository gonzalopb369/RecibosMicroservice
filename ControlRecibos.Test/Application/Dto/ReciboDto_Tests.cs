using ControlRecibos.Application.Dto.Recibos;
using System;
using Xunit;


namespace ControlRecibos.Test.Application.Dto
{
	public class ReciboDto_Tests
	{
		[Fact]
		public void ReciboDto_CheckPropertiesValid()
		{
			var idTest = Guid.NewGuid();
			var nroRecibo = 11;
			var fechaPago = new DateTime(2022,01,01);
			var nombrePasajero = "Juan Perez";
			var codigoReserva = Guid.NewGuid();
			var concepto = "Adelanto pasajes";
			decimal montoTotal = new(1000.0);
			decimal aCuenta = new(400.0);
			decimal saldo = new(600.0);
			int estado = 3;

			var objRecibo = new ReciboDto();

			// se testean valores iniciales
			Assert.Equal(Guid.Empty,objRecibo.Id);
			Assert.Equal(0,objRecibo.NroRecibo);
			Assert.Null(objRecibo.NombrePasajero);
			Assert.Null(objRecibo.CodigoReserva);
			Assert.Null(objRecibo.Concepto);
			Assert.Equal(new decimal(0.0),objRecibo.MontoTotal);
			Assert.Equal(new decimal(0.0),objRecibo.ACuenta);
			Assert.Equal(new decimal(0.0),objRecibo.Saldo);
			Assert.Equal(0,objRecibo.Estado);

			objRecibo.Id = idTest;
			objRecibo.NroRecibo = nroRecibo;
			objRecibo.NombrePasajero = nombrePasajero;
			objRecibo.CodigoReserva = codigoReserva;
			objRecibo.Concepto = concepto;
			objRecibo.MontoTotal = montoTotal;
			objRecibo.ACuenta = aCuenta;
			objRecibo.Saldo = saldo;
			objRecibo.Estado = estado;

			Assert.Equal(idTest,objRecibo.Id);
			Assert.Equal(nroRecibo,objRecibo.NroRecibo);
			Assert.Equal(nombrePasajero,objRecibo.NombrePasajero);
			Assert.Equal(codigoReserva,objRecibo.CodigoReserva);
			Assert.Equal(concepto,objRecibo.Concepto);
			Assert.Equal(montoTotal,objRecibo.MontoTotal);
			Assert.Equal(aCuenta,objRecibo.ACuenta);
			Assert.Equal(saldo,objRecibo.Saldo);
			Assert.Equal(estado,objRecibo.Estado);
		}

		//var detallePedidoTest = MockFactory.GetDetallePedido();

	}
}
