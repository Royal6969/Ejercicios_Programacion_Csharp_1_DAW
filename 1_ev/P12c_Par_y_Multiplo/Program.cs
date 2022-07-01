using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace P12c_Par_y_Multiplo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduzca un número para saber si es par/impar y/o múltiplo de 3: \t");
            double num = Convert.ToDouble(Console.ReadLine());

            Thread.Sleep(1000);
            Console.Write("\n");

            if (num % 2 == 0)
            {
                Console.Write("\n\nEl número " + num + " es par.");
                Thread.Sleep(1750);
                if (num % 3 == 0)
                {
                    Console.Write(" Y además, también es múltiplo de 3!");
                } else
                {
                    Console.Write(" Pero no es múltiplo de 3...");
                }
            } else
            {
                Console.Write("El número " + num + " es impar.");
                Thread.Sleep(1750);
                if (num % 3 == 0)
                {
                    Console.Write(" Y además, también es múltiplo de 3!");
                }
                else
                {
                    Console.Write(" Pero no es múltiplo de 3...");
                }
            }

            Thread.Sleep(1000);
            Console.Write("\n\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
