using ControlRecibos.Domain.Event;
using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Infraestructure.EF.Config.WriteConfig;
using Microsoft.EntityFrameworkCore;
using ShareKernelRecibos.Core;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace ControlRecibos.Infraestructure.EF.Contexts
{
	public class WriteDbContext : DbContext
	{
		public virtual DbSet<Recibo> Recibo { get; set; }


		public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
		{
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var reciboConfig = new ReciboWriteConfig();
			modelBuilder.ApplyConfiguration<Recibo>(reciboConfig);
			modelBuilder.Ignore<DomainEvent>();
			modelBuilder.Ignore<ReciboCreado>();
			//modelBuilder.Ignore<ItemPedidoAgregado>();
		}
	}
}
