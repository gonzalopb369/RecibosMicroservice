using ControlRecibos.Application.Services;
using ControlRecibos.Domain.Factories;
using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace ControlRecibos.Application.UseCases.Command.Recibos {
	public class CrearReciboHandler : IRequestHandler<CrearReciboCommand,Guid> {
		private readonly IReciboRepository _reciboRepository;
		private readonly ILogger<CrearReciboHandler> _logger;
		private readonly IReciboService _reciboService; // No hay este
		private readonly IReciboFactory _reciboFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CrearReciboHandler(IReciboRepository reciboRepository,ILogger<CrearReciboHandler> logger,
			IReciboService reciboService,IReciboFactory reciboFactory,IUnitOfWork unitOfWork) {
			_reciboRepository = reciboRepository;
			_logger = logger;
			_reciboService = reciboService;
			_reciboFactory = reciboFactory;
			_unitOfWork = unitOfWork;
		}


		public async Task<Guid> Handle(CrearReciboCommand request,CancellationToken cancellationToken) {
			try {
				int nroRecibo = await _reciboService.GenerarNroReciboAsync();
				//Recibo objRecibo = _reciboFactory.Create(nroRecibo); Este era el original
				Recibo objRecibo = _reciboFactory.CrearRecibo(nroRecibo, //nroRecibo !!! Tiene que generar nro. recibo!,
					request.FechaPago,request.NombrePasajero,request.CodigoReserva,
					request.Concepto,request.MontoTotal,request.ACuenta,request.Saldo,
					request.Estado);
				objRecibo.ConsolidarRecibo();
				await _reciboRepository.CreateAsync(objRecibo);
				await _unitOfWork.Commit();
				return objRecibo.Id;
			}
			catch (Exception ex) {
				_logger.LogError(ex,"Error al crear Recibo");
			}
			return Guid.Empty;
		}
	}
}
