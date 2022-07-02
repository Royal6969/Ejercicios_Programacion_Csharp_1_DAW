/*
VectorNonesGlobal:

• Declaramos el vector global vNones.
• El programa pregunta cuántos impares vas a cargar en la tabla [5..100].
• Luego llama al método CargaTablaNones, que recibe el número de elementos, numE, 
e inicializa y carga el vector que ya tenemos declarado global, vNones, 
con los primeros “numE” números impares.
• Por último, pregunta en cuántas columnas los quieres mostrar [1..8] y llama al método MuestraTabla, 
que recibe el número de columnas en que las vas a mostrar y presenta cada elemento con su índice delante
*/

using System;
using System.Threading;

namespace P22d1_Vector_Nones_Global
{
    class Program
    {
        /*********************************** Variables Globales *******************************/
        static int[] vNones;
        /**************************************************************************************/
        static void Main(string[] args)
        {

            int numE = 0;
            numE = LongitudArray();

            vNones = CargaTablaNones(numE);

            int nCol = 0;
            nCol = CuantasColumnasQuiereMostrar();

            Console.WriteLine();
            MostrarArray(nCol);

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

        public static int[] CargaTablaNones(int numE)
        {
            vNones = new int[numE];
            vNones[0] = 1;

            for(int i=1; i<numE; i++)
            {
                vNones[i] = vNones[i-1] + 2;
            }

            return vNones;

            /*
            vNones = new int[numE];
            int none = 1;

            for(int i=1; i<vNones[i]; i++)
            {
                vNones[i] = none;
                none += 2;
            }

            return vNones;
            */
        }

        public static int CuantasColumnasQuiereMostrar()
        {
            int nCol = 0;

            Console.Write("\n\n¿En cuántas columnas desea presentar el Array vNones[]?");
            nCol = Convert.ToInt32(Console.ReadLine());

            return nCol;
        }

        public static void MostrarArray(int nCol)
        {
            int contCol = 0;

            for(int i=0; i<vNones.Length; i++)
            {
                Console.Write(i + ") " + vNones[i] + "\t");
                contCol ++;

                if(contCol == nCol)
                {
                    Console.WriteLine();
                    contCol = 0;
                }
            }
        }

        public static void PararPrograma()
        {
            Console.Write("\n\n\nPres any key to exit.");
            Console.ReadLine();
        }
    }
}
