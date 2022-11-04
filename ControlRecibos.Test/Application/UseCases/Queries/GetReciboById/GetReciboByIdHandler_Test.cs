using ControlRecibos.Application.Dto.Recibos;
using ControlRecibos.Application.UseCases.Queries.Recibos.GetReciboById;
using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using System.Threading;
using Xunit;



namespace ControlRecibos.Test.Application.UseCases.Queries.GetReciboById
{
	public class GetReciboByIdHandler_Test
	{
		private readonly Mock<IReciboRepository> reciboRepository;
		private readonly Mock<ILogger<GetReciboByIdQuery>> logger;	


		public GetReciboByIdHandler_Test()
		{
			reciboRepository = new Mock<IReciboRepository>();
			logger = new Mock<ILogger<GetReciboByIdQuery>>();
		}


		[Fact]
		public void GetReciboByIdHandler_HandleCorrectly()
		{
			Guid idReciboTest = Guid.NewGuid();
			var nroReciboTest = 11;

			var objRecibo = new ReciboDto();
			objRecibo.Id = idReciboTest;

			Recibo reciboTest = new Recibo(nroReciboTest);
			var tcs = new CancellationTokenSource(1000);
			reciboRepository.Setup(reciboRepository => reciboRepository.FindByIdAsync(idReciboTest))
				.Returns(Task.FromResult(reciboTest));
			var handler = new GetReciboByIdHandler(reciboRepository.Object,logger.Object);
			var objRequest = new GetReciboByIdQuery(idReciboTest);
			var result = handler.Handle(objRequest,tcs.Token);
			Assert.NotNull(result);
			Assert.Equal(nroReciboTest,(int)reciboTest.NroRecibo);
		}


		[Fact]
		public void GetReciboByIdHandler_Handle_Fail()
		{
			var nroReciboTest = 11;
			Recibo reciboTest = new Recibo(nroReciboTest);
			var idReciboTest = Guid.NewGuid();
			var idReciboTest_Fail = new Guid();

			reciboRepository.Setup(reciboRepository => reciboRepository.FindByIdAsync(idReciboTest))
				.Returns(Task.FromResult(reciboTest));

			var handler = new GetReciboByIdHandler(reciboRepository.Object,logger.Object);
			var objRequest = new GetReciboByIdQuery(idReciboTest_Fail);
			var tcs = new CancellationTokenSource(1000);

			var result = handler.Handle(objRequest,tcs.Token);
			Assert.NotNull(result);			
		}

	}
}
