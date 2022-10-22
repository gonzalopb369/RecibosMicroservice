using ControlRecibos.Domain.ValueObjects;
using ShareKernelRecibos.Core;
using ShareKernelRecibos.ValueObjects;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace ControlRecibos.Domain.Event
{
	public record ReciboCreado : DomainEvent
	{
		public Guid IdRecibo { get; } // Como es inmutable no va tener "set"
		public NroDocumentoValue NroRecibo { get; }
		public DateTime FechaPago { get; }
		public PersonNameValue NombrePasajero { get; }
		public Guid CodigoReserva { get; private set; }
		public string Concepto { get; private set; }
		public PrecioValue MontoTotal { get; private set; }
		public PrecioValue ACuenta { get; private set; }
		public PrecioValue Saldo { get; private set; }
		public int Estado { get; private set; }


		public ReciboCreado(Guid idRecibo,NroDocumentoValue nroRecibo,DateTime fechaPago,
					 PersonNameValue nombrePasajero,Guid codigoReserva,string concepto,
					 PrecioValue montoTotal,PrecioValue aCuenta,PrecioValue saldo,
					 int estado) : base(DateTime.Now)
		{
			IdRecibo = idRecibo;
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
