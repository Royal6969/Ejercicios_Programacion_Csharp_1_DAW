using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P11e_DesglosaEuros_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Escribe la cantidad de billetes de 20€: \t");
            int billetes20 = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEscribe la cantidad de billetes de 5€: \t\t");
            int billetes5 = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEscribe la cantidad de monedas de 2€: \t\t");
            int monedas2 = Convert.ToInt32(Console.ReadLine());

            int total = (billetes20 * 20) + (billetes5 * 5) + (monedas2 * 2);
            Console.Write("\n\nLa cantidad total de dinero es: \t"+(billetes20 * 20)+" + "+(billetes5 * 5)+" + "+(monedas2 * 2)+" = "+total);

            int billetes50 = total / 50;
            int restoBilletes50 = total % 50;

            int billetes10 = restoBilletes50 / 10;
            int restoBilletes10 = restoBilletes50 % 10;

            Console.Write("\n\nEl número de billetes de 50€ es: \t" + billetes50);
            Console.Write("\nEl número de billetes de 10€ es: \t" + billetes10);
            Console.Write("\nEl número de monedas de 1€ es: \t\t" + restoBilletes10);

            Console.Write("\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
