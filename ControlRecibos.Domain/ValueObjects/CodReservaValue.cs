using ShareKernelRecibos.Core;
using ShareKernelRecibos.Rules;
//using System;


namespace ControlRecibos.Domain.ValueObjects {
	public record CodReservaValue : ValueObject {
		public string CodigoReserva { get; }

		public CodReservaValue(string codigoReserva)   // !!! poner en listado los valores válidos de las ciudades
		{
			CheckRule(new StringNotNullOrEmptyRule(codigoReserva));
			if (codigoReserva.Length > 40) {
				throw new BusinessRuleValidationException("El código de Reserva NO puede ser mayor a 10 caracteres!");
			}
			CodigoReserva = codigoReserva;
		}


		public static implicit operator string(CodReservaValue value) {
			return value.CodigoReserva;
		}


		public static implicit operator CodReservaValue(string name) {
			return new CodReservaValue(name);
		}
	}
}
