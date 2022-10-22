using ControlRecibos.Application.Dto.Recibos;
using MediatR;
using System;


namespace ControlRecibos.Application.UseCases.Queries.Recibos.GetReciboById
{
	public class GetReciboByIdQuery : IRequest<ReciboDto>
	{
		public Guid Id { get; set; }


		public GetReciboByIdQuery()
		{
		}


		public GetReciboByIdQuery(Guid id)
		{
			Id = id;
		}
	}
}
