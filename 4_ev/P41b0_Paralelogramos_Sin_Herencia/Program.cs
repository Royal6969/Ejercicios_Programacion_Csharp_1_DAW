/*
Paralelogramos, versión 0 (Sin herencia)

En esta primera versión usaremos clases independientes para cada uno de los tipos de paralelogramos.

Los campos
En el documento de conceptos se mostraba los campos que necesita cada tipo de paralelogramo.

A la hora de realizar el proyecto cambiaremos los nombres de los identificadores:
    • base ➔ ladoBase (base no se puede utilizar porque es palabra reservada)
    • lateral ➔ ladoLateral (sólo por coherencia con el anterior)

Las propiedades y el método Presentar se construirán como se indica en el documento de conceptos.

El punto de entrada:
Se construirá una figura de cada tipo y se realizará la presentación de todas, utilizando el método Presentar
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b0_Paralelogramos_Sin_Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Cuadrado cuadrado1 = new Cuadrado("cuadrado1", 15);
            Rectangulo rectangulo1 = new Rectangulo("rectangulo1", 15, 50);
            Rombo rombo1 = new Rombo("rombo1", 30, 120);
            Romboide romboide1 = new Romboide("romboide1", 50, 15, 120);

            Console.WriteLine("\n\n\tNombre          Base    Lateral   Ángulo    Perim.    Área");
            Console.WriteLine("\t----------------------------------------------------------------------\n");

            Console.WriteLine(cuadrado1.CuadradoAString());
            Console.WriteLine(rectangulo1.RectanguloAString());
            Console.WriteLine(rombo1.RomboAString());
            Console.WriteLine(romboide1.RomboideAString());

            Tools.StopProgram();
        }
    }
}
