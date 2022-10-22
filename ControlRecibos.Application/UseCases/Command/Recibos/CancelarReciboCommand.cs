using ControlRecibos.Domain.Utils;
using MediatR;
using System;


namespace ControlRecibos.Application.UseCases.Command.Recibos
{
	public class CancelarReciboCommand : IRequest<Guid>
	{
		public int NroRecibo { get; set; }
		public DateTime FechaPago { get; set; }
		public string NombrePasajero { get; set; }
		public string CodigoReserva { get; set; }
		public string Concepto { get; set; }
		public decimal MontoTotal { get; set; }
		public decimal ACuenta { get; set; }
		public decimal Saldo { get; set; }
		public int Estado { get; set; }


		private CancelarReciboCommand()
		{
		}


		//public CancelarReciboCommand(int nroRecibo, DateTime fechaPago, string nombrePasajero,
		//            string codigoReserva, string concepto, decimal montoTotal,
		//            decimal aCuenta, decimal saldo, int estado)
		public CancelarReciboCommand(Guid idRecibo)
		{
			//NroRecibo = nroRecibo;
			//FechaPago = fechaPago;
			//NombrePasajero = nombrePasajero;
			//CodigoReserva = codigoReserva;
			//Concepto = concepto;
			//MontoTotal = montoTotal;
			//ACuenta = aCuenta;
			//Saldo = saldo;
			Estado = (int)EstadoRecibo.ReservaCancelada;
		}
	}
}
