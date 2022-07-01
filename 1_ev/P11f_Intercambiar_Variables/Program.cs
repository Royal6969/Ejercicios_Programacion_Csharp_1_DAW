using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace P11f_Intercambiar_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Se introducen los valores de dos variables de cadena (x e y) e intercambia sus valores. 
             * Para comprobar que el intercambio se ha realizado correctamente, 
             * se escribirán sus valores, antes y después del intercambio.
             */
            Console.Write("Escriba el valor de X \t");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("El valor de X es: \t" + x);

            Console.Write("\n\nEscriba el valor de y \t");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.Write("El valor de Y es: \t" + y);

            double auxZ = x;
            x = y;
            y = auxZ;

            Thread.Sleep(1000);
            Console.Write("\n\nHaciendo la magia...");
            Thread.Sleep(1000);
            Console.Write("\nCambiando los valores de las variables...");
            Thread.Sleep(1000);
            Console.Write("\nyyyyyy aquí lo tenemos!");
            Thread.Sleep(1000);
            Console.Write("\nLas variables han intercambiado sus valores !!");
            Thread.Sleep(2000);
            Console.Write("\n\nEl valor de X ahora es el de Y ... \t" + x);
            Console.Write("\nEl valor de Y ahora es el de X ... \t" + y);

            Console.Write("\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
