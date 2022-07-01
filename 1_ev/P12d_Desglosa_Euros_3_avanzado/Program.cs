using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P12d_Desglosa_Euros_3_avanzado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("This program will separate a total amount in 20€, 5€ and 1€ coins\n");

            Thread.Sleep(1250);
            Console.Write("\nWrite the amount (€) without cents\t");
            int total = Convert.ToInt32(Console.ReadLine());

            int billetes20 = total / 20;
            int restoBilletes20 = total % 20;

            int billetes5 = restoBilletes20 / 5;
            int restoBilletes5 = restoBilletes20 % 5;

            Console.Write(total + " euros son ");

            Thread.Sleep(1500);
            if (billetes20 > 1)
            {
                Console.Write(billetes20+" billetes de 20 euros");
            }else if (billetes20 == 1)
            {
                Console.Write(billetes20+" billete de 20 euros");
            }

            Thread.Sleep(1500);
            if (billetes5 >= 1 && billetes20 >= 0)
            {
                Console.Write(", "+billetes5+" billetes de 5 euros");

            }else if (billetes5 == 0 && billetes20 >= 1)
            {
                Console.Write(", y ");
            }

            Thread.Sleep(1500);
            if (restoBilletes5 >= 1 && billetes5 >= 1)
            {
                Console.Write(", y "+restoBilletes5+" monedas de 1 euro.");
            }
            
            else if (restoBilletes5 == 0 && billetes5 >= 1)
            {
                Console.Write(".");
            }
            else if(billetes20 == 0 && billetes5 == 0 && restoBilletes5 >= 0)
            {
                Console.Write(restoBilletes5 + " monedas de 1 euro");
            }
            else if(billetes20 == 0 && billetes5 == 0 && restoBilletes5 == 1)
            {
                Console.Write("Solo hay 1 moneda de un euro.");
            }

            Thread.Sleep(1500);
            Console.Write("\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
