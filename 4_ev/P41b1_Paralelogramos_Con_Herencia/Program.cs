using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b1_Paralelogramos_Con_Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Cuadrado cuadrado1 = new Cuadrado("cuadrado1", 15);
            Rectangulo rectangulo1 = new Rectangulo("rectangulo1", 15, 50);
            Rombo rombo1 = new Rombo("rombo1", 30, 120);
            Romboide romboide1 = new Romboide("romboide1", 50, 15, 120);
            */

            Cuadrado cuadrado1 = new Cuadrado("cuadrado1", 15), // Ejemplo1 de POLIMORFISMO
                     rectangulo1 = new Rectangulo("rectangulo1", 15, 50),
                     rombo1 = new Rombo("rombo1", 30, 120),
                     romboide1 = new Romboide("romboide1", 50, 15, 120);

            Console.WriteLine("\n\n\tNombre          Base    Lateral   Ángulo    Perim.    Área");
            Console.WriteLine("\t----------------------------------------------------------------------\n");

            Console.WriteLine(cuadrado1.ComoString());
            Console.WriteLine(rectangulo1.ComoString());
            Console.WriteLine(rombo1.ComoString());
            Console.WriteLine(romboide1.ComoString());

            Tools.StopProgram();
        }
    }
}

