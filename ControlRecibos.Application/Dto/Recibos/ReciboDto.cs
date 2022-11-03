using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace ControlRecibos.Application.Dto.Recibos
{
	public class ReciboDto
	{
		public Guid Id { get; set; }
		public int NroRecibo { get; set; }
		public DateTime FechaPago { get; set; } = DateTime.Now;
		public string NombrePasajero { get; set; }
		public Guid CodigoReserva { get; set; }
		public string Concepto { get; set; }
		public decimal MontoTotal { get; set; }
		public decimal ACuenta { get; set; }
		public decimal Saldo { get; set; }
		public int Estado { get; set; }
		public string ACuentaLiteral { get; set; }


		public ReciboDto()
		{
		}
	}
}
