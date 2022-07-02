using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P40c_Cliente_Fecha
{
    class Tools
    {
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

        public static int CapturaEntero(int posScreen, string pregunta, int min, int max)
        {

            int num = 0;
            bool numOk;

            do
            {
                //Console.SetCursorPosition(posScreen, 2);
                //Console.Write("                                                 ");
                //Console.SetCursorPosition(posScreen, 2);
                Console.Write("Introduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
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


        public static void StopProgram()
        {
            Console.WriteLine("\n\n\n\tPress any key to exit.");
            Console.ReadKey(true);
        }

    }
}