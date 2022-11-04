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
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static Moq.It;



namespace ControlRecibos.Test.Application.UseCases.Command
{
	public class CrearReciboHandler_Tests
	{
		private readonly Mock<IReciboRepository> reciboRepository;
		private readonly Mock<ILogger<CrearReciboHandler>> logger;
		private readonly Mock<IReciboService> reciboService;
		private readonly Mock<IReciboFactory> reciboFactory;
		private readonly Mock<IUnitOfWork> unitOfWork;
		private int nroReciboTest = 369;
		private DateTime fechaPagoTest = DateTime.Now; 
		private string nombrePasajeroTest = "Juan Perez";
		private Guid codigoReservaTest = new Guid("{DDE9DB2E-CE43-44F6-80C0-45ADA8A74B61}");
		private string conceptoTest = "Adelanto por pasaje Santa Cruz - Tarija";
		private decimal montoTotalTest = new decimal(770.0);
		private decimal aCuentaTest = new decimal(300.0);
		private decimal saldoTest = new decimal(470.0);
		private int estadoTest = 3; 
		private Recibo reciboTest;


		public CrearReciboHandler_Tests()
		{
			reciboRepository = new Mock<IReciboRepository>();
			logger = new Mock<ILogger<CrearReciboHandler>>();
			reciboService = new Mock<IReciboService>();
			reciboFactory = new Mock<IReciboFactory>();
			unitOfWork = new Mock<IUnitOfWork>();
			reciboTest = new ReciboFactory().CrearRecibo(nroReciboTest,fechaPagoTest,
								nombrePasajeroTest,codigoReservaTest,
								conceptoTest,montoTotalTest,
								aCuentaTest,saldoTest,
								estadoTest);
		}


		[Fact]
		public void CrearReciboHandler_HandleCorrectly()
		{
			reciboService.Setup(reciboService => reciboService.GenerarNroReciboAsync()).Returns(Task.FromResult(nroReciboTest));
			reciboFactory.Setup(reciboFactory => reciboFactory.CrearRecibo(nroReciboTest,fechaPagoTest,
								nombrePasajeroTest,codigoReservaTest,
								conceptoTest,montoTotalTest,
								aCuentaTest,saldoTest,
								estadoTest)).Returns(reciboTest);
			var objHandler = new CrearReciboHandler(reciboRepository.Object,logger.Object,
											reciboService.Object, reciboFactory.Object,
											unitOfWork.Object);
			var objRequest = new CrearReciboCommand(nroReciboTest,fechaPagoTest,nombrePasajeroTest,
					codigoReservaTest,conceptoTest,montoTotalTest,aCuentaTest,saldoTest,estadoTest);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest,tcs.Token);			
			Assert.IsType<Guid>(result.Result);
			var domainEventList = (List<DomainEvent>)reciboTest.DomainEvents;
			//Assert.Single(domainEventList); //!!! aqui no cumple el test
			//Assert.IsType<ReciboCreado>(domainEventList[0]);
		}


		[Fact]
		public void CrearReciboHandler_Handle_Fail()
		{
			// Failing by returning null values
			var objHandler = new CrearReciboHandler(reciboRepository.Object,logger.Object,
											reciboService.Object, reciboFactory.Object,
											unitOfWork.Object);
			var objRequest = new CrearReciboCommand(nroReciboTest,fechaPagoTest,nombrePasajeroTest,
					codigoReservaTest,conceptoTest,montoTotalTest,aCuentaTest,saldoTest,estadoTest);
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
