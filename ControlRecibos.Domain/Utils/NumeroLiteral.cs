using System;
using System.Threading;


namespace ControlRecibos.Domain.Utils
{
	public class NumeroLiteral
	{
		string numero = "";		
		int numeroComas = 0;
		static string nombreMoneda;

		public NumeroLiteral()
		{
		}

		public string Cadena
		{
			set { numero = value; }
			get { return numero; }
		}

		private int CantidadComas
		{
			get { return numeroComas; }
		}

		private string GetFracciones()
		{
			int tamaño = 0;
			int largo = 0;
			int res = 0;
			string elDecimal;
			largo = numero.Length - 1;
			tamaño = numero.IndexOf(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
			if (tamaño != -1)
			{
				res = largo - tamaño;
				elDecimal = numero.Substring(tamaño + 1,res);
				return elDecimal;
			}
			else return "0";

		}

		private string GetNumeroEntero()
		{
			int indPunto = 0;
			string elEntero;
			indPunto = numero.IndexOf(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
			if (indPunto >= 0)
			{
				if (indPunto == 0) elEntero = "0";
				else elEntero = numero.Substring(0,indPunto);
				return elEntero;
			}
			else return numero;
		}

		private string GetMiles()
		{
			int comaUno = GetIndiceComaUno() + 1;
			int comaDos = GetIndiceComaDos() + 1;
			string losMiles = "";
			if (numeroComas == 2)
			{
				// OJOJOOOOOOOOOOOOOO
				losMiles = numero.Substring(comaUno,3);
				if (losMiles == "000") losMiles = "";
				//else losMiles;
				return losMiles;

			}
			else
			{
				if (numeroComas == 1)
				{
					losMiles = numero.Substring(0,comaUno - 1);
					return losMiles;
				}
				else return "0";

			}

		}

		private void GetNumeroComas()
		{
			numeroComas = 0;
			for (int i = 0; i < numero.Length; i++)
			{
				if (numero[i].ToString() == Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator) numeroComas++;

			}
		}

		//
		private int GetIndiceComaUno()
		{
			int indice = 0;
			indice = numero.IndexOf(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator);
			return indice;
		}

		private int GetIndiceComaDos()
		{
			int indice = 0;
			for (int i = 0; i < numero.Length; i++)
			{
				if (numero[i].ToString() == Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator && i > 1) indice = i;
			}
			return indice;
		}

		//
		private bool hayPuntoDecimal()
		{
			if (numero.IndexOf(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator) >= 0)
			{
				return true;

			}
			else
				return false;
		}

		#region GENERA LOS LITERALES
		private string GetLiteralUnidades(int numeroX)
		{
			string dato = "";
			switch (numeroX)
			{
				case 0:
					dato = "Cero";
					break;
				case 1:
					dato = "Uno";
					break;
				case 2:
					dato = "Dos";
					break;
				case 3:
					dato = "Tres";
					break;
				case 4:
					dato = "Cuatro";
					break;
				case 5:
					dato = "Cinco";
					break;
				case 6:
					dato = "Seis";
					break;
				case 7:
					dato = "Siete";
					break;
				case 8:
					dato = "Ocho";
					break;
				case 9:
					dato = "Nueve";
					break;
			}
			return dato;
		}

		private string GetLiteralDecenaSingle(int numeroX)
		{
			string dato = "";
			switch (numeroX)
			{
				case 1:
					dato = "Diez";
					break;
				case 2:
					dato = "Veinti";
					break;
				case 3:
					dato = "Treinta";
					break;
				case 4:
					dato = "Cuarenta";
					break;
				case 5:
					dato = "Cincuenta";
					break;
				case 6:
					dato = "Sesenta";
					break;
				case 7:
					dato = "Setenta";
					break;
				case 8:
					dato = "Ochenta";
					break;
				case 9:
					dato = "Noventa";
					break;
			}
			return dato;
		}

		private string GetLiteralDecena(int numeroX)
		{
			string dato = "";
			switch (numeroX)
			{
				case 10:
					dato = "Diez";
					break;
				case 11:
					dato = "Once";
					break;
				case 12:
					dato = "Doce";
					break;
				case 13:
					dato = "Trece";
					break;
				case 14:
					dato = "Catorce";
					break;
				case 15:
					dato = "Quince";
					break;
				case 16:
					dato = "Dieciséis";
					break;
				case 17:
					dato = "Diecisiete";
					break;
				case 18:
					dato = "Dieciocho";
					break;
				case 19:
					dato = "Diecinueve";
					break;
				case 20:
					dato = "Veinte";
					break;
				case 30:
					dato = "Treinta";
					break;
				case 40:
					dato = "Cuarenta";
					break;
				case 50:
					dato = "Cincuenta";
					break;
				case 60:
					dato = "Sesenta";
					break;
				case 70:
					dato = "Setenta";
					break;
				case 80:
					dato = "Ochenta";
					break;
				case 90:
					dato = "Noventa";
					break;
			}
			return dato;
		}

		private string GetLiteralCentena(int numeroX)
		{
			string dato = "";

			switch (numeroX)
			{
				case 100:
					dato = "Cien";
					break;
				case 200:
					dato = "Doscientos";
					break;
				case 300:
					dato = "Trescientos";
					break;
				case 400:
					dato = "Cuatrocientos";
					break;
				case 500:
					dato = "Quinientos";
					break;
				case 600:
					dato = "Seiscientos";
					break;
				case 700:
					dato = "Setecientos";
					break;
				case 800:
					dato = "Ochocientos";
					break;
				case 900:
					dato = "Novecientos";
					break;

			}
			return dato;
		}
		private string GetLiteralCentenaSingle(int numeroX)
		{
			string dato = "";
			switch (numeroX)
			{
				case 1:
					dato = "Ciento";
					break;
				case 2:
					dato = "Doscientos";
					break;
				case 3:
					dato = "Trescientos";
					break;
				case 4:
					dato = "Cuatrocientos";
					break;
				case 5:
					dato = "Quinientos";
					break;
				case 6:
					dato = "Seiscientos";
					break;
				case 7:
					dato = "Setecientos";
					break;
				case 8:
					dato = "Ochocientos";
					break;
				case 9:
					dato = "Novecientos";
					break;


			}
			return dato;
		}
		private string GetLiteralMiles(string milX)
		{
			//int indice = 0;
			int valor;
			string milSinComas = "";
			string dato = "";
			string laCentena;
			if (numeroComas > 0)
			{
				laCentena = GetCentena();
				milSinComas = GetEnterosSinComas();
				valor = Convert.ToInt32(milSinComas);
			}
			else
			{
				valor = Convert.ToInt16(milX);
			}
			switch (valor)
			{
				case 1000:
					dato = "Mil";
					break;
				case 2000:
					dato = "Dos Mil";
					break;
				case 3000:
					dato = "Tres Mil";
					break;
				case 4000:
					dato = "Cuatro Mil";
					break;
				case 5000:
					dato = "Cinco Mil";
					break;
				case 6000:
					dato = "Seis Mil";
					break;
				case 7000:
					dato = "Siete Mil";
					break;
				case 8000:
					dato = "Ocho Mil";
					break;
				case 9000:
					dato = "Nueve Mil";
					break;

			}
			return dato;
		}
		private string GetLiteralMilesSingle(int numeroX)
		{
			string dato = "";
			switch (numeroX)
			{
				case 1:
					dato = "Mil";
					break;
				case 2:
					dato = "Dos Mil";
					break;
				case 3:
					dato = "Tres Mil";
					break;
				case 4:
					dato = "Cuatro Mil";
					break;
				case 5:
					dato = "Cinco Mil";
					break;
				case 6:
					dato = "Seis Mil";
					break;
				case 7:
					dato = "Siete Mil";
					break;
				case 8:
					dato = "Ocho Mil";
					break;
				case 9:
					dato = "Nueve Mil";
					break;

			}
			return dato;
		}
		private string GetLiteralMillonesSingle(int numeroX)
		{
			string dato = "";
			switch (numeroX)
			{
				case 1:
					dato = "Un Millon";
					break;
				case 2:
					dato = "Dos Millones";
					break;
				case 3:
					dato = "Tres Millones";
					break;
				case 4:
					dato = "Cuatro Millones";
					break;
				case 5:
					dato = "Cinco Millones";
					break;
				case 6:
					dato = "Seis Millones";
					break;
				case 7:
					dato = "Siete Millones";
					break;
				case 8:
					dato = "Ocho Millones";
					break;
				case 9:
					dato = "Nueve Millones";
					break;

			}
			return dato;
		}
		private string GetLiteralMillones(string millonXY)
		{
			string dato = "";
			int numero = Convert.ToInt32(millonXY);
			switch (numero)
			{
				case 1000000:
					dato = "Un Millon";
					break;
				case 2000000:
					dato = "Dos Millones";
					break;
				case 3000000:
					dato = "Tres Millones";
					break;
				case 4000000:
					dato = "Cuatro Millones";
					break;
				case 5000000:
					dato = "Cinco Millones";
					break;
				case 6000000:
					dato = "Seis Millones";
					break;
				case 7000000:
					dato = "Siete Millones";
					break;
				case 8000000:
					dato = "Ocho Millones";
					break;
				case 9000000:
					dato = "Nueve Millones";
					break;

			}
			return dato;
		}
		#endregion

		private string GetMillon()
		{
			string elMil = "";
			int firstComa = GetIndiceComaUno();
			if (numeroComas == 2)
			{
				elMil = numero.Substring(0,firstComa);
				return elMil;
			}
			else return "0";
		}
		private string GetCentena()
		{
			string lacentena = "";
			int firstComa = GetIndiceComaUno() + 1;
			int comaDos = GetIndiceComaDos() + 1;
			if (numeroComas == 2)
			{
				if (hayPuntoDecimal())
				{
					//int pto = numero.IndexOf(Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
					lacentena = numero.Substring(comaDos,3);
				}
				else
				{
					lacentena = numero.Substring(comaDos);

				}

			}
			else if (numeroComas == 1)
			{
				if (hayPuntoDecimal())
				{
					lacentena = numero.Substring(firstComa,3);
				}
				else
				{
					lacentena = numero.Substring(firstComa);

				}

			}
			return lacentena;
		}
		private string GetElDecimal(string decenaX)
		{
			return decenaX.Substring(1,2);
		}
		private string GetRestoMiles(string milesX)
		{
			int laComaUno = GetIndiceComaUno() + 1;
			int laComaDos = GetIndiceComaDos() + 1;
			string resto = "";
			if (numeroComas == 2)
			{
				resto = numero.Substring(laComaDos,3); //milesX.Substring(laComaDos,3);
			}
			else if (numeroComas == 1)
			{
				if (hayPuntoDecimal())
				{
					resto = numero.Substring(laComaUno,3);// MODIFICADO  'NUMERO/MILES-X'
				}
				else
				{
					resto = numero.Substring(laComaUno);
				}
			}
			return resto;
		}

		private string GetRestoMillon(string millonX)
		{
			string restoMillon = "";
			int comaUno = GetIndiceComaUno() + 1;
			if (numeroComas == 2)
			{
				restoMillon = millonX.Substring(comaUno);
				return restoMillon;
			}
			else return restoMillon;

		}
		private string GetEnterosSinComas()
		{
			string sinComas = GetNumeroEntero();
			string elNumero = "";
			for (int i = 0; i < sinComas.Length; i++)
			{
				if (sinComas[i].ToString() != Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator)
				{
					elNumero += Convert.ToString(sinComas[i]);
				}
			}
			return elNumero;
		}
		// EL MAKER LITERAL 
		/*
         * SOLO DEBES PASARLE A ESTE METODO EL --NUMERO-- QUE DESEAS TRANSFORMAR; PERO 
         * PREVIAMENTE DEBES CARGAR EL NUMERO ATRAVEZ DEL METODO --CADENA--
         */
		public string GetLiteral(string datoX)
		{
			this.numero = datoX;
			string literalX = "";
			string centenas = "";
			string decenas = "";
			string unidades = "";
			string miles = "";
			string millones = "";
			string centenaY = "";
			string elEntero;
			GetNumeroComas();
			string fraccionY = GetFracciones();
			//SI ES MILLON????==> ESCRIBE MILLONES
			if (numeroComas == 2)
			{
				millones = makeLiteralMillones(datoX);

			}
			//SI SON MILES ???? ==> ESCRIBE MIL
			if (numeroComas == 1)
			{
				miles = makeLiteralMiles(datoX);

			}
			else
			{
				if (hayPuntoDecimal())
				{
					string elCero = "";
					if (fraccionY.Length == 1)
					{
						elCero = "0";
					}
					elEntero = GetNumeroEntero();
					switch (elEntero.Length)
					{
						case 1:
							unidades = makeLiteralUnidad(elEntero);
							centenaY = unidades + " con " + elCero + fraccionY + "/100 ";
							break;
						case 2:
							decenas = makeLiteralDecenas(elEntero);
							centenaY = decenas + " con " + elCero + fraccionY + "/100 ";
							break;
						case 3:
							centenas = makeLiteralCentenas(elEntero);
							centenaY = centenas + " con " + elCero + fraccionY + "/100 ";
							break;

					}
				}
				else
				{
					switch (datoX.Length)
					{
						case 1:
							unidades = makeLiteralUnidad(datoX);
							centenaY = unidades + " con 00/100 ";
							break;
						case 2:
							decenas = makeLiteralDecenas(datoX);
							centenaY = decenas + " con 00/100 ";
							break;
						case 3:
							centenas = makeLiteralCentenas(datoX);
							centenaY = centenas + " con 00/100 ";
							break;

					}
				}
			}

			return literalX = millones + miles + centenaY + " " + nombreMoneda;

		}
		// MAKERS
		private string makeLiteralMillones(string numeroX)
		{
			string elMillon = GetMillon();
			string restoMillones = GetRestoMillon(numeroX);
			string laCadena = "";
			string literalDecimal = "";
			//
			string sinComas = GetEnterosSinComas();
			string esMillon = GetLiteralMillones(sinComas);
			if (esMillon != "")
			{
				laCadena = esMillon;
			}
			else
			{
				if (elMillon.Length == 3)
				{
					laCadena = makeLiteralCentenas(elMillon) + " Millones ";

				}
				if (elMillon.Length == 2)
				{
					literalDecimal = makeLiteralDecenas(elMillon);
					laCadena = literalDecimal + " Millones ";

				}
				if (elMillon.Length == 1)
				{
					laCadena = GetLiteralUnidades(Convert.ToInt16(elMillon));
					if (laCadena == "Uno") laCadena = " Un Millon ";
					else laCadena += " Millones ";
				}
				laCadena += " " + makeLiteralMiles(restoMillones);
			}

			return laCadena;


		}
		private string makeLiteralMiles(string numeroX)
		{
			string elResto = GetRestoMiles(numeroX);
			string midecena = GetElDecimal(elResto);
			string losMiles = GetMiles();
			string literalDecimal;
			//string datoY;
			string laCentena = GetCentena();
			string laCadena = "";
			string lafraccion = "";
			string esMil = GetLiteralMiles(numeroX);
			if (esMil != "")
			{
				laCadena = esMil;
			}
			else
			{
				if (losMiles.Length == 3)
				{
					// ojojooooo
					if (losMiles != "") laCadena = makeLiteralCentenas(losMiles) + " Mil ";
					// else laCadena;

				}
				if (losMiles.Length == 2)
				{
					literalDecimal = makeLiteralDecenas(losMiles);
					laCadena = literalDecimal + " Mil ";

				}
				if (losMiles.Length == 1)
				{
					laCadena = GetLiteralUnidades(Convert.ToInt16(losMiles));
					if (laCadena == "Uno") laCadena = " Un Mil ";
					else laCadena += " Mil ";
				}
				// trabajando el resto
				if (!hayPuntoDecimal())
				{
					laCadena += makeLiteralCentenas(elResto) + " con 00/100";
				}
				else
				{
					string elCero = "";
					laCadena += makeLiteralCentenas(laCentena);
					lafraccion = GetFracciones();
					if (lafraccion.Length == 1)
					{
						elCero = "0";
					}
					if (lafraccion == "00") laCadena += " con " + lafraccion + "/100";
					else laCadena += " con " + elCero + lafraccion + "/100";

				}



			}
			return laCadena;


		}
		private string makeLiteralCentenas(string numeroX)
		{
			string midecena = GetElDecimal(numeroX);
			string literalDecimal;
			string datoY;
			string laCentena = "";
			string laCadena = "";
			laCentena = GetLiteralCentena(Convert.ToInt16(numeroX));
			if (laCentena != "")
			{
				laCadena = laCentena;
			}
			else
			{
				datoY = Convert.ToString(numeroX[0]);
				laCadena += "" + GetLiteralCentenaSingle(Convert.ToInt16(datoY));
				literalDecimal = makeLiteralDecenas(midecena);
				laCadena += " " + literalDecimal;

			}
			return laCadena;


		}
		private string makeLiteralDecenas(string numeroX)
		{
			string datoZ = "";
			string laCadena = "";
			// SI TIENE SOLO DOS DIGITOS??????
			if (numeroX.Length == 2)
			{
				datoZ = GetLiteralDecena(Convert.ToInt16(numeroX));
				if (datoZ.Length > 0)
				{
					laCadena = datoZ;
				}
				else
				{
					for (int i = 0; i < numeroX.Length; i++)
					{
						switch (i)
						{
							case 0:
								datoZ = Convert.ToString(numeroX[i]);
								laCadena += GetLiteralDecenaSingle(Convert.ToInt16(datoZ));
								break;
							case 1:
								datoZ = Convert.ToString(numeroX[i]);
								if (laCadena == "Veinti") laCadena += " " + GetLiteralUnidades(Convert.ToInt16(datoZ));
								else
								{
									if (numeroComas == 2) laCadena += GetLiteralUnidades(Convert.ToInt16(datoZ));
									else laCadena += " y " + GetLiteralUnidades(Convert.ToInt16(datoZ));
								}

								break;

						}
					}
				}
			}
			// si es solo un numero????
			else if (numeroX.Length == 1)
			{
				laCadena = GetLiteralDecenaSingle(Convert.ToInt16(numeroX));
			}

			return laCadena;

		}
		private string makeLiteralUnidad(string numeroX)
		{
			string datoK;
			string laCadena = "";
			datoK = Convert.ToString(numeroX[0]);
			laCadena = GetLiteralUnidades(Convert.ToInt16(datoK));
			return laCadena;
		}

		public static string ObtenerNumeroLiteral(decimal pMonto,string pFormat,string pNombreMoneda)
		{
			nombreMoneda = pNombreMoneda;
			NumeroLiteral vNumToLiteral = new NumeroLiteral();
			if (pMonto == 0)
				return "";
			else
				return vNumToLiteral.GetLiteral(pMonto.ToString("N2"));
		}
	}
}
