/*
TablaNonesLocal:

Repetir la práctica anterior con las siguientes variaciones:

1) La tabla NO será global. 
(Esto implica que los métodos que utilizan la tabla, tienen que recibirla como parámetro)

2) Preguntará si quiere repetir, que actuará en consecuencia. 
Para esto, construir y utilizar el método PreguntaSiNo, 
que recibe una cadena (la pregunta) y devuelve true si pulsas ‘s’ (o ‘S’) o false si pulsas ‘n’ (o ‘N’).
*/

using System;
using System.Threading;

namespace P22d2_Vector_Nones_Local
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vNones;
            bool continuar;

            do
            {
                int numE = 0;
                numE = LongitudArray();

                vNones = new int[numE];

                vNones = CargaTablaNones(vNones, numE);

                int nCol = 0;
                nCol = CuantasColumnasQuiereMostrar();

                Console.WriteLine();
                MostrarArray(vNones, nCol);

                string pregunta = "\n¿Desea continuar?\n\nPulse [s] para SÍ, o pulse [n] para NO:\t";
                continuar = PreguntaSiNo(pregunta);

            } while (continuar);

            PararPrograma();
        }

        /***************************************** MÉTODOS ***************************************/

        public static int CapturaLongitud()
        {
            int min = 5;
            int max = 100;
            int num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "] para dar una longitud al Array vNones[]:\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico.");
                }
                else if (num < min)
                {
                    Console.Write("\n\nError. El número no puede ser inferior a " + min + ".");
                    numOk = false;
                }
                else if (num > max)
                {
                    Console.Write("\n\nError. El número no puede ser superior a " + max + ".");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static int LongitudArray()
        {
            int numE = 0;

            Console.Write("\n\n¿Cuántos números impares va a contener el Array?");
            numE = CapturaLongitud();

            return numE;
        }

        public static int[] CargaTablaNones(int[] vNones, int numE)
        {
            vNones[0] = 1;

            for (int i = 1; i < numE; i++)
            {
                vNones[i] = vNones[i - 1] + 2;
            }

            return vNones;
        }

        public static int CuantasColumnasQuiereMostrar()
        {
            int nCol = 0;

            Console.Write("\n\n¿En cuántas columnas desea presentar el Array vNones[]?");
            nCol = Convert.ToInt32(Console.ReadLine());

            return nCol;
        }

        public static void MostrarArray(int[] vNones, int nCol)
        {
            int contCol = 0;

            for (int i = 0; i < vNones.Length; i++)
            {
                Console.Write(i + ") " + vNones[i] + "\t");
                contCol++;

                if (contCol == nCol)
                {
                    Console.WriteLine();
                    contCol = 0;
                }
            }
        }

        public static bool PreguntaSiNo(string pregunta)
        {
            bool continuar = true;
            char letra;
            bool letraOk;

            do
            {
                Console.Write(pregunta);
                letraOk = Char.TryParse(Console.ReadLine(), out letra);

                if (!letraOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor alfabético");
                }
                else if ((letra != 's' && letra != 'S') && (letra != 'n' && letra != 'N'))
                {
                    Console.Write("\n\nError. El carácter introducido no es ni una [s] ni una [n]");
                    letraOk = false;
                }
                else if (letra == 's' || letra == 'n')
                {
                    letraOk = true;
                }

            } while (!letraOk);

            if (letra == 's' || letra == 'S')
            {
                continuar = true;
            }
            else if (letra == 'n' || letra == 'N')
            {
                continuar = false;
            }

            return continuar;
        }

        public static void PararPrograma()
        {
            Console.Write("\n\n\nPres any key to exit.");
            Console.ReadLine();
        }
    }
}