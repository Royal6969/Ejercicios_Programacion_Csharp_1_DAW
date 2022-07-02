/*
Construye, además de CapturaEntero, los métodos siguientes:

GeneraVector, que
• Recibe: tres enteros tam, num y numInicial
• Hace: Construye un vector de tamaño tam y lo carga con los primeros múltiplos de num a partir de numInicial.
• Devuelve: El vector construido.

BarajaVector, que no devuelve nada y...
• Recibe: un vector de enteros vInt
• Hace: Baraja el vector.

MuestraVector, que no devuelve nada y...
• Recibe: un vector de enteros vInt y un entero posScreen
• Hace: Presenta los valores del vector, precedidos por su índice, alineados en la columna de la pantalla que indica posScreen

El programa:
1) Pide un número cant, entre 10 y 30, un número inicial ni, entre 100 y 200, un número num, entre 11 y 77. 
El programa, utilizando el método GeneraVector, obtendrá un vector con los cant múltiplos de num, a partir de ni.
Ejemplo: Si cant= 20, ni = 150, num=30, el programa obtendrá un vector con los 20 primeros múltiplos de 30 a partir del 150.
2) Utilizando MuestraVector, Mostrará los valores del vector en la columna 3 de la pantalla
3) Barajará el vector utilizando BarajaVector
4) Volverá a mostrar los valores del vector en la columna 15 de la pantalla.
5) Ordenará los valores del vector. Para esto puedes utilizar una lista auxiliar.
6) Volverá a mostrar los valores del vector en la columna 27 de la pantalla.
*/

using System;

namespace P24a_Baraja_Coleccion
{
    class Program
    {

        static void Main(string[] args)
        {
            /*2*/
            int posScreen = 3;

            /*1*/
            string pregunta = "para la cantidad de múltiplos a presentar";
            int tamaño = CapturaEntero(posScreen, pregunta, 10, 30);
            /*1*/
            pregunta = "para el número inicial a partir del cual se presentarán sus múltiplos";
            int numInicial = CapturaEntero(posScreen, pregunta, 100, 200);

            /*1*/
            pregunta = "para presentar sus múltiplos";
            int num = CapturaEntero(posScreen, pregunta, 11, 77);

            /*1*/
            int[] vInt = GenerarVector(tamaño, num, numInicial);
            /*2*/
            MostrarVector(vInt, posScreen);

            /*3*/
            BarajarVector(vInt);
            /*4*/
            MostrarVector_v2(vInt);

            /*5*/
            OrdenarVector(vInt);
            /*6*/
            MostrarVector_v3(vInt);

            PararPrograma();
        }

        /*********************************************** MÉTODOS **********************************************/

        // GeneraVector, que
        //    • Recibe: tres enteros tam, num y numInicial
        //    • Hace: Construye un vector de tamaño tam y lo carga con los primeros múltiplos de num a partir de numInicial.
        //    • Devuelve: El vector construido.
        public static int[] GenerarVector(int tamaño, int num, int numInicial)
        {
            int[] vInt = new int[tamaño];
            int mul = num * (numInicial / num);

            if (mul < numInicial)
            {
                mul += num;
            }

            vInt[0] = mul;

            for (int i = 1; i < tamaño; i++)
            {
                vInt[i] = vInt[i - 1] + num;
            }


            return vInt;
        }

        // BarajaVector, que no devuelve nada y...
        //    • Recibe: un vector de enteros vInt
        //    • Hace: Baraja el vector.
        // https://www.youtube.com/watch?v=pZZFzX-f9Es&t=0m30s
        public static void BarajarVector(int[] vInt)
        {
            Random random = new Random();
            int posAleatoria;
            bool posRepetida = false;
            int aux = 0;

            for (int i = 0; i < vInt.Length; i++)
            {
                do
                {
                    posRepetida = false;
                    posAleatoria = random.Next(vInt.Length);

                    for (int j = 0; j < i; j++)
                    {
                        if (posAleatoria == j)
                        {
                            posRepetida = true;
                        }
                    }

                } while (posRepetida == true);

                aux = vInt[posAleatoria];
                vInt[posAleatoria] = vInt[0];
                vInt[0] = aux;
            }
        }

        // MuestraVector, que no devuelve nada y...
        //    • Recibe: un vector de enteros vInt y un entero posScreen
        //    • Hace: Presenta los valores del vector, precedidos por su índice, alineados en la columna de la pantalla que indica posScreen
        public static void MostrarVector(int[] vInt, int posScreen)
        {
            Console.SetCursorPosition(posScreen, 5);

            for (int i = 0; i < vInt.Length; i++)
            {
                Console.SetCursorPosition(posScreen, 5 + i);
                Console.WriteLine(i + ")\t" + vInt[i]);
            }
        }

        public static void MostrarVector_v2(int[] vInt)
        {
            Console.SetCursorPosition(15, 5);

            for (int i = 0; i < vInt.Length; i++)
            {
                Console.SetCursorPosition(15, 5 + i);
                Console.WriteLine(i + ")   " + vInt[i]); // he puesto 3 especios entre el índice y el múltiplo porque no sé por qué la tabulación no me funciona bien aquí...
            }
        }

        public static void MostrarVector_v3(int[] vInt)
        {
            Console.SetCursorPosition(27, 5);

            for (int i = 0; i < vInt.Length; i++)
            {
                Console.SetCursorPosition(27, 5 + i);
                Console.WriteLine(i + ")\t" + vInt[i]); // ¿Por qué esta tabulación es más larga que la del MostrarVector()?
            }
        }

        public static int CapturaEntero(int posScreen, string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                Console.SetCursorPosition(posScreen, 3);
                Console.Write("                                                                                                                                       ");
                Console.SetCursorPosition(posScreen, 3);
                Console.Write("Introduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.SetCursorPosition(posScreen, 5);
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min)
                {
                    Console.SetCursorPosition(posScreen, 5);
                    Console.Write("Error. El número no puede ser inferior a " + min + ".");
                    numOk = false;
                }
                else if (num > max)
                {
                    Console.SetCursorPosition(posScreen, 5);
                    Console.Write("Error. El número no puede ser superior a " + max + ".");
                    numOk = false;
                }
                else if (num == 0)
                {
                    numOk = true;
                }

            } while (!numOk);

            return num;
        }

        // para ordenar el vector usamos el Método Burbuja
        // https://www.youtube.com/watch?v=hf-_c7DFb3U&t=8m30s
        public static void OrdenarVector(int[] vInt)
        {
            int aux = 0;

            for (int i = 0; i < vInt.Length - 1; i++)
            {
                for (int j = 0; j < vInt.Length - 1; j++)
                {
                    if (vInt[j] > vInt[j + 1]) // Si numeroActual > numeroSiguiente
                    {
                        aux = vInt[j];
                        vInt[j] = vInt[j + 1];
                        vInt[j + 1] = aux;
                    }
                }
            }
        }


        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\n\t\tPress any key to exit.");
            Console.ReadLine();
        }
    }
}