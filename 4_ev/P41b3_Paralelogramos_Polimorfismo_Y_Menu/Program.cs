using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b3_Paralelogramos_Polimorfismo_Y_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rombo> figureList = new List<Rombo>();
            int option = 0;

            int ladoBaseFigura = 0;
            int ladoLateralFigura = 0;
            int anguloFigura = 0;

            string[] vNombres = { "", "cuad-", "rectn-", "romb-", "roide-" }; // vProfesor
            int[] vContadores = { 0, 0, 0, 0, 0 };                            // vProfesor

            do
            {
                Console.Clear();
                ShowMenu();
                option = Tools.CapturaEntero("para seleccionar una opción del menú", 0, 5);

                if (option > 0 && option < 5)
                {
                    vContadores[option]++;

                    Console.Write("\n\n\tEstá creando la figura:\t" + vNombres[option] + vContadores[option] + "\n");
                    ladoBaseFigura = Tools.CapturaEntero("para definir la longitud del ladoBase", 1, 100);
                }

                switch (option)
                {
                    case 0:
                        Console.WriteLine("\n\n\tMuchas gracias por utilizar nuestro programa.");
                        break;

                    case 1:
                        figureList.Add
                        (
                            new Cuadrado(SetFigureName(vNombres[option], vContadores[option]), ladoBaseFigura, 90)
                        );
                        break;

                    case 2:
                        ladoLateralFigura = Tools.CapturaEntero("para definir la longitud del ladoLateral del rectángulo", 1, 100);

                        figureList.Add
                        (
                            new Rectangulo(SetFigureName(vNombres[option], vContadores[option]), ladoBaseFigura, ladoLateralFigura, 90)
                        );
                        break;

                    case 3:
                        anguloFigura = Tools.CapturaEntero("para definir el ángulo menor del rombo", 1, 90);

                        figureList.Add
                        (
                            new Rombo(SetFigureName(vNombres[option], vContadores[option]), ladoBaseFigura, anguloFigura)
                        );
                        break;

                    case 4:
                        ladoLateralFigura = Tools.CapturaEntero("para definir la longitud del ladoLateral del romboide", 1, 100);
                        anguloFigura = Tools.CapturaEntero("para definir el ángulo menor del romboide", 1, 90);

                        figureList.Add
                        (
                            new Romboide(SetFigureName(vNombres[option], vContadores[option]), ladoBaseFigura, ladoLateralFigura, anguloFigura)
                        );
                        break;

                    case 5:
                        ShowFiguresFeatures(figureList);
                        break;
                }
                Tools.BackToMenu();

            } while (option != 0);

            Tools.StopProgram();
        }

        /*************************************************** MÉTODOS **********************************************/

        static void ShowMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t╔═════════════════════════════════════════╗");
            Console.WriteLine("\t║         FIGURAS A CONSTRUIR             ║");
            Console.WriteLine("\t╠═════════════════════════════════════════╣");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t║    1.- Construir Cuadrado               ║");
            Console.WriteLine("\t║    2.- Construir Rectángulo             ║");
            Console.WriteLine("\t║    3.- Construir Rombo                  ║");
            Console.WriteLine("\t║    4.- Construir Romboide               ║");
            Console.WriteLine("\t║    5.- Presentar Paralelogramos         ║");
            Console.WriteLine("\t║    0.- Salir                            ║");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t╚═════════════════════════════════════════╝");
        }

        static string SetFigureName(string text, int num)
        {
            text = text + num.ToString();

            return text;
        }

        static void ShowFiguresFeatures(List<Rombo> figureList)
        {
            Console.WriteLine("\n\n\tNombre          Base    Lateral   Ángulo    Perim.    Área");
            Console.WriteLine("\t----------------------------------------------------------------------\n");

            foreach (Rombo figura in figureList)
                Console.WriteLine(figura.ToString());
        }
    }
}
