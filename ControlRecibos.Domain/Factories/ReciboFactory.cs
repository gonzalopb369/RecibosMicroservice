using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.Utils;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


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

				
		public Recibo EliminarRecibo(Recibo oRecibo)
		{ //!!! AQUI ELIMINAR RECIBO???			
			return oRecibo;
		}
	}
}
