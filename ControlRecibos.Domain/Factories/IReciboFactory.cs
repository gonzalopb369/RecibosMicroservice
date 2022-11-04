using ControlRecibos.Domain.Model.Recibos;
using System;



namespace ControlRecibos.Domain.Factories
{	
	public interface IReciboFactory
	{
		Recibo CrearRecibo(int nroRecibo,DateTime fechaPago,string nombrePasajero,
				Guid codigoReserva,string concepto,decimal montoPagado,
				decimal aCuenta,decimal saldo,int estado);		
	}
}
