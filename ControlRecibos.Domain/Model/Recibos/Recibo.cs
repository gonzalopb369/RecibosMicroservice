using ControlRecibos.Domain.Event;
using ControlRecibos.Domain.Utils;
using ControlRecibos.Domain.ValueObjects;
using ShareKernelRecibos.Core;
using ShareKernelRecibos.ValueObjects;
using System;


namespace ControlRecibos.Domain.Model.Recibos {
	public class Recibo : AggregateRoot<Guid> {
		public NroDocumentoValue NroRecibo { get; private set; }
		public DateTime FechaPago { get; private set; }
		public PersonNameValue NombrePasajero { get; private set; }
		public Guid CodigoReserva { get; private set; }
		public string Concepto { get; private set; }
		public PrecioValue MontoTotal { get; private set; }
		public PrecioValue ACuenta { get; private set; }
		public PrecioValue Saldo { get; private set; }
		public int Estado { get; private set; }


		private Recibo() {
			MontoTotal = 0;
			ACuenta = 0;
			Saldo = 0;
		}


		internal Recibo(int nroRecibo)   // !!! ver. si añadir los demás campos
		{
			Id = Guid.NewGuid();
			NroRecibo = nroRecibo;
			Estado = (int)EstadoRecibo.ReservaPendiente;
			//_detalleAsientos = new List<AsientosAeronave>();
		}


		public Recibo(NroDocumentoValue nroRecibo,DateTime fechaPago,
						PersonNameValue nombrePasajero, Guid codigoReserva,
						string concepto,PrecioValue montoTotal,PrecioValue aCuenta,
						PrecioValue saldo,int estado) {
			Id = Guid.NewGuid();
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


		// Por una reserva que no terminó de pagarla en totalidad se cambia estado a Cancelada
		//public void CancelarRecibo()
		//{
		//    Estado = (int)EstadoRecibo.ReservaCancelada;
		//}


		// COMENTAR!!!
		//public void RestarSaldo(PrecioValue montoPagado)
		//{
		//    PrecioValue montoResultante = Saldo - montoPagado;
		//    if (montoResultante > 0)
		//        Estado = (int)EstadoRecibo.ReservaPendiente;
		//    else
		//        Estado = (int)EstadoRecibo.ReservaPagoTotal;
		//    Saldo = montoResultante;
		//}


		// !!! tendria que generarse solo cuando se pago total o no??
		public void ConsolidarRecibo() {
			var evento = new ReciboCreado(Id,NroRecibo,FechaPago,NombrePasajero,
									CodigoReserva,Concepto,MontoTotal,ACuenta,Saldo,Estado);
			AddDomainEvent(evento);
		}
	}
}
