/* P21g3 ColocaNumeros0a99Azar
Presenta los números [0..99] pero en lugar de colocarlos de forma consecutiva, 
obtiene 200 números aleatorios [0..99] y los coloca ada uno en su lugar correspondiente.
Como faltarán números por colocar, hacer que el usuario los ponga a mano 
en color blanco con fondo rojo. Acaba cuando escriba el valor 0.
   		//-- Cambiar a Blanco sobre Rojo
     	Console.BackgroundColor = ConsoleColor.Red;
   		Console.ForegroundColor = ConsoleColor.White;
*/


using System;

namespace P21g_Coloca_Nums_alAzar_099
{
    class Program
    {
        const int FILAPREGUNTA = 22; // <-- Fila donde voy a pedir los datos
        static void Main(string[] args)
        {
            Random azar = new Random();
            int num;
            // Colocamos 200 valores al azar entre 0 y 99
            for (int i = 0; i < 200; i++)
            {
                num = azar.Next(100);
                ColocaElNumero(num);
            }

            // vamos a completar la presentación
            do
            {
                // Coloco la pregunta donde me interesa
                Console.SetCursorPosition(10, FILAPREGUNTA);
                num = CapturaEntero("Dime el número a colocar: ", 0, 99);

                // Establezco el color blanco sobre rojo
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                // Escribo el número en su posición
                ColocaElNumero(num);
                // Establezco el color por defecto; amarillo sobre negro
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;

                // Limpio la línea de petición de datos
                Console.SetCursorPosition(10, FILAPREGUNTA);
                Console.Write("                                                     ");

            } while (num != 0);

            Console.Write("\n\t\tPulsa una tecla para salir");
            Console.ReadKey();

        }


        /// <summary>
        /// Calcula la posición que le corresponde a num en la pantalla y lo presenta en dicha posición
        /// </summary>
        /// <param name="num"> número a presentar en su posición correspondiente</param>
        static void ColocaElNumero(int num)
        {
            int columna, fila;
            // Posición de columna = 5 * <valor de la unidad de num> (+ 10 desplazamiento fijo a la derecha)
            columna = 10 + 5 * (num % 10);
            // Posición de fila = 2 * <valor de la decena de num> (+ 1 desplazamiento fijo hacia abajo)
            fila = 1 + 2 * (num / 10);

            // Colocamos el culsor en la posición calculada y escribimos el número
            Console.SetCursorPosition(columna, fila);
            Console.Write(num);
            //Emitimos un beep de frecuencia proporcional a num y 10ms de duración
            Console.Beep(200 + 40 * num, 100);
        }

        static int CapturaEntero(string texto, int min, int max)
        {
            int num;
            bool esCorrecto;
            do
            {
                Console.Write(" {0} [{1}..{2}]: ", texto, min, max);
                esCorrecto = Int32.TryParse(Console.ReadLine(), out num);
                if (!esCorrecto)
                    Console.WriteLine("\n\t ** ERROR de FORMATO **");
                else if (num < min || num > max)
                {
                    Console.WriteLine(" ** ERROR: VALOR FUERA DE RANGO **");
                    esCorrecto = false;
                }
            } while (!esCorrecto);

            return num;
        }

    }

}
