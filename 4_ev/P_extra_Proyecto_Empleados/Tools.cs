using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace P_Proyecto_Empleados
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
            texto += "                                                                                                                                           ";

            return texto.Substring(0, nCaracteres);
        }

        public static bool PreguntaSiNo(string pregunta)
        {
            char tecla;

            do
            {
                // Hacemos la pregunta
                Console.Write("\n\n\t{0} (s=Sí; n=No): ", pregunta);
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
                    //Error_Pro("Error. El dato introducido no es un valor numérico.", 24, 5);
                    //Error_vProfesor2("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    //Error_Pro("Error. Esa opción no se encuentra en el menú.", 24, 5);
                    //Error_vProfesor2("Error. Esa opción no se encuentra en el menú.");
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

                if (num < (char)0 || num > (char)9)
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

        public static int CapturaEntero_Limpiando_v1(string pregunta, int min, int max)
        {

            int num = 0;
            bool numOk;

            do
            {
                RowCleaner(20);
                Console.SetCursorPosition(10, 20);
                Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    //Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                    Error_vProfesor2("El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    //Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    Error_vProfesor2("Opción fuera del rango permitido.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static int CapturaEntero_Limpiando_v2(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                RowCleaner(20);
                Console.SetCursorPosition(10, 20);
                Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                num = Console.ReadKey(true).KeyChar - '0';

                if (num < (char)0 || num > (char)9)
                {
                    //Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                    Error_vProfesor2("El dato introducido no es un valor numérico.");
                    numOk = false;
                }
                else if (num < min || num > max)
                {
                    //Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    Error_vProfesor2("Esa opción no se encuentra en el menú.");
                    numOk = false;
                }
                else
                {
                    numOk = true;
                }

            } while (!numOk);

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
            if (opcion < 7 && opcion > 0)
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

        public static void StopProgram_v1()
        {
            Console.WriteLine("\n\n\n\tMuchas gracias por utilizar nuestro programa.");
            Console.ReadLine(); 
        }

        public static void StopProgram_v2()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\tMuchas gracias por utilizar nuestro programa.");
            Thread.Sleep(1785);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ShowMenu()
        {
            Console.WriteLine("\n\n\t\t\t╔════════════════════════════╗");
            Console.WriteLine("\t\t\t║ Opciones del Piloto        ║");
            Console.WriteLine("\t\t\t╠════════════════════════════╣");
            Console.WriteLine("\t\t\t║ 1) Aumentar Velocidad      ║");
            Console.WriteLine("\t\t\t║ 2) Disminuir Velocidad     ║");
            Console.WriteLine("\t\t\t║ 3) Despegar                ║");
            Console.WriteLine("\t\t\t║ 4) Aumentar Altitud        ║");
            Console.WriteLine("\t\t\t║ 5) Disminuir Altitud       ║");
            Console.WriteLine("\t\t\t║ 6) Aterrizar               ║");
            Console.WriteLine("\t\t\t║                            ║");
            Console.WriteLine("\t\t\t║ 0) Salir                   ║");
            Console.WriteLine("\t\t\t║                            ║");
            Console.WriteLine("\t\t\t╚════════════════════════════╝");
        }

        public static ConsoleColor EligeColor()
        {
            ConsoleColor[] vColores = { ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.DarkBlue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White }; // el primero no sirve

            Console.WriteLine("\n\tElige un color\n");

            for (int i = 1; i < vColores.Length; i++)
            {
                Console.ForegroundColor = vColores[i];
                Console.WriteLine("\t" + (i) + ")  " + "████████ ◄ " + vColores[i]);
                Console.ResetColor();
            }

            int indice = CapturaEntero_vProfesor("\t¿Color?", 1, 8);

            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\n\n\tEl color de la puerta se ha pintado en "); Console.ForegroundColor = vColores[indice];
            Console.WriteLine(vColores[indice]);
            Console.ResetColor();

            return vColores[indice];
        }

        #region Errores
        public static void Error(string texto)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n\n\t** ¡" + texto + "! **");

            Console.ResetColor();
        }

        public static void Error_vPro1(string texto, int fila, int columna)
        {
            int max = texto.Length;
            int posX = Console.CursorLeft;
            int posY = Console.CursorTop;

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.SetCursorPosition(columna, fila);
            Console.Write("╔═══ERROR");
            
            for (int j = 0; j < max + 4 - 8; j++)
                Console.Write("═");
            
            Console.WriteLine("╗");

            Console.SetCursorPosition(columna, fila + 1);
            
            Console.Write("║  ");
            Console.Write(texto);
            Console.Write("  ║");
            Console.WriteLine("█");

            Console.SetCursorPosition(columna, fila + 2);
            
            Console.Write("╚");
            
            for (int j = 0; j < max + 4; j++)
                Console.Write("═");
            
            Console.Write("╝");
            Console.WriteLine("█");
            Console.SetCursorPosition(columna + 1, fila + 3);
            
            for (int j = 0; j < max + 6; j++)
                Console.Write("▀");

            Console.ResetColor();

            Console.SetCursorPosition(posX, posY); // volvemos a poner el cursor donde estaba antes de llamar a este método

            // Nota para mejorar: hacer que previamente a mostrar el error, limpie ese espacio de la pantalla (tales filas)
        }

        public static void Error_vPro2(string texto)
        {
            int max = texto.Length;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition((Console.WindowWidth - max - 4) / 2, Console.CursorTop + 2);
            Console.Write("╔═══ERROR");
            for (int j = 0; j < max + 4 - 8; j++)
                Console.Write("═");
            Console.WriteLine("╗");
            Console.SetCursorPosition((Console.WindowWidth - max - 4) / 2, Console.CursorTop);
            Console.Write("║  ");
            Console.Write(texto);
            Console.Write("  ║");
            Console.WriteLine("█");
            Console.SetCursorPosition((Console.WindowWidth - max - 4) / 2, Console.CursorTop);
            Console.Write("╚");
            for (int j = 0; j < max + 4; j++)
                Console.Write("═");
            Console.Write("╝");
            Console.WriteLine("█");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(((Console.WindowWidth - max - 4) / 2) + 1, Console.CursorTop);
            for (int j = 0; j < max + 6; j++)
                Console.Write("▀");
            Console.Beep();
            Console.ResetColor();
        }

        public static void Error_vProfesor2(string texto)
        {
            int num = 24;
            texto = $"*** Error: {texto} ***";
            int length = texto.Length;
            int left = (80 - length) / 2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(left, num);
            Console.Write(texto);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Beep(400, 400);
            Console.ReadKey();
            RowCleaner(num);

            Console.ResetColor();
        }
        #endregion

        #region Mensajes
        public static void MensajeOK_vProfesor1(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\tOK: {0}. Pulse una tecla.", mensaje);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ReadKey();
            Console.Beep(1000, 100);
        }

        public static void MensajeOK_vProfesor2(string texto)
        {
            int num = 24;
            texto = $"{texto}";
            int length = texto.Length;
            int left = (80 - length) / 2;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(left, num);
            Console.Write(texto);
            Console.Beep(400, 400);
            Console.ReadKey();
            RowCleaner(num);

            Console.ResetColor();
        }
        #endregion

        public static void RowCleaner(int row)
        {
            Console.SetCursorPosition(0, row);
            Console.Write("                                                                                                                 ");
        }
    }
}
