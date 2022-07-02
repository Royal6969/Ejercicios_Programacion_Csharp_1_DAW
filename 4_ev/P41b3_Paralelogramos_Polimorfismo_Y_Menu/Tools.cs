using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P41b3_Paralelogramos_Polimorfismo_Y_Menu
{
    class Tools
    {

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += "                                         ";

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

        public static int CapturaEntero(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

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

        public static string CapturaNombreRectangulo(int posScreen, string pregunta, string defaultName)
        {

            string nombreRectangulo = string.Empty;
            bool nombreOk = false;
            int posX;
            int posY;

            do
            {
                Console.Write("\n\nIntroduzca un nombre, " + pregunta + ":\t");
                posX = Console.CursorLeft;
                posY = Console.CursorTop;
                nombreRectangulo = Console.ReadLine().Trim();

                if (nombreRectangulo == " ")
                {
                    Console.Write("Error. El nombre introducido para el Rectángulo no puede dejarse en blanco.");
                    nombreOk = false;
                }
                else if (nombreRectangulo == "")
                {
                    nombreOk = true;
                    nombreRectangulo = defaultName;
                    Console.SetCursorPosition(posX, posY);
                    Console.WriteLine(nombreRectangulo);
                }
                else if (nombreRectangulo.Length > 8)
                {
                    Console.Write("Error. El nombre introducido para el Rectángulo no puede tener más de 8 caracteres.");
                    nombreOk = false;
                }
                else
                {
                    nombreOk = true;
                }

            } while (!nombreOk);

            return nombreRectangulo;
        }

        public static float CapturaFloat(int posScreen, string pregunta, int min, int max)
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

        public static double CapturaDouble(int posScreen, string pregunta, int min, int max)
        {

            double num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Double.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("Error. El número introducido no puede ser superior a " + max + " ni inferior a " + min);
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static void BackToMenu()
        {
            Console.WriteLine("\n\n\n\tPress any key to back to menu.");
            Console.ReadKey(true);
        }

        public static void StopProgram()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\tPress any key to exit.");
            Console.ReadKey(true);
        }

    }
}
