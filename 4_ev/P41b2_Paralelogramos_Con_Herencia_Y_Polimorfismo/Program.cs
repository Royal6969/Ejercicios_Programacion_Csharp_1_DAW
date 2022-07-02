using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b2_Paralelogramos_Con_Herencia_Y_Polimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Cuadrado cuadrado1 = new Cuadrado("cuadrado1", 15);
            Rectangulo rectangulo1 = new Rectangulo("rectangulo1", 15, 50);
            Rombo rombo1 = new Rombo("rombo1", 30, 120);
            Romboide romboide1 = new Romboide("romboide1", 50, 15, 120);

            List<Rectangulo> rectanglesList = new List<Rectangulo>();
            rectanglesList.Add(cuadrado1);
            rectanglesList.Add(rectangulo1);
            rectanglesList.Add(rombo1);
            rectanglesList.Add(romboide1);

            Console.WriteLine("\n\n\tNombre          Base    Lateral   Ángulo    Perim.    Área");
            Console.WriteLine("\t----------------------------------------------------------------------\n");

            foreach (Rectangulo rectangulo in rectanglesList)
                Console.WriteLine(rectangulo.ComoString());


            Rectangulo[] vRectangulos = { cuadrado1, rectangulo1, rombo1, romboide1 }; // también lo pruebo con un vector

            Console.WriteLine("\n\n\tNombre          Base    Lateral   Ángulo    Perim.    Área");
            Console.WriteLine("\t----------------------------------------------------------------------\n");

            foreach (Rectangulo rectangulo in vRectangulos)
                Console.WriteLine(rectangulo.ComoString());

            Tools.StopProgram();
        }
    }
}

