using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon.SimpleNotificationService;
using ControlRecibos.Application.Dto.Recibos;
using ControlRecibos.Application.Dto.Pagos;
using ControlRecibos.Application.UseCases.Command.Recibos;
using ControlRecibos.Application.UseCases.Queries.Recibos.GetReciboById;
using ControlRecibos.Application.UseCases.Queries.Recibos.SearchRecibos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Text.Json;
//using System.Text.Json.Serialization;
//using ControlRecibos.Domain.Utils;
using Amazon.SimpleNotificationService.Model;
//using Amazon.SQS.Internal;
//using System.Collections.Generic;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using ControlRecibos.Domain.Model.Recibos;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
				JsonNode mensajeNode = JsonNode.Parse(mensaje)!;
				var mensajeSerializer = System.Text.Json.JsonSerializer.Serialize(mensajeNode["Message"]);
				dynamic mensajeObj = JsonConvert.DeserializeObject(mensajeSerializer);
				JObject mensajeObj1 = JObject.Parse(mensajeObj);
				var mensajeBody = mensajeObj1["body"];
				var mensajePayment = mensajeBody["payment"];
				var mensajePassanger = mensajeBody["passanger"];
				var mensajeBooking = mensajeBody["booking"];
				string vNombPasajero = (string)mensajePassanger["name"] + (string)mensajePassanger["lastName"];
				Guid vid = (Guid)mensajePayment["id"];				
				var mensajeAmount = mensajePayment["amount"];
				int vAmount = (Int32)mensajeAmount["data"];				
				Guid vbooking = (Guid)mensajePayment["booking"];
				DateTime vdate = (DateTime)mensajeBooking["date"];
				var mensajeResNumber = mensajeBooking["reservationNumber"];
				string vreservationNumber = (string)mensajeResNumber["data"];
				var mensajeAccountReceivable = mensajeBooking["accountReceivable"];
				var mensajeOriginalValue = mensajeAccountReceivable["originalValue"];
				int vOriginalValue = (Int32)mensajeOriginalValue["data"];				
				var mensajeCurrentValue = mensajeAccountReceivable["currentValue"];
				int vcurrentValue = (Int32)mensajeCurrentValue["data"];

				OPago = new PagoDto()
				{
					Id = vid,//id pago					
					NombPasajero = vNombPasajero,
					ReservationNumber = vreservationNumber,
					originalValue = vOriginalValue,
					currentValue = vcurrentValue,
					Amount = vAmount,
					Booking = vbooking,
					Date = vdate
				};				
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
