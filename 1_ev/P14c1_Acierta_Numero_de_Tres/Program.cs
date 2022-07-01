using System;
using System.Threading;

/*
P14c0 Acierta Número (muy básico)
A un usuario A se le pide que escriba un número entre el 10 y el 20.
Luego, se limpia la pantalla y se le pide a otro usuario B que lo acierte. 
Por supuesto, B no ha visto el número introducido.
La máquina contará el número de oportunidades que necesita el usuario B para acertarlo.
Cada vez que B introduzca un número, la máquina limpia la pantalla y le dice...
• si ha fallado: “Ha fallado: Inténtelo de nuevo” o,
• si ha acertado: “Acertaste en x oportunidades”.

Nota: habrá que utilizar un contador: int cont=0;
A cada intento se incrementará el contador
*/

namespace P14c1_Acierta_Numero_de_Tres
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nEste programa generará un número aleatorio entre el 10 y el 20 ...");
            Console.WriteLine("Usted tiene que intentar acertar ese número");
            Console.WriteLine("Para ello, cuenta con tres oportunidades para intentarlo");
            Console.WriteLine("\nSi se encuentra preparado, pulse una tecla para empezar");
            Console.ReadLine();

            Console.Clear();
            Thread.Sleep(1500);
            Console.WriteLine("Generando número ...\n");
            Thread.Sleep(1500);
            Console.WriteLine("¡¡ Todo listo !!");
            Thread.Sleep(1500);

            Random random = new Random();
            //Generar un numero entre 10 y 20 (21 no se incluye)
            //Console.WriteLine(num.Next (10,21)); // esto sería si lo fuese a mostrar directamente el número aleatorio generado
            int num = random.Next(10, 21);
            int respuesta;
            int oportunidades = 3;
            int intentos = 0;

            do
            {
                    intentos++;
                    Console.Write("\nIntroduzca el número que usted crea que ha salido: \t");
                    respuesta = Convert.ToInt32(Console.ReadLine());

                    Thread.Sleep(1500);
                    Console.WriteLine("\nComprobando respuesta ...\n");
                    Thread.Sleep(1500);

                    if (respuesta == num)
                    {
                        // Console.WriteLine("\n¡Increíble! Has acertado.");
                        // Console.WriteLine("Elegiste el número "+respuesta+" y el número generado fue también el "+num);
                        Console.WriteLine("Acertaste en el " + intentos + "º intento.");
                    }
                    else
                    {
                        // Console.WriteLine("Ups casi ... no has acertado ... ");
                        oportunidades--;
                        Console.Write("Ha fallado ... ");
                        if (num < respuesta)
                        {
                            Console.WriteLine("Te has pasado de largo ... ");
                        }
                        else
                        {
                            Console.WriteLine("Te has quedado corto ... ");
                        }
                        Console.WriteLine("Le quedan " + oportunidades + " oportunidades");
                    }
                    
                    if (oportunidades == 0)
                    {
                        Thread.Sleep(1500);
                        Console.WriteLine("\nHas agotado las tres oportunidades ... Has perido ... ");
                        Console.WriteLine("El número secreto era el " + num);
                    }

            } while (respuesta != num && oportunidades > 0);

            Thread.Sleep(1500);
            Console.Write("\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}