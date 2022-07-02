/*
P21g Mostrar en pantalla
1-MuestraNums0a99:
Presentará en pantalla los números, del 0 al 99 en 10 filas de 10
columnas. Para que los números queden bien distribuidos, haremos que
las columnas vayan de 5 en 5 espacios y las filas vayan separadas una
posición.
*/

using System;
using System.Threading;

namespace P21g_Muestra_Nums_099
{
    class Program
    {
        static void Main(string[] args)
        {
            PresentarEn10Filas10Columnas();

            PararPrograma();
        }

        /************************************** MÉTODOS **************************************/

        public static void PresentarEn10Filas10Columnas()
        {
            int nCol = 10;
            int sumaCols = 0;

            for (int i=0; i<100; i++)
            {
                Console.Write(i + "\t");
                sumaCols++;

                if(sumaCols == nCol)
                {
                    Console.WriteLine("\n");
                    sumaCols = 0;
                }
            }
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
