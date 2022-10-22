using ControlRecibos.Domain.Model.Recibos;
using MediatR;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace ControlRecibos.Application.UseCases.Command.Recibos
{
	public class EliminarReciboCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public Recibo ORecibo { get; set; }


		public EliminarReciboCommand()
		{
		}


		public EliminarReciboCommand(Recibo oRecibo)
		{
			//Id = id;
			ORecibo = oRecibo;
		}
	}
}