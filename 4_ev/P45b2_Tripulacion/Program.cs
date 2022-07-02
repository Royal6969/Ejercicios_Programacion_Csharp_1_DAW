using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace P45b_Tripulacion
{
    class Program
    {
        static Avion avion1 = new Avion("Flyanair", "a1", "1111AAA", 1000, 800);
        static Avion automatico1 = new AvionAutomatico("SpaceX", "au1", "1212ABA", 1000, 800);
        static Avion avionAux = new AvionAutomatico("avionAux", "aux", "0000ZZZ", 1000, 1000);

        static List<Pasajero> listaPasajeros = new List<Pasajero>();
        static Avion rescate1 = new AvionRescate("rescateAux", "aux", "0000YYY", 1000, 1000, listaPasajeros);
        static Pasajero pasajero = new Pasajero(12345678, 'A', "Sergio", "Díaz Campos", 95, 04, 17);

        static void Main(string[] args)
        {
            List<Avion> listaAviones = new List<Avion>(); 

            listaAviones.Add(avionAux);
            listaAviones.Add(avion1);
            listaAviones.Add(automatico1);

            int cantidad = 0;
            int opcion1 = 0;
            int opcion2 = 0;
            int contEstandar = 0;
            int contAutomatico = 0;

            do
            {
                MenuAviones();
                opcion1 = Tools.CapturaEntero_Limpiando_v2("para seleccionar una opción del menú", 0, 4);
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
                        MisionSalvarUcrania(opcion2, cantidad);
                        break;

                    case 4:
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
            Console.WriteLine("\t\t\t║     Opcíones de aviones    ║");
            Console.WriteLine("\t\t\t╠════════════════════════════╣");
            Console.WriteLine("\t\t\t║ 1) Probar Avión Estandar   ║");
            Console.WriteLine("\t\t\t║ 2) Probar Avión Automático ║");
            Console.WriteLine("\t\t\t║ 3) Misión Salvar Ucrania   ║");
            Console.WriteLine("\t\t\t║ 4) CRUD aviones            ║");
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

                    Console.WriteLine("\n\n\n\n\n\n\tTipo        Marca        Modelo    Matrícula    Altitud    AltitudMax    Velocidad    VelocidadMax");
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

                } while (opcion2 != 0 || avionAux.Velocidad != 0);
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

                    Console.WriteLine("\n\n\n\n\n\n\tTipo        Marca        Modelo    Matrícula    Altitud    AltitudMax    Velocidad    VelocidadMax");
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
                                Tools.Error_vProfesor2("No se puede acelerar más de máximo permitido de " +avionAux.VelocidadMax + "km/h");
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

                } while (opcion2 != 0 || avionAux.Velocidad != 0);
            }

        }

        public static void MisionSalvarUcrania(int opcion2, int cantidad)
        {
            rescate1.MisionCumplida = false;
            listaPasajeros = null;

            do
            {
                opcion2 = 0;
                cantidad = 0;
                Console.Clear();

                if (rescate1 != null)
                {
                    Console.WriteLine("\n\n\n\n\n\n\tTipo        Marca    Modelo    Matrícula    Altitud    AltitudMax    Velocidad    VelocidadMax    nPasajeros");
                    Console.WriteLine("\t-------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t" + rescate1.ToString());
                }

                Tools.ShowMenu2();
                opcion2 = Tools.CapturaEntero_Limpiando_v2("para seleccionar una opción del menú", 0, 8);
                Console.Clear();

                switch (opcion2)
                {
                    case 0:
                        if (!rescate1.MisionCumplida)
                        {
                            Tools.Error_vProfesor2("Aún tienes que terminar la misión");
                            opcion2 = -1;
                            break;
                        }

                        if (rescate1.EnVuelo || rescate1.Velocidad != 0)
                        {
                            Tools.Error_vProfesor2("Para salir el avión tiene que estar parado en la pista");
                        }
                        else
                        {
                            Console.WriteLine("\n\n\tHa elegido la opción 0 de Salir");
                        }
                        break;

                    case 1:
                        if (listaPasajeros != null && !rescate1.MisionCumplida)
                        {
                            Tools.Error_vProfesor2("Los pasajeros ya están a bordo, los subistes antes!");
                            opcion2 = -1;
                            break;
                        }

                        if (rescate1.MisionCumplida == true)
                        {
                            Tools.Error_vProfesor2("Ya has salvado a los heridos ucranianos. Descanse piloto!");
                            opcion2 = -1;
                            break;
                        }

                        Console.Write("\n\n\tAyudando a los heridos a subir al Avión de Rescate...");
                        Thread.Sleep(1500);

                        listaPasajeros = new List<Pasajero>();
                        pasajero.LeerFicheroGuardarRegistros(listaPasajeros);
                        rescate1 = new AvionRescate("Spain", "A400M", "9999ZZZ", 3000, 1500, listaPasajeros);

                        Console.Write("\n\n\tPerfecto, ya están todos a bordo!");
                        break;

                    case 2:
                        if (listaPasajeros == null && !rescate1.MisionCumplida)
                        {
                            Tools.Error_vProfesor2("Primeros debes ayudar a los heridos a subir a bordo");
                            opcion2 = -1;
                            break;
                        }

                        if (rescate1.MisionCumplida == true)
                        {
                            Tools.Error_vProfesor2("Ya has salvado a los heridos ucranianos. Descanse piloto!");
                            opcion2 = -1;
                            break;
                        }

                        pasajero.MostrarListaPasajeros(listaPasajeros);
                        break;

                    case 3:
                        if (listaPasajeros == null && !rescate1.MisionCumplida)
                        {
                            Tools.Error_vProfesor2("Primeros debes ayudar a los heridos a subir a bordo");
                            opcion2 = -1;
                            break;
                        }

                        if (rescate1.MisionCumplida == true)
                        {
                            Tools.Error_vProfesor2("Ya has salvado a los heridos ucranianos. Descanse piloto!");
                            opcion2 = -1;
                            break;
                        }

                        if (!rescate1.EnVuelo && rescate1.Velocidad == 400)
                        {
                            Tools.Error_vProfesor2("Ya no se puede acelerar más antes de despegar... Despega ya!");
                        }
                        else if (rescate1.EnVuelo && rescate1.Velocidad == rescate1.VelocidadMax)
                        {
                            Tools.Error_vProfesor2("No se puede acelerar más de máximo permitido de " + rescate1.VelocidadMax + "km/h");
                        }
                        else
                        {
                            cantidad = Tools.CapturaEntero_Limpiando_v1("para aumentar la velocidad en km/h", 0, 200);
                            rescate1.AumentarVelocidad(cantidad);
                        }
                        break;

                    case 4:
                        if (listaPasajeros == null && !rescate1.MisionCumplida)
                        {
                            Tools.Error_vProfesor2("Primeros debes ayudar a los heridos a subir a bordo");
                            opcion2 = -1;
                            break;
                        }

                        if (rescate1.MisionCumplida == true)
                        {
                            Tools.Error_vProfesor2("Ya has salvado a los heridos ucranianos. Descanse piloto!");
                            opcion2 = -1;
                            break;
                        }

                        if (!rescate1.EnVuelo && rescate1.Velocidad == 0)
                        {
                            Tools.Error_vProfesor2("Las leyes de la física impiden poner la velocidad en negativo");
                        }
                        else if (rescate1.EnVuelo && rescate1.Velocidad == 200)
                        {
                            Tools.Error_vProfesor2("No se puede reducir la velocidad, el mínimo para volar es 200km/h");
                        }
                        else
                        {
                            cantidad = Tools.CapturaEntero_Limpiando_v1("para reducir la velocidad en km/h", 0, 200);
                            rescate1.DisminuirVelocidad(cantidad);
                        }
                        break;

                    case 5:
                        if (listaPasajeros == null && !rescate1.MisionCumplida)
                        {
                            Tools.Error_vProfesor2("Primeros debes ayudar a los heridos a subir a bordo");
                            opcion2 = -1;
                            break;
                        }

                        if (rescate1.MisionCumplida == true)
                        {
                            Tools.Error_vProfesor2("Ya has salvado a los heridos ucranianos. Descanse piloto!");
                            opcion2 = -1;
                            break;
                        }

                        else
                        {
                            rescate1.Despegar();
                        }
                        break;

                    case 6:
                        if (listaPasajeros == null && !rescate1.MisionCumplida)
                        {
                            Tools.Error_vProfesor2("Primeros debes ayudar a los heridos a subir a bordo");
                            opcion2 = -1;
                            break;
                        }

                        if (rescate1.MisionCumplida == true)
                        {
                            Tools.Error_vProfesor2("Ya has salvado a los heridos ucranianos. Descanse piloto!");
                            opcion2 = -1;
                            break;
                        }

                        if (!rescate1.EnVuelo)
                        {
                            Tools.Error_vProfesor2("No se puede aumentar la altitud porque el avión no ha despegado");
                        }
                        else if (rescate1.Altitud == rescate1.AltitudMax)
                        {
                            Tools.Error_vProfesor2("No se puede volar más alto de máximo permitido de " + rescate1.AltitudMax + "m");
                        }
                        else
                        {
                            cantidad = Tools.CapturaEntero_Limpiando_v1("para aumentar la altitud en metros", 0, 200);
                            rescate1.AumentarAltitud(cantidad);
                        }
                        break;

                    case 7:
                        if (listaPasajeros == null && !rescate1.MisionCumplida)
                        {
                            Tools.Error_vProfesor2("Primeros debes ayudar a los heridos a subir a bordo");
                            opcion2 = -1;
                            break;
                        }

                        if (rescate1.MisionCumplida == true)
                        {
                            Tools.Error_vProfesor2("Ya has salvado a los heridos ucranianos. Descanse piloto!");
                            opcion2 = -1;
                            break;
                        }

                        if (!rescate1.EnVuelo)
                        {
                            Tools.Error_vProfesor2("No se puede reducir la altitud porque el avión no ha despegado");
                        }
                        else if (rescate1.Altitud == 100)
                        {
                            Tools.Error_vProfesor2("No se puede volar más bajo del mínimo permitido de 100m");
                        }
                        else
                        {
                            cantidad = Tools.CapturaEntero_Limpiando_v1("para reducir la altitud en metros", 0, 200);
                            rescate1.DisminuirAltitud(cantidad);
                        }
                        break;

                    case 8:
                        if (listaPasajeros == null && !rescate1.MisionCumplida)
                        {
                            Tools.Error_vProfesor2("Primeros debes ayudar a los heridos a subir a bordo");
                            opcion2 = -1;
                            break;
                        }

                        if (listaPasajeros != null && !rescate1.MisionCumplida)
                        {
                            rescate1.Aterrizar();
                        }

                        else if (rescate1.MisionCumplida == true)
                        {
                            Tools.Error_vProfesor2("Ya has salvado a los heridos ucranianos. Descanse piloto!");
                            opcion2 = -1;
                            break;
                        }

                        break;
                }

                Tools.BackToMenu(opcion2);

            } while (opcion2 != 0 || rescate1.Velocidad != 0);
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

            if (opcion2 == 1)
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

                Tools.MensajeOK_vProfesor2("Perfecto. Has creado el estandar-" + contEstandar);
            }
            else
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

                Tools.MensajeOK_vProfesor2("Perfecto. Has creado el automatico-" + contAutomatico);
            }
        }

        public static Avion ModificarEstandar_o_Automatico(List<Avion> listaAviones)
        {
            Console.WriteLine("\n\n\t----- Modifiquemos el avión ------");

            avionAux = SeleccionarEstandar_o_Automatico(listaAviones);
            Console.Clear();

            Console.WriteLine("\n\n\t----- Está modificando el modelo " + avionAux.Modelo + " ------");

            int altitudMax = Tools.CapturaEntero_Limpiando_v1("\n\t¿Altitud Máxima en metros?", 1000, 2000);
            int velocidadMax = Tools.CapturaEntero_Limpiando_v1("\n\t¿Velocidad máxima en km/h?", 1000, 2000);

            avionAux.AltitudMax = altitudMax;
            avionAux.VelocidadMax = velocidadMax;

            Tools.MensajeOK_vProfesor2("Perfecto. Has modificado el modelo " + avionAux.Modelo);

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