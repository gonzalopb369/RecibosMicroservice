using ControlRecibos.Application.Dto.Recibos;
using MediatR;
using System;
using System.Collections.Generic;


namespace ControlRecibos.Application.UseCases.Queries.Recibos.SearchRecibos
{
	public class SearchRecibosQuery : IRequest<List<ReciboDto>>
	{
		//public int NroRecibo { get; set; }
		public Guid id { get; set; }

	}
}
