using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P43a2_Proyecto_Portón_Con_Herencia
{
    class Program_vProfesor
    {
        public static Porton portonAux = new Porton("portonAux", 200, 200, ConsoleColor.White);

        public static Porton porton1 = new Porton("porton-base1", 150, 130, ConsoleColor.White);
        public static Porton porton2 = new Porton("porton-base2", 200, 180, ConsoleColor.White);
        public static Porton porton3 = new Porton("porton-base3", 225, 195, ConsoleColor.White);
        public static Porton porton4 = new Porton("porton-base4", 250, 115, ConsoleColor.White);

        // static void Main(string[] args)
        static void Main_vProfesor(string[] args)
        {
            List<Porton> listaPortones = new List<Porton>();

            listaPortones.Add(portonAux); // listaPortones[0]
            listaPortones.Add(porton1);   // listaPortones[1]
            listaPortones.Add(porton2);   // listaPortones[2]
            listaPortones.Add(porton3);   // listaPortones[3]
            listaPortones.Add(porton4);   // listaPortones[4]


            int contPortones = 0;
            int opcion = 0;

            do
            {
                Console.Clear();
                Tools.ShowMenu();
                opcion = Tools.CapturaEntero_vProfesor("para elegir una opción del menú", 0, 9);
                Console.Clear();

                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("\n\n\tHa elegido la opción 0 de salir.");
                        break;

                    case 1:
                        AbrirUnoAbrirTodos(opcion, listaPortones);
                        break;

                    case 2:
                        CerrarUnoCerrarTodos(opcion, listaPortones);
                        break;

                    case 3:
                        MostrarListaPortones(listaPortones);
                        Console.ResetColor();
                        break;

                    case 4:
                        PintarUnoPintarTodos(opcion, listaPortones);
                        break;

                    case 5:
                        ModificarPorton(listaPortones);
                        break;

                    case 6:
                        CrearPorton(opcion, listaPortones, contPortones);
                        break;

                    case 7:
                        EliminarPorton(listaPortones);
                        break;

                    case 8:
                        BloquearUnoBloquearTodos(opcion, listaPortones);
                        break;

                    case 9:
                        DesbloquearUnoDesbloquearTodos(opcion, listaPortones);
                        break;
                }

                Tools.BackToMenu(opcion);

            } while (opcion != 0);

            Tools.StopProgram();
        }

        /********************************************************************************************************/
        /************************************************* MÉTODOS **********************************************/
        /********************************************************************************************************/

        public static Porton SeleccionarPorton(List<Porton> listaPortones)
        {
            string nombre = string.Empty;
            bool nombreOk = false;

            do
            {
                Console.WriteLine("\n");

                foreach (Porton porton in listaPortones)
                    Console.WriteLine("\t" + porton.Nombre);

                nombreOk = false;
                Console.Write("\n\n\tIntroduzca el nombre del portón a buscar:\t");
                nombre = Console.ReadLine();

                for (int i = 0; i < listaPortones.Count; i++)
                {
                    if (listaPortones[i].Nombre == nombre)
                    {
                        nombreOk = true;
                        portonAux = (Porton)listaPortones[i];
                    }
                }

                if (!nombreOk) Console.WriteLine("\n\n\t***** Error ***** Ningún nombre de la lista coincide con el introducido.");

            } while (!nombreOk);

            return portonAux;
        }

        public static void AbrirUnoAbrirTodos(int opcion, List<Porton> listaPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para abrir un portón concreto:");
            Console.WriteLine("\n\tPulse 2 para abrir todos los portones");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de apertura", 1, 2);

            if (opcion == 1)
            {
                portonAux = SeleccionarPorton(listaPortones);
                portonAux.Abrir();
            }
            else
            {
                foreach (Porton porton in listaPortones)
                    porton.Abrir();
            }
        }

        public static void CerrarUnoCerrarTodos(int opcion, List<Porton> listaPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para cerrar un portón concreto:");
            Console.WriteLine("\n\tPulse 2 para cerrar todos los portones");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de cerraje", 1, 2);

            if (opcion == 1)
            {
                portonAux = SeleccionarPorton(listaPortones);
                portonAux.Cerrar();
            }
            else
            {
                foreach (Porton porton in listaPortones)
                    porton.Cerrar();
            }
        }

        public static void PintarUnoPintarTodos(int opcion, List<Porton> listaPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para pintar un portón concreto:");
            Console.WriteLine("\n\tPulse 2 para pintar todos los portones");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de pintada", 1, 2);

            if (opcion == 1)
            {
                portonAux = SeleccionarPorton(listaPortones);
                portonAux.Color = Tools.EligeColor();
            }
            else
            {
                ConsoleColor color = Tools.EligeColor();

                foreach (Porton porton in listaPortones)
                    porton.Color = color;
            }
        }

        public static void BloquearUnoBloquearTodos(int opcion, List<Porton> listaPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para bloquear un portón concreto:");
            Console.WriteLine("\n\tPulse 2 para bloquear todos los portones");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de bloqueo", 1, 2);

            if (opcion == 1)
            {
                portonAux = SeleccionarPorton(listaPortones);
                portonAux.Bloquear();
            }
            else
            {
                foreach (Porton porton in listaPortones)
                    porton.Bloquear();
            }
        }

        public static void DesbloquearUnoDesbloquearTodos(int opcion, List<Porton> listaPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para desbloquear un portón concreto:");
            Console.WriteLine("\n\tPulse 2 para desbloquear todos los portones");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de desbloqueo", 1, 2);

            if (opcion == 1)
            {
                portonAux = SeleccionarPorton(listaPortones);
                portonAux.Desbloquear();
            }
            else
            {
                foreach (Porton porton in listaPortones)
                    porton.Desbloquear();
            }
        }

        /********************************************************************************************************/
        /**************************************************** CRUD **********************************************/
        /********************************************************************************************************/

        public static void CrearPorton(int opcion, List<Porton> listaPortones, int contPortones)
        {
            Console.WriteLine("\n\n\t----- Creamos el portón ------");
            contPortones++;

            string nombre = "portón-" + contPortones;
            int alto = Tools.CapturaEntero_Normal("\n\t¿Altura en cm?", 50, 250);
            int ancho = Tools.CapturaEntero_Normal("\n\t¿Anchura en cm?", 30, 250);
            ConsoleColor color = Tools.EligeColor();

            listaPortones.Add
            (
                new Porton(nombre, alto, ancho, color)
            );

            Console.WriteLine("\n\n\tPerfecto. Has creado el porton-" + contPortones);
        }

        public static void MostrarListaPortones(List<Porton> listaPortones)
        {
            Console.WriteLine("\n\n\tNombre\t\tSituación     Estado     Altura     Anchura     Color");
            Console.WriteLine("\t----------------------------------------------------------------------\n");

            foreach (Porton porton in listaPortones)
            {
                Console.WriteLine(porton.ToString_ConDibujo());
            }
        }

        public static void ModificarPorton(List<Porton> listaPortones)
        {
            Console.WriteLine("\n\n\t----- Modifiquemos el portón ------");

            portonAux = SeleccionarPorton(listaPortones);

            Console.WriteLine("\n\n\t----- Está modificando " + portonAux.Nombre + " ------");

            int alto = Tools.CapturaEntero_Normal("\n\t¿Altura en cm?", 50, 250);
            int ancho = Tools.CapturaEntero_Normal("\n\t¿Anchura en cm?", 30, 250);
            ConsoleColor color = Tools.EligeColor();

            portonAux.Alto = alto;
            portonAux.Ancho = ancho;
            portonAux.Color = color;
        }

        public static void EliminarPorton(List<Porton> listaPortones)
        {
            Console.WriteLine("\n\n\t----- Eliminemos un portón ------");

            portonAux = SeleccionarPorton(listaPortones);

            if (Tools.PreguntaSiNo("Esta seguro de eliminar el objeto " + portonAux.Nombre + " ??"))
            {
                for (int i = 1; i < listaPortones.Count; i++) // empezamos saltando la posición 0 del único objeto del tipo Puerta para que el usuario no pueda borrarlo
                {
                    if (listaPortones[i].Nombre == portonAux.Nombre)
                    {
                        listaPortones.RemoveAt(i);
                    }
                }

                if (portonAux.Nombre == "portonAux") Console.WriteLine("\n\n\tNo puedes eliminar el PortonAux y dejar la lista vacía");
                else Console.WriteLine("\n\n\tPerfecto. El portón seleccionado ha sido eliminado.");

            }
            else
            {
                Console.WriteLine("\n\n\tEl objeto " + portonAux.Nombre + " no ha sido eliminado");
            }

        }
    }
}
