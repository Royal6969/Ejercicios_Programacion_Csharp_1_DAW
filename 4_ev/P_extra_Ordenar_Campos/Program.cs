using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Ordenar_Campos
{
    class Program
    {
        static EquipoResultados equipoAux = new EquipoResultados("aux", 0, 0, 0, 0, 0, 0); // objeto auxiliar para el CRUD

        static void Main(string[] args)
        {
            string[] vMenu =
                {
                    "MENÚ DE CLASIFICACIÓN",
                    "Mostrar Lista SIN Ordenar",
                    "Mostrar Lista Por Orden de Nombres",
                    "Mostrar Lista Por Orden de Puntos",
                    "Mostrar Lista Por Orden de Partidos Ganados",
                    "Mostrar Lista Por Orden de Partidos Empatados",
                    "Mostrar Lista Por Orden de Partidos Perdidos",
                    "Mostrar Lista Por Orden de Goles a Favor",
                    "Mostrar Lista Por Orden de Goles en Contra",
                    "CRUD de Equipos"
                };

            Menu menu = new Menu(vMenu);
            int opcion = 0;
            List<EquipoResultados> listaEquiposResultados = new List<EquipoResultados>();
            List<EquipoResultados> listaBackUp = new List<EquipoResultados>();

            EquipoResultados.LeerFicheroGuardarRegistros(listaEquiposResultados);

            for (int i = 0; i < listaEquiposResultados.Count; i++) // hago un backUp de la lista original
            {
                listaBackUp.Add(listaEquiposResultados[i]);
            }

            do
            {
                Console.Clear();
                opcion = menu.showMenu();
                Console.Clear();

                switch (opcion)
                {
                    case 1: // mostrar la clasificación SIN ordenar
                        MostrarListaEquipos(listaEquiposResultados);
                        break;

                    case 2: // mostrar la clasificación ordenada por nombres
                        listaEquiposResultados = OrdenarPorNombre(listaEquiposResultados);
                        break;

                    case 3: // mostrar la clasificación ordenada por puntos
                        listaEquiposResultados = OrdenarPorPuntos(listaEquiposResultados);
                        break;

                    case 4: // mostrar la clasificación ordenada por partidos ganados
                        listaEquiposResultados = OrdenarPorPartidosGanados(listaEquiposResultados);
                        break;

                    case 5: // mostrar la clasificación ordenada por partidos empatados
                        listaEquiposResultados = OrdenarPorPartidosEmpatados(listaEquiposResultados);
                        break;

                    case 6: // mostrar la clasificación ordenada por partidos perdidos
                        listaEquiposResultados = OrdenarPorPartidosPerdidos(listaEquiposResultados);
                        break;

                    case 7: // mostrar la clasificación ordenada por goles a favor
                        listaEquiposResultados = OrdenarPorGolesAfavor(listaEquiposResultados);
                        break;

                    case 8: // mostrar la clasificación ordenada por goles en contra
                        listaEquiposResultados = OrdenarPorGolesEnContra(listaEquiposResultados);
                        break;

                    case 9: // CRUD de equipos
                        CRUDdeEquipos(listaEquiposResultados);
                        break;
                }

                if (opcion == 2)
                    MostrarListaEquipos(listaEquiposResultados);

                if (opcion > 2 && opcion < 9) // predeterminadamente el orden será descendente
                {
                    listaEquiposResultados.Reverse();
                    MostrarListaEquipos(listaEquiposResultados);
                }

                ResetearListaEquipos(listaEquiposResultados, listaBackUp);
                Tools.BackToMenu(opcion);

            } while (opcion != 0);

            Tools.StopProgram();
        }

        /************************************************************************************************************************************/
        /********************************************************** MÉTODOS ****************************************************************/
        /***********************************************************************************************************************************/

        public static void ResetearListaEquipos(List<EquipoResultados> listaEquiposResultados, List<EquipoResultados> listaBackUp)
        {
            listaEquiposResultados.Clear();

            for (int i = 0; i < listaBackUp.Count; i++)
            {
                listaEquiposResultados.Add(listaBackUp[i]);
            }
        }

        public static void MostrarListaEquipos(List<EquipoResultados> listaEquiposResultados)
        {
            Console.WriteLine("\n\n\tEquipo             Pts  Pg  Pe  Pp  gf  gc");
            Console.WriteLine("\t-----------------  ---  --  --  --  --  --\n");

            foreach (EquipoResultados equipo in listaEquiposResultados)
                Console.WriteLine(equipo.ToString());
        }

        public static void MostrarEquiposPorNombres_v2(List<EquipoResultados> listaEquiposResultados)
        {
            Console.WriteLine("\n\n\tEquipo             Pts  Pg  Pe  Pp  gf  gc");
            Console.WriteLine("\t-----------------  ---  --  --  --  --  --\n");

            // listaEquiposResultados.Sort();
            // si hacemos simplemente .Sort() ... el comparador por defecto no podrá ordenar la lista ...
            // System.InvalidOperationException: 'No se pudieron comparar dos elementos en la matriz.'
            // ArgumentException: Al menos un objeto debe implementar IComparable.
            // tal como nos indica la excepción interna, debemos implementar una interfaz comparable, y crear un método para controlar la ordenación...
            // en este momento, volvemos a la clase EquipoResultados para implementar la interfaz IComparable y generar el método CompareTo()

            listaEquiposResultados.Sort();

            foreach (EquipoResultados equipo in listaEquiposResultados)
                Console.WriteLine(equipo.ToString());
        }

        public static List<EquipoResultados> OrdenarPorNombre(List<EquipoResultados> listaEquiposResultados)
        {
            List<EquipoResultados> listaAux = new List<EquipoResultados>();

            foreach (EquipoResultados equipo in listaEquiposResultados)
            {
                if (listaAux.Count == 0) // si se trata de la primera vuelta, añado directamente el primer equipo de la lista
                    listaAux.Add(equipo);

                else
                {
                    for (int i = 0; i < listaAux.Count; i++)
                    {
                        //compruebo si el nombre del equipo por el que va recorriendo la listaAux es previo alfabéticamente al que estoy leyendo de la lista real con el forEach, y si lo es, lo añado en su correspondiente posición
                        if (equipo.Nombre.CompareTo(listaAux[i].Nombre) < 0 || (equipo.Nombre.CompareTo(listaAux[i].Nombre) == 0))
                        {
                            listaAux.Insert(i, equipo);
                            break;
                        }
                        // si por el contrario es posterior alfabéticamente y además es la ultima vuelta, añado el equipo en el último lugar
                        else if (equipo.Nombre.CompareTo(listaAux[i].Nombre) > 0 && i == listaAux.Count - 1)
                        {
                            listaAux.Insert(listaAux.Count, equipo);
                            break;
                        }
                    }
                }
            }

            return listaAux;
        }

        public static List<EquipoResultados> OrdenarPorPuntos(List<EquipoResultados> listaEquiposResultados)
        {
            List<EquipoResultados> listaAux = new List<EquipoResultados>();

            foreach (EquipoResultados equipo in listaEquiposResultados)
            {
                if (listaAux.Count == 0) // si se trata de la primera vuelta, añado directamente el primer equipo de la lista
                    listaAux.Add(equipo);

                else
                {
                    for (int i = 0; i < listaAux.Count; i++)
                    {
                        //compruebo si el nombre del equipo por el que va recorriendo la listaAux es previo alfabéticamente al que estoy leyendo de la lista real con el forEach, y si lo es, lo añado en su correspondiente posición
                        if (equipo.Puntos.CompareTo(listaAux[i].Puntos) < 0 || (equipo.Puntos.CompareTo(listaAux[i].Puntos) == 0))
                        {
                            listaAux.Insert(i, equipo);
                            break;
                        }
                        // si por el contrario es posterior alfabéticamente y además es la ultima vuelta, añado el equipo en el último lugar
                        else if (equipo.Puntos.CompareTo(listaAux[i].Puntos) > 0 && i == listaAux.Count - 1)
                        {
                            listaAux.Insert(listaAux.Count, equipo);
                            break;
                        }
                    }
                }
            }

            return listaAux;
        }

        public static List<EquipoResultados> OrdenarPorPartidosGanados(List<EquipoResultados> listaEquiposResultados)
        {
            List<EquipoResultados> listaAux = new List<EquipoResultados>();

            foreach (EquipoResultados equipo in listaEquiposResultados)
            {
                if (listaAux.Count == 0) // si se trata de la primera vuelta, añado directamente el primer equipo de la lista
                    listaAux.Add(equipo);

                else
                {
                    for (int i = 0; i < listaAux.Count; i++)
                    {
                        //compruebo si el nombre del equipo por el que va recorriendo la listaAux es previo alfabéticamente al que estoy leyendo de la lista real con el forEach, y si lo es, lo añado en su correspondiente posición
                        if (equipo.PartidosGanados.CompareTo(listaAux[i].PartidosGanados) < 0 || (equipo.PartidosGanados.CompareTo(listaAux[i].PartidosGanados) == 0))
                        {
                            listaAux.Insert(i, equipo);
                            break;
                        }
                        // si por el contrario es posterior alfabéticamente y además es la ultima vuelta, añado el equipo en el último lugar
                        else if (equipo.PartidosGanados.CompareTo(listaAux[i].PartidosGanados) > 0 && i == listaAux.Count - 1)
                        {
                            listaAux.Insert(listaAux.Count, equipo);
                            break;
                        }
                    }
                }
            }

            return listaAux;
        }

        public static List<EquipoResultados> OrdenarPorPartidosEmpatados(List<EquipoResultados> listaEquiposResultados)
        {
            List<EquipoResultados> listaAux = new List<EquipoResultados>();

            foreach (EquipoResultados equipo in listaEquiposResultados)
            {
                if (listaAux.Count == 0) // si se trata de la primera vuelta, añado directamente el primer equipo de la lista
                    listaAux.Add(equipo);

                else
                {
                    for (int i = 0; i < listaAux.Count; i++)
                    {
                        //compruebo si el nombre del equipo por el que va recorriendo la listaAux es previo alfabéticamente al que estoy leyendo de la lista real con el forEach, y si lo es, lo añado en su correspondiente posición
                        if (equipo.PartidosEmpatados.CompareTo(listaAux[i].PartidosEmpatados) < 0 || (equipo.PartidosEmpatados.CompareTo(listaAux[i].PartidosEmpatados) == 0))
                        {
                            listaAux.Insert(i, equipo);
                            break;
                        }
                        // si por el contrario es posterior alfabéticamente y además es la ultima vuelta, añado el equipo en el último lugar
                        else if (equipo.PartidosEmpatados.CompareTo(listaAux[i].PartidosEmpatados) > 0 && i == listaAux.Count - 1)
                        {
                            listaAux.Insert(listaAux.Count, equipo);
                            break;
                        }
                    }
                }
            }

            return listaAux;
        }

        public static List<EquipoResultados> OrdenarPorPartidosPerdidos(List<EquipoResultados> listaEquiposResultados)
        {
            List<EquipoResultados> listaAux = new List<EquipoResultados>();

            foreach (EquipoResultados equipo in listaEquiposResultados)
            {
                if (listaAux.Count == 0) // si se trata de la primera vuelta, añado directamente el primer equipo de la lista
                    listaAux.Add(equipo);

                else
                {
                    for (int i = 0; i < listaAux.Count; i++)
                    {
                        //compruebo si el nombre del equipo por el que va recorriendo la listaAux es previo alfabéticamente al que estoy leyendo de la lista real con el forEach, y si lo es, lo añado en su correspondiente posición
                        if (equipo.PartidosPerdidos.CompareTo(listaAux[i].PartidosPerdidos) < 0 || (equipo.PartidosPerdidos.CompareTo(listaAux[i].PartidosPerdidos) == 0))
                        {
                            listaAux.Insert(i, equipo);
                            break;
                        }
                        // si por el contrario es posterior alfabéticamente y además es la ultima vuelta, añado el equipo en el último lugar
                        else if (equipo.PartidosPerdidos.CompareTo(listaAux[i].PartidosPerdidos) > 0 && i == listaAux.Count - 1)
                        {
                            listaAux.Insert(listaAux.Count, equipo);
                            break;
                        }
                    }
                }
            }

            return listaAux;
        }

        public static List<EquipoResultados> OrdenarPorGolesAfavor(List<EquipoResultados> listaEquiposResultados)
        {
            List<EquipoResultados> listaAux = new List<EquipoResultados>();

            foreach (EquipoResultados equipo in listaEquiposResultados)
            {
                if (listaAux.Count == 0) // si se trata de la primera vuelta, añado directamente el primer equipo de la lista
                    listaAux.Add(equipo);

                else
                {
                    for (int i = 0; i < listaAux.Count; i++)
                    {
                        //compruebo si el nombre del equipo por el que va recorriendo la listaAux es previo alfabéticamente al que estoy leyendo de la lista real con el forEach, y si lo es, lo añado en su correspondiente posición
                        if (equipo.GolesAfavor.CompareTo(listaAux[i].GolesAfavor) < 0 || (equipo.GolesAfavor.CompareTo(listaAux[i].GolesAfavor) == 0))
                        {
                            listaAux.Insert(i, equipo);
                            break;
                        }
                        // si por el contrario es posterior alfabéticamente y además es la ultima vuelta, añado el equipo en el último lugar
                        else if (equipo.GolesAfavor.CompareTo(listaAux[i].GolesAfavor) > 0 && i == listaAux.Count - 1)
                        {
                            listaAux.Insert(listaAux.Count, equipo);
                            break;
                        }
                    }
                }
            }

            return listaAux;
        }

        public static List<EquipoResultados> OrdenarPorGolesEnContra(List<EquipoResultados> listaEquiposResultados)
        {
            List<EquipoResultados> listaAux = new List<EquipoResultados>();

            foreach (EquipoResultados equipo in listaEquiposResultados)
            {
                if (listaAux.Count == 0) // si se trata de la primera vuelta, añado directamente el primer equipo de la lista
                    listaAux.Add(equipo);

                else
                {
                    for (int i = 0; i < listaAux.Count; i++)
                    {
                        //compruebo si el nombre del equipo por el que va recorriendo la listaAux es previo alfabéticamente al que estoy leyendo de la lista real con el forEach, y si lo es, lo añado en su correspondiente posición
                        if (equipo.GolesEnContra.CompareTo(listaAux[i].GolesEnContra) < 0 || (equipo.GolesEnContra.CompareTo(listaAux[i].GolesEnContra) == 0))
                        {
                            listaAux.Insert(i, equipo);
                            break;
                        }
                        // si por el contrario es posterior alfabéticamente y además es la ultima vuelta, añado el equipo en el último lugar
                        else if (equipo.GolesEnContra.CompareTo(listaAux[i].GolesEnContra) > 0 && i == listaAux.Count - 1)
                        {
                            listaAux.Insert(listaAux.Count, equipo);
                            break;
                        }
                    }
                }
            }

            return listaAux;
        }


        /************************************************************************************************************************************/
        /********************************************************** CRUD ****************************************************************/
        /***********************************************************************************************************************************/

        public static void CRUDdeEquipos(List<EquipoResultados> listaEquiposResultados)
        {
            string[] vMenu =
                {
                    "MENÚ DEL CRUD",
                    "Mostrar Equipos",
                    "Añadir Equipo",
                    "Modificar Equipo",
                    "Eliminar Equipo"
                };
            Menu menu = new Menu(vMenu);
            int opcion = 0;

            do
            {
                Console.Clear();
                opcion = menu.showMenu();
                Console.Clear();

                Console.Clear();

                switch (opcion)
                {
                    case 0:
                        Console.WriteLine("\n\n\tHa elegido la opción 0 de Salir");
                        break;

                    case 1: // mostrar equipos
                        MostrarListaEquipos(listaEquiposResultados);
                        break;

                    case 2: // crear equipo
                        AñadirEquipo(listaEquiposResultados);
                        break;

                    case 3: // modificar equipo
                        ModificarEquipo(listaEquiposResultados);
                        break;

                    case 4: // eliminar equipo
                        EliminarEquipo(listaEquiposResultados);
                        break;
                }

                Tools.BackToMenu(opcion);

            } while (opcion != 0);
        }

        public static void AñadirEquipo(List<EquipoResultados> listaEquiposResultados)
        {
            string nombre = Tools.CapturaNombre();
            byte puntos = (byte)Tools.CapturaEntero_Normal("¿Puntos?", 0, 999);
            byte partidosGanados = (byte)Tools.CapturaEntero_Normal("¿Partidos Ganados?", 0, 99);
            byte partidosEmpatados = (byte)Tools.CapturaEntero_Normal("¿Partidos Empatados?", 0, 99);
            byte partidosPerdidos = (byte)Tools.CapturaEntero_Normal("¿Partidos Perdidos?", 0, 99);
            byte golesAfavor = (byte)Tools.CapturaEntero_Normal("¿Goles a Favor?", 0, 99);
            byte golesEnContra = (byte)Tools.CapturaEntero_Normal("¿Goles en Contra?", 0, 99);

            EquipoResultados equipo = new EquipoResultados(nombre, puntos, partidosGanados, partidosEmpatados, partidosPerdidos, golesAfavor, golesEnContra);

            listaEquiposResultados.Add(equipo);

            Console.WriteLine("\n\n\tPerfecto. Equipo añadido correctamente.");
        }

        public static EquipoResultados SeleccionarEquipo(List<EquipoResultados> listaEquiposResultados)
        {
            string nombre = string.Empty;
            bool nombreOk = false;

            do
            {
                MostrarListaEquipos(listaEquiposResultados);

                nombreOk = false;
                Console.Write("\n\n\tIntroduzca el nombre del equipo a buscar:\t");
                nombre = Console.ReadLine();

                for (int i = 0; i < listaEquiposResultados.Count; i++)
                {
                    if (listaEquiposResultados[i].Nombre.ToLower() == nombre.ToLower())
                    {
                        nombreOk = true;
                        equipoAux = listaEquiposResultados[i];
                    }
                }

                if (!nombreOk) Tools.Error("Ningún nombre de la lista coincide con el introducido");

            } while (!nombreOk);

            return equipoAux;
        }

        public static void ModificarEquipo(List<EquipoResultados> listaEquiposResultados)
        {
            equipoAux = SeleccionarEquipo(listaEquiposResultados); // se modifica el objeto por referencia

            Console.Clear();
            Console.WriteLine("\n\n\t----- Está modificando el equipo:\n");
            Console.WriteLine(equipoAux.ToString());

            equipoAux.Nombre = Tools.CapturaNombre();
            equipoAux.Puntos = (byte)Tools.CapturaEntero_Normal("¿Puntos?", 0, 999);
            equipoAux.PartidosGanados = (byte)Tools.CapturaEntero_Normal("¿Partidos Ganados?", 0, 99);
            equipoAux.PartidosEmpatados = (byte)Tools.CapturaEntero_Normal("¿Partidos Empatados?", 0, 99);
            equipoAux.PartidosPerdidos = (byte)Tools.CapturaEntero_Normal("¿Partidos Perdidos?", 0, 99);
            equipoAux.GolesAfavor = (byte)Tools.CapturaEntero_Normal("¿Goles en Favor?", 0, 99);
            equipoAux.GolesEnContra = (byte)Tools.CapturaEntero_Normal("¿Goles en Contra?", 0, 99);

            Console.WriteLine("\n\n\tPerfecto. Has modificado el equipo " + equipoAux.Nombre);
        }

        public static void EliminarEquipo(List<EquipoResultados> listaEquiposResultados)
        {
            equipoAux = SeleccionarEquipo(listaEquiposResultados);

            if (Tools.PreguntaSiNo("¿Eliminar el equipo " + equipoAux.Nombre + "?"))
            {
                for (int i = 0; i < listaEquiposResultados.Count; i++)
                {
                    if (listaEquiposResultados[i].Nombre == equipoAux.Nombre)
                    {
                        listaEquiposResultados.RemoveAt(i);
                    }
                }

                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\n\n\tPerfecto. El equipo seleccionado ha sido "); Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("eliminada/o.");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\n\tEl equipo seleccionado NO ha sido eliminado");
                Console.ResetColor();
            }
        }
    }
}
