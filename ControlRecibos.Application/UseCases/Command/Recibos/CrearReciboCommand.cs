using MediatR;
using System;



namespace ControlRecibos.Application.UseCases.Command.Recibos
{
	public class CrearReciboCommand : IRequest<Guid>
	{
		//public Guid Id { get; set; }
		public int NroRecibo { get; set; }
		public DateTime FechaPago { get; set; }
		public string NombrePasajero { get; set; }
		public Guid CodigoReserva { get; set; }
		public string Concepto { get; set; }
		public decimal MontoTotal { get; set; }
		public decimal ACuenta { get; set; }
		public decimal Saldo { get; set; }
		public int Estado { get; set; }


		private CrearReciboCommand()
		{
		}


		public CrearReciboCommand(int nroRecibo,DateTime fechaPago,string nombrePasajero,
					Guid codigoReserva,string concepto,decimal montoTotal,
					decimal aCuenta,decimal saldo,int estado)
		{
			NroRecibo = nroRecibo;
			FechaPago = fechaPago;
			NombrePasajero = nombrePasajero;
			CodigoReserva = codigoReserva;
			Concepto = concepto;
			MontoTotal = montoTotal;
			ACuenta = aCuenta;
			Saldo = saldo;
			Estado = estado;
		}

	}
}
