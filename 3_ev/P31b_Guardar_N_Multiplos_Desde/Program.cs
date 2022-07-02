/*
Construye un método de nombre NMultiplosDesde que...

 Recibe: Tres enteros, num, cantidad y numDesde.
 Devuelve: la tabla construida.
 Hace: Construye un vector de tamaño cantidad 
y guarda en él los primeros múltiplos de num que indique cantidad a partir de numDesde sin incluir éste.

Ejemplo: si num=19; cantidad=300 y numdesde=1000, 
guardará los 300 primeros múltiplos de 19 a partir del 1000.

El Main

1) En el programa se pedirá un número de dos cifras, la cantidad de sus múltiplos a representar 
y el número a partir del cual hallar los múltiplos, y se llamará a este método.

2) Luego se le pedirá el nombre del fichero en el que guardar los valores de la tabla. 
El programa añadirá la extensión .TXT al nombre del fichero y lo construirá.

3) Por último guardará en dicho fichero —de la carpeta de pruebas— todos los
valores, separados entre sí por el carácter ‘;’ (punto y coma)
*/

using System;
using System.Collections.Generic;
using System.IO;

namespace P31b_Guardar_N_Multiplos_Desde
{
    class Program
    {
        static void Main(string[] args)
        {
            string pregunta = "para definir un número sobre el que calcular sus múltiplos";
            int num = CapturaEntero(0, pregunta, 0, 100);

            pregunta = "para definir la cantidad de múltiplos a presentar";
            int cantidad = CapturaEntero(0, pregunta, 100, 300);

            pregunta = "para definir un número inicial a partir del cual presentar los múltiplos";
            int numInicial = CapturaEntero(0, pregunta, 100, 3000);

            int[] vMultiplos = NMultiplosDesde(num, cantidad, numInicial);

            Console.WriteLine("\n\n¿Nombre del fichero?\t");
            string nombreFichero = Console.ReadLine();
            StreamWriter streamWriter = new StreamWriter("../../../../ficheros/P31b_Guardar_N_Multiplos_Desde/" + nombreFichero + ".txt", false);

            for (int i = 0; i < vMultiplos.Length; i++)
            {
                streamWriter.Write(vMultiplos[i] + ";");
            }

            streamWriter.Close();

            PararPrograma();
        }

        /************************************************ MÉTODOS **************************************************/

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

                if (!numOk)
                {
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("                                                                                                                                                                        ");
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min)
                {
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("                                                                                                                                                                        ");
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. El número no puede ser inferior a " + min + ".");
                    numOk = false;
                }
                else if (num > max)
                {
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("                                                                                                                                                                        ");
                    Console.SetCursorPosition(posScreen, 4);
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

        public static int[] NMultiplosDesde(int num, int cantidad, int numInicial)
        {
            int[] vMultiplos = new int[cantidad];

            int mul = num * (numInicial / num);

            if (mul < numInicial)
            {
                mul += num;
            }

            vMultiplos[0] = mul;

            for (int i=1; i<vMultiplos.Length; i++)
            {
                vMultiplos[i] = vMultiplos[i - 1] + num;
            }

            return vMultiplos;
        }

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}
