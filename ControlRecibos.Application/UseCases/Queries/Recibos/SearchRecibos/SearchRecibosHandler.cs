
using ControlRecibos.Application.Dto.Recibos;
using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
//using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace ControlRecibos.Application.UseCases.Queries.Recibos.SearchRecibos
{
	public class SearchRecibosHandler : IRequestHandler<SearchRecibosQuery,List<ReciboDto>>
	{
		private readonly IReciboRepository _reciboRepository;
		private readonly ILogger<SearchRecibosQuery> _logger;


		public SearchRecibosHandler(IReciboRepository reciboRepository,ILogger<SearchRecibosQuery> logger)
		{
			_reciboRepository = reciboRepository;
			_logger = logger;
		}


		public async Task<List<ReciboDto>> Handle(SearchRecibosQuery request,CancellationToken cancellationToken)
		{
			List<ReciboDto> ListaRecibosDto = new List<ReciboDto>();
			List<Recibo> ListaRecibos;
			ListaRecibos = await _reciboRepository.GetAll();
			ReciboDto oReciboDto;
			foreach (var recibo in ListaRecibos)
			{
				oReciboDto = new ReciboDto()
				{
					Id = recibo.Id,
					NroRecibo = recibo.NroRecibo,
					FechaPago = recibo.FechaPago,
					NombrePasajero = recibo.NombrePasajero,
					CodigoReserva = recibo.CodigoReserva,
					Concepto = recibo.Concepto,
					MontoTotal = recibo.MontoTotal,
					ACuenta = recibo.ACuenta,
					Saldo = recibo.Saldo,
					Estado = recibo.Estado
					//ACuentaLiteral = NumeroLiteral.ObtenerNumeroLiteral(recibo.ACuenta,"N2","Bolivianos")
				};
				ListaRecibosDto.Add(oReciboDto);
			}
			return ListaRecibosDto;
		}

	}
}
