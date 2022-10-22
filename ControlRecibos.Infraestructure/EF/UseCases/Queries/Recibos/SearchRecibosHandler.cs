using ControlRecibos.Application.Dto.Recibos;
using ControlRecibos.Application.UseCases.Queries.Recibos.SearchRecibos;
using ControlRecibos.Infraestructure.EF.Contexts;
using ControlRecibos.Infraestructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ControlRecibos.Infraestructure.EF.UseCases.Queries.Recibos {
	public class SearchRecibosHandler :
			 IRequestHandler<SearchRecibosQuery,ICollection<ReciboDto>> {
		private readonly DbSet<ReciboReadModel> _recibos;

		public SearchRecibosHandler(ReadDbContext context) {
			_recibos = context.Recibo;
		}


		public async Task<ICollection<ReciboDto>> Handle(SearchRecibosQuery request,CancellationToken cancellationToken) {
			var reciboList = await _recibos
							.AsNoTracking()
							//.Where(x => x.NroRecibo == request.NroRecibo)
							//.Where(x => x.NroRecibo == request.id)
							.ToListAsync();

			//!!! CORREGIR esto xq no es una coleccion ni tiene detalle
			var result = new List<ReciboDto>();
			foreach (var objRecibo in reciboList) {
				var reciboDto = new ReciboDto() {
					Id = objRecibo.Id,
					NroRecibo = objRecibo.NroRecibo,
					FechaPago = objRecibo.FechaPago,
					NombrePasajero = objRecibo.NombrePasajero,
					CodigoReserva = objRecibo.CodigoReserva,
					Concepto = objRecibo.Concepto,
					MontoTotal = objRecibo.MontoTotal,
					ACuenta = objRecibo.ACuenta,
					Saldo = objRecibo.Saldo,
					Estado = objRecibo.Estado
				};
				result.Add(reciboDto);
			}
			return result;
		}
	}
}
