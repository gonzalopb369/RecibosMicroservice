using ControlRecibos.Application.UseCases.Command.Recibos;
using ControlRecibos.Application.UseCases.Queries.Recibos.GetReciboById;
using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;


namespace ControlRecibos.Test.Application.UseCases.Queries.GetReciboById
{
	public class GetReciboByIdHandler_Test
	{
		private readonly Mock<IReciboRepository> reciboRepository;
		private readonly Mock<ILogger<GetReciboByIdQuery>> logger;
		//private Guid idRecibo; NO debe haber!!!
		private int nroRecibo;
		private DateTime fechaPago = new DateTime(2022,06,04);
		private string nombrePasajero = "Juan Perez";
		private string codigoReserva = "123XYZ";
		private string concepto = "Adelanto por pasaje Santa Cruz - Tarija";
		private decimal montoTotal = new decimal(770.0);
		private decimal aCuenta = new decimal(300.0);
		private decimal saldo = new decimal(470.0);
		private int estado = 3; // Reserva pendiente 
		private Recibo reciboTest;


		public GetReciboByIdHandler_Test()
		{
			reciboRepository = new Mock<IReciboRepository>();
			logger = new Mock<ILogger<GetReciboByIdQuery>>();
		}


		[Fact]
		public void GetReciboByIdHandler_HandleCorrectly()
		{           //!!! Concluir

			//reciboRepository.Setup(repository => repository.FindByIdAsync(idRecibo).Result(                
			//    nroRecibo, fechaPago, nombrePasajero,
			//        codigoReserva, concepto, montoTotal, aCuenta, saldo, estado))
			//        .Returns(reciboTest);


			//reciboFactory.Setup(factory => factory.CrearRecibo(nroRecibo, fechaPago, nombrePasajero,
			//        codigoReserva, concepto, montoTotal, aCuenta, saldo, estado))
			//        .Returns(reciboTest);
			//var objHandler = new CrearReciboHandler(reciboRepository.Object, logger.Object,
			//                                reciboService.Object, reciboFactory.Object,
			//                                unitOfWork.Object);
			//var objRequest = new CrearReciboCommand(nroRecibo, fechaPago, nombrePasajero,
			//        codigoReserva, concepto, montoTotal, aCuenta, saldo, estado);
			//var tcs = new CancellationTokenSource(1000);
			//var result = objHandler.Handle(objRequest, tcs.Token);
			//Assert.IsType<Guid>(result.Result);
			//var domainEventList = (List<DomainEvent>)reciboTest.DomainEvents;
			//Assert.Single(domainEventList); //!!! aqui no cumple el test
			//Assert.IsType<ReciboCreado>(domainEventList[0]);
		}

	}
}
