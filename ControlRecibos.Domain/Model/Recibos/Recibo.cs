using ControlRecibos.Domain.Event;
using ControlRecibos.Domain.Utils;
using ControlRecibos.Domain.ValueObjects;
using ShareKernelRecibos.Core;
using ShareKernelRecibos.ValueObjects;
using System;


namespace ControlRecibos.Domain.Model.Recibos
{
	public class Recibo : AggregateRoot<Guid>
	{
		public NroDocumentoValue NroRecibo { get; private set; }
		public DateTime FechaPago { get; private set; }
		public PersonNameValue NombrePasajero { get; private set; }
		public Guid CodigoReserva { get; private set; }
		public string Concepto { get; private set; }
		public PrecioValue MontoTotal { get; private set; }
		public PrecioValue ACuenta { get; private set; }
		public PrecioValue Saldo { get; private set; }
		public int Estado { get; private set; }


		private Recibo()
		{
			MontoTotal = 0;
			ACuenta = 0;
			Saldo = 0;
		}


		public Recibo(int nroRecibo)   
		{
			//Id = Guid.NewGuid(); rehabilitar?
			FechaPago = DateTime.Now;
			NroRecibo = nroRecibo;
			MontoTotal = 0;
			ACuenta = 0;
			Saldo = 0;
			Estado = (int)EstadoRecibo.ReservaPendiente;			
		}


		public Recibo(NroDocumentoValue nroRecibo,DateTime fechaPago,
						PersonNameValue nombrePasajero,Guid codigoReserva,
						string concepto,PrecioValue montoTotal,PrecioValue aCuenta,
						PrecioValue saldo,int estado)
		{
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


		public void CrearRecibo(Guid id, NroDocumentoValue nroRecibo,DateTime fechaPago,
						PersonNameValue nombrePasajero,Guid codigoReserva,
						string concepto,PrecioValue montoTotal,PrecioValue aCuenta,
						PrecioValue saldo,int estado)
		{
			Id = id;
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



		public void ConsolidarRecibo()
		{
			var evento = new ReciboCreado(Id,NroRecibo,FechaPago,NombrePasajero,
									CodigoReserva,Concepto,MontoTotal,ACuenta,Saldo,Estado);
			AddDomainEvent(evento);
		}
	}
}
