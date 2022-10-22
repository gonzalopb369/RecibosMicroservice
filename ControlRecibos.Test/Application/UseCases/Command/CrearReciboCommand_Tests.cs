using ControlRecibos.Application.UseCases.Command.Recibos;
using System;
using Xunit;


namespace ControlRecibos.Test.Application.UseCases.Command
{
	public class CrearReciboCommand_Tests
	{
		public CrearReciboCommand_Tests()
		{
		}

		[Fact]
		public void CrearReciboCommand_DataValid()
		{			
			var nroRecibo = 123;
			var fechaPago = new DateTime(2022,06,04);
			var nombrePasajero = "Juan Perez";
			Guid codigoReserva = Guid.NewGuid();
			var concepto = "Adelanto por pasaje Santa Cruz - Tarija";
			var montoTotal = new decimal(770.0);
			var aCuenta = new decimal(300.0);
			var saldo = new decimal(470.0);
			var estado = 3; // Reserva pendiente 

			var command = new CrearReciboCommand(nroRecibo,fechaPago,nombrePasajero,
					codigoReserva,concepto,montoTotal,aCuenta,saldo,estado);

			Assert.Equal(nroRecibo,command.NroRecibo);
			Assert.Equal(fechaPago,command.FechaPago);
			Assert.Equal(nombrePasajero,command.NombrePasajero);
			Assert.Equal(codigoReserva,command.CodigoReserva);
			Assert.Equal(concepto,command.Concepto);
			Assert.Equal(montoTotal,command.MontoTotal);
			Assert.Equal(aCuenta,command.ACuenta);
			Assert.Equal(saldo,command.Saldo);
			Assert.Equal(estado,command.Estado);
		}


		[Fact]
		public void TestConstructor_IsPrivate()
		{
			var command = (CrearReciboCommand)Activator.CreateInstance(typeof(CrearReciboCommand),true);
			Assert.Equal(0,command.NroRecibo);			
			Assert.Null(command.NombrePasajero);
			//Assert.Null(command.CodigoReserva);
			Assert.Null(command.Concepto);
			Assert.Equal(0,command.MontoTotal);
			Assert.Equal(new decimal(0.0),command.ACuenta);
			Assert.Equal(new decimal(0.0),command.Saldo);
			Assert.Equal(0,command.Estado);
		}
	}
}
