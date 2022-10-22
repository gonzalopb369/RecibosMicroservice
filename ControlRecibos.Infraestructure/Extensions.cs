using ControlRecibos.Application;
using ControlRecibos.Domain.Repositories;
using ControlRecibos.Infraestructure.EF;
using ControlRecibos.Infraestructure.EF.Contexts;
using ControlRecibos.Infraestructure.EF.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;


namespace ControlRecibos.Infraestructure {
	public static class Extensions {
		public static IServiceCollection AddInfrastructure(this IServiceCollection services,
				IConfiguration configuration) {
			services.AddApplication();
			services.AddMediatR(Assembly.GetExecutingAssembly());

			var connectionString =
				configuration.GetConnectionString("ReciboDbConnectionString");

			services.AddDbContext<ReadDbContext>(context =>
				context.UseSqlServer(connectionString));
			services.AddDbContext<WriteDbContext>(context =>
				context.UseSqlServer(connectionString));

			//services.AddScoped<IPedidoRepository, PedidoRepository>();
			services.AddScoped<IReciboRepository,ReciboRepository>();
			services.AddScoped<IUnitOfWork,UnitOfWork>();

			return services;
		}
	}
}
