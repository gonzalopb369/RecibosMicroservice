using ControlRecibos.Application.Dto.Recibos;
using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.Repositories;
using ControlRecibos.Domain.Utils;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace ControlRecibos.Application.UseCases.Queries.Recibos.GetReciboById
{
	public class GetReciboByIdHandler : IRequestHandler<GetReciboByIdQuery,ReciboDto>
	{
		private readonly IReciboRepository _reciboRepository;
		private readonly ILogger<GetReciboByIdQuery> _logger;

		public GetReciboByIdHandler(IReciboRepository reciboRepository,ILogger<GetReciboByIdQuery> logger)
		{
			_reciboRepository = reciboRepository;
			_logger = logger;
		}


		public async Task<ReciboDto> Handle(GetReciboByIdQuery request,CancellationToken cancellationToken)
		{
			ReciboDto result = null;
			try
			{
				Recibo objRecibo = await _reciboRepository.FindByIdAsync(request.Id);
				result = new ReciboDto()
				{
					Id = objRecibo.Id,
					NroRecibo = objRecibo.NroRecibo,
					FechaPago = objRecibo.FechaPago,
					NombrePasajero = objRecibo.NombrePasajero,
					CodigoReserva = objRecibo.CodigoReserva,
					Concepto = objRecibo.Concepto,
					MontoTotal = objRecibo.MontoTotal,
					ACuenta = objRecibo.ACuenta,
					Saldo = objRecibo.Saldo,
					Estado = objRecibo.Estado,
					ACuentaLiteral = NumeroLiteral.ObtenerNumeroLiteral(objRecibo.ACuenta,"N2","Bolivianos")
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex,"Error al obtener Recibo con id: { IdRecibo }",request.Id);
			}
			return result;
		}
	}
}
