// P21g Mostrar en pantalla

/*
1-MuestraNums0a99:
Presentará en pantalla los números, del 0 al 99 en 10 filas de 10
columnas. Para que los números queden bien distribuidos, haremos que
las columnas vayan de 5 en 5 espacios y las filas vayan separadas una
posición.
*/

/*
2-ColocaNums0a99:
Repetir el apartado anterior pero calculando la posición de cada número
en función de su valor. Para ello utilizar el método...
ColocaElNumero que...
Recibe: un entero num que valdrá entre 0 y 99
Hace: Calcula la posición que le corresponde a num en la pantalla y lo
presenta en dicha posición
Nota: Hay utilizar Console.SetCursorPosition(columna,fila)
Pistas: columna = 10 + 5 * <unidad del número> ;
fila = 2 + 2 * <decena del número >;

Valor añadido: Además, hacer que se produzca un bip, en el que la
frecuencia también se calcule a partir del número:
Console.Beep(int frecuencia, int duración).
*/

/*
3-ColocaNúms0a99Azar
Repetir el anterior pero colocándolos de forma aleatoria en 200 intentos.
Como faltarán números por colocar, 
hacer que el usuario los ponga a mano 
en color blanco con fondo rojo (ver ejemplo). 
Acaba cuando escriba el valor 0.

    -- Cambiamos a Blanco sobre Rojo
Console.BackgroundColor = ConsoleColor.Red;
Console.ForegroundColor = ConsoleColor.White;
*/

using System;
using System.Threading;

namespace P21g_Coloca_Nums_099
{
    class Program
    {
        static void Main(string[] args)
        {
            ColocaNums0a99();

            PararPrograma();
        }

        /**************************************** MÉTODOS *************************************/

        /// <summary>
        /// Coloca los números [0..99] pero llamando a ColocaElNumero
        /// </summary>
        static void ColocaNums0a99()
        {
            for (int i = 0; i < 100; i++)
            {
                ColocaElNumero(i);
                //Emitimos un beep de frecuencia proporcional a num y 10ms de duración
                Console.Beep(200 + 40 * i, 100);
            }
        }

        /// <summary>
        /// Recibe un número y lo presenta en pantalla en la posición que le corresponde.
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
        }

        public static void PararPrograma()
        {
            Thread.Sleep(1300);
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }

        public static void CleanScreen()
        {
            Console.Clear();
            Thread.Sleep(1275);
        }
    }
}