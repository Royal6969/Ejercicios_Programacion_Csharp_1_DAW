/*
 * MultiplosMenoresDe:
Pide un entero, num, de dos cifras y otro, tope, del valor que quieras pero positivo. 
Esto lo harás utilizando dos versiones de CapturaEntero.
Presenta los múltiplos de num menores que tope.
Para esto utilizará el método MultiplosMenoresDe que...
• Recibe: Dos enteros: num y limiteSup.
• Hace: Presenta los múltiplos de num menores de limiteSup
• Devuelve: La suma de los números presentados.
En el programa se pedirá un número de dos cifras y se llamará a este método.
Tras la presentación mostrará la suma calculada.
 */

using System;

namespace P21d_Multiplos_Menores_De_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            num = CapturaEntero_v1(num);

            int min = 0;
            min = CapturaEntero_v2(num, min);

            int max = 0;
            max = CapturaEntero_v3(num, max);

            Console.Write("\n\nLos múltiplos de " + num + " que hay entre " + min + " y " + max + " son:");
            int sumaMultiplos = 0;
            sumaMultiplos = MultiplosMenoresDe(num, min, max);

            Console.Write("\n\nY la suma de todos estos múltiplos es:\t" + sumaMultiplos);

            PararPrograma();
        }

        /******************************* MÉTODOS **********************************/

        public static int CapturaEntero_v1(int num)
        {
            bool numOk;
            do
            {
                Console.Write("\n\nPor favor, introduzca un número entero positivo de dos cifras.\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\nError. El dato introducido no es un valor numérico.");
                }
                else if (num < 10 || num > 99)
                {
                    Console.Write("\nError. El número introducido tiene que tener dos cifras y ser positivo.");
                    numOk = false;
                }

            } while (!numOk);
            

            return num;
        }

        public static int CapturaEntero_v2(int num, int min)
        {
            bool minOk;
            do
            {
                Console.Write("\n\nPor favor, introduzca un número entero positivo de dos cifras para el mínimo del rango.\t");
                minOk = Int32.TryParse(Console.ReadLine(), out min);

                if (!minOk)
                {
                    Console.Write("\nError. El dato introducido no es un valor numérico.");
                }
                else if (min > num)
                {
                    Console.Write("\nError. El mínimo introducido tiene que estar por debajo del número principal.");
                    minOk = false;
                }
                else if (min < 10 || min > 99)
                {
                    Console.Write("\nError. El mínimo introducido tiene que tener dos cifras y ser positivo.");
                    minOk = false;
                }

            } while (!minOk);

            return min;
        }

        public static int CapturaEntero_v3(int num, int max)
        {
            bool maxOk;
            do
            {
                Console.Write("\n\nPor favor, introduzca un número entero positivo de dos cifras para el máximo del rango.\t");
                maxOk = Int32.TryParse(Console.ReadLine(), out max);

                if (!maxOk)
                {
                    Console.Write("\nError. El dato introducido no es un valor numérico.");
                }
                else if (max < num)
                {
                    Console.Write("\nError. El máximo introducido tiene que estar por arriba del número principal.");
                    maxOk = false;
                }
                else if (max < 10 || max > 99)
                {
                    Console.Write("\nError. El máximo introducido tiene que tener dos cifras y ser positivo.");
                    maxOk = false;
                }

            } while (!maxOk);

            return max;
        }

        public static int MultiplosMenoresDe(int num, int min, int max)
        {
            int sumaMultiplos = 0;

            for (int i=min; i<max; i++)
            {
                if(i % num == 0)
                {
                    Console.Write("\t" + i);
                    sumaMultiplos += i;
                }    
            }

            return sumaMultiplos;
        }

        public static void PararPrograma()
        {
            Console.Write("\n\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}