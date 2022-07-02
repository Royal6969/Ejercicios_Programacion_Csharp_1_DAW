using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P51_CRUD_Pacientes_Con_Diccionarios
{
    class Program
    {
        static Paciente pacienteAux = new Paciente(0, "", 666666666, new Fecha(01, 01, 2000), 0, 0);

        static void Main(string[] args)
        {
            Random random = new Random(); // para generar el id en el método de AñadirPaciente()

            string[] vMenu = 
                { 
                    "MENÚ DE PACIENTES", 
                    "Mostrar Lista", 
                    "Añadir Paciente", 
                    "Modificar Paciente", 
                    "Eliminar Paciente",
                };
            
            Menu menu = new Menu(vMenu);
            int opcion = 0;
            Dictionary<byte, Paciente> dicPacientes = new Dictionary<byte, Paciente>();

            Paciente.LeerFicheroGuardarRegistros(dicPacientes);

            do
            {
                Console.Clear();
                opcion = menu.showMenu();
                Console.Clear();

                switch (opcion)
                {
                    case 1: // mostrar los pacientes
                        MostrarPacientes(dicPacientes);
                        break;

                    case 2: // añadir un paciente
                        AñadirPaciente(dicPacientes, random);
                        break;

                    case 3: // modificar un paciente
                        ModificarPaciente(dicPacientes);
                        break;

                    case 4: // eliminar un paciente
                        EliminarPaciente(dicPacientes);
                        break;
                }

                Tools.BackToMenu(opcion);

            } while (opcion != 0);

            Tools.StopProgram();
        }

        /************************************************************************************************************************************/
        /********************************************************** CRUD ****************************************************************/
        /***********************************************************************************************************************************/

        public static void MostrarPacientes(Dictionary<byte, Paciente> dicPacientes)
        {
            float pesoMedio = 0;

            Console.WriteLine("\n\n\tID   Paciente                  Teléfono    Fecha Nac.     Edad   Altura    Peso");
            Console.WriteLine("\t---  ------------------------  ---------   ----------     ----   ------    -----\n");

            foreach (KeyValuePair<byte, Paciente> paciente in dicPacientes)
            {
                Console.WriteLine(paciente.Value.ToString());

                pesoMedio += paciente.Value.Peso;
            }

            Console.WriteLine("\n\n\tEl peso medio de todos los pacientes es:\t" + (pesoMedio / dicPacientes.Count).ToString("00.00"));
        }

        public static void AñadirPaciente(Dictionary<byte, Paciente> dicPacientes, Random random)
        {
            byte id;

            do
            {
                id = (byte)Tools.GenerarId(random);

            } while (dicPacientes.ContainsKey(id));

            string nombre = Tools.CapturaNombre();
            int telefono = Tools.CapturaTelefonoEsp();
            Fecha fechaNac = Tools.CapturaFechaNac();
            byte altura = (byte)Tools.CapturaEntero_Normal("Introduzca la altura en cm", 1, 999);
            float peso = Tools.CapturaFloat("Introduzca el peso en kg", 1, 999);

            Paciente paciente = new Paciente(id, nombre, telefono, fechaNac, altura, peso);

            dicPacientes.Add(id, paciente);

            Console.WriteLine("\n\n\tPerfecto. Paciente añadido correctamente.");
        }

        public static Paciente SeleccionarPaciente(Dictionary<byte, Paciente> dicPacientes)
        {
            byte id;
            bool idOk = false;

            do
            {
                Console.WriteLine("\n\n\tID   Paciente");
                Console.WriteLine("\t---  ------------------------\n");

                foreach (KeyValuePair<byte, Paciente> paciente in dicPacientes)
                {
                    Console.WriteLine("\t" + Tools.CuadraTexto(Tools.CuadraUnidad(paciente.Value.Id), 5) + paciente.Value.Nombre);
                }

                idOk = false;
                Console.Write("\n\n\tIntroduzca el ID del paciente a buscar:\t");
                id = (byte)Tools.CapturaEntero_Normal("", 1, 999);

                
                if (dicPacientes.ContainsKey(id))
                {
                    idOk = true;
                }

                if (!idOk) Console.WriteLine("\n\n\tNingún ID de la lista coincide con el introducido");

            } while (!idOk);

            return dicPacientes[id];
        }

        public static void ModificarPaciente(Dictionary<byte, Paciente> dicPacientes)
        {
            pacienteAux = SeleccionarPaciente(dicPacientes);

            Console.Clear();
            Console.WriteLine("\n\n\t----- Está modificando el paciente:\n");
            Console.WriteLine(pacienteAux.ToString());

            pacienteAux.Nombre = Tools.CapturaNombre();
            pacienteAux.Telefono = Tools.CapturaTelefonoEsp();
            pacienteAux.FechaNac = Tools.CapturaFechaNac();
            pacienteAux.Altura = (byte)Tools.CapturaEntero_Normal("Introduzca la altura en cm", 1, 999);
            pacienteAux.Peso = Tools.CapturaFloat("Introduzca el peso en kg", 1, 999);

            dicPacientes[pacienteAux.Id] = pacienteAux;

            Console.WriteLine("\n\n\tPerfecto. Has modificado el paciente " + dicPacientes[pacienteAux.Id].Nombre);
        }

        public static void EliminarPaciente(Dictionary<byte, Paciente> dicPacientes)
        {
            pacienteAux = SeleccionarPaciente(dicPacientes);

            if (Tools.PreguntaSiNo("¿Eliminar el paciente " + pacienteAux.Nombre + "?"))
            {
                dicPacientes.Remove(pacienteAux.Id);

                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("\n\n\tPerfecto. El paciente seleccionado ha sido "); Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("eliminada/o.");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\n\tEl paciente seleccionado NO ha sido eliminado");
                Console.ResetColor();
            }
        }
    }
}
