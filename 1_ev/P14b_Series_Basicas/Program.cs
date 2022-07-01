using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Threading;

/*
 * Series numéricas simples:
 * Presenta un menú para elegir las opciones siguientes (además de 0.- Salir): 
 * 1) Enteros positivos menores de 500 
 * 2) Los números pares menores de 500. 
 * 3) Los números impares entre 500 y 1000.
 *     ● Al pulsar una de las opciones del 1 al 3...,
 *         1º Se limpiará la pantalla y aparecerá la cabecera de la opción elegida, por ejemplo: Números enteros positivos menores de 500; 
 *         2º A continuación se muestra en horizontal, separándolos con un tabulador, la serie numérica de la opción elegida. 
 *         3º Se mostrará el mensaje: Pulse una tecla para volver al menú.
 *     ● Si se pulsa un valor erróneo dará mensaje de error y pedirá de nuevo que se introduzca una opción.
 *     ● Si se pulsa 0 aparecerá el mensaje Pulse una tecla para Salir.
 * (Nota: Para cada caso, utiliza las tres instrucciones de iteración estudiadas)
 */

namespace P14b_Series_Basicas
{
    class Program
    {
        static void Main(string[] args)
        {
            char option;
            do
            {

                Console.Write("\n\n\n\n");
                Console.WriteLine("\t\t\t╔═════════════════════════════════════════════╗");
                Console.WriteLine("\t\t\t║             MENU                            ║");
                Console.WriteLine("\t\t\t╠═════════════════════════════════════════════╣");
                Console.WriteLine("\t\t\t║                                             ║");
                Console.WriteLine("\t\t\t║    1) Enteros positivos menores de 500      ║");
                Console.WriteLine("\t\t\t║    2) Los números pares menores de 500      ║");
                Console.WriteLine("\t\t\t║    3) Los números impares entre 500 y 1000  ║");
                Console.WriteLine("\t\t\t║                                             ║");
                Console.WriteLine("\t\t\t║          0) Salir                           ║");
                Console.WriteLine("\t\t\t║                                             ║");
                Console.WriteLine("\t\t\t╚═════════════════════════════════════════════╝");
                Thread.Sleep(1500);
                Console.Write("\n\nIntroduce una opción: \t");

                option = Console.ReadKey().KeyChar;

                if (option == '0' || option == '1' || option == '2' || option == '3')
                {
                    Console.Clear();
                    Thread.Sleep(1500);

                    switch (option)
                    {
                        case '0':
                            Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Salir""");
                            Console.Write("\n\nMuchas gracias por utilizar nuestro programa");
                            break;

                        //case 1:
                        case '1':
                            Console.WriteLine("\n\nHa elegido la opción nº: \t" + option + @": ""Enteros positivos menores de 500""");
                            Console.WriteLine();

                            for (int i = 0; i <= 500; i++)
                            {
                                Console.Write(i + " - ");
                            }

                            Thread.Sleep(1250);
                            Console.Write("\n\n\nPress any key to come back to menu.");
                            Console.ReadLine();

                            break;

                        //case 2:
                        case '2':
                            Console.WriteLine("\n\nHa elegido la opción nº: \t" + option + @": ""Los números pares menores de 500""");
                            Console.WriteLine();
                            int num = 2;

                            for (int i = 0; i <= 500; i++)
                            {
                                if (i % 2 == 0)
                                {
                                    Console.Write(i + " - ");
                                }
                            }

                            Thread.Sleep(1250);
                            Console.Write("\n\n\nPress any key to come back to menu.");
                            Console.ReadLine();

                            break;

                        case '3':
                            Console.WriteLine("\n\nHa elegido la opción nº: \t" + option + @": ""Los números impares entre 500 y 1000""");
                            Console.WriteLine();

                            for (int i = 0; i <= 500; i++)
                            {
                                if (i % 2 != 0)
                                {
                                    Console.Write(i + " - ");
                                }
                            }

                            Thread.Sleep(1250);
                            Console.Write("\n\n\nPress any key to come back to menu.");
                            Console.ReadLine();

                            break;
                    }
                }
                else
                {
                    Thread.Sleep(1500);
                    Console.Write("\n\nError. la opción nº " + option + " no existe en el menú.");
                    Console.Write("\n\nPor favor, reinicie el programa y vuelva a intentarlo");
                }
            } while (option != '0') ;

             Thread.Sleep(1250);
             Console.Write("\n\n\nPress any key to exit.");
             Console.ReadLine();
        }
    } 
}
