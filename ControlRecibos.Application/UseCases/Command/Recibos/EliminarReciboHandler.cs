using ControlRecibos.Application.Services;
using ControlRecibos.Domain.Factories;
using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace ControlRecibos.Application.UseCases.Command.Recibos
{
	public class EliminarReciboHandler : IRequestHandler<EliminarReciboCommand,Guid>
	{
		private readonly IReciboRepository _reciboRepository;
		private readonly ILogger<EliminarReciboHandler> _logger;
		//private readonly IReciboService _reciboService; 
		//private readonly IReciboFactory _reciboFactory;
		private readonly IUnitOfWork _unitOfWork;


		public EliminarReciboHandler(IReciboRepository reciboRepository,ILogger<EliminarReciboHandler> logger,
			IUnitOfWork unitOfWork)
		{
			_reciboRepository = reciboRepository;
			_logger = logger;
			//_reciboService = reciboService;
			//_reciboFactory = reciboFactory;
			_unitOfWork = unitOfWork;
		}



		public async Task<Guid> Handle(EliminarReciboCommand request,CancellationToken cancellationToken)
		{
			try
			{
				Recibo objRecibo = await _reciboRepository.FindByIdAsync(request.Id);
				if (objRecibo != null)
				{
					await _reciboRepository.RemoveAsync(objRecibo);
					await _unitOfWork.Commit();
					return objRecibo.Id;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex,$"Error al ELIMINAR Recibo con id: {request.Id}");
			}
			return Guid.Empty;
		}
	}
}
