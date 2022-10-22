using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRecibos.Application.Services {
	public interface IReciboService {
		Task<int> GenerarNroReciboAsync();
	}
}
