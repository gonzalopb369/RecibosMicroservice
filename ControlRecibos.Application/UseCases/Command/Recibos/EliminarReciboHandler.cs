using ControlRecibos.Application.Services;
using ControlRecibos.Domain.Factories;
using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ControlRecibos.Application.UseCases.Command.Recibos
{
	public class EliminarReciboHandler : IRequestHandler<EliminarReciboCommand,Guid>
	{
		private readonly IReciboRepository _reciboRepository;
		private readonly ILogger<EliminarReciboHandler> _logger;
		private readonly IReciboService _reciboService; // No hay este
		private readonly IReciboFactory _reciboFactory;
		private readonly IUnitOfWork _unitOfWork;


		public EliminarReciboHandler(IReciboRepository reciboRepository,ILogger<EliminarReciboHandler> logger,
			IReciboService reciboService,IReciboFactory reciboFactory,IUnitOfWork unitOfWork)
		{
			_reciboRepository = reciboRepository;
			_logger = logger;
			_reciboService = reciboService;
			_reciboFactory = reciboFactory;
			_unitOfWork = unitOfWork;
		}



		public async Task<Guid> Handle(EliminarReciboCommand request,CancellationToken cancellationToken)
		{
			try
			{				
				//bool exito = _reciboFactory.EliminarRecibo(request.Id);
				Recibo objRecibo = _reciboFactory.EliminarRecibo(request.ORecibo);
				//Recibo objRecibo = _reciboFactory.CrearRecibo(nroRecibo, //nroRecibo !!! Tiene que generar nro. recibo!,
				//	request.FechaPago,request.NombrePasajero,request.CodigoReserva,
				//	request.Concepto,request.MontoTotal,request.ACuenta,request.Saldo,
				//	request.Estado);
				//objRecibo.ConsolidarRecibo(); !!!!!

				if (objRecibo != null)
				{
					await _reciboRepository.RemoveAsync(objRecibo);
					await _unitOfWork.Commit();
					return objRecibo.Id;
				}
				
			}
			catch (Exception ex)
			{
				_logger.LogError(ex,"Error al ELIMINAR Recibo");
			}
			return Guid.Empty;
		}
	}
}
