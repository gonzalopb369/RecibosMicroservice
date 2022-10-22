using ControlRecibos.Domain.Model.Recibos;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace ControlRecibos.Domain.Factories
{
	//!!! verificar si va este factory en este caso
	public interface IReciboFactory
	{
		//Recibo Create(int nroRecibo);

		Recibo CrearRecibo(int nroRecibo,DateTime fechaPago,string nombrePasajero,
				Guid codigoReserva,string concepto,decimal montoPagado,
				decimal aCuenta,decimal saldo,int estado);

		Recibo EliminarRecibo(Recibo oRecibo);
	}
}
