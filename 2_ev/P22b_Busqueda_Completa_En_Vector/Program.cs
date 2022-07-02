/*
Búsqueda Completa en vector:

Pide al usuario el tamaño de un vector de enteros [5..100].
Se construye dicho vector de enteros tabEnt con el tamaño elegido. 
Luego se rellena con valores aleatorios de dos cifras y los muestra en pantalla precedidos de su índice.

A continuación se pide al usuario un número a buscar 
y el programa presenta la cabecera “El número se encuentra en la/s posición/es...” 
y muestra todas las posiciones donde se encuentra dicho número 
o lanza el mensaje de “El número X no existe en la tabla”.

Se pedirán nuevas búsquedas hasta que busquemos el número cero.
Nota: Utilizaremos CapturaEntero y cualquier otro método que necesites.
Y recuerda que la aplicación no debe colapsar ¡¡NUNNNNCA””

Avanzado:

En lugar de salir con el valor cero, se sale pulsando Intro sin ningún valor.
Además, que controle los plurales en la cabecera “El número se encuentra en la posición” o “... posiciones”
Además, si no existe el número buscado, que no aparezca la cabecera “El número se encuentra ...” 
*/

using System;
using System.Threading;

namespace P22b_Busqueda_Completa_En_Vector
{
    class Program
    {
        static void Main(string[] args)
        {

            int longitud = 0;
            longitud = LongitudArray(longitud);

            int[] tabEnt = new int[longitud];

            tabEnt = RellenarTabEnt(tabEnt);

            MostrarVectorTabEnt(tabEnt);

            BuscarNumero(tabEnt);

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
            Random random = new Random();

            for (int i = 0; i < tabEnt.Length; i++)
            {
                tabEnt[i] = random.Next(10, 100);
            }

            return tabEnt;
        }

        public static void BuscarNumero(int[] tabEnt)
        {
            int num = 0;
            bool encontrado = false;

            do
            {
                num = CapturaEntero();

                for (int i = 0; i < tabEnt.Length; i++)
                {
                    if (tabEnt[i] == num)
                    {
                        Console.Write("\n\nEl número " + num + " se encuentra en la posición " + i + " del vector tabEnt[]\n");
                        Console.WriteLine("Pulse 0 para dejar de buscar");
                        encontrado = true;
                    }
                }

                if (!encontrado && num != 0)
                {
                    Console.Write("\n\nLo sentimos, pero el número " + num + " no existe en el vector tabEnt[]\n");
                    Console.WriteLine("Pulse 0 para dejar de buscar");
                }

                encontrado = false;
                
            } while (num != 0);

        }


        public static int CapturaEntero()
        {
            int num;
            bool numOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [1, 99] para buscar su posición en el vector tabEnt[]:\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico.");
                }
                else if (num < 0)
                {
                    Console.Write("\n\nError. El número no puede ser inferior a 0.");
                    numOk = false;
                }
                else if (num > 99)
                {
                    Console.Write("\n\nError. El número no puede ser superior a 99.");
                    numOk = false;
                }
                else if (num == 0)
                {
                    numOk = true;
                }

            } while (!numOk);

            return num;
        }

        public static void MostrarVectorTabEnt(int[] tabEnt)
        {
            Console.WriteLine("\nLas posiciones y los números del vector tabEnt[] son:\n");
            for (int i = 0; i < tabEnt.Length; i++)
            {
                Console.Write(i + "\t");
            }
            
            Console.WriteLine();
            
            for (int j = 0; j < tabEnt.Length; j++)
            {
                Console.Write(tabEnt[j] + "\t");
            }
        }

        public static void PararPrograma()
        {
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
