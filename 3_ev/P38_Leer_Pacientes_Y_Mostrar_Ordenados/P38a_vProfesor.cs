/*
Los registros de "Pacientes.txt", tienen los campos separados por ';' en el siguiente orden: 
id; Apellidos, Nombre; movil; fechaNac; altura; peso
El proceso a seguir será el siguiente: 
1)	Mostrará el menú que tienes en el proyecto, para seleccionar el orden en que se desea presentar los datos. Importante: De este menú no se sale hasta que se elija una opción correcta.
2)	A continuación, leerá los registros del fichero y los ordenará según la opción elegida, y los presentará en pantalla con su cabecera. Ejemplo para la opción 0 (Sin ordenar).
 
3)	Por último, dirá el peso medio de todos los Pacientes.

Importante: 
•	Ten en cuenta que la fecha está guardada como un entero compuesto como AAAAMMDD, es decir, los 4 primeros dígitos son el año, los dos siguientes el mes y los dos últimos el día. Tú lo debes presentar como día/mes/año.
•	Tanto el id como la altura (que está en centímetros) deben estar alineados a la derecha. El peso también tiene que estar bien alineado.
Extra: 
Añadir al menú la opción de ordenar por «Nombre Apellidos» y estos datos serán los que aparezcan en la columna de Paciente, en lugar de «Apellidos, Nombre».


*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class Program
{
	static void Main(string[] args)
	{
		// Construyo una lista donde guardar las líneas del fichero (registros)
		List<string> listaReg = new List<string>();
		List<string> listaOrdenada;

		// el StreamReader para leer los datos
		StreamReader sr = new StreamReader(@".\Datos\Pacientes.txt", Encoding.Default);
		//// Construimos el StreamWriter para escribir el fichero destino
		//StreamWriter sw = new StreamWriter(@"C:\zDatosPruebas\Pacientes\Pacientes.txt");
		string[] nombreCamposOrdenacion = { " ", "por orden de id", "por orden de Apellidos, Nombre", "por orden de Edad", "por orden de altura", "por orden de peso", "Sin ordenar" };



		// Leemos todas las lineas del fichero y las guardamos en la listas
		string registro;
		string[] vCampos; // <-- tabla donde guardaremos los campos de cada registro
						  // colocamos el campo de ordenación delante del registro

		while (!sr.EndOfStream)
			listaReg.Add(sr.ReadLine());
		// ya hemnos leído todas las líneas, por lo tanto cierro el stream
		sr.Close();

		int opcion = Menu();

		while (opcion != 0)
		{
			listaOrdenada = new List<string>(listaReg);
			for (int i = 0; i < listaOrdenada.Count; i++)
			{
				registro = listaOrdenada[i]; // sólo lo hago así para que tengas en cuenta que cada elemento es un registro

				vCampos = registro.Split(';');
				switch (opcion)
				{
					case 1: // Por id
						registro = CuadraTexto(4, vCampos[0]) + ';' + registro;
						break;
					case 2: // Por Apellidos, Nombre
						registro = vCampos[1] + ';' + registro;
						break;
					case 3: // Por Edad
						registro = vCampos[3] + ';' + registro;
						break;
					case 4: // Por Estatura
						registro = vCampos[4] + ';' + registro;
						break;
					case 5: // Por Peso
						registro = CuadraNumero(Convert.ToDouble(vCampos[5]), 6) + ';' + registro;
						break;
					case 6: // sin ordenar
						registro = " " + ';' + registro;
						break;
				}
				listaOrdenada[i] = registro;
			}

			//Ordenamos la Lista
			listaOrdenada.Sort();
			// Si se ordena por la edad, de menor a mayor, 
			// hay que invertir la el orden porque la fecha debe estar de mayor a menor
			if (opcion == 3)
				listaOrdenada.Reverse();

			Console.WriteLine("    ------ Pacientes de la consulta {0} ------", nombreCamposOrdenacion[opcion]);

			// Atento a la codificación
			Console.WriteLine("\n  Id  Paciente                     Movil      Fecha Nac.  Alt.  Peso");
			Console.WriteLine("  --- ---------------------------- ---------  ----------  ---- -----");

			double peso, sumaPeso = 0;
			int cont = 0;
			string fechaSP;
			// necesitamos el vector de campos
			foreach (string reg in listaOrdenada)
			{
				vCampos = reg.Split(';');
				// id
				Console.Write("  " + CuadraTexto(3, vCampos[1]));
				// paciente y su móvil
				Console.Write(" {0} {1} ", CuadraTexto(vCampos[2], 28), CuadraTexto(vCampos[3], 9));
				// fecha en español
				fechaSP = vCampos[4];
				Console.Write(" {2}/{1}/{0}  ", fechaSP.Substring(0, 4), fechaSP.Substring(4, 2), fechaSP.Substring(6));
				// Altura
				Console.Write(vCampos[5]);
				// Peso
				peso = Convert.ToDouble(vCampos[6]);
				Console.WriteLine("  {0}", CuadraNumero(peso, 5));
				sumaPeso += peso;
				cont++;
			}

			Console.Write("\n\n\t*** El peso medio de todos los pacientes es {0} kg ***", (sumaPeso / cont).ToString("0.0"));
			Console.WriteLine("\n\n\t Pulsa una tecla para volver al menú");
			Console.ReadKey();
			opcion = Menu();
		}
		Console.WriteLine("\n\n\t Pulsa una tecla para salir");
		Console.ReadKey();
	}


	static int Menu()
	{
		int opcion = 0;
		Console.Clear();
		Console.WriteLine("\n\n\t\t╔═════════════════════════╗");
		Console.WriteLine("\t\t║   Ordenar datos por...  ║");
		Console.WriteLine("\t\t╠═════════════════════════╣");
		Console.WriteLine("\t\t║   1) id                 ║");
		Console.WriteLine("\t\t║                         ║");
		Console.WriteLine("\t\t║   2) Apellidos, Nombre  ║");
		Console.WriteLine("\t\t║                         ║");
		Console.WriteLine("\t\t║   3) Edad (creciente)   ║");
		Console.WriteLine("\t\t║                         ║");
		Console.WriteLine("\t\t║   4) Altura             ║");
		Console.WriteLine("\t\t║                         ║");
		Console.WriteLine("\t\t║   5) Peso               ║");
		Console.WriteLine("\t\t║                         ║");
		Console.WriteLine("\t\t║   6) Sin ordenar        ║");
		Console.WriteLine("\t\t║_________________________║");
		Console.WriteLine("\t\t║                         ║");
		Console.WriteLine("\t\t║      0)  Salir          ║");
		Console.WriteLine("\t\t╚═════════════════════════╝");

		//		Console.WriteLine("\t\t║   7) Nombre Apellidos   ║");


		Console.Write("\t\tIntroduce una opción: ");
		// guardamos el valor numérico de la tecla pulsada
		opcion = Console.ReadKey().KeyChar - '0';
		// Comprobamos que se ha pulsado una opción correcta
		while (opcion < 0 || opcion > 6)
		{
			Console.WriteLine("\n\t\t\t*ERROR*");
			Console.Write("\t\tIntroduce una opción: ");
			opcion = Console.ReadKey().KeyChar - '0';
		}
		Console.Clear();
		return opcion;
	}
	/// <summary>
	/// Cuadra el texto alineándolo a la izquierda
	/// </summary>
	/// <param name="texto">Texto a cuadrar en el espacio indicado por numCaracteres</param>
	/// <param name="numCaracteres">Número de caracteres de la cadena resultante</param>
	/// <returns>Devuelve el texto alineado a la izquierda, dentro del número de caracteres indicado</returns>
	static string CuadraTexto(string texto, int numCaracteres)
	{
		texto += "                                  ";
		return texto.Substring(0, numCaracteres);
	}

	/// <summary>
	/// Cuadra el texto alineándolo a la derecha
	/// </summary>
	/// <param name="numCaracteres">Número de caracteres de la cadena resultante</param>
	/// <param name="texto">Texto a cuadrar en el espacio indicado por numCaracteres</param>
	/// <returns>Devuelve el texto alineado a la derecha dentro del número de caracteres indicado</returns>
	static string CuadraTexto(int numCaracteres, string texto)
	{
		texto += "                                  " + texto;
		return texto.Substring(texto.Length - numCaracteres);
	}

	/// <summary>
	/// Cuadra un número con un decimal, alineándolo a la derecha
	/// </summary>
	/// <param name="num">Número a cuadrar en el espacio indicado por numCaracteres</param>
	/// <param name="numCharacteres">Número de caracteres de la cadena resultante</param>
	/// <returns>Devuelve una cadena que representa el número, con un decimal, alineado a la derecha dentro del número de caracteres indicado</returns>
	static string CuadraNumero(double num, int numCharacteres)
	{
		string texto = "                    " + num.ToString("0.0");
		return texto.Substring(texto.Length - numCharacteres);
	}

}

