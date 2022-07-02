/*
El programa pedirá los límites mínimo y máximo (ambos enteros de tres cifras) 
y presentará los números impares entre estos dos valores, 
sin incluir ninguno de los dos.

Se tiene que comprobar que son de tres cifras y que mínimo no es mayor que máximo. 
Si no cumple estas condiciones, da mensaje de error y vuelve a pedir el valor. 
(Nota: Es obvio que tendrás que usar CapturaEntero)

Para presentar los impares se llamará al método siguiente:
ImparesEntreLímites, que:
• Recibe: Dos enteros min y max.
• Hace: Presenta los números impares entre min y max, sin incluir ninguno de los dos.
• Devuelve: Nada.

Avanzado: 
El método recibe también el número de columnas y en la llamada se hará que se presente en 6 columnas.

EXTRA: Avanzado vSergio:
El método recibe también el número de columnas,
el cual ya vendrá recogido de antemano por otro método, 
que pedirá al usuario el número de columnas en que se presentarán sus impares.
 */

using System;

namespace P21c_Impares_Entre_Limites_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 0;
            min = CapturaEntero_v1(min);

            int max = 0;
            max = CapturaEntero_v2(min, max);

            int nCol = 0;
            nCol = PresentarEnColumnas();

            Console.Write("\n\nLos múltiplos de que hay entre " + min + " y " + max + " son:\n\n");
            PresentarImparesEntreLimites(min, max, nCol);
        }

        /*********************************************** MÉTODOS ********************************************/

        public static int CapturaEntero_v1(int min)
        {
            bool minOk;
            do
            {
                Console.Write("\n\nPor favor, introduzca un número entero positivo de tres cifras para el mínimo del rango:\t");
                minOk = Int32.TryParse(Console.ReadLine(), out min);

                if (!minOk)
                {
                    Console.Write("\nError. El dato introducido no es un valor numérico.");
                }
                else if (min < 100 || min > 999)
                {
                    Console.Write("\nError. El mínimo introducido tiene que tener tres cifras y ser positivo.");
                    minOk = false;
                }

            } while (!minOk);

            return min;
        }

        public static int CapturaEntero_v2(int min, int max)
        {
            bool maxOk;
            do
            {
                Console.Write("\n\nPor favor, introduzca un número entero positivo de dos cifras para el máximo del rango:\t");
                maxOk = Int32.TryParse(Console.ReadLine(), out max);

                if (!maxOk)
                {
                    Console.Write("\nError. El dato introducido no es un valor numérico.");
                }
                else if (max < min)
                {
                    Console.Write("\nError. El máximo introducido tiene que estar por encima del mínimo.");
                    maxOk = false;
                }
                else if (max == min)
                {
                    Console.Write("\nError. El máximo introducido no puede ser igual que el mínimo.");
                    maxOk = false;
                }
                else if (max < 100 || max > 999)
                {
                    Console.Write("\nError. El máximo introducido tiene que tener tres cifras y ser positivo.");
                    maxOk = false;
                }

            } while (!maxOk);

            return max;
        }

        public static void PresentarImparesEntreLimites(int min, int max, int nCol)
        {
            int contCol = 0;

            for(int i=min+1; i<max; i++)
            {
                if(i % 2 != 0)
                {
                    Console.Write(i + "\t");
                    contCol ++;

                    if(contCol == nCol)
                    {
                        Console.WriteLine();
                        contCol = 0;
                    }
                }
            }
        }

        public static int PresentarEnColumnas()
        {
            int nCol;

            bool nColOk;
            do
            {
                Console.Write("\n\nPor favor, introduzca el número de columnas para el que se van a presentar los números impares:\t");
                nColOk = Int32.TryParse(Console.ReadLine(), out nCol);

                if(!nColOk)
                {
                    Console.Write("\nError. El dato introducido no es un valor numérico.");
                }
                else if(nCol < 0)
                {
                    Console.Write("\nError. El número introducido tiene que ser un entero y positivo.");
                    nColOk = false;
                }
                else if(nCol > 20)
                {
                    Console.Write("\nError. Son demasiadas columnas, podrían salirse de su pantalla !.");
                    nColOk = false;
                }

            } while (!nColOk);

            return nCol;
        }

        public static void PararPrograma()
        {
            Console.Write("\n\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
