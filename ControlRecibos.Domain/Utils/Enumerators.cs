using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ControlRecibos.Domain.Utils
//{
//    class Enumerators
//    {
//    }
//}


namespace ControlRecibos.Domain.Utils
{
	/// <summary>
	/// Enumera todos los estados generales
	/// </summary>
	//public enum EstadoGeneral
	//{
	//    /// <summary>
	//    /// Activo
	//    /// </summary>
	//    Activo = 1,
	//    /// <summary>
	//    /// Inactivo
	//    /// </summary>
	//    Inactivo = 2
	//}


	/// <summary>
	/// Enumera todos los tipos de usuarios
	/// </summary>
	public enum EstadoRecibo
	{
		/// <summary>
		/// Recibo por una Reserva pendiente de pago
		/// </summary>
		ReservaPendiente = 3,

		/// <summary>
		/// Recibo por una Reserva que no termino de pagarla a tiempo
		/// </summary>
		ReservaCancelada = 4,

		/// <summary>
		/// Recibo por una Reserva que fue cancelada en su totalidad
		/// </summary>
		ReservaPagoTotal = 5
	}



	/// <summary>
	/// Enumera todos los clasificadores
	/// </summary>
	//public enum Clasificadores
	//{
	//    /// <summary>
	//    /// Tipo de Nota de Entrada
	//    /// </summary>
	//    TipoNotaEntrada = 5,

	//    /// <summary>
	//    /// Tipo de Nota de Salida
	//    /// </summary>
	//    TipoNotaSalida = 6,
	//}

}