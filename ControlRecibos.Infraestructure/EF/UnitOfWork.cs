using ControlRecibos.Domain.Repositories;
using ControlRecibos.Infraestructure.EF.Contexts;
using MediatR;
using ShareKernelRecibos.Core;
using System;
//using System.Collections.Generic;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;


namespace ControlRecibos.Infraestructure.EF {
	public class UnitOfWork : IUnitOfWork {
		private readonly WriteDbContext _context;
		private readonly IMediator _mediator;

		public UnitOfWork(WriteDbContext context,IMediator mediator) {
			_context = context;
			_mediator = mediator;
		}


		public async Task Commit() {
			//Publica los eventos de dominio
			var domainEvents = _context.ChangeTracker.Entries<Entity<Guid>>() // estan todos los objetos Entity que cambiaron en la transacción
				.Select(x => x.Entity.DomainEvents) // de cada entity selecciona su domainevents
				.SelectMany(x => x)
				.ToArray();

			foreach (var @event in domainEvents) {
				await _mediator.Publish(@event);    // publica los eventos
			}

			await _context.SaveChangesAsync();
		}
	}
}
