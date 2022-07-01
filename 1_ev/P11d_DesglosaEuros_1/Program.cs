using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P11d_DesglosaEuros_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("This program will separate a total amount in 20€, 5€ and 1€ coins\n");

            Console.Write("\nWrite the amount (€) without cents\t");
            int total = Convert.ToInt32(Console.ReadLine());

            int billetes20 = total / 20;
            int restoBilletes20 = total % 20;

            int billetes5 = restoBilletes20 / 5;
            int restoBilletes5 = restoBilletes20 % 5;

            Console.Write("\nEl número de billetes de 20€ es: \t"+  billetes20);
            Console.Write("\nEl número de billetes de 5€ es: \t" + billetes5);
            Console.Write("\nEl número de monedas de 1€ es: \t\t" + restoBilletes5);

            Console.Write("\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
