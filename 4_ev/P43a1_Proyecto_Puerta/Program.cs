using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P43a1_Proyecto_Puerta
{
    class Program
    {
        static void Main(string[] args)
        {
            Puerta puerta = new Puerta(100, 80, ConsoleColor.White);

            int opcion = 0;

            do
            {
                Console.Clear();
                Tools.ShowMenu();
                opcion = Tools.CapturaEntero_vProfesor("para elegir una opción del menú", 0, 5);

                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("\n\n\tHa elegido la opción 0 de salir.");
                        break;

                    case 1:
                        puerta.Abrir();
                        break;

                    case 2:
                        puerta.Cerrar();
                        break;

                    case 3:
                        puerta.Mostrar();
                        break;

                    case 4:
                        puerta.Color = Tools.EligeColor();
                        break;

                    case 5:
                        puerta = ModificarPuerta(puerta);
                        break;
                }

                Tools.BackToMenu(opcion);

            } while (opcion != 0);

            Tools.StopProgram();
        }

        /***************************************************** MÉTODOS ********************************************/

        
        public static Puerta ModificarPuerta(Puerta puerta)
        {
        	Console.WriteLine("\n\n\t----- Modifiquemos la puerta ------");

        	int alto = Tools.CapturaEntero_vProfesor("\n\t¿Altura en cm?", 50, 250);
        	int ancho = Tools.CapturaEntero_vProfesor("\n\t¿Anchura en cm?", 30, 250);
            ConsoleColor color = Tools.EligeColor();

            puerta.Alto = alto;
            puerta.Ancho = ancho;
            puerta.Color = color;

            return puerta;
        }
        
    }
}
