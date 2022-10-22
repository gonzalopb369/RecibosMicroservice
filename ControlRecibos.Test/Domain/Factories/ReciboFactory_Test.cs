using ControlRecibos.Domain.Factories;
using System;
using Xunit;


namespace ControlRecibos.Test.Domain.Factories
{
	public class ReciboFactory_Test
	{
		[Fact]
		public void CrearRecibo_Correctly()
		{
			int nroRecibo = 123;
			DateTime fechaPago = new DateTime(2022,06,04);
			string nombrePasajero = "Juan Perez";
			Guid codigoReserva = Guid.NewGuid();
			string concepto = "Adelanto por pasaje Santa Cruz - Tarija";
			decimal montoTotal = new decimal(770.0);
			decimal aCuenta = new decimal(300.0);
			decimal saldo = new decimal(470.0);
			int estado = 3; // Reserva pendiente 

			var factory = new ReciboFactory();
			var recibo = factory.CrearRecibo(nroRecibo,fechaPago,nombrePasajero,
					codigoReserva,concepto,montoTotal,aCuenta,saldo,estado);

			Assert.NotNull(recibo);
			Assert.Equal(nroRecibo,(int)recibo.NroRecibo);
			Assert.Equal(fechaPago,recibo.FechaPago);
			Assert.Equal(nombrePasajero,recibo.NombrePasajero);
			Assert.Equal(codigoReserva,recibo.CodigoReserva);
			Assert.Equal(concepto,recibo.Concepto);
			Assert.Equal(montoTotal,(decimal)recibo.MontoTotal);
			Assert.Equal(aCuenta,(decimal)recibo.ACuenta);
			Assert.Equal(saldo,(decimal)recibo.Saldo);
			Assert.Equal(estado,recibo.Estado);

		}
	}
}
