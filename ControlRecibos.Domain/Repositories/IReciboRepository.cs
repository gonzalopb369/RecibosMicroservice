using ControlRecibos.Domain.Model.Recibos;
using ShareKernelRecibos.Core;
using System;
using System.Collections.Generic;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading.Tasks;


namespace ControlRecibos.Domain.Repositories
{
	public interface IReciboRepository : IRepository<Recibo,Guid>
	{
		Task UpdateAsync(Recibo obj);
		Task RemoveAsync(Recibo obj);
		Task<List<Recibo>> GetAll();
	}
}
