using System;
using System.Collections.Generic;

namespace P46_Pintar_Piso
{
    public class PintarPisoApp
    {
        public static Recinto recintoAux = null;

        static void Main(string[] args)
        {
            // Construímos las pinturas
            Pintura blanco = new Pintura("Blanco", 4.5);
            Pintura verde = new Pintura("Verde", 3.8);
            Pintura salmon = new Pintura("Salmón", 8.5);
            Pintura beige = new Pintura("Beige", 7.2);
            Pintura amarillo = new Pintura("Amarillo", 6.2);

            // Construímos un catálogo y añadimos las pinturas a la ListaPinturas
            CatalogoPinturas catalogo = new CatalogoPinturas();

            catalogo.ListaPinturas.Add(blanco);
            catalogo.ListaPinturas.Add(verde);
            catalogo.ListaPinturas.Add(salmon);
            catalogo.ListaPinturas.Add(beige);
            catalogo.ListaPinturas.Add(amarillo);

            // Construímos el piso
            Piso pBase = new Piso("Bellavista, 9, 9B");

            // Construímos los recintos y los añadimos a la ListaRecintos
            Recinto salon =      new Habitacion("Salón", 20.5, 2, 3, 0);
            Recinto dormitorio = new Habitacion("Dormi1", 15, 1, 1, 2);
            Recinto terraza =    new Terraza("Terraza1", 4.0, 1, 1, 3, 10);

            pBase.ListaRecintos.Add(salon);
            pBase.ListaRecintos.Add(dormitorio);
            pBase.ListaRecintos.Add(terraza);

            // Construímos el flujo de acciones del programa
            int opcion;
            int contHabitaciones = 0;
            int contTerrazas = 0;

            do
            {
                opcion = Util.Menu();
                Console.Clear();

                switch (opcion)
                {
                    case 1: // Mostrar las pinturas
                        catalogo.Mostrar();
                        break;

                    case 2: // Mostrar los recintos y sus precios
                        pBase.MostrarRecintos(catalogo);
                        break;

                    case 3: // Añadir Recinto
                        CrearRecinto(opcion, pBase, catalogo, contHabitaciones, contTerrazas);
                        break;

                    case 4: // Eliminar Recintos
                        EliminarRecinto(pBase);
                        break;

                    case 5: // Modificar Recinto
                        ModificarRecinto(pBase, catalogo);
                        break;
                }

                Util.BackToMenu(opcion);

            } while (opcion != 0);

            Util.StopProgram();
        }

        /************************************************************************************************************************************/
        /********************************************************** MÉTODOS ****************************************************************/
        /***********************************************************************************************************************************/

        public static void CrearRecinto(int opcion, Piso pBase, CatalogoPinturas catalogo, int contHabitaciones, int contTerrazas)
        {
            Console.WriteLine("\n\n\n\n\n\n\tPulse 1 para crear una Habitación:");
            Console.WriteLine("\n\tPulse 2 para crear una Terraza");

            opcion = Util.CapturaEntero("para seleccionar una opción de creación", 1, 2);
            Console.Clear();

            if (opcion == 1) // creamos un objeto del tipo Habitación
            {
                foreach (Recinto r in pBase.ListaRecintos)
                {
                    if (r.GetType().Name == "Habitacion") contHabitaciones++;
                }

                Console.WriteLine("\n\n\t----- Creamos el recinto Habitación -" + contHabitaciones + " ------");

                string nombre = "h-" + contHabitaciones;
                double mPared = Util.CapturaEntero("para definir los metros de pared", 10, 100);

                //... OJO con lo siguiente!!... hay un posibe fallo en el que podemos incurrir, que es que si ponemos más metros de puertas y ventanas superior a los metros de pared del piso, el precio resultante será negativo... para evitar esto, hay que modificar el máximo de puertas y ventanas que el usuario puede introducir(máximo flexible con una fórmula)
                int numPuertas = Util.CapturaEntero("para definir el número de puertas", 1, 10); // (int)(mPared / 0.8) 
                int numVentanas = Util.CapturaEntero("para definir el número de ventanas", 1, 10); // (int)(mPared - 0.8 * nP)
                int tipoPintura = Util.EligePintura(catalogo);

                pBase.ListaRecintos.Add
                (
                    new Habitacion(nombre, mPared, numPuertas, numVentanas, tipoPintura)
                );

                Console.WriteLine("\n\n\tPerfecto. Has creado la habitación " + nombre);
            }
            else // creamos un objeto del tipo Terraza
            {
                foreach (Recinto r in pBase.ListaRecintos)
                {
                    if (r.GetType().Name == "Terraza") contTerrazas++;
                }

                Console.WriteLine("\n\n\t----- Creamos el recinto Terraza -" + contTerrazas + " ------");

                string nombre = "t-" + contTerrazas;
                double mPared = Util.CapturaEntero("para definir los metros de pared", 10, 100);

                //... OJO con lo siguiente!!... hay un posibe fallo en el que podemos incurrir, que es que si ponemos más metros de puertas y ventanas superior a los metros de pared del piso, el precio resultante será negativo... para evitar esto, hay que modificar el máximo de puertas y ventanas que el usuario puede introducir(máximo flexible con una fórmula)
                int numPuertas = Util.CapturaEntero("para definir el número de puertas", 1, 10); // (int)(mPared / 0.8) 
                int numVentanas = Util.CapturaEntero("para definir el número de ventanas", 1, 10); // (int)(mPared - 0.8 * nP)
                double mPetril = Util.CapturaEntero("para definir los metros de petril", 1, 20);
                int tipoPintura = Util.EligePintura(catalogo);

                pBase.ListaRecintos.Add
                (
                    new Terraza(nombre, mPared, numPuertas, numVentanas, tipoPintura, mPetril)
                );

                Console.WriteLine("\n\n\tPerfecto. Has creado la terraza " + nombre);
            }
        }

