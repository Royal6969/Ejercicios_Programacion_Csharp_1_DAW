using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P12e_Captura_Entero_1
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
                Console.Write("\n\nIntroduce un número entre el (" + min + "-" + max + "): \t");
                double numero = Convert.ToDouble(Console.ReadLine());

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
