/*
Vector con Dimensión Dinámica:

Pide al usuario el tamaño de una tabla de enteros [5..20].
Se construye la tabla de enteros tabEnt con dicho tamaño.

Luego va pidiendo los valores de los elementos de la tabla [-30..50], hasta que introduzcas un cero o se hayan cargado todos.

Por último mostrará, en una columna, todos los elementos de tabEnt precedidos por su índice.

Ejemplo: 0) 24.

Nota: Por supuesto, utilizaremos CapturaEntero para introducir los valores.
*/

using System;
using System.Threading;

namespace P22a_Vector_Con_Dimension_Dinamica
{
    class Program
    {
        static void Main(string[] args)
        {
            int longitud = 0;
            longitud = LongitudArray(longitud);

            int[] tabEnt = new int[longitud];

            tabEnt = RellenarTabEnt(tabEnt);

            Console.Clear();
            MostrarTabEnt(tabEnt);

            PararPrograma();
        }

        /************************************* MÉTODOS ********************************/

        public static int LongitudArray(int longitud)
        {
            bool longitudOk;

            do
            {
                Console.Write("\n\nPor favor, introduzca la longitud del Array entre [5, 20]:\t");
                longitudOk = Int32.TryParse(Console.ReadLine(), out longitud);

                if (!longitudOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico.");
                }
                else if (longitud < 5)
                {
                    Console.Write("\n\nError. El Array no puede tener una longitud inferior a 5.");
                    longitudOk = false;
                }
                else if (longitud > 20)
                {
                    Console.Write("\n\nError. El Array no puede tener una longitud superior a 20.");
                    longitudOk = false;
                }

            } while (!longitudOk);

            return longitud;
        }

        public static int[] RellenarTabEnt(int[] tabEnt)
        {
            for (int i=0; i<tabEnt.Length; i++)
            {
                tabEnt[i] = CapturaEntero();
                
                if (tabEnt[i] == 0)
                {
                    break;
                }
            }

            return tabEnt;
        }

        public static int CapturaEntero()
        {
            int num;
            bool numOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [-30, 50]:\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico.");
                }
                else if (num < -30)
                {
                    Console.Write("\n\nError. El número no puede ser inferior a -30.");
                    numOk = false;
                }
                else if (num > 50)
                {
                    Console.Write("\n\nError. El número no puede ser superior a 50.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static void MostrarTabEnt(int[] tabEnt)
        {
            Console.WriteLine("\n\nEl vector TabEnt[] contiene los siguientes valores:\n");

            for (int i = 0; i < tabEnt.Length; i++)
            {
                Console.WriteLine("\t" + (i + 1) + ")\t" + tabEnt[i]);
            }
        }

        public static void PararPrograma()
        {
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
