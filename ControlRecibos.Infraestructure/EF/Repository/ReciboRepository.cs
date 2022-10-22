using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.Repositories;
using ControlRecibos.Infraestructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ControlRecibos.Infraestructure.EF.Repository {
	public class ReciboRepository : IReciboRepository {
		public readonly DbSet<Recibo> _recibos;

		public ReciboRepository(WriteDbContext context) {
			_recibos = context.Recibo;
		}


		public async Task CreateAsync(Recibo obj) {
			await _recibos.AddAsync(obj);
		}


		public async Task<Recibo> FindByIdAsync(Guid id) {
			return await _recibos.SingleOrDefaultAsync(x => x.Id == id);
		}


		public async Task<List<Recibo>> GetAll()
		{
			return await _recibos.ToListAsync();
		}



		public Task RemoveAsync(Recibo obj) {
			_recibos.Remove(obj);
			return Task.CompletedTask;
		}


		public Task UpdateAsync(Recibo obj) {
			_recibos.Update(obj);
			return Task.CompletedTask;
		}
	}
}
