/*
Construye el método EsPrimo que...
• Recibe: un entero num.
• Hace: Averigua si num es primo o no.
• Devuelve: true si es primo o false si no lo es.

Construye el método ListaDePrimos que...
• Recibe: un entero limiteSup.
• Hace: Construye una lista con todos los números primos anteriores a limiteSup.
• Devuelve: la lista construida.

El Main:
• Se le pregunta al usuario cuál es el límite superior «top» de los primos a obtener [10..10000].
• Guardará en una lista todos los números primos menores de top
• Guardará los valores de esa lista, separados por el carácter ‘;’ en un fichero de nombre primos.txt.

----------------

Versión mejorada
Haz otra versión en la que el archivo de primos se llame primos Menores de X.txt (donde X es top).
La primera línea del archivo será una cabecera:
“Números primos menores de ” + top
A continuación, aparecerán los primos (sin ‘;’) pero en cinco columnas bien alineadas.
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace P31c_Guarda_Primos
{
    class Program
    {
        static void Main(string[] args)
        {
            // El Main:
            //     • Se le pregunta al usuario cuál es el límite superior «top» de los primos a obtener [10..10000].
            //     • Guardará en una lista todos los números primos menores de top
            //     • Guardará los valores de esa lista, separados por el carácter ‘;’ en un fichero de nombre primos.txt.

            string pregunta = "para definir el límite superior de los primos a obtener";
            int limiteSup = CapturaEntero(0, pregunta, 10, 10000);

            List<int> listaPrimos = ListaDePrimos(limiteSup);

            MostrarListaPrimos(listaPrimos);

            StreamWriter streamWriter = new StreamWriter("../../../../ficheros/P31c_Guarda_Primos/P31c_Guarda_Primos.txt", false);

            GuardarListaEnFichero(listaPrimos, streamWriter);
            streamWriter.Close();

            Console.WriteLine("\n\nLa lista se ha guardado en el fichero 'P31c_Guarda_Primos.txt' con éxito ... consulta el archivo .txt !!");

            // Versión mejorada
            //     Haz otra versión en la que el archivo de primos se llame primos Menores de X.txt (donde X es top).
            //     La primera línea del archivo será una cabecera:
            //     “Números primos menores de ” + top
            //     A continuación, aparecerán los primos (sin ‘;’) pero en cinco columnas bien alineadas.

            streamWriter = new StreamWriter("../../../../ficheros/P31c_Guarda_Primos/PrimosMenoresDe" + limiteSup + ".txt", false);

            GuardarListaEnFichero_Avanzado(limiteSup, listaPrimos, streamWriter);
            streamWriter.Close();

            Console.WriteLine("La lista se ha guardado en el fichero 'PrimosMenoresDe" + limiteSup + ".txt' con éxito ... consulta el archivo .txt !!");

            PararPrograma();
        }

        /******************************************** MÉTODOS ******************************************/

        public static int CapturaEntero(int posScreen, string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                Console.SetCursorPosition(posScreen, 2);
                Console.Write("                                                                                                                                                                        ");
                Console.SetCursorPosition(posScreen, 2);
                Console.Write("Introduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                Console.SetCursorPosition(posScreen, 4);
                Console.Write("                                                                                                                                                                        ");
                Console.SetCursorPosition(posScreen, 4);

                if (!numOk)
                {
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min)
                {
                    Console.Write("Error. El número no puede ser inferior a " + min + ".");
                    numOk = false;
                }
                else if (num > max)
                {
                    Console.Write("Error. El número no puede ser superior a " + max + ".");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        // Construye el método EsPrimo que...
        //     • Recibe: un entero num.
        //     • Hace: Averigua si num es primo o no.
        //     • Devuelve: true si es primo o false si no lo es.
        public static bool EsPrimo(int num)
        {
            bool esPrimo = true;
            int i; //contador de division

            i = num - 1;

            while (i > 1 && esPrimo)
            {
                if (num % i == 0) //si el resto es 0 entonces no es primo
                {
                    esPrimo = false;
                }
                else
                {
                    i--;
                }
            }

            return esPrimo;
        }

        public static bool EsPrimo_vProfesor(int num)
        {
            bool esPrimo = true;

            if (num == 2)
            {
                esPrimo = true;
            }

            if (num % 2 == 0)
            {
                esPrimo = false;
            }

            for (int i = 3; i < num; i += 2)
            {
                if (num % i == 0)
                {
                    esPrimo = false;
                }
            }

            return esPrimo;
        }

        // Construye el método ListaDePrimos que...
        //     • Recibe: un entero limiteSup.
        //     • Hace: Construye una lista con todos los números primos anteriores a limiteSup.
        //     • Devuelve: la lista construida.
        public static List<int> ListaDePrimos(int limiteSup)
        {
            List<int> listaPrimos = new List<int>();
            int cont = 0;

            while (cont < limiteSup) // también se puede hacer con un for
            {
                if (EsPrimo(cont) == true)
                {
                    listaPrimos.Add(cont);
                }

                cont++;
            }

            return listaPrimos;
        }

        public static void MostrarListaPrimos(List<int> listaPrimos)
        {
            for (int i = 0; i < listaPrimos.Count; i++)
            {
                Console.Write(listaPrimos[i] + "\t");
            }
        }

        public static void GuardarListaEnFichero(List<int> listaPrimos, StreamWriter streamWriter)
        {
            for (int i = 0; i < listaPrimos.Count; i++)
            {
                streamWriter.Write(listaPrimos[i] + ";");
            }
        }

        // Versión mejorada
        //     Haz otra versión en la que el archivo de primos se llame primos Menores de X.txt (donde X es top).
        //     La primera línea del archivo será una cabecera:
        //     “Números primos menores de ” + top
        //     A continuación, aparecerán los primos (sin ‘;’) pero en cinco columnas bien alineadas.
        public static void GuardarListaEnFichero_Avanzado(int limiteSup, List<int> listaPrimos, StreamWriter streamWriter)
        {
            streamWriter.WriteLine("Números primos menores de " + limiteSup + "\n");
            int contCols = 0;

            for (int i = 0; i < listaPrimos.Count; i++)
            {
                streamWriter.Write(listaPrimos[i] + "\t");
                contCols++;

                if (contCols == 5)
                {
                    streamWriter.WriteLine();
                    contCols = 0;
                }
            }
        }

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }

    }
}