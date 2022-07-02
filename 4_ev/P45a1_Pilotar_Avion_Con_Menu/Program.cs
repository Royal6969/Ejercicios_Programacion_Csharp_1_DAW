using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P45a1_Pilotar_Avion_Con_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Avion avion1 = new Avion("Flyanair", "a1", "1111AAA", 1000, 800);

            int cantidad;
            int opcion;

            do
            {
                cantidad = 0;
                Console.Clear();

                Console.WriteLine("\n\n\tMarca        Modelo        Matrícula        Altitud        AltitudMax        Velocidad        VelocidadMax");
                Console.WriteLine("\t----------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\t" + avion1.ToString());

                Tools.ShowMenu();
                opcion = Tools.CapturaEntero_Limpiando_v2("para seleccionar una opción del menú", 0, 6);
                Console.Clear();

                switch (opcion)
                {
                    case 0:
                        if (avion1.EnVuelo || avion1.Velocidad != 0)
                        {
                            Tools.Error_vProfesor2("Para salir el avión tiene que estar parado en la pista");
                        }
                        else
                        {
                            Console.WriteLine("\n\n\tHa elegido la opción 0 de Salir");
                        }
                        break;

                    // OJO, cómo venía corrigiendo en la clase Avión, los datos los pido aquí en el Main y realizo las comprobaciones al entrar en cada case

                    case 1:
                        if (!avion1.EnVuelo && avion1.Velocidad == 400)
                        {
                            Tools.Error_vProfesor2("Ya no se puede acelerar más antes de despegar... Despega ya!");
                        }
                        else if (avion1.EnVuelo && avion1.Velocidad == avion1.VelocidadMax)
                        {
                            Tools.Error_vProfesor2("No se puede acelerar más de máximo permitido de " + avion1.VelocidadMax + "km/h");
                        }
                        else
                        {
                            cantidad = Tools.CapturaEntero_Limpiando_v1("para aumentar la velocidad en km/h", 0, 200);
                            avion1.AumentarVelocidad(cantidad);
                        }
                        break;

                    case 2:
                        if (!avion1.EnVuelo && avion1.Velocidad == 0)
                        {
                            Tools.Error_vProfesor2("Las leyes de la física impiden poner la velocidad en negativo");
                        }
                        else if (avion1.EnVuelo && avion1.Velocidad == 200)
                        {
                            Tools.Error_vProfesor2("No se puede reducir la velocidad, el mínimo para volar es 200km/h");
                        }
                        else
                        {
                            cantidad = Tools.CapturaEntero_Limpiando_v1("para reducir la velocidad en km/h", 0, 200);
                            avion1.DisminuirVelocidad(cantidad);
                        }
                        break;

                    case 3:
                        avion1.Despegar();
                        break;

                    case 4:
                        if (!avion1.EnVuelo)
                        {
                            Tools.Error_vProfesor2("No se puede aumentar la altitud porque el avión no ha despegado");
                        }
                        else if (avion1.Altitud == avion1.AltitudMax)
                        {
                            Tools.Error_vProfesor2("No se puede volar más alto de máximo permitido de " + avion1.AltitudMax + "m");
                        }
                        else
                        {
                            cantidad = Tools.CapturaEntero_Limpiando_v1("para aumentar la altitud en metros", 0, 200);
                            avion1.AumentarAltitud(cantidad);
                        }
                        break;

                    case 5:
                        if (!avion1.EnVuelo)
                        {
                            Tools.Error_vProfesor2("No se puede reducir la altitud porque el avión no ha despegado");
                        }
                        else if (avion1.Altitud == 100)
                        {
                            Tools.Error_vProfesor2("No se puede volar más bajo del mínimo permitido de 100m");
                        }
                        else
                        {
                            cantidad = Tools.CapturaEntero_Limpiando_v1("para reducir la altitud en metros", 0, 200);
                            avion1.DisminuirAltitud(cantidad);
                        }
                        break;

                    case 6:
                        avion1.Aterrizar();
                        break;
                }

                Tools.BackToMenu(opcion);

            } while (opcion != 0 || avion1.Velocidad != 0); // otra opción, en vez de añadir en el while() la restricción de la velocidad, sería añadir en el case 0: opcion = -1

            Tools.StopProgram();
        }

        /************************************************************************************************************************************/
        /********************************************************** MÉTODOS ****************************************************************/
        /***********************************************************************************************************************************/

    }
}
