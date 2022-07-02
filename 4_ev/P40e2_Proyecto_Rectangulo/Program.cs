/*
Proyecto Rectángulo (mejorado)

Mejorar el proyecto Rectángulo realizando el siguiente cambio en ModificaRectangulo:

Si se pulsa sólo Intro cuando se pide un dato, 
se mantiene y se presenta el valor que ya existía.

Para lograrlo, te conviene utilizar:
• Un CapturaEntero que reciba otro parámetro entero, int valorPorDefecto, 
que será el valor que devuelva en caso de pulsar sólo Intro.
• La posición actual del cursor, para poder presentar el valor actual cuando pulsas sólo Intro. 

Las coordenadas del cursor se obtienen así:
int posX = Console.CursorLeft;
int posY = Console.CursorTop;
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace P40e2_Proyecto_Rectangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangulo rectangulo1 = new Rectangulo("Rectan-1", 10, 20);

            rectangulo1.RectanguloAString();

            while (Tools.PreguntaSiNo("¿Quieres Modificar?"))
            {
                rectangulo1.ModifyRectangle();
                Console.Clear();

                rectangulo1.RectanguloAString();
                Thread.Sleep(2575);
            }

            Console.Clear();
            Console.WriteLine("\n\tMuchas gracias por utilizar nuestro programa.");

            Tools.StopProgram();
        }
    }
}

