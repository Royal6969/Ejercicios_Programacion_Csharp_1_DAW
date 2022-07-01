using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Threading;

/*
 * (20’) Utilizando el “dibujo del menú” que se te entrega, 
 * realiza un programa que te presenta el Menú y te permite elegir una de sus opciones. 
 * Si se elige una opción correcta —si no se dará el correspondiente mensaje de error— 
 * lo único que hará será limpiar la pantalla e imprimir en el centro de la misma: 
 * Ha elegido la opción no ...: <la que sea> 
 * Pulse Intro para Salir.
 */
namespace P13c_Menu_0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n\nIntroduzca su Nombre y primer Apellido: \t");
            string nomApe = Console.ReadLine();
            Console.Clear();
            Thread.Sleep(1500);

            Console.WriteLine("\n\n\n\n\t\t\t"+nomApe);
            Console.WriteLine("\t\t\t╔══════════════════════════════╗");
            Console.WriteLine("\t\t\t║             MENU             ║");
            Console.WriteLine("\t\t\t╠══════════════════════════════╣");
            Console.WriteLine("\t\t\t║                              ║");
            Console.WriteLine("\t\t\t║    1.- Lista de Clientes     ║");
            Console.WriteLine("\t\t\t║    2.- Añadir Cliente        ║");
            Console.WriteLine("\t\t\t║    3.- Eliminar Cliente      ║");
            Console.WriteLine("\t\t\t║    4.- Modificar Datos       ║");
            Console.WriteLine("\t\t\t║                              ║");
            Console.WriteLine("\t\t\t║          0) Salir            ║");
            Console.WriteLine("\t\t\t║                              ║");
            Console.WriteLine("\t\t\t╚══════════════════════════════╝");
            Thread.Sleep(1500);
            Console.Write("\n\nIntroduce una opción: \t");

            //int option = Convert.ToInt32(Console.ReadLine());
            //char caracter; ... //int option = Convert.ToInt32(caracter) - '0'; //esta fórmula permite convertir un char en int ... y lo más interesante es que si no restase el '0', me quedaría con el código numérico de tal carácter
            char option = Console.ReadKey().KeyChar;

            //if ((option >= 0 && option <=4))
            //{
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
                        Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Lista de Clientes""");
                        break;

                    //case 2:
                    case '2':
                        Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Añadir Cliente""");
                        break;

                    //case 3:
                    case '3':
                        Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Eliminar Cliente""");
                        break;

                    //case 4:
                    case '4':
                        Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Modificar Datos""");
                        break;

                    default:
                    //Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Salir""");
                    //Console.Write("\n\nMuchas gracias por utilizar nuestro programa");
                    //break;
                        Thread.Sleep(1500);
                        Console.Write("\n\nError. la opción nº " + option + " no existe en el menú.");
                        Console.Write("\n\nPor favor, reinicie el programa y vuelva a intentarlo");
                    break;
                }
            //} else
            //{
            //    Thread.Sleep(1500);
            //    Console.Write("\n\nError. la opción nº " + option + " no existe en el menú.");
            //    Console.Write("\n\nPor favor, reinicie el programa y vuelva a intentarlo");
            //}

            Thread.Sleep(1500);
            Console.Write("\n\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
