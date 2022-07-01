using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P12e_Captura_Entero_0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduzca un número entero positivo de dos cifras (10-99): \t");
            double numero = Convert.ToDouble(Console.ReadLine());

            Thread.Sleep(1500);
            if (numero >= 10 && numero <= 99)
            {
                Console.Write("\n\nCorrecto. El número elegido es: \t" + numero);
            }
            else
            {
                Console.Write("\n\nError. Número fuera de rango. Vuelva a intentarlo.");
            }

            Thread.Sleep(1500);
            Console.Write("\n\n\n\n\tPress any key to exit");
            Console.ReadLine();
        }
    }
}
