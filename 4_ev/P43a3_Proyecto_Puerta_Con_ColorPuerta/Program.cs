using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P43a3_Proyecto_Puerta_Con_ColorPuerta
{
    class Program
    {
        public static Puerta puerta = new Puerta("p-base", 100, 80, new ColorPuerta("white", ConsoleColor.White));
        // public static Puerta puerta = new Puerta("p-base", 100, 80); // vProfesor
        public static ColorPuerta[] vColores = 
        { 
            new ColorPuerta("white", ConsoleColor.White), // el primero no sirve
            new ColorPuerta("gray", ConsoleColor.Gray), 
            new ColorPuerta("dark blue", ConsoleColor.DarkBlue), 
            new ColorPuerta("green", ConsoleColor.Green), 
            new ColorPuerta("cyan", ConsoleColor.Cyan), 
            new ColorPuerta("red", ConsoleColor.Red), 
            new ColorPuerta("magenta", ConsoleColor.Magenta), 
            new ColorPuerta("yellow", ConsoleColor.Yellow), 
            new ColorPuerta("white", ConsoleColor.White) 
        };

        static void Main(string[] args)
        {
            List<Puerta> listaPuertas = new List<Puerta>();
            listaPuertas.Add(puerta);

            int cont = 0;
            int opcion = 0;

            do
            {
                Console.Clear();
                Tools.ShowMenu();
                opcion = Tools.CapturaEntero_vProfesor("para elegir una opción del menú", 0, 7);
                Console.Clear();

                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("\n\n\tHa elegido la opción 0 de salir.");
                        break;

                    case 1:
                        AbrirTodasAbrirUna(opcion, listaPuertas);
                        break;

                    case 2:
                        CerrarTodasAbrirUna(opcion, listaPuertas);
                        break;

                    case 3:
                        MostrarListaPuertas(listaPuertas);
                        Console.ResetColor();
                        break;

                    case 4:
                        PintarUnaPintarTodas(opcion, listaPuertas);
                        break;

                    case 5:
                        puerta = ModificarPuerta(listaPuertas);
                        break;

                    case 6:
                        cont++;
                        CrearPuerta(listaPuertas, cont);
                        break;

                    case 7:
                        EliminarPuerta(listaPuertas);
                        break;
                }

                Tools.BackToMenu(opcion);

            } while (opcion != 0);

            Tools.StopProgram();
        }

        /************************************************* MÉTODOS **********************************************/

        public static Puerta SeleccionarPuerta(List<Puerta> listaPuertas)
        {
            string nombre = string.Empty;
            bool nombreOk = false;

            do
            {
                Console.WriteLine("\n");

                foreach (Puerta p in listaPuertas)
                    Console.WriteLine("\t" + p.Nombre);

                nombreOk = false;
                Console.Write("\n\n\tIntroduzca el nombre de la puerta a buscar:\t");
                nombre = Console.ReadLine();

                for (int i = 0; i < listaPuertas.Count; i++)
                {
                    if (listaPuertas[i].Nombre == nombre)
                    {
                        nombreOk = true;
                        puerta = listaPuertas[i];
                    }
                }

                if (!nombreOk) Console.WriteLine("\n\n\t***** Error ***** Ningún nombre de la lista coincide con el introducido.");

            } while (!nombreOk);

            return puerta;
        }

        public static void AbrirTodasAbrirUna(int opcion, List<Puerta> listaPuertas)
        {
            Console.WriteLine("\n\n\tPulse 1 para abrir una puerta concreta:");
            Console.WriteLine("\n\tPulse 2 para abrir todas las puertas");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de apertura sde puerta", 1, 2);

            if (opcion == 1)
            {
                puerta = SeleccionarPuerta(listaPuertas);
                puerta.Abrir();
            }
            else
            {
                foreach (Puerta puerta in listaPuertas)
                    puerta.Abrir();
            }
        }

        public static void CerrarTodasAbrirUna(int opcion, List<Puerta> listaPuertas)
        {
            Console.WriteLine("\n\n\tPulse 1 para cerrar una puerta concreta:");
            Console.WriteLine("\n\tPulse 2 para cerrar todas las puertas");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de cerraje de puerta", 1, 2);

            if (opcion == 1)
            {
                puerta = SeleccionarPuerta(listaPuertas);
                puerta.Cerrar();
            }
            else
            {
                foreach (Puerta puerta in listaPuertas)
                    puerta.Cerrar();
            }
        }

        public static ColorPuerta EligeColor()
        {
            Console.WriteLine("\n\tElige un color\n");

            for (int i = 1; i < vColores.Length; i++) // para que se salte el primero (posición 0) que no sirve
            {
                Console.ForegroundColor = vColores[i].Color;
                Console.WriteLine("\t" + (i) + ")  " + "████████ ◄ " + vColores[i].Nombre); // aquí debería haber usado el método Mostrar() que hice en la clase ColorPuerta
                Console.ResetColor();
            }

            int indice = Tools.CapturaEntero_vProfesor("\t¿Color?", 1, 8);

            Console.WriteLine("\n\n\tEl color de la puerta se ha pintado en " + vColores[indice].Nombre);

            return vColores[indice];
        }

        public static void PintarUnaPintarTodas(int opcion, List<Puerta> listaPuertas)
        {
            Console.WriteLine("\n\n\tPulse 1 para pintar una puerta concreta:");
            Console.WriteLine("\n\tPulse 2 para pintar todas las puertas");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de pintada de puerta", 1, 2);

            if (opcion == 1)
            {
                puerta = SeleccionarPuerta(listaPuertas);
                puerta.Color = EligeColor();
            }
            else
            {
                ColorPuerta color = EligeColor();

                foreach (Puerta puerta in listaPuertas)
                    puerta.Color = color;
            }
        }

        /**************************************************** CRUD **********************************************/

        public static void CrearPuerta(List<Puerta> listaPuertas, int cont)
        {
            Console.WriteLine("\n\n\t----- Creamos la puerta ------");

            string nombre = "p-" + cont;
            int alto = Tools.CapturaEntero_Normal("\n\t¿Altura en cm?", 50, 250);
            int ancho = Tools.CapturaEntero_Normal("\n\t¿Anchura en cm?", 30, 250);
            ColorPuerta color = EligeColor();

            listaPuertas.Add
            (
                new Puerta(nombre, alto, ancho, color)
            );

            Console.WriteLine("\n\n\tPerfecto. Has creado la puerta p-" + cont);
        }

        public static void MostrarListaPuertas(List<Puerta> listaPuertas)
        {
            for (int i = 0; i < listaPuertas.Count; i++)
            {
                Console.WriteLine(listaPuertas[i].ToString_ConDibujo());
            }
        }

        public static Puerta ModificarPuerta(List<Puerta> listaPuertas)
        {
            Console.WriteLine("\n\n\t----- Modifiquemos la puerta ------");

            puerta = SeleccionarPuerta(listaPuertas);

            Console.WriteLine("\n\n\t----- Está modificando la puerta " + puerta.Nombre + " ------");

            int alto = Tools.CapturaEntero_Normal("\n\t¿Altura en cm?", 50, 250);
            int ancho = Tools.CapturaEntero_Normal("\n\t¿Anchura en cm?", 30, 250);
            ColorPuerta color = EligeColor();

            puerta.Alto = alto;
            puerta.Ancho = ancho;
            puerta.Color = color;

            return puerta;
        }

        public static void EliminarPuerta(List<Puerta> listaPuertas)
        {
            Console.WriteLine("\n\n\t----- Eliminemos una puerta ------");

            puerta = SeleccionarPuerta(listaPuertas);

            if (Tools.PreguntaSiNo("Esta seguro de eliminar el objeto " + puerta.Nombre + " ??"))
            {
                for (int i = 1; i < listaPuertas.Count; i++) // empezamos saltando la posición 0 del único objeto del tipo Puerta para que el usuario no pueda borrarlo
                {
                    if (listaPuertas[i].Nombre == puerta.Nombre)
                    {
                        listaPuertas.RemoveAt(i);
                    }
                }

                if (puerta.Nombre == "p-base") Console.WriteLine("\n\n\tNo puedes eliminar la Puerta-Base y dejar la lista vacía");
                else Console.WriteLine("\n\n\tPerfecto. La puerta seleccionada ha sido eliminada.");

            }
            else
            {
                Console.WriteLine("\n\n\tEl objeto " + puerta.Nombre + " no ha sido eliminado");
            }

        }
    }
}
