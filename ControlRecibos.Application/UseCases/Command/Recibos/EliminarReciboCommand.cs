using MediatR;
using System;



namespace ControlRecibos.Application.UseCases.Command.Recibos
{
	public class EliminarReciboCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }


		//public EliminarReciboCommand()
		//{
		//}


		public EliminarReciboCommand(Guid id)
		{
			Id = id;			
		}
	}
}
