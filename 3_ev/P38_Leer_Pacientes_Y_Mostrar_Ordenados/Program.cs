using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace P38_Leer_Pacientes_Y_Mostrar_Ordenados
{
	class Program
	{
		static double suma = 0;

		static void Main(string[] args)
		{
			StreamReader streamReader = new StreamReader("./Datos/Pacientes.txt", Encoding.Default);
			List<string> logsList = new List<string>();
			List<string> auxList = new List<string>();

			ReadFileAndSaveLogs(streamReader, logsList, auxList);

			int opcion = 0;

			do
			{
				Console.Clear();
				ShowMenu();

				opcion = CapturaEntero(0, "para seleccionar una opción del menú", 0, 7);
				Console.Clear();

				SetHeader(opcion);

				switch (opcion)
				{
					case 0:
						Console.Clear();
						Console.WriteLine("Ha elegido la opción " + opcion + " de Salir.");
						break;

					case 1:
						SortByIDs(logsList);
						ResetLogsList(logsList, auxList);
						break;

					case 2:
						SortBySurname(logsList);
						ResetLogsList(logsList, auxList);
						break;

					case 3:
						SortByAge(logsList);
						ResetLogsList(logsList, auxList);
						break;

					case 4:
						SortByHeight(logsList);
						ResetLogsList(logsList, auxList);
						break;

					case 5:
						SortByWeight(logsList);
						ResetLogsList(logsList, auxList);
						break;

					case 6:
						NoSort(logsList);
						ResetLogsList(logsList, auxList);
						break;

					case 7:
						SortByName(logsList);
						ResetLogsList(logsList, auxList);
						break;
				}

				BackToMenu();

			} while (opcion != 0);

			PararPrograma();
		}

		/**************************************************************/

		public static void ShowMenu()
		{
			Console.WriteLine("\n\n\n\n\n\n\t\t╔═════════════════════════╗");
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
			Console.WriteLine("\t\t║                         ║");
			Console.WriteLine("\t\t║   7) Nombre Apellidos   ║");
			Console.WriteLine("\t\t║_________________________║");
			Console.WriteLine("\t\t║                         ║");
			Console.WriteLine("\t\t║      0)  Salir          ║");
			Console.WriteLine("\t\t╚═════════════════════════╝");
		}

		public static void ReadFileAndSaveLogs(StreamReader streamReader, List<string> logsList, List<string> auxList)
		{
			while (!streamReader.EndOfStream)
			{
				logsList.Add(streamReader.ReadLine());
			}

			for (int i = 0; i < logsList.Count; i++)
			{
				auxList.Add(logsList[i]);
			}

			streamReader.Close();
		}

		public static int CapturaEntero(int posScreen, string pregunta, int min, int max)
		{
			int num = 0;
			bool numOk;

			do
			{
				Console.SetCursorPosition(posScreen, 2);
				Console.Write("                                                                                                                                                                        ");
				Console.SetCursorPosition(posScreen, 2);
				Console.Write("Introduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
				numOk = Int32.TryParse(Console.ReadLine(), out num);

				if (!numOk)
				{
					Console.SetCursorPosition(posScreen, 4);
					Console.Write("                                                                                                                                                                        ");
					Console.SetCursorPosition(posScreen, 4);
					Console.Write("Error. El dato introducido no es un valor numérico.");
				}
				else if (num < min || num > max)
				{
					Console.SetCursorPosition(posScreen, 4);
					Console.Write("                                                                                                                                                                        ");
					Console.SetCursorPosition(posScreen, 4);
					Console.Write("Error. Esa opción no se encuentra en el menú.");
					numOk = false;
				}

			} while (!numOk);

			return num;
		}

		public static void SortByIDs(List<string> logsList)
		{
			string[] vLog = new string[6];

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				logsList[i] = Int32.Parse(vLog[0]).ToString("000") + ";" + vLog[1] + ";" + vLog[2] + ";" + vLog[3] + ";" + vLog[4] + ";" + vLog[5];
			}

			logsList.Sort();

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				Console.WriteLine
				(
					"{0}\t{1}\t{2}\t{3}\t{4}\t{5}",

					CuadraIDs(Int32.Parse(vLog[0]).ToString("00")),
					CuadraTexto(vLog[1], 30),
					vLog[2],
					vLog[3].Substring(6, 2) + "/" + vLog[3].Substring(4, 2) + "/" + vLog[3].Substring(0, 4),
					vLog[4],
					CuadraPesos(vLog[5])
				);
			}

			CalculateAndShowWeightAverage(logsList, vLog);
		}

		public static void SortBySurname(List<string> logsList)
		{
			string[] vLog = new string[7];

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				logsList[i] = vLog[1] + ";" + vLog[0] + ";" + vLog[1] + ";" + vLog[2] + ";" + vLog[3] + ";" + vLog[4] + ";" + vLog[5];
			}

			logsList.Sort();

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				Console.WriteLine
				(
					"{0}\t{1}\t{2}\t{3}\t{4}\t{5}",

					CuadraIDs(Int32.Parse(vLog[1]).ToString("00")),
					CuadraTexto(vLog[2], 30),
					vLog[3],
					vLog[4].Substring(6, 2) + "/" + vLog[4].Substring(4, 2) + "/" + vLog[4].Substring(0, 4),
					vLog[5],
					CuadraPesos(vLog[6])
				);
			}

			CalculateAndShowWeightAverage(logsList, vLog);
		}

		public static void SortByAge(List<string> logsList)
		{
			string[] vLog = new string[7];

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				logsList[i] = Int32.Parse(vLog[3]) + ";" + vLog[0] + ";" + vLog[1] + ";" + vLog[2] + ";" + vLog[3] + ";" + vLog[4] + ";" + vLog[5];
			}


			logsList.Sort();
			logsList.Reverse();

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				Console.WriteLine
				(
					"{0}\t{1}\t{2}\t{3}\t{4}\t{5}",

					CuadraIDs(Int32.Parse(vLog[1]).ToString("00")),
					CuadraTexto(vLog[2], 30),
					vLog[3],
					(vLog[4].Substring(6, 2) + "/" + vLog[4].Substring(4, 2) + "/" + vLog[4].Substring(0, 4)).ToString(),
					vLog[5],
					CuadraPesos(vLog[6])
				);
			}

			CalculateAndShowWeightAverage(logsList, vLog);
		}

		public static void SortByHeight(List<string> logsList)
		{
			string[] vLog = new string[7];

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				logsList[i] = Int32.Parse(vLog[4]) + ";" + vLog[0] + ";" + vLog[1] + ";" + vLog[2] + ";" + vLog[3] + ";" + vLog[4] + ";" + vLog[5];
			}

			logsList.Sort();

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				Console.WriteLine
				(
					"{0}\t{1}\t{2}\t{3}\t{4}\t{5}",

					CuadraIDs(Int32.Parse(vLog[1]).ToString("00")),
					CuadraTexto(vLog[2], 30),
					vLog[3],
					vLog[4].Substring(6, 2) + "/" + vLog[4].Substring(4, 2) + "/" + vLog[4].Substring(0, 4),
					vLog[5],
					CuadraPesos(vLog[6])
				);
			}

			CalculateAndShowWeightAverage(logsList, vLog);
		}

		public static void SortByWeight(List<string> logsList)
		{
			string[] vLog = new string[7];

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				if (double.Parse(vLog[5]) < 100.0 && double.Parse(vLog[5]) > 9.9)
				{
					vLog[5] = 0 + vLog[5];
				}

				logsList[i] = (double.Parse(vLog[5])).ToString("000.00") + ";" + vLog[0] + ";" + vLog[1] + ";" + vLog[2] + ";" + vLog[3] + ";" + vLog[4] + ";" + vLog[5];
			}

			logsList.Sort();

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				Console.WriteLine
				(
					"{0}\t{1}\t{2}\t{3}\t{4}\t{5}",

					CuadraIDs(Int32.Parse(vLog[1]).ToString("00")),
					CuadraTexto(vLog[2], 30),
					vLog[3],
					vLog[4].Substring(6, 2) + "/" + vLog[4].Substring(4, 2) + "/" + vLog[4].Substring(0, 4),
					vLog[5],
					CuadraPesos(vLog[6])
				);
			}

			CalculateAndShowWeightAverage(logsList, vLog);
		}

		public static void NoSort(List<string> logsList)
		{
			string[] vLog = new string[6];

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				Console.WriteLine
				(
					"{0}\t{1}\t{2}\t{3}\t{4}\t{5}",

					CuadraIDs(Int32.Parse(vLog[0]).ToString("00")),
					CuadraTexto(vLog[1], 30),
					vLog[2],
					vLog[3].Substring(6, 2) + "/" + vLog[3].Substring(4, 2) + "/" + vLog[3].Substring(0, 4),
					vLog[4],
					CuadraPesos(vLog[5])
				);
			}

			CalculateAndShowWeightAverage(logsList, vLog);
		}

		public static void SortByName(List<string> logsList)
		{
			string[] vLog = new string[7];
			string[] nameSurname = new string[2];
			string name = string.Empty;
			string surname = string.Empty;

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				nameSurname = vLog[1].Split(',');
				name = nameSurname[1].Trim();
				surname = nameSurname[0];
				vLog[1] = name + " " + surname;

				logsList[i] = vLog[1] + ";" + vLog[0] + ";" + vLog[1] + ";" + vLog[2] + ";" + vLog[3] + ";" + vLog[4] + ";" + vLog[5];
			}

			logsList.Sort();

			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				Console.WriteLine
				(
					"{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",

					CuadraIDs(Int32.Parse(vLog[1]).ToString("00")),
					CuadraTexto(vLog[2], 30),
					vLog[3],
					vLog[4].Substring(6, 2) + "/" + vLog[4].Substring(4, 2) + "/" + vLog[4].Substring(0, 4),
					2022 - Int32.Parse(vLog[4].Substring(0, 4)),
					vLog[5],
					CuadraPesos(vLog[6])
				);
			}

			CalculateAndShowWeightAverage(logsList, vLog);
		}

		public static void CalculateAndShowWeightAverage(List<string> logsList, string[] vLog)
		{
			for (int i = 0; i < logsList.Count; i++)
			{
				vLog = logsList[i].Split(';');

				if (vLog.Length == 6)
				{
					suma += double.Parse(vLog[5]);
				}
				else if (vLog.Length == 7)
				{
					suma += double.Parse(vLog[6]);
				}

			}

			Console.WriteLine("\n\nEl peso medio de todos los pacientes es:\t" + Math.Round((suma / logsList.Count), 2).ToString("00.00") + " kg");

			suma = 0;
		}

		public static void ResetLogsList(List<string> logsList, List<string> auxList)
		{
			logsList.Clear();

			for (int i = 0; i < auxList.Count; i++)
			{
				logsList.Add(auxList[i]);
			}
		}

		public static string CuadraIDs(string vLog)
		{
			if (vLog.Length < 3)
			{
				vLog = " " + Convert.ToString(Int32.Parse(vLog).ToString("00"));
			}
			else
			{
				vLog = Convert.ToString(Int32.Parse(vLog).ToString("000"));
			}

			return vLog;
		}

		public static string CuadraPesos(string vLog)
		{
			if (vLog.Length < 5)
			{
				vLog = " " + Convert.ToString(double.Parse(vLog).ToString("00.00"));
			}
			else
			{
				vLog = Convert.ToString(double.Parse(vLog).ToString("000.00"));
			}

			return vLog;
		}

		public static string CuadraTexto(string texto, int nCaracteres)
		{
			texto += ".........................................";

			return texto.Substring(0, nCaracteres);
		}

		public static void SetHeader(int opcion)
		{
			if (opcion != 0 && opcion != 7)
			{
				Console.WriteLine("\nId\tPaciente\t\t\tMovil\t\tFecha Nac.\tAlt.\tPeso");
				Console.WriteLine("--------------------------------------------------------------------------------------");
			}
			else if (opcion == 7)
			{
				Console.WriteLine("\nId\tPaciente\t\t\tMovil\t\tFecha Nac.\tAge\tAlt.\tPeso");
				Console.WriteLine("----------------------------------------------------------------------------------------------");
			}
		}

		public static void BackToMenu()
		{
			Console.WriteLine("\n\nPress any key to back to menu.");
			Console.ReadKey(true);
		}

		public static void PararPrograma()
		{
			Console.Clear();
			Console.WriteLine("\n\n\t Pulsa una tecla para salir");
			Console.ReadKey(true);
		}
	}
}

/*
Curiosidad:

para el formato de la fecha, intenté varias conversiones ...

DateTime.ParseExact(log[3], "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString(),
Convert.ToDateTime(log[3]).ToString("dd, MM", CultureInfo.InvariantCulture),

Enlaces de interés:

Cadenas con formato de fecha y hora estándar:
https://docs.microsoft.com/es-es/dotnet/standard/base-types/standard-date-and-time-format-strings

Parse date and time strings in .NET:
https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-datetime

Convert.ToDateTime Método:
https://docs.microsoft.com/es-es/dotnet/api/system.convert.todatetime?view=net-6.0


Videos de interés:

Convert Date Time Strings to DateTime C#
https://www.youtube.com/watch?v=2s4gjtBqLU8
*/