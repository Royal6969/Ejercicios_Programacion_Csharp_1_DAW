using System;

/* 
 * Práctica que muestra la tabla de caracteres ASCII desde el 32 al 255 en 7 columnas. 
 * Hay que presentar el código y el carácter. 
 * Ejemplo: 67) C 68) D. 
 * 
 * Nota: 
 * Para presentar el carácter cuyo código es el cod habría que hacer un cásting a char, ya sabes: (char)cod
 */

namespace P14g_Presenta_en_Columna_0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tChar - ASCII\tChar - ASCII\tChar - ASCII\tChar - ASCII\tChar - ASCII\tChar - ASCII\tChar - ASCII");

            int countColumnas = 0;

            for(int cod=32; cod<256; cod++)
            {
                Console.Write("\t" + cod + "\t" + (char)cod);
                countColumnas ++;

                if(countColumnas == 7)
                {
                    Console.WriteLine();
                    countColumnas = 0;
                }

                // forma deluxe de hacerlo
                //if(countColumnas++ % 7 == 0)
                //{
                //    Console.WriteLine();
                //}
            }

            Console.WriteLine("\n\nPres any key to exit");
            Console.ReadLine();
        }
    }
}
