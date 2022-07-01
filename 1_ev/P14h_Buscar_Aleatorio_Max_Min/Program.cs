using System;

/*
 * Buscar el máximo o mínimo de una serie de datos:
 * 
 * El programa elige dos números al azar: min, menor que 100 y max entre 300 y 500. 
 * A continuación mostrará en la pantalla 50 valores tomados al azar entre min y max, ambos incluidos. 
 * Por último, mostrará cuál ha sido el valor máximo de los presentados.
 * 
 * Versión Plus: Que presente los valores mínimo y máximo
 */

namespace P14h_Buscar_Aleatorio_Max_Min
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random1 = new Random();
            Random random2 = new Random();
            int max = random1.Next(300, 501);
            int min = random2.Next(0, 101);

            Console.WriteLine("\n\nEl intervalo para el mínimo y máximo es:\t(" + min + ", " + max + ")\n\n");

            Random random3 = new Random();
            int num;
            int minSerie = 500;
            int maxSerie = 0;

            for (int i=0; i<50; i++)
            {
                num = random3.Next(min, max);
                Console.Write(num+"\t");

                if(num > maxSerie)
                {
                    maxSerie = num;
                }
                if (num < minSerie)
                {
                    minSerie = num;
                }
            }

            Console.WriteLine("\n\n\nEl número mínimo de la serie es:\t" + minSerie);
            Console.WriteLine("El número máximo de la serie es:\t" + maxSerie);

            Console.WriteLine("\n\n\n\n\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
