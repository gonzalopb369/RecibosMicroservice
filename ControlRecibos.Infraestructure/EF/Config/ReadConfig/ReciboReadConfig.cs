using ControlRecibos.Infraestructure.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace ControlRecibos.Infraestructure.EF.Config.ReadConfig
{
	public class ReciboReadConfig : IEntityTypeConfiguration<ReciboReadModel>
	{
		public void Configure(EntityTypeBuilder<ReciboReadModel> builder)
		{
			builder.ToTable("Recibo");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.NroRecibo)
				.HasColumnName("nroRecibo");

			builder.Property(x => x.FechaPago)
			   .HasColumnName("fechaPago")
			   .HasColumnType("DateTime");

			builder.Property(x => x.NombrePasajero)
				.HasMaxLength(500)
				.HasColumnName("nombrePasajero");

			builder.Property(x => x.CodigoReserva)
			   .HasMaxLength(100)
			   .HasColumnName("codigoReserva");

			builder.Property(x => x.Concepto)
			   .HasMaxLength(100)
			   .HasColumnName("concepto");

			builder.Property(x => x.MontoTotal)
				.HasColumnName("montoTotal")
				.HasColumnType("decimal")
				.HasPrecision(12,2);

			//!!! ver. si entrará el monto literal

			builder.Property(x => x.ACuenta)
				.HasColumnName("aCuenta")
				.HasColumnType("decimal")
				.HasPrecision(12,2);

			builder.Property(x => x.Saldo)
				.HasColumnName("saldo")
				.HasColumnType("decimal")
				.HasPrecision(12,2);

			builder.Property(x => x.Estado)
				.HasColumnName("estado");

		}
	}
}
