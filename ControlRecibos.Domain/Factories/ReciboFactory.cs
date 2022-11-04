using ControlRecibos.Domain.Model.Recibos;
using System;


namespace ControlRecibos.Domain.Factories
{
	public class ReciboFactory : IReciboFactory
	{

		public Recibo CrearRecibo(int nroRecibo,DateTime fechaPago,string nombrePasajero,
				Guid codigoReserva,string concepto,decimal montoPagado,
				decimal aCuenta,decimal saldo,int estado)
		{
			return new Recibo(nroRecibo,fechaPago,nombrePasajero,codigoReserva,
					concepto,montoPagado,aCuenta,saldo,estado);
		}		
	}
}
