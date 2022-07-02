using System;
using System.Threading;

namespace P21f_Multiplicar_Sumando
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            a = CapturaEntero_a();

            int b = 0;
            b = CapturaEntero_b();

            int producto = 0;
            producto = MultiplicarSumando(a, b);

            CleanScreen();

            Explicacion();

            Thread.Sleep(1200);
            Console.Write("\n\nEl producto de " + a + " x " + b + " es:\t" + producto);

            PararPrograma();
        }

        /******************************************* MÉTODOS ************************************ */

        public static int CapturaEntero_a()
        {
            int a;
            bool numOk;

            do
            {
                Console.Write("\n\nPor favor, introduzca un número entero y positivo, entre [0, 10.000] para la variable (a):\t");
                numOk = Int32.TryParse(Console.ReadLine(), out a);

                if (!numOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico.");
                }
                else if (a < 0)
                {
                    Console.Write("\n\nError. El valor introducido debe ser un número entero y positivo");
                    numOk = false;
                }
                else if (a > 10000)
                {
                    Console.Write("\n\nError. El número entero y positivo introducido para (a) debe estar entre [0, 10.000]");
                    numOk = false;
                }

            } while (!numOk);

            return a;
        }

        public static int CapturaEntero_b()
        {
            int b;
            bool numOk;

            do
            {
                Console.Write("\n\nPor favor, introduzca un número entero y positivo, entre [0, 10.000] para la variable (b):\t");
                numOk = Int32.TryParse(Console.ReadLine(), out b);

                if (!numOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico.");
                }
                else if (b < 0)
                {
                    Console.Write("\n\nError. El valor introducido debe ser un número entero y positivo");
                    numOk = false;
                }
                else if (b > 10000)
                {
                    Console.Write("\n\nError. El número entero y positivo introducido para (b) debe estar entre [0, 10.000]");
                    numOk = false;
                }

            } while (!numOk);

            return b;
        }

        public static int MultiplicarSumando(int a, int b)
        {
            int producto = 0;

            for(int i=0; i<b; i++)
            {
                producto += a;
            }

            return producto;
        }

        public static void Explicacion()
        {
            Console.Write("\n\npublic static int MultiplicarSumando(int a, int b)");
            Console.Write("\n{");
            Console.Write("\n\tint producto = 0;");
            Console.Write("\n");
            Console.Write("\n\tfor(int i=0; i<b; i++)");
            Console.Write("\n\t{");
            Console.Write("\n\t\tproducto += a;");
            Console.Write("\n\t}");
            Console.Write("\n");
            Console.Write("\n\treturn producto;");
            Console.Write("\n}");
        }

        public static void PararPrograma()
        {
            Thread.Sleep(1300);
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }

        public static void CleanScreen()
        {
            Console.Clear();
            Thread.Sleep(1275);
        }
    }
}
