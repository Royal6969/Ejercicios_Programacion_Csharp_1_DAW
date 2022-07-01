using System;

/*
 * El usuario va introduciendo sumandos hasta que se introduce 0. 
 * Al introducir este valor, el programa devuelve la suma de los números introducidos hasta el momento 
 * y la media aritmética de todos.
 * Para hallar la media no se tendrá encuenta el valor 0.
 */

namespace P14f_Sumador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nEn este programa, usted debe doubleroducir una serie de números para posteriormente ver la media entre éstos");
            Console.WriteLine("\nPulse 0 en cualquier momento para dejar de introducir números, ver la media final, y salir\n\n");

            double num;
            double i = 0;
            double suma = 0;

            do
            {
                Console.Write(i + ". Introduzca un número:\t");
                num = Convert.ToDouble(Console.ReadLine());
                suma += num;

                if (num == 0)
                {
                    Console.WriteLine("\n\nHa introducido " + (i - 1) + " números, y entre todos ellos suman " + suma);
                    Console.WriteLine("Y la media entre todos esos números es: " + suma + " / " + (i - 1) + " = " + (suma / (i - 1)));
                    Console.WriteLine("\nMuchas gracias por usar nuestro programa. Hasta luego !");
                }

		i++;

            } while (num != 0);

            Console.Write("\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
