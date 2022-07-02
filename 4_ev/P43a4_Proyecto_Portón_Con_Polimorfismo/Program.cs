using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P43a4_Proyecto_Portón_Con_Polimorfismo
{
    class Program
    {
        public static Porton portonAux = new Porton("portonAux", 100, 80, ConsoleColor.White);
        public static Puerta puertaPortonAux = new Porton("puertaPortonAux", 100, 80, ConsoleColor.White); // con este objeto del tipo Puerta pero creado como Porton, manipularé los objetos de ambos tipos, y así probaré el Polimorfismo

        static void Main(string[] args)
        {
            List<Puerta> listaPuertasPortones = new List<Puerta>(); // a esta lista tipo Puerta le añadiré los objetos tipo Porton, y así probaré también el Polimorfismo

            Puerta puertaBase1 = new Puerta("puertaBase1", 100, 80, ConsoleColor.White);
            Puerta puertaBase2 = new Puerta("puertaBase2", 100, 80, ConsoleColor.White);

            Porton portonBase1 = new Porton("portonBase1", 150, 130, ConsoleColor.White);
            Porton portonBase2 = new Porton("portonBase2", 200, 180, ConsoleColor.White);

            listaPuertasPortones.Add(puertaPortonAux); // añado la PuertaPortonAux para remarcar el polismorfismo
            listaPuertasPortones.Add(portonAux);       // añado el PortonAux para remarcar el polimorfismo

            listaPuertasPortones.Add(puertaBase1);
            listaPuertasPortones.Add(puertaBase2);

            listaPuertasPortones.Add(portonBase1);
            listaPuertasPortones.Add(portonBase2);

            int contPuertas = 0;
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
                        AbrirTodasAbrirUna(opcion, listaPuertasPortones);
                        break;

                    case 2:
                        CerrarTodasAbrirUna(opcion, listaPuertasPortones);
                        break;

                    case 3:
                        BloquearUnaBloquearTodas(opcion, listaPuertasPortones);
                        break;

                    case 4:
                        DesbloquearUnaBloquearTodas(opcion, listaPuertasPortones);
                        break;

                    case 5:
                        PintarUnaPintarTodas(opcion, listaPuertasPortones);
                        break;

                    case 6:
                        FabricarPuerta_o_Porton(opcion ,listaPuertasPortones, contPuertas, contPortones);
                        break;

                    case 7:
                        EliminarPuerta_o_Porton(listaPuertasPortones);
                        break;

                    case 8:
                        ModificarPuerta_o_Porton(listaPuertasPortones);
                        break;

                    case 9:
                        MostrarListaPuertasPortones(listaPuertasPortones);
                        Console.ResetColor();
                        break;
                }

                Tools.BackToMenu(opcion);

            } while (opcion != 0);

            Tools.StopProgram();
        }

        /*********************************************************************************************************************************************/
        /**************************************************************** MÉTODOS ********************************************************************/
        /*********************************************************************************************************************************************/

        public static Puerta SeleccionarPuerta_o_Porton(List<Puerta> listaPuertasPortones) // devuelve un objeto del tipo Puerta pero creado como Porton (polimorfismo)
        {
            string nombre = string.Empty;
            bool nombreOk = false;

            do
            {
                Console.WriteLine("\n");

                foreach (Puerta p in listaPuertasPortones)
                    Console.WriteLine("\t" + p.Nombre);

                nombreOk = false;
                Console.Write("\n\n\tIntroduzca el nombre de la puerta o del portón a buscar:\t");
                nombre = Console.ReadLine();

                for (int i = 0; i < listaPuertasPortones.Count; i++)
                {
                    if (listaPuertasPortones[i].Nombre == nombre)
                    {
                        nombreOk = true;
                        puertaPortonAux = listaPuertasPortones[i];
                    }
                }

                if (!nombreOk) Tools.Error("Ningún nombre de la lista coincide con el introducido");

            } while (!nombreOk);

            return puertaPortonAux;
        }

        public static void AbrirTodasAbrirUna(int opcion, List<Puerta> listaPuertasPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para abrir una puerta o portón concreta/o:");
            Console.WriteLine("\n\tPulse 2 para abrir todas las puertas y portones");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de apertura", 1, 2);

            if (opcion == 1)
            {
                puertaPortonAux = SeleccionarPuerta_o_Porton(listaPuertasPortones);
                puertaPortonAux.Abrir(); // también puede abrir un portón
            }
            else
            {
                foreach (Puerta p in listaPuertasPortones) // aquí es necesario que el objeto auxiliar sea del tipo Puerta, porque como sea Porton y se encuentra un tipo Puerta (tipo padre), se produce un error de ejecución
                    p.Abrir(); // también abre todos los portones
            }
        }

        public static void CerrarTodasAbrirUna(int opcion, List<Puerta> listaPuertasPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para cerrar una puerta o portón concreta/o:");
            Console.WriteLine("\n\tPulse 2 para cerrar todas las puertas y portones");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de cerraje de puerta", 1, 2);

            if (opcion == 1)
            {
                puertaPortonAux = SeleccionarPuerta_o_Porton(listaPuertasPortones); // aquí es necesario que el objeto auxiliar sea del tipo Puerta, porque como sea Porton y se encuentra un tipo Puerta (tipo padre), se produce un error de ejecución
                puertaPortonAux.Cerrar(); // también puede cerrar un portón
            }
            else
            {
                foreach (Puerta p in listaPuertasPortones)
                    p.Cerrar(); // también abre todos los portones
            }
        }

        public static void PintarUnaPintarTodas(int opcion, List<Puerta> listaPuertasPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para pintar una puerta o portón concreta/o:");
            Console.WriteLine("\n\tPulse 2 para pintar todas las puertas y portones");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de pintada", 1, 2);

            if (opcion == 1)
            {
                puertaPortonAux = SeleccionarPuerta_o_Porton(listaPuertasPortones);
                puertaPortonAux.Color = Tools.EligeColor(); // también puede pintar un portón
            }
            else
            {
                ConsoleColor color = Tools.EligeColor();

                foreach (Puerta p in listaPuertasPortones) // aquí es necesario que el objeto auxiliar sea del tipo Puerta, porque como sea Porton y se encuentra un tipo Puerta (tipo padre), se produce un error de ejecución
                    p.Color = color; // también puede pintar todos los portones
            }
        }

        public static void BloquearUnaBloquearTodas(int opcion, List<Puerta> listaPuertasPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para bloquear un portón concreto:");
            Console.WriteLine("\n\tPulse 2 para bloquear todos los portones");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de bloqueo", 1, 2);

            if (opcion == 1)
            {
                try // este try{}catch{} evitará el error de ejecución si el usuario elige bloquear una puerta
                {
                    portonAux = (Porton)SeleccionarPuerta_o_Porton(listaPuertasPortones); // como el método devuelve un objeto tipo Puerta, hace falta castear el dato que devuelve para recogerlo en un objeto Porton
                    portonAux.Bloquear();
                }
                catch
                {
                    Tools.Error("Los objetos de tipo Puerta no se pueden bloquear, tan sólo los de tipo Porton pueden bloquearse");
                } // este try{}catch{} fue la forma que se me ocurrió a priori, antes de que mi profesor me enseñase a usar el método GetType().Name
            }
            else
            {
                for (int i = 0; i < listaPuertasPortones.Count; i++)
                {
                    if (listaPuertasPortones[i].GetType().Name == "Porton")
                    {
                        portonAux = (Porton)listaPuertasPortones[i]; // necesito usar portonAux porque es del tipo Portón y el método bloquear es propio sólo de la clase Portón
                        portonAux.Bloquear(); // si tan sólo pusiera esta sentencia, siempre se bloquearía el mismo (primer) portón ... necesitaba ir guardando en portonAux el objeto de la posición por la que vamos recorriendo la lista, y castearlo a Porton 
                    }
                    else
                    {
                        Tools.Error("Los objetos de tipo Puerta no se pueden bloquear, tan sólo los de tipo Porton pueden bloquearse");
                    }
                }   
            }
        }

        public static void DesbloquearUnaBloquearTodas(int opcion, List<Puerta> listaPuertasPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para desbloquear un portón concreto:");
            Console.WriteLine("\n\tPulse 2 para desbloquear todos los portones");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de desbloqueo", 1, 2);

            if (opcion == 1)
            {
                try // este try{}catch{} evitará el error de ejecución si el usuario elige desbloquear una puerta
                {
                    portonAux = (Porton)SeleccionarPuerta_o_Porton(listaPuertasPortones); // como el método devuelve un objeto tipo Puerta, hace falta castear el dato que devuelve para recogerlo en un objeto Porton
                    portonAux.Desbloquear();
                }
                catch
                {
                    Tools.Error("Los objetos de tipo Puerta no se pueden desbloquear, tan sólo los de tipo Porton pueden desbloquearse");
                } // este try{}catch{} fue la forma que se me ocurrió a priori, antes de que mi profesor me enseñase a usar el método GetType().Name
            }
            else
            {
                for (int i = 0; i < listaPuertasPortones.Count; i++)
                {
                    if (listaPuertasPortones[i].GetType().Name == "Porton")
                    {
                        portonAux = (Porton)listaPuertasPortones[i]; // necesito usar portonAux porque es del tipo Portón y el método bloquear es propio sólo de la clase Portón
                        portonAux.Desbloquear(); // si tan sólo pusiera esta sentencia, siempre se bloquearía el mismo (primer) portón ... necesitaba ir guardando en portonAux el objeto de la posición por la que vamos recorriendo la lista, y castearlo a Porton
                    }
                    else
                    {
                        Tools.Error("Los objetos de tipo Puerta no se pueden desbloquear, tan sólo los de tipo Porton pueden desbloquearse");
                    }
                }
            }
        }

        /*********************************************************************************************************************************************/
        /**************************************************************** CRUD ***********************************************************************/
        /*********************************************************************************************************************************************/

        public static void FabricarPuerta_o_Porton(int opcion, List<Puerta> listaPuertasPortones, int contPuertas, int contPortones)
        {
            Console.WriteLine("\n\n\tPulse 1 para fabricar una puerta:");
            Console.WriteLine("\n\tPulse 2 para fabricar un portón");

            opcion = Tools.CapturaEntero_vProfesor("para seleccionar una opción de fabricación", 1, 2);

            if (opcion == 1) // creamos un objeto del tipo Puerta
            {
                foreach (Puerta p in listaPuertasPortones)
                {
                    if (p.GetType().Name == "Puerta") contPuertas ++; // cuento el número de objetos creados como Puerta que ya hay en la lista, para que en la creación de una nueva Puerta, continue con el número de nombre que le tocaría (ya que al sumarse uno más al contador, pero dentro de un método, ese valor +1 se pierde cuando acaba la ejecución de este método)
                }

                contPuertas++;
                Console.WriteLine("\n\n\t----- Fabricamos la puerta-" + contPuertas + " ------");

                string nombre = "puerta-" + contPuertas;
                int alto = Tools.CapturaEntero_Normal("\n\t¿Altura en cm?", 50, 250);
                int ancho = Tools.CapturaEntero_Normal("\n\t¿Anchura en cm?", 30, 250);
                ConsoleColor color = Tools.EligeColor();

                listaPuertasPortones.Add
                (
                    new Puerta(nombre, alto, ancho, color)
                );

                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n\n\tPerfecto. Has fabricado la puerta puerta-" + contPuertas);
                Console.ResetColor();
            }
            else // creamos un objeto del tipo Porton
            {
                foreach (Puerta p in listaPuertasPortones)
                {
                    if (p.GetType().Name == "Porton") contPortones++; // cuento el número de objetos creados como Porton que ya hay en la lista, para que en la creación de un nuevo Porton, continue con el número de nombre que le tocaría (ya que al sumarse uno más al contador, pero dentro de un método, ese valor +1 se pierde cuando acaba la ejecución de este método)
                }

                contPortones++;
                Console.WriteLine("\n\n\t----- Fabricamos el portón-" + contPortones + " ------");

                string nombre = "porton-" + contPortones;
                int alto = Tools.CapturaEntero_Normal("\n\t¿Altura en cm?", 50, 250);
                int ancho = Tools.CapturaEntero_Normal("\n\t¿Anchura en cm?", 30, 250);
                ConsoleColor color = Tools.EligeColor();

                listaPuertasPortones.Add
                (
                    new Porton(nombre, alto, ancho, color)
                );

                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n\n\tPerfecto. Has fabricado el porton-" + contPortones);
                Console.ResetColor();
            }
        }

        public static void MostrarListaPuertasPortones(List<Puerta> listaPuertasPortones)
        {
            Console.WriteLine("\n\n\tNombre\t\tSituación     Estado     Altura     Anchura     Color     Tipo       Dibujo");
            Console.WriteLine("\t--------------------------------------------------------------------------------------------------\n");

            /*
            for (int i = 0; i < listaPuertasPortones.Count; i++) // también se puede hacer con un for()
            {
                Console.WriteLine(listaPuertasPortones[i].ToString_ConDibujo());
            }
            */

            foreach (Puerta puerta in listaPuertasPortones)
            {
                Console.WriteLine(puerta.ToString_ConDibujo());
            }
        }

        public static Puerta ModificarPuerta_o_Porton(List<Puerta> listaPuertasPortones) // puede modificar tanto un objeto tipo Puerta como un objeto tipo Porton
        {
            Console.WriteLine("\n\n\t----- Modifiquemos la puerta o el portón ------");

            puertaPortonAux = SeleccionarPuerta_o_Porton(listaPuertasPortones);

            Console.WriteLine("\n\n\t----- Está modificando " + puertaPortonAux.Nombre + " ------");

            int alto = Tools.CapturaEntero_Normal("\n\t¿Altura en cm?", 50, 250);
            int ancho = Tools.CapturaEntero_Normal("\n\t¿Anchura en cm?", 30, 250);
            ConsoleColor color = Tools.EligeColor();

            puertaPortonAux.Alto = alto;
            puertaPortonAux.Ancho = ancho;
            puertaPortonAux.Color = color;

            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\n\tPerfecto. Has modificado " + puertaPortonAux.Nombre);
            Console.ResetColor();

            return puertaPortonAux;
        }

        public static void EliminarPuerta_o_Porton(List<Puerta> listaPuertasPortones)
        {
            Console.WriteLine("\n\n\t----- Eliminemos una puerta o un portón ------");

            puertaPortonAux = SeleccionarPuerta_o_Porton(listaPuertasPortones);

            if (Tools.PreguntaSiNo("¿¿ Esta seguro de eliminar el objeto " + puertaPortonAux.Nombre + " ??"))
            {
                for (int i = 1; i < listaPuertasPortones.Count; i++) // empezamos saltando la posición 0, donde está nuestro objeto auxiliar polimorfista, para que el usuario no pueda borrarlo
                {
                    if (listaPuertasPortones[i].Nombre == puertaPortonAux.Nombre)
                    {
                        listaPuertasPortones.RemoveAt(i);
                    }
                }

                if (puertaPortonAux.Nombre == "puertaPortonAux")
                {
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n\n\tNo puedes eliminar la puertaPortonAux");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\n\n\tPerfecto. La puerta/portón seleccionada/o ha sido "); Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("eliminada/o.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\n\tEl objeto " + puertaPortonAux.Nombre + " no ha sido eliminado");
                Console.ResetColor();
            }
            
        }
    }
}
