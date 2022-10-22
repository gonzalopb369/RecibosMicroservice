using ShareKernelRecibos.Core;


namespace ControlRecibos.Domain.ValueObjects
{
	public record NroDocumentoValue : ValueObject
	{
		public int Value { get; }


		public NroDocumentoValue(int value)
		{
			if (value < 0)
			{
				throw new BusinessRuleValidationException("El número de documento no puede ser negativo o cero");
			}
			Value = value;
		}


		public static implicit operator int(NroDocumentoValue value)
		{
			return value.Value;
		}


		public static implicit operator NroDocumentoValue(int value)
		{
			return new NroDocumentoValue(value);
		}
	}
}
