using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Threading;

namespace P12a_Mayor_de_Edad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduzca su nombre: \t");
            string nombre = Console.ReadLine();

            Console.Write("Introduzca su edad: \t");
            int edad = Convert.ToInt32(Console.ReadLine());

            Thread.Sleep(1000);

            if (edad >= 18)
            {
                Console.Write("\n\nBuenos días " + nombre + ". Ya tienes " + edad + ", así que ya eres mayor de edad!");
            } else
            {
                Console.Write("\n\nBuenos días " + nombre + ". Aún no eres mayor de edad... te quedan " + (18 - edad) + " años para tener los 18!");
            }

            Console.Write("\n\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}