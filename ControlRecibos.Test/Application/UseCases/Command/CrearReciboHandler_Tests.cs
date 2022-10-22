using ControlRecibos.Application.Services;
using ControlRecibos.Application.UseCases.Command.Recibos;
using ControlRecibos.Domain.Event;
using ControlRecibos.Domain.Factories;
using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using ShareKernelRecibos.Core;
using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading;
//using System.Threading.Tasks;
using Xunit;


namespace ControlRecibos.Test.Application.UseCases.Command {
	public class CrearReciboHandler_Tests {
		private readonly Mock<IReciboRepository> reciboRepository;
		private readonly Mock<ILogger<CrearReciboHandler>> logger;
		private readonly Mock<IReciboFactory> reciboFactory;
		private readonly Mock<IReciboService> reciboService;
		private readonly Mock<IUnitOfWork> unitOfWork;
		// !!!faltaria reciboService
		private int nroRecibo = 123;
		private DateTime fechaPago = new DateTime(2022,06,04);
		private string nombrePasajero = "Juan Perez";
		private Guid codigoReserva = Guid.NewGuid();
		private string concepto = "Adelanto por pasaje Santa Cruz - Tarija";
		private decimal montoTotal = new decimal(770.0);
		private decimal aCuenta = new decimal(300.0);
		private decimal saldo = new decimal(470.0);
		private int estado = 3; // Reserva pendiente 
		private Recibo reciboTest;


		public CrearReciboHandler_Tests() {
			reciboRepository = new Mock<IReciboRepository>();
			logger = new Mock<ILogger<CrearReciboHandler>>();
			reciboFactory = new Mock<IReciboFactory>();
			reciboService = new Mock<IReciboService>();
			unitOfWork = new Mock<IUnitOfWork>();
			reciboTest = new ReciboFactory().CrearRecibo(nroRecibo,fechaPago,nombrePasajero,
					codigoReserva,concepto,montoTotal,aCuenta,saldo,estado);
		}


		[Fact]
		public void CrearReciboHandler_HandleCorrectly() {
			reciboFactory.Setup(factory => factory.CrearRecibo(nroRecibo,fechaPago,nombrePasajero,
					codigoReserva,concepto,montoTotal,aCuenta,saldo,estado))
					.Returns(reciboTest);
			var objHandler = new CrearReciboHandler(reciboRepository.Object,logger.Object,
											reciboService.Object,reciboFactory.Object,
											unitOfWork.Object);
			var objRequest = new CrearReciboCommand(nroRecibo,fechaPago,nombrePasajero,
					codigoReserva,concepto,montoTotal,aCuenta,saldo,estado);
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest,tcs.Token);
			Assert.IsType<Guid>(result.Result);
			var domainEventList = (List<DomainEvent>)reciboTest.DomainEvents;
			Assert.Single(domainEventList); //!!! aqui no cumple el test
			Assert.IsType<ReciboCreado>(domainEventList[0]);
		}


		[Fact]
		public void CrearReciboHandler_Handle_Fail() {
			// Failing by returning null values
			var objHandler = new CrearReciboHandler(reciboRepository.Object,logger.Object,
											reciboService.Object,reciboFactory.Object,
											unitOfWork.Object);
			var objRequest = new CrearReciboCommand(nroRecibo,fechaPago,nombrePasajero,
					codigoReserva,concepto,montoTotal,aCuenta,saldo,estado);
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest,tcs.Token);
			logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object,@type) => @object.ToString() == "Error al crear Recibo"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType,Exception,string>>())
			,Times.Once);
		}
	}
}
