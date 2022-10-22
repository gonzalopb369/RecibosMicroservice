using ShareKernelRecibos.Core;
//using System;


namespace ControlRecibos.Domain.ValueObjects {
	public record PrecioValue {
		public decimal Value { get; }


		public PrecioValue(decimal value) {
			if (value < 0) {
				throw new BusinessRuleValidationException("El precio no puede ser un valor negativo!!");
			}
			Value = value;
		}


		public static implicit operator decimal(PrecioValue value) {
			return value.Value;
		}

		public static implicit operator PrecioValue(decimal value) {
			return new PrecioValue(value);
		}
	}
}
