using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace P38
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("./Datos/Pacientes.txt", Encoding.Default);
            List<string> logsList = new List<string>();
            List<string> auxList = new List<string>();
            
            ReadFileAndSaveLogs(streamReader, logsList, auxList);

            int opcion;

            do 
            {
                Console.Clear();
                ShowMenu();
                opcion = CapturaEntero("para elegir una opción del menú", 0, 7);
                Console.Clear();

                switch (opcion)
                {
                    case 0:
						Console.WriteLine("Ha elegido la opción " + opcion + " de Salir.");
						break;

					case 1:
						SortById(logsList);
						break;

					case 2:
						SortBySurname(logsList);
						break;

					case 3:
						// SortByAge(logsList);
						break;

					case 4:
						// SortByHeight(logsList);
						break;

					case 5:
						// SortByWeight(logsList);
						break;

					case 6:
						// NoSort(logsList);
						break;

					case 7:
						SortByName(logsList);
						break;
                }

                ResetLogsList(logsList, auxList);
                BackToMenu();

            } while (opcion != 0);

            StopProgram();
        }

        /************************************* MÉTODOS *************************************/

        public static void ShowMenu()
        {	
			Console.WriteLine("\n\t\t╔═════════════════════════╗");
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

        public static void SortById(List<string> logsList)
        {
            string[] vLog = new string[6]; // id; Apellidos, Nombre; movil; fechaNac; altura; peso = 6 campos

            for (int i = 0; i < logsList.Count; i++)
            {
                vLog = logsList[i].Split(';');

                logsList[i] = Int32.Parse(vLog[0]).ToString("000") + ";" + vLog[1] + ";" + vLog[2] + ";" + vLog[3] + ";" + vLog[4] + ";" + vLog[5]; 
            }

            logsList.Sort();

            for (int i = 0; i < logsList.Count; i++)
            {
                vLog = logsList[i].Split(";");

                Console.WriteLine
                (
                    "{0}\t{1}\t{2}\t{3}\t{4}\t{5}",

                    Int32.Parse(vLog[0]).ToString("00"),
                    CuadraTexto(vLog[1], 30),
                    vLog[2],
                    vLog[3].Substring(6, 2) + "/" + vLog[3].Substring(4, 2) + "/" + vLog[3].Substring(0, 4),
                    vLog[4],
                    vLog[5]
                );
            }
        }

        public static void SortBySurname(List<string> logsList)
        {
            string[] vLog = new string[6]; // Apellidos, Nombre + id; Apellidos, Nombre; movil; fechaNac; altura; peso = 6 campos y duplicamos uno

            for (int i = 0; i < logsList.Count; i++)
            {
                vLog = logsList[i].Split(";");

                logsList[i] = vLog[1] + ";" + vLog[0] + ";" + vLog[1] + ";" + vLog[2] + ";" + vLog[3] + ";" + vLog[4] + ";" + vLog[5];
            }

            logsList.Sort();

            for (int i = 0; i < logsList.Count; i++)
            {
                vLog = logsList[i].Split(";");

                Console.WriteLine
                (
                    "{0}\t{1}\t{2}\t{3}\t{4}\t{5}",

                    Int32.Parse(vLog[1]).ToString("00"),
                    CuadraTexto(vLog[2], 30),
                    vLog[3],
                    vLog[4].Substring(6, 2) + "/" + vLog[4].Substring(4, 2) + "/" + vLog[4].Substring(0, 4),
                    vLog[5],
                    vLog[6]
                );
            }
        }

        public static void SortByName(List<string> logsList)
        {
            string[] vLog = new string[6];
            string[] surnameAndName = new string[2];
            string nameAndSurname = string.Empty;

            for (int i = 0; i < logsList.Count; i++)
            {
                vLog = logsList[i].Split(";");

                surnameAndName = vLog[1].Split(",");
                nameAndSurname = surnameAndName[1].Trim() + " " + surnameAndName[0].Trim();

                logsList[i] = nameAndSurname + ";" + vLog[0] + ";" + nameAndSurname + ";" + vLog[2] + ";" + vLog[3] + ";" + vLog[4] + ";" + vLog[5];
            }

            logsList.Sort();

            for (int i = 0; i < logsList.Count; i++)
            {
                vLog = logsList[i].Split(";");

                Console.WriteLine
                (
                    "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",

                    CuadraId(vLog[1]),
                    CuadraTexto(vLog[2], 30),
                    vLog[3],
                    vLog[4].Substring(6, 2) + "/" + vLog[4].Substring(4, 2) + "/" + vLog[4].Substring(0, 4),
                    2022 - Int32.Parse(vLog[4].Substring(0, 4)),
                    vLog[5],
                    CuadraPeso(vLog[6])
                );
            }
        }

        public static void ReadFileAndSaveLogs(StreamReader streamReader, List<string> logsList, List<string> auxList)
        {
            while (!streamReader.EndOfStream)
            {
                logsList.Add(streamReader.ReadLine());
            }

            foreach (var item in logsList)
            {
                auxList.Add(item);
            }

            streamReader.Close();
        }

        public static void ResetLogsList(List<string> logsList, List<string> auxList)
        {
            logsList.Clear();

            for (int i = 0; i < auxList.Count; i++)
            {
                logsList.Add(auxList[i]);
            }
        }

        public static int CapturaEntero(string pregunta, int min, int max)
        {
            int num;
            bool numOk;

            do 
            {
                Console.Write("\n\nPor favor, introduzca un número entre el [" + min + ", " + max + "] para " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.WriteLine("\n\nError. El dato introducido no es un valor numérico");
                }
                else if (num < min || num > max)
                {
                    Console.WriteLine("\n\nError. El número introducido debe estar entre [" + min + ", " + max + "]");
                    numOk = false;
                }
            
            } while (!numOk);

            return num;
        }

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += "...........................................";

            return texto.Substring(0, nCaracteres);
        }

        public static string CuadraId(string id)
        {
            if (id.Length < 3)
            {
                id = " " + id;
            }

            return id;
        }

        public static string CuadraPeso(string peso)
        {
            if (peso.Length < 5)
            {
                peso = " " + Double.Parse(peso).ToString("00.0");
            }

            return peso;
        }

        public static void BackToMenu()
        {
            Console.WriteLine("\n\nPress any key to back to menu.");
            Console.ReadKey(true);
        }

        public static void StopProgram()
        {
            Console.WriteLine("\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}