using ControlRecibos.Domain.Model.Recibos;
using ControlRecibos.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShareKernelRecibos.ValueObjects;



namespace ControlRecibos.Infraestructure.EF.Config.WriteConfig {
	public class ReciboWriteConfig : IEntityTypeConfiguration<Recibo> {
		public void Configure(EntityTypeBuilder<Recibo> builder) {
			builder.ToTable("Recibo");
			builder.HasKey(x => x.Id);

			var nroDocumentoValueConverter = new ValueConverter<NroDocumentoValue,int>(
			   nroDocumentoValue => nroDocumentoValue.Value,
			   nroDocumento => new NroDocumentoValue(nroDocumento)
		   );
			builder.Property(x => x.NroRecibo)
				.HasConversion(nroDocumentoValueConverter)
				.HasColumnName("nroRecibo");

			builder.Property(x => x.FechaPago)
			   .HasColumnName("fechaPago")
			   .HasColumnType("DateTime");


			var nombrePasajeroValueConverter = new ValueConverter<PersonNameValue,string>(
			   nombrePasajeroValue => nombrePasajeroValue.Name,
			   nombrePasajero => new PersonNameValue(nombrePasajero)
			);
			builder.Property(x => x.NombrePasajero)
				.HasConversion(nombrePasajeroValueConverter)
				.HasMaxLength(500)
				.HasColumnName("nombrePasajero");

			//var codigoReservaValueConverter = new ValueConverter<CodReservaValue,string>(
			//   codigoReservaValue => codigoReservaValue.CodigoReserva,
			//   codigoReserva => new CodReservaValue(codigoReserva)
			//);
			builder.Property(x => x.CodigoReserva)
				//.HasConversion(codigoReservaValueConverter)
			   .HasMaxLength(100)
			   .HasColumnName("codigoReserva");

			builder.Property(x => x.Concepto)
			   .HasMaxLength(100)
			   .HasColumnName("concepto");

			var montoTotalValueConverter = new ValueConverter<PrecioValue,decimal>(
				montoTotalValue => montoTotalValue.Value,
				montoTotal => new PrecioValue(montoTotal)
			);
			builder.Property(x => x.MontoTotal)
				.HasConversion(montoTotalValueConverter)
				.HasColumnName("montoTotal")
				.HasPrecision(12,2);

			//!!! ver. si entrará el monto literal

			var aCuentaValueConverter = new ValueConverter<PrecioValue,decimal>(
				aCuentaValue => aCuentaValue.Value,
				aCuenta => new PrecioValue(aCuenta)
			);
			builder.Property(x => x.ACuenta)
				.HasConversion(aCuentaValueConverter)
				.HasColumnName("aCuenta")
				.HasPrecision(12,2);

			var saldoValueConverter = new ValueConverter<PrecioValue,decimal>(
				saldoValue => saldoValue.Value,
				saldo => new PrecioValue(saldo)
			);
			builder.Property(x => x.Saldo)
				.HasConversion(saldoValueConverter)
				.HasColumnName("saldo")
				.HasPrecision(12,2);

			builder.Property(x => x.Estado)
				.HasColumnName("estado");

		}
	}
}
