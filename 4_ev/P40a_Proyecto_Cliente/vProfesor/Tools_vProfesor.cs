using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoClientes
{
	class Util
	{
		public static DateTime FECHAHOY = DateTime.Now;
		public static string CuadraTexto(string texto, int numChar)
		{
			texto += "                                            ";
			return texto.Substring(0, numChar);
		}
	}
}