        public static Recinto SeleccionarRecinto(Piso pBase)
        {
            string nombre = string.Empty;
            bool nombreOk = false;

            do
            {
                Console.WriteLine("\n");

                foreach (Recinto r in pBase.ListaRecintos)
                    Console.WriteLine("\t" + r.Nombre);

                nombreOk = false;
                Console.Write("\n\n\tIntroduzca el nombre del recinto a buscar:\t");
                nombre = Console.ReadLine();

                for (int i = 0; i < pBase.ListaRecintos.Count; i++)
                {
                    if (pBase.ListaRecintos[i].Nombre.ToLower() == nombre.ToLower())
                    {
                        nombreOk = true;

                        // al volcar el objeto por el que va recorriendo la lista en nuestra variable "recintoAux" debemos diferenciar si se volcará como Habitación o Terraza
                        if (pBase.ListaRecintos[i].GetType().Name == "Habitacion")
                            recintoAux = (Habitacion)pBase.ListaRecintos[i];
                        else
                            recintoAux = (Terraza)pBase.ListaRecintos[i];
                    }
                }

                if (!nombreOk) Console.WriteLine("\n\n\tNingún nombre de la lista coincide con el introducido");

            } while (!nombreOk);

            return recintoAux;
        }

        public static void ModificarRecinto(Piso pBase, CatalogoPinturas catalogo)
        {
            Terraza terrazaAux = null;

            Console.WriteLine("\n\n\t----- Modifiquemos el recinto ------");

            recintoAux = SeleccionarRecinto(pBase);
            Console.Clear();

            Console.WriteLine("\n\n\t----- Está modificando el Recinto " + recintoAux.Nombre + " ------");

            double mPared = Util.CapturaEntero("para los metros de pared?", 1, 100);
            int numPuertas = Util.CapturaEntero("para el número de puertas", 1, 10);
            int numVentanas = Util.CapturaEntero("para el número de ventanas", 1, 10);
            int tipoPintura = Util.EligePintura(catalogo);

            recintoAux.MPared = mPared;
            recintoAux.NumPuertas = numPuertas;
            recintoAux.NumVentanas = numVentanas;
            recintoAux.TipoPintura = tipoPintura;

            if (recintoAux.GetType().Name == "Terraza")
            {
                // como mPteril es un atributo exclusivo de Terraza, necesitamos aquí una variable "terrazaAux" para que el objeto que guarda "recintoAux" adquiera la identidad de una Terraza
                terrazaAux = (Terraza)recintoAux;
                
                int mPetril = Util.CapturaEntero("para los metros de petril", 1, 10);
                terrazaAux.MPetril = mPetril;
            }

            Console.WriteLine("\n\n\tPerfecto. Has modificado el recinto " + recintoAux.Nombre);
        }

        public static void EliminarRecinto(Piso pBase)
        {
            Console.WriteLine("\n\n\t----- Eliminemos un recinto ------");

            recintoAux = SeleccionarRecinto(pBase);

            if (Util.PreguntaSiNo("¿¿ Esta seguro de eliminar el Recinto " + recintoAux.Nombre + " ??"))
            {
                for (int i = 1; i < pBase.ListaRecintos.Count; i++) // empezamos saltando la posición 0, donde está nuestro objeto auxiliar polimorfista (recintoAux), para que el usuario no pueda borrarlo
                {
                    if (pBase.ListaRecintos[i].Nombre == recintoAux.Nombre)
                    {
                        pBase.ListaRecintos.RemoveAt(i);
                    }
                }

                if (recintoAux.Nombre == "recintoAux")
                {
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\n\tNo puedes eliminar el recintoAux");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\n\n\tPerfecto. El recinto seleccionado ha sido "); Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("eliminada/o.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\n\tEl Recinto " + recintoAux.Nombre + " no ha sido eliminado");
                Console.ResetColor();
            }

        }
    }
}