using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P40f_Menu_Dinamico
{
    class Menu
    {
        // ATRIBUTOS
        string[] vMenu;
        
        
        // CONSTRUCTORES
        public Menu(string[] vMenu)
        {
            this.vMenu = vMenu;
        }


        // GETTERS Y SETTERS
        public string[] VMenu { get => vMenu; set => vMenu = value; }


        // PROPIEDADES


        // MÉTODOS
        public int ShowMenu()
        {
            int max = 0, cont = 0;
            for (int i = 0; i < vMenu.Length; i++)
            {
                if (vMenu[i].Length > max)
                    max = vMenu[i].Length;
            }

            Console.WriteLine("\n\n");
            Console.Write("\t\t╔");
            for (int j = 0; j < max + 7; j++)
                Console.Write("═");
            Console.WriteLine("╗");

            Console.WriteLine("\t\t║     {0} ║", Tools.CuadraTexto_vMenu(vMenu[0], max + 1));
            Console.Write("\t\t╠");
            for (int j = 0; j < max + 7; j++)
                Console.Write("═");
            Console.WriteLine("╣");
            //Console.WriteLine("\t\t\t\t\t╠═════════════════════╣"); 
            for (int i = 0; i < (((vMenu.Length - 1) * 2) - 1); i++)
            {
                if (i % 2 == 0)
                {
                    cont++;
                    Console.WriteLine("\t\t║   {0}) {1}║", cont, Tools.CuadraTexto_vMenu(vMenu[cont], max + 1));
                }
                else
                {
                    Console.Write("\t\t║");
                    for (int j = 0; j < max + 7; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("║");
                }

            }
            Console.Write("\t\t║");
            for (int j = 0; j < max + 7; j++)
                Console.Write("_");
            Console.WriteLine("║");
            Console.Write("\t\t║");
            for (int j = 0; j < max + 7; j++)
                Console.Write(" ");
            Console.WriteLine("║");
            Console.WriteLine("\t\t║   {0}) {1}║", 0, Tools.CuadraTexto_vMenu("Salir", max + 1));
            Console.Write("\t\t╚");
            for (int j = 0; j < max + 7; j++)
                Console.Write("═");
            Console.WriteLine("╝");

            return Tools.CapturaEntero_vProfesor("Eliga una opción", 0, vMenu.Length - 1);
        }

        // ToString
    }
}
