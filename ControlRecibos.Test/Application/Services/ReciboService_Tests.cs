using ControlRecibos.Application.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Xunit;

namespace ControlRecibos.Test.Application.Services
{
	public class ReciboService_Tests
	{
		[Theory]
		[InlineData(-4,false)]
		[InlineData(123,true)]
		[InlineData(0,false)]
		[InlineData(345,true)]
		[InlineData(null,false)]
		[InlineData(-88,false)]
		[InlineData(6757,true)]
		[InlineData(-6,false)]
		public async void GenerarNroRecibo_CheckValidData(int expectedNroRecibo,bool isEqual)
		{
			var reciboService = new ReciboService();
			int nroRecibo = await reciboService.GenerarNroReciboAsync();
			if (isEqual)
			{				
				Assert.InRange(expectedNroRecibo,1,9999);
			}
			else
			{
				Assert.NotEqual(expectedNroRecibo,nroRecibo);
			}
		}

	}

}
