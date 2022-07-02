using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace P43a1_Proyecto_Puerta
{
    class Tools
    {
        Random random = new Random();

        public static float GenerarNota(Random random)
        {
            //Random random = new Random(); // AQUI NOO
            // float nota = float.Parse(random.Next(3, 10).ToString("0.00"));
            // float nota = random.Next(300, 1000) / 100F; // vProfesor // para dos decimales
            float nota = random.Next(30, 100) / 10F; // vProfesor // para un decimal

            return nota;
        }

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += ".........................................";

            return texto.Substring(0, nCaracteres);
        }

        public static bool PreguntaSiNo(string pregunta)
        {
            char tecla;

            do
            {
                // Hacemos la pregunta
                Console.Write("\n\n{0} (s=Sí; n=No): ", pregunta);
                // Capturamos la respuesta (una pulsación)
                tecla = (Console.ReadKey()).KeyChar;
                if (tecla == 's' || tecla == 'S')
                    return true;
                if (tecla == 'n' || tecla == 'N')
                    return false;
                // Si llega aquí es que no ha pulsado ninguna de las teclas correctas
                Console.Write("\n\n\t** Error: por favor, responde S o N **");

            } while (true);
        }

        #region CapturaEnteros
        public static int CapturaEntero_Normal(string pregunta, int min, int max)
        {

            int num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static int CapturaEntero_vProfesor(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                num = Console.ReadKey().KeyChar - '0';

                if (num < (char)0 || num > (char)7)
                {
                    Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                    numOk = false;
                }
                else if (num < min || num > max)
                {
                    Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }
                else
                {
                    numOk = true;
                }

            } while (!numOk);

            return num;
        }


        public static int CapturaEntero(int posScreen, string pregunta, int min, int max)
        {

            int num = 0;
            bool numOk;

            do
            {
                //Console.SetCursorPosition(posScreen, 2);
                //Console.Write("                                                 ");
                //Console.SetCursorPosition(posScreen, 2);
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    //Console.SetCursorPosition(posScreen, 4);
                    //Console.Write("                                             ");
                    //Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    //Console.SetCursorPosition(posScreen, 4);
                    //Console.Write("                                             ");
                    //Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static int CapturaEntero(string pregunta, int min, int max, int defaultValue)
        {
            int num = 0;
            bool numOk;
            string aux = string.Empty;
            int posX;
            int posY;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                posX = Console.CursorLeft;
                posY = Console.CursorTop;
                aux = Console.ReadLine();
                numOk = Int32.TryParse(aux, out num);

                if (!numOk && aux != "")
                {
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (!numOk && aux == "")
                {
                    Console.SetCursorPosition(posX, posY);
                    Console.WriteLine(defaultValue);
                }
                else if (num < min || num > max)
                {
                    Console.Write("Error. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk && aux != "");

            if (aux == "")
            {
                num = defaultValue;
            }

            return num;
        }

        public static int CapturaEntero(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;
            string aux = string.Empty;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + "(escriba [fin] para terminar):\t");

                aux = Console.ReadLine().ToLower();
                numOk = Int32.TryParse(aux, out num);

                if (!numOk && aux != "fin")
                {
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("Error. Número introducido fuera de rango.");
                    numOk = false;
                }

            } while (!numOk && aux != "fin");

            return num;
        }

        public static float CapturaFloat(string pregunta, int min, int max)
        {

            float num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Single.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("Error. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }
        #endregion

        public static void BackToMenu(int opcion)
        {
            if (opcion < 6 && opcion > 0)
            {
                Console.WriteLine("\n\n\n\tPress any key to back to menú.");
                Console.ReadKey(true);
            } 
            else if (opcion == 0)
            {
                Console.WriteLine("\n\tPulse una tecla para salir.");
                Console.ReadKey(true);
            }
            
        }

        public static void StopProgram()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\tMuchas gracias por utilizar nuestro programa.");
            Thread.Sleep(1785);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ShowMenu()
        {
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\t\t\t╔═════════════════════╗");
            Console.WriteLine("\t\t\t║   MENÚ de PUERTA    ║");
            Console.WriteLine("\t\t\t╠═════════════════════╣");
            Console.WriteLine("\t\t\t║     1) Abrir        ║");
            Console.WriteLine("\t\t\t║                     ║");
            Console.WriteLine("\t\t\t║     2) Cerrar       ║");
            Console.WriteLine("\t\t\t║                     ║");
            Console.WriteLine("\t\t\t║     3) Mostrar      ║");
            Console.WriteLine("\t\t\t║                     ║");
            Console.WriteLine("\t\t\t║     4) Pintar       ║");
            Console.WriteLine("\t\t\t║                     ║");
            Console.WriteLine("\t\t\t║     5) Modificar    ║");
            Console.WriteLine("\t\t\t║_____________________║");
            Console.WriteLine("\t\t\t║                     ║");
            Console.WriteLine("\t\t\t║     0) Salir        ║");
            Console.WriteLine("\t\t\t╚═════════════════════╝");
        }

        public static ConsoleColor EligeColor()
        {
            ConsoleColor[] vColores = { ConsoleColor.Gray, ConsoleColor.DarkBlue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.DarkMagenta, ConsoleColor.Yellow, ConsoleColor.White };

            Console.WriteLine("\n\tElige un color\n");

            for (int i = 0; i < vColores.Length; i++)
            {
                Console.ForegroundColor = vColores[i];
                Console.WriteLine("\t" + (i+1) + ")  " + "████████ ◄ " + vColores[i]);
                Console.ResetColor();
            }

            int indice = CapturaEntero_vProfesor("\t¿Color?", 1, 8);

            Console.WriteLine("\n\n\tEl color de la puerta se ha pintado en " + vColores[indice -1]);

            return vColores[indice -1];
        }

    }
}
