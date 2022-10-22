using System;


namespace ControlRecibos.Infraestructure.EF.ReadModel {
	public class ReciboReadModel {
		public Guid Id { get; set; }
		public int NroRecibo { get; set; }
		public DateTime FechaPago { get; set; }
		public string NombrePasajero { get; set; }
		public Guid CodigoReserva { get; set; }
		public string Concepto { get; set; }
		public decimal MontoTotal { get; set; }
		public decimal ACuenta { get; set; }
		public decimal Saldo { get; set; }
		public int Estado { get; set; }
	}
}
