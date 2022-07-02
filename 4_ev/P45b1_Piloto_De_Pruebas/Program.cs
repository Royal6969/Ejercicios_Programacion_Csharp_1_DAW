using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P45b_Piloto_De_Pruebas
{
    class Program
    {
        static Avion avionAux = new AvionAutomatico("avionAux", "aux", "0000ZZZ", 1000, 1000); // con este objeto auxiliar, probaremos el Polimorfismo! 😀

        static void Main(string[] args)
        {
            Avion avion1 = new Avion("Flyanair", "a1", "1111AAA", 1000, 800);
            Avion automatico1 = new AvionAutomatico("SpaceX", "au1", "1212ABA", 1000, 800);

            List<Avion> listaAviones = new List<Avion>(); // esta lista es polimorfista, admite tanto avión estándar como avión automático! 😀

            listaAviones.Add(avionAux);
            listaAviones.Add(avion1);
            listaAviones.Add(automatico1);

            int cantidad = 0;
            int opcion1 = 0; // para el menú principal de elegir el tipo de avión
            int opcion2 = 0; // para el menú secundario de las opciones de cada avión
            int contEstandar = 0;
            int contAutomatico = 0;

            do
            {
                Console.Clear();
                opcion1 = 0;
                MenuAviones();
                opcion1 = Tools.CapturaEntero_Limpiando_v2("para seleccionar una opción del menú", 0, 3);
                Console.Clear();

                switch (opcion1)
                {
                    case 0:
                        Console.WriteLine("\n\n\tHa elegido la opción 0 de Salir");
                        break;

                    case 1:
                        ProbarAvionEstandar(listaAviones, opcion2, cantidad);
                        break;

                    case 2:
                        ProbarAvionAutomatico(listaAviones, opcion2, cantidad);
                        break;

                    case 3:
                        CRUDdeAviones(listaAviones, opcion2, cantidad, contEstandar, contAutomatico);
                        break;
                }

            } while (opcion1 != 0);

            Tools.StopProgram();
        }

        /************************************************************************************************************************************/
        /********************************************************** MÉTODOS ****************************************************************/
        /***********************************************************************************************************************************/

        public static void MenuAviones()
        {
            Console.Clear();

            Console.WriteLine("\n\n\n\n\n\n\t\t\t╔════════════════════════════╗");
            Console.WriteLine("\t\t\t║     Opcíones de Aviones    ║");
            Console.WriteLine("\t\t\t╠════════════════════════════╣");
            Console.WriteLine("\t\t\t║ 1) Probar Avión Estándar   ║");
            Console.WriteLine("\t\t\t║ 2) Probar Avión Automático ║");
            Console.WriteLine("\t\t\t║ 3) CRUD de aviones         ║");
            Console.WriteLine("\t\t\t║                            ║");
            Console.WriteLine("\t\t\t║ 0) Salir                   ║");
            Console.WriteLine("\t\t\t╚════════════════════════════╝");
        }

        public static void ProbarAvionEstandar(List<Avion> listaAviones, int opcion2, int cantidad)
        {
            avionAux = SeleccionarEstandar_o_Automatico(listaAviones);

            if (avionAux.GetType().Name != "Avion")
            {
                Console.Clear();
                Tools.Error_vProfesor2("Debes seleccionar un avión de tipo estándar.");
            }
            else
            {
                do
                {
                    opcion2 = 0;
                    cantidad = 0;
                    Console.Clear();

                    Console.WriteLine("\n\n\tTipo        Marca        Modelo    Matrícula    Altitud    AltitudMax    Velocidad    VelocidadMax");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t" + avionAux.ToString());

                    Tools.ShowMenu();
                    opcion2 = Tools.CapturaEntero_Limpiando_v2("para seleccionar una opción del menú", 0, 6);
                    Console.Clear();

                    switch (opcion2)
                    {
                        case 0:
                            if (avionAux.EnVuelo || avionAux.Velocidad != 0)
                            {
                                Tools.Error_vProfesor2("Para salir el avión tiene que estar parado en la pista");
                            }
                            else
                            {
                                Console.WriteLine("\n\n\tHa elegido la opción 0 de Salir");
                            }
                            break;

                        case 1:
                            if (!avionAux.EnVuelo && avionAux.Velocidad == 400)
                            {
                                Tools.Error_vProfesor2("Ya no se puede acelerar más antes de despegar... Despega ya!");
                            }
                            else if (avionAux.EnVuelo && avionAux.Velocidad == avionAux.VelocidadMax)
                            {
                                Tools.Error_vProfesor2("No se puede acelerar más de máximo permitido de " + avionAux.VelocidadMax + "km/h");
                            }
                            else
                            {
                                cantidad = Tools.CapturaEntero_Limpiando_v1("para aumentar la velocidad en km/h", 0, 200);
                                avionAux.AumentarVelocidad(cantidad);
                            }
                            break;

                        case 2:
                            if (!avionAux.EnVuelo && avionAux.Velocidad == 0)
                            {
                                Tools.Error_vProfesor2("Las leyes de la física impiden poner la velocidad en negativo");
                            }
                            else if (avionAux.EnVuelo && avionAux.Velocidad == 200)
                            {
                                Tools.Error_vProfesor2("No se puede reducir la velocidad, el mínimo para volar es 200km/h");
                            }
                            else
                            {
                                cantidad = Tools.CapturaEntero_Limpiando_v1("para reducir la velocidad en km/h", 0, 200);
                                avionAux.DisminuirVelocidad(cantidad);
                            }
                            break;

                        case 3:
                            avionAux.Despegar();
                            break;

                        case 4:
                            if (!avionAux.EnVuelo)
                            {
                                Tools.Error_vProfesor2("No se puede aumentar la altitud porque el avión no ha despegado");
                            }
                            else if (avionAux.Altitud == avionAux.AltitudMax)
                            {
                                Tools.Error_vProfesor2("No se puede volar más alto de máximo permitido de " + avionAux.AltitudMax + "m");
                            }
                            else
                            {
                                cantidad = Tools.CapturaEntero_Limpiando_v1("para aumentar la altitud en metros", 0, 200);
                                avionAux.AumentarAltitud(cantidad);
                            }
                            break;

                        case 5:
                            if (!avionAux.EnVuelo)
                            {
                                Tools.Error_vProfesor2("No se puede reducir la altitud porque el avión no ha despegado");
                            }
                            else if (avionAux.Altitud == 100)
                            {
                                Tools.Error_vProfesor2("No se puede volar más bajo del mínimo permitido de 100m");
                            }
                            else
                            {
                                cantidad = Tools.CapturaEntero_Limpiando_v1("para reducir la altitud en metros", 0, 200);
                                avionAux.DisminuirAltitud(cantidad);
                            }
                            break;

                        case 6:
                            avionAux.Aterrizar();
                            break;
                    }

                    Tools.BackToMenu(opcion2);

                } while (opcion2 != 0 || avionAux.Velocidad != 0); // otra opción, en vez de añadir en el while() la restricción de la velocidad, sería añadir en el case 0: opcion = -1
            }
        }

        public static void ProbarAvionAutomatico(List<Avion> listaAviones, int opcion2, int cantidad)
        {
            avionAux = SeleccionarEstandar_o_Automatico(listaAviones);

            if (avionAux.GetType().Name != "AvionAutomatico")
            {
                Console.Clear();
                Tools.Error_vProfesor2("Debes seleccionar un avión de tipo automático.");
            }
            else
            {
                do
                {
                    opcion2 = 0;
                    cantidad = 0;
                    Console.Clear();

                    Console.WriteLine("\n\n\tTipo        Marca        Modelo    Matrícula    Altitud    AltitudMax    Velocidad    VelocidadMax");
                    Console.WriteLine("\t----------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t" + avionAux.ToString());

                    Tools.ShowMenu();
                    opcion2 = Tools.CapturaEntero_Limpiando_v2("para seleccionar una opción del menú", 0, 6);
                    Console.Clear();

                    switch (opcion2)
                    {
                        case 0:
                            if (avionAux.EnVuelo || avionAux.Velocidad != 0)
                            {
                                Tools.Error_vProfesor2("Para salir el avión tiene que estar parado en la pista");
                            }
                            else
                            {
                                Console.WriteLine("\n\n\tHa elegido la opción 0 de Salir");
                            }
                            break;

                        case 1:
                            if (!avionAux.EnVuelo && avionAux.Velocidad == 400)
                            {
                                Tools.Error_vProfesor2("Ya no se puede acelerar más antes de despegar... Despega ya!");
                            }
                            else if (avionAux.EnVuelo && avionAux.Velocidad == avionAux.VelocidadMax)
                            {
                                Tools.Error_vProfesor2("No se puede acelerar más de máximo permitido de " + avionAux.VelocidadMax + "km/h");
                            }
                            else
                            {
                                cantidad = Tools.CapturaEntero("para aumentar la velocidad en km/h", 0, 200, 100); // DefaultValue 100
                                avionAux.AumentarVelocidad(cantidad);
                            }
                            break;

                        case 2:
                            if (!avionAux.EnVuelo && avionAux.Velocidad == 0)
                            {
                                Tools.Error_vProfesor2("Las leyes de la física impiden poner la velocidad en negativo");
                            }
                            else if (avionAux.EnVuelo && avionAux.Velocidad == 200)
                            {
                                Tools.Error_vProfesor2("No se puede reducir la velocidad, el mínimo para volar es 200km/h");
                            }
                            else
                            {
                                cantidad = Tools.CapturaEntero("para reducir la velocidad en km/h", 0, 200, 100); // DefaultValue 100
                                avionAux.DisminuirVelocidad(cantidad);
                            }
                            break;

                        case 3:
                            avionAux.Despegar();
                            break;

                        case 4:
                            if (!avionAux.EnVuelo)
                            {
                                Tools.Error_vProfesor2("No se puede aumentar la altitud porque el avión no ha despegado");
                            }
                            else if (avionAux.Altitud == avionAux.AltitudMax)
                            {
                                Tools.Error_vProfesor2("No se puede volar más alto de máximo permitido de " + avionAux.AltitudMax + "m");
                            }
                            else
                            {
                                cantidad = Tools.CapturaEntero("para aumentar la altitud en metros", 0, 200, 100); // DefaultValue 100
                                avionAux.AumentarAltitud(cantidad);
                            }
                            break;

                        case 5:
                            if (!avionAux.EnVuelo)
                            {
                                Tools.Error_vProfesor2("No se puede reducir la altitud porque el avión no ha despegado");
                            }
                            else if (avionAux.Altitud == 100)
                            {
                                Tools.Error_vProfesor2("No se puede volar más bajo del mínimo permitido de 100m");
                            }
                            else
                            {
                                cantidad = Tools.CapturaEntero("para reducir la altitud en metros", 0, 200, 100); // DefaultValue 100
                                avionAux.DisminuirAltitud(cantidad);
                            }
                            break;

                        case 6:
                            avionAux.Aterrizar();
                            break;
                    }

                    Tools.BackToMenu(opcion2);

                } while (opcion2 != 0 || avionAux.Velocidad != 0); // otra opción, en vez de añadir en el while() la restricción de la velocidad, sería añadir en el case 0: opcion = -1
            }  
        }

        /************************************************************************************************************************************/
        /********************************************************** CRUD *******************************************************************/
        /***********************************************************************************************************************************/

        public static void CRUDdeAviones(List<Avion> listaAviones, int opcion2, int cantidad, int contEstandar, int contAutomatico)
        {
            do
            {
                opcion2 = 0;
                cantidad = 0;
                contEstandar = 0;
                contAutomatico = 0;
                Console.Clear();

                Console.WriteLine("\n\n\n\n\n\n\t\t\t╔════════════════════════════╗");
                Console.WriteLine("\t\t\t║     Opcíones del CRUD      ║");
                Console.WriteLine("\t\t\t╠════════════════════════════╣");
                Console.WriteLine("\t\t\t║ 1) CREAR AVIÓN             ║");
                Console.WriteLine("\t\t\t║ 2) MODIFICAR AVIÓN         ║");
                Console.WriteLine("\t\t\t║ 3) ELIMINAR AVIÓN          ║");
                Console.WriteLine("\t\t\t║ 4) LISTAR AVIONES          ║");
                Console.WriteLine("\t\t\t║                            ║");
                Console.WriteLine("\t\t\t║ 0) Salir                   ║");
                Console.WriteLine("\t\t\t╚════════════════════════════╝");

                opcion2 = Tools.CapturaEntero_Limpiando_v2("para seleccionar una opción del menú", 0, 4);
                Console.Clear();

                switch (opcion2)
                {
                    case 0:
                        Console.WriteLine("\n\n\tHa elegido la opción 0 de Salir");
                        break;

                    case 1:
                        CrearEstandar_o_Automatico(opcion2, listaAviones, contEstandar, contAutomatico);
                        break;

                    case 2:
                        ModificarEstandar_o_Automatico(listaAviones);
                        break;

                    case 3:
                        EliminarEstandar_o_Automatico(listaAviones);
                        break;

                    case 4:
                        MostrarListaAviones(listaAviones, opcion2);
                        break;
                }

            } while (opcion2 != 0);

            Tools.BackToMenu(opcion2);
        }

        public static void CrearEstandar_o_Automatico(int opcion2, List<Avion> listaAviones, int contEstandar, int contAutomatico)
        {
            Console.WriteLine("\n\n\n\n\n\n\tPulse 1 para crear un Avión Estándar:");
            Console.WriteLine("\n\tPulse 2 para crear un Avión Automático");

            opcion2 = Tools.CapturaEntero_Limpiando_v2("para seleccionar una opción de creación", 1, 2);
            Console.Clear();

            if (opcion2 == 1) // creamos un objeto del tipo Avión Estandar
            {
                foreach (Avion a in listaAviones)
                {
                    if (a.GetType().Name == "Avion") contEstandar++;
                }

                contEstandar++;
                Console.WriteLine("\n\n\t----- Creamos el Avión Estándar -" + contEstandar + " ------");

                string marca = "ESP-EST";
                string modelo = "es-" + contEstandar;
                string matricula = (contEstandar + 1000) + "E";
                int altitudMax = Tools.CapturaEntero_Limpiando_v1("\n\t¿Altitud Máxima en metros?", 500, 1500);
                int velocidadMax = Tools.CapturaEntero_Limpiando_v1("\n\t¿Velocidad Máxima en km/h?", 500, 1500);

                listaAviones.Add
                (
                    new Avion(marca, modelo, matricula, altitudMax, velocidadMax)
                );

                Tools.MensajeOK_vProfesor2("Perfecto. Has creado el modelo es-" + contEstandar);
            }
            else // creamos un objeto del tipo Avión Automático
            {
                foreach (Avion a in listaAviones)
                {
                    if (a.GetType().Name == "AvionAutomatico") contAutomatico++;
                }

                contAutomatico++;
                Console.WriteLine("\n\n\t----- Creamos el Avión Automático -" + contAutomatico + " ------");

                string marca = "ESP-AUT";
                string modelo = "au-" + contAutomatico;
                string matricula = (contAutomatico + 1000) + "A";
                int altitudMax = Tools.CapturaEntero_Limpiando_v1("\n\t¿Altitud Máxima en metros?", 1000, 2000);
                int velocidadMax = Tools.CapturaEntero_Limpiando_v1("\n\t¿Velocidad máxima en km/h?", 1000, 2000);

                listaAviones.Add
                (
                    new AvionAutomatico(marca, modelo, matricula, altitudMax, velocidadMax)
                );

                Tools.MensajeOK_vProfesor2("Perfecto. Has creado el modelo au-" + contAutomatico);
            }
        }

        public static Avion ModificarEstandar_o_Automatico(List<Avion> listaAviones)
        {
            Console.WriteLine("\n\n\t----- Modifiquemos el avión ------");

            avionAux = SeleccionarEstandar_o_Automatico(listaAviones);
            Console.Clear();

            Console.WriteLine("\n\n\t----- Está modificando el modelo " + avionAux.Marca + " - " + avionAux.Modelo + " ------");

            int altitudMax = Tools.CapturaEntero_Limpiando_v1("\n\t¿Altitud Máxima en metros?", 1000, 2000);
            int velocidadMax = Tools.CapturaEntero_Limpiando_v1("\n\t¿Velocidad máxima en km/h?", 1000, 2000);

            avionAux.AltitudMax = altitudMax;
            avionAux.VelocidadMax = velocidadMax;

            Tools.MensajeOK_vProfesor2("Perfecto. Has modificado el avión " + avionAux.Marca + " - " + avionAux.Modelo);

            return avionAux;
        }

        public static Avion SeleccionarEstandar_o_Automatico(List<Avion> listaAviones)
        {
            string nombre = string.Empty;
            bool nombreOk = false;

            do
            {
                Console.WriteLine("\n\tTipo        Marca        Modelo    Matrícula    Altitud    AltitudMax    Velocidad    VelocidadMax");
                Console.WriteLine("\t----------------------------------------------------------------------------------------------------------");

                foreach (Avion a in listaAviones)
                    Console.WriteLine("\t" + a.ToString());

                nombreOk = false;
                Console.Write("\n\n\tIntroduzca el modelo del avión a buscar:\t");
                nombre = Console.ReadLine();

                for (int i = 0; i < listaAviones.Count; i++)
                {
                    if (listaAviones[i].Modelo.ToLower() == nombre.ToLower())
                    {
                        nombreOk = true;
                        avionAux = listaAviones[i];
                    }
                }

                if (!nombreOk) Tools.Error("Ningún nombre de la lista coincide con el introducido");

            } while (!nombreOk);

            return avionAux;
        }

        public static void EliminarEstandar_o_Automatico(List<Avion> listaAviones)
        {
            Console.WriteLine("\n\n\t----- Eliminemos un avión ------");

            avionAux = SeleccionarEstandar_o_Automatico(listaAviones);

            if (Tools.PreguntaSiNo("¿¿ Esta seguro de eliminar el objeto " + avionAux.Marca + " - " + avionAux.Modelo + " ??"))
            {
                for (int i = 1; i < listaAviones.Count; i++)
                {
                    if (listaAviones[i].Modelo == avionAux.Modelo)
                    {
                        listaAviones.RemoveAt(i);
                    }
                }

                Console.Clear();
                if (avionAux.Modelo == "aux")
                {
                    Tools.Error_vProfesor2("No puedes eliminar el modelo aux");
                }
                else
                {
                    Tools.MensajeOK_vProfesor2("Perfecto. El avión seleccionado ha sido eliminado");
                }
            }
            else
            {
                Console.Clear();
                Tools.Error_vProfesor2("El avión con el modelo " + avionAux.Modelo + " no ha sido eliminado.");
            }
        }

        public static void MostrarListaAviones(List<Avion> listaAviones, int opcion2)
        {
            Console.WriteLine("\n\n\tTipo        Marca        Modelo    Matrícula    Altitud    AltitudMax    Velocidad    VelocidadMax");
            Console.WriteLine("\t----------------------------------------------------------------------------------------------------------\n");

            foreach (Avion a in listaAviones)
            {
                Console.WriteLine("\t" + a.ToString());
            }

            Tools.BackToMenu(opcion2);
        }
    }
}
