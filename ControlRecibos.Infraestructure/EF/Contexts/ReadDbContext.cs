using ControlRecibos.Domain.Event;
using ControlRecibos.Infraestructure.EF.Config.ReadConfig;
using ControlRecibos.Infraestructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using ShareKernelRecibos.Core;


namespace ControlRecibos.Infraestructure.EF.Contexts
{
	public class ReadDbContext : DbContext
	{
		public virtual DbSet<ReciboReadModel> Recibo { set; get; }


		public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			var reciboConfig = new ReciboReadConfig();
			modelBuilder.ApplyConfiguration<ReciboReadModel>(reciboConfig);

			modelBuilder.Ignore<DomainEvent>();
			modelBuilder.Ignore<ReciboCreado>();
		}
	}
}
