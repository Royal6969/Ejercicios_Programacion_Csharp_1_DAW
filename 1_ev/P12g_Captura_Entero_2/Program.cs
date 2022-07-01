using System;
using System.Threading;

namespace P12g_Captura_Entero_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduzca el número mínimo de un rango: \t");
            double min = Convert.ToDouble(Console.ReadLine());
            Console.Write("Introduzca el número máximo de un rango: \t");
            double max = Convert.ToDouble(Console.ReadLine());

            Thread.Sleep(1500);
            Console.Clear();
            Thread.Sleep(1000);

            if (max > min && min < max)
            {
                Console.Write("\n\nCorrecto !!");
                Thread.Sleep(750);
                Console.Write("\n\nIntroduce un número entre el (" + min + " - " + max + "): \t");
                double numero = Convert.ToDouble(Console.ReadLine());

                if (numero >= min && numero <= max)
                {
                    Thread.Sleep(1500);
                    Console.Write("\n\nCorrecto, número dentro del rango !!");
                } else 
                {
                    Thread.Sleep(1500);
                    Console.Write("\n\nError, número fuera del rango !!");
                }

            }
            else
            {
                Console.Write("\n\nError: No puede ser el máximo menor que el mínimo.");
            }

            Thread.Sleep(1500);
            Console.Write("\n\n\n\n\tPress any key to exit");
            Console.ReadLine();
        }
    }
}
