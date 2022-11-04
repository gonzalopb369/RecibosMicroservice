using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
//using Amazon.SimpleNotificationService;
using ControlRecibos.Application.Dto.Recibos;
using ControlRecibos.Application.Dto.Pagos;
using ControlRecibos.Application.UseCases.Command.Recibos;
using ControlRecibos.Application.UseCases.Queries.Recibos.GetReciboById;
using ControlRecibos.Application.UseCases.Queries.Recibos.SearchRecibos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
//using System.Text.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ControlRecibos.WebApi.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class ControlReciboController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ControlReciboController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CrearReciboCommand command)
		{
			Guid id = await _mediator.Send(command);
			if (id == Guid.Empty)
				return BadRequest();
			return Ok(id);
		}



		[Route("{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> GetReciboById([FromRoute] GetReciboByIdQuery command)
		{
			ReciboDto result = await _mediator.Send(command);
			if (result == null)
				return NotFound();
			return Ok(result);
		}



		[Route("{id:guid}")]
		[HttpDelete]
		public async Task<IActionResult> DeleteReciboById([FromRoute] EliminarReciboCommand command)
		{
			Guid vId = await _mediator.Send(command);
			if (vId == Guid.Empty)
				return NotFound();
			return Ok(vId);
		}



		[HttpGet]
		[Route("search")]
		public async Task<IActionResult> GetAll()
		{
			SearchRecibosQuery query = new SearchRecibosQuery();
			var recibos = await _mediator.Send(query);
			if (recibos == null)
				return BadRequest();
			return Ok(recibos);
		}




		[HttpGet]
		[Route("leerpagos")]
		public async Task<PagoDto> LeerPagos()
		{
			var credentials = new BasicAWSCredentials("AKIASZCTJFEF7436GE73","bGrwxvC3c0qrSpvvjmxSt1dAKj9lUDtRgbLAh4VU");
			var client = new AmazonSQSClient(credentials,RegionEndpoint.USEast1);
			var msg = await GetMessage(client,"https://sqs.us-east-1.amazonaws.com/191300708619/recibos_queue",0);
			PagoDto OPago;
			if (msg.Messages.Count != 0)
			{
				var mensaje = msg.Messages[0].Body;
				OPago = JsonConvert.DeserializeObject<PagoDto>(mensaje);
				return OPago;
			}
			else
				OPago = new PagoDto();
			return OPago;
		}




		private static async Task<ReceiveMessageResponse> GetMessage(IAmazonSQS sqsClient,string qUrl,int waitTime = 0)
		{
			return await sqsClient.ReceiveMessageAsync(new ReceiveMessageRequest
			{
				QueueUrl = qUrl,
				MaxNumberOfMessages = 10,
				WaitTimeSeconds = waitTime
			});
		}


		private static async Task DeleteMessage(IAmazonSQS sqsClient,Message message,string qUrl)
		{
			Console.WriteLine($"\nDeleting message {message.MessageId} from queue...");
			await sqsClient.DeleteMessageAsync(qUrl,message.ReceiptHandle);
		}

	}
}
