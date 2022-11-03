using ControlRecibos.Application.Services;
using ControlRecibos.Domain.Factories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace ControlRecibos.Application
{
	public static class Extensions
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient<IReciboService,ReciboService>();
			services.AddTransient<IReciboFactory,ReciboFactory>();
			return services;
		}
	}
}
