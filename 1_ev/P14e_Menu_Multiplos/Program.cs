using System;
using System.Threading;

namespace P14e_Menu_Multiplos
{
    class Program
    {
        static void Main(string[] args)
        {
            char option = '0'; // hay que inicializrala aquí, si no me da fallo la condición del while()
            
            Console.Write("\nIntroduzca un número positivo de dos cifras para empezar:\t");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num > 9 && num < 100)
            {
                do
                {
                    Console.Write("\n\n\n\n");
                    Console.WriteLine("\t\t\t╔═════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t║             MENU                            ║");
                    Console.WriteLine("\t\t\t╠═════════════════════════════════════════════╣");
                    Console.WriteLine("\t\t\t║                                             ║");
                    Console.WriteLine("\t\t\t║    1) Múltiplos menores de 300              ║");
                    Console.WriteLine("\t\t\t║    2) Cien primeros múltiplos               ║");
                    Console.WriteLine("\t\t\t║    3) Múltiplos entre 500 y 700             ║");
                    Console.WriteLine("\t\t\t║    4) Ochenta múltiplos desde 700           ║");
                    Console.WriteLine("\t\t\t║                                             ║");
                    Console.WriteLine("\t\t\t║          0) Salir                           ║");
                    Console.WriteLine("\t\t\t║                                             ║");
                    Console.WriteLine("\t\t\t╚═════════════════════════════════════════════╝");

                    Console.Write("\n\nIntroduce una opción: \t");
                    option = Console.ReadKey(true).KeyChar;

                    switch (option)
                    {
                        case '0':
                            Console.WriteLine("\n\nHa elegido la opción " + option + ") Salir");
                            Console.WriteLine("\nMuchas gracias por usar nuestro programa. Hasta luego !");
                            break;

                        case '1':
                            Console.WriteLine("\n\nHa elegido la opción " + option + ") Múltiplos menores de 300");
                            if (num > 9 && num < 100)
                            {
                                for (int i = 300; i > 0; i--)
                                {
                                    if (i % num == 0)
                                    {
                                        Console.Write(i+"\t");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nError. Por favor, asegúrese de introducir un número positivo de dos cifras");
                            }

                            break;

                        case '2':
                            Console.WriteLine("\n\nHa elegido la opción " + option + ") Cien primeros múltiplos");

                            int j = 1;

                            while (j < 101)
                            {
                                Console.Write((num * j)+"\t");
                                j++;
                            }
                            break;

                        case '3':
                            Console.WriteLine("\n\nHa elegido la opción " + option + ") Múltiplos entre 500 y 700");

                            for(int k=500; k<700; k++)
                            {
                                if (k % num == 0)
                                {
                                    Console.Write(k + "\t");
                                }
                            }
                            break;

                        case '4':
                            Console.WriteLine("\n\nHa elegido la opción " + option + ") Ochenta múltiplos desde 700");

                            int l = 1;

                            while ( l < 81)
                            {
                                Console.Write(700+(num * l) + "\t");
                                l++;
                            }
                            break;

                        default:
                            Console.WriteLine("\nLo sentimos, pero la opción " + option + " no se encuentra en el menú.");
                            break;
                    }

                } while (option != '0');

            }
            else
            {
                Console.WriteLine("\nError. Por favor, vuelva a introducir un número entero positivo de dos cifras");
            }
            

            Thread.Sleep(1500);
            Console.Write("\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
