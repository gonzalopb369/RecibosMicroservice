//using ControlRecibos.Domain.Repositories;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading.Tasks;


namespace ControlRecibos.Application.Services {
	public class ReciboService : IReciboService {

		//public Task<int> GenerarNroReciboAsync() => Task.FromResult(123); 

		public Task<int> GenerarNroReciboAsync() // Debe generar un nro. secuencial de la bd
		{
			Random Aleatorio = new Random();
			int NumAleatorio = Aleatorio.Next(10,9999);
			return Task.FromResult(NumAleatorio);
		}

	}
}
