/*
Construye los métodos siguientes:

1) CapturaEntero, que ya sabes cómo funciona.
2) DevuelveListaGente, que Recibe dos vectores string de la misma longitud, uno de apellidos y otro de nombres, 
y devuelve lista de string que se ha cargado con los “Apellidos, Nombres” tomados de dichas tablas.
3) MuestraColeccion, que Recibe una lista de string y un int posScreen. 
Muestra los elementos de la lista, con su índice delante, colocados en la columna de la pantalla que indique posScreen.
4) IntercambiaPos, que Recibe una lista de string y dos enteros pos1 y pos2. 
El método intercambia los elementos que se encuentran en las posiciones indicadas. No devuelve nada.
5) BorraElemento, que Recibe una lista de string y un entero pos. 
El método elimina el elemento que se encuentra en la posición indicada. 
Devuelve true si lo ha podido borrar o false si no ha podido (por ejemplo, porque se le haya dado una posición fuera de rango)
6) BorraElemento, que Recibe una lista de string y un string elemento. 
El método elimina el elemento que se indica. 
Devuelve true si lo ha podido borrar o false si no ha podido (por ejemplo, porque dicho elemento no existe en la lista)
7) Pausa: Recibe un texto y muestra el mensaje “Pulsa una tecla para ”+ texto.
Esperará una pulsación para que continúe el programa.

Para probar dichos métodos realizaremos lo siguiente en el main:

1) Construir los vectores vApellidos y vNombres. Tal como hicimos en la práctica de vectores
2) Construye la lista de string listaGente y rellénala con los “Apellidos, Nombres” tomándolos de las tablas anteriores.
3) Se mostrará la lista inicial en la columna 0
4) Se pedirán dos posiciones de la lista para intercambiar los elementos de dichas posiciones. 
Se mostrará la nueva lista en la columna 40 para comprobar que se han realizado bien los cambios.
5) Al pulsar una tecla, se limpia la pantalla y se vuelve a mostrar la lista que tenemos en la columna 0. 
Se le pide una posición y se eliminará el elemento de la posición indicada.
Se mostrará la nueva lista en la columna 40 para comprobar que se han realizado bien los cambios.
6) Al pulsar una tecla, se limpia la pantalla y se vuelve a mostrar la lista que tenemos en la columna 0. 
Se le pide que escriba “Apellidos, Nombre” de una persona y se eliminará el elemento indicado si se puede (si no existe dará el mensaje correspondiente). 
Se mostrará la nueva lista en la columna 40 para comprobar que se han realizado bien los cambios.

Nota: entre un paso y el siguiente pon una pausa en la que el usuario tenga que pulsar una tecla
*/

using System;
using System.Collections.Generic;

namespace P24c_Lista_Gente
{
    class Program
    {
        static void Main(string[] args)
        {
            //1) Construir los vectores vApellidos y vNombres. Tal como hicimos en la práctica de vectores
            string[] vNombres = { "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "Tomás", "Carlos", "Jose Carlos", "Juan Luis", "Daniel", "Angel", "Jacobo", "Alejandro", "Francisco", "Alfredo", "Francisco", "Antonio", "Constantino", "Roberto", "Rafael", "Antonio" };
            string[] vApellidos = { "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delgado Rodríguez", "Duque Martínez" };

            // 2) Construye la lista de string listaGente y rellénala con los “Apellidos, Nombres” tomándolos de las tablas anteriores.
            List<string> listaGente = DevuelveListaGente(vApellidos, vNombres);

            // 3) Se mostrará la lista inicial en la columna 0
            int posScreen = 0;
            MostrarColeccion(listaGente, 0);

            // 4) Se pedirán dos posiciones de la lista para intercambiar los elementos de dichas posiciones. 
            // Se mostrará la nueva lista en la columna 40 para comprobar que se han realizado bien los cambios.
            string pregunta = "para definir la posición 1";
            int posicion1 = CapturaEntero(posScreen, pregunta, 0, listaGente.Count - 1);

            pregunta = "para definir la posición 2";
            int posicion2 = CapturaEntero(posScreen, pregunta, 0, listaGente.Count - 1);

            IntercambiarPosicion(listaGente, posicion1, posicion2);
            MostrarColeccion(listaGente, 40);

            //5) Al pulsar una tecla, se limpia la pantalla y se vuelve a mostrar la lista que tenemos en la columna 0.
            //Se le pide una posición y se eliminará el elemento de la posición indicada.
            //Se mostrará la nueva lista en la columna 40 para comprobar que se han realizado bien los cambios.
            Pausa("para limpiar la pantalla y volver a mostrar la lista");
            Console.Clear();
            MostrarColeccion(listaGente, posScreen);

            Pausa("para pedirle una posición y borrar el elemento de tal posición");
            pregunta = "para definir una posición y borrar su elemento";
            int posicion = CapturaEntero(posScreen, pregunta, 0, listaGente.Count - 1);
            bool borrado = BorrarElemento(listaGente, posicion);

            Console.SetCursorPosition(posScreen, 3);
            Console.Write("¿El elemento ha sido borrado?:\t" + borrado);
            MostrarColeccion(listaGente, 40);

            //6) Al pulsar una tecla, se limpia la pantalla y se vuelve a mostrar la lista que tenemos en la columna 0.
            //Se le pide que escriba “Apellidos, Nombre” de una persona y se eliminará el elemento indicado si se puede(si no existe dará el mensaje correspondiente). 
            //Se mostrará la nueva lista en la columna 40 para comprobar que se han realizado bien los cambios.
            Pausa("para limpiar la pantalla y volver a mostrar la lista");
            Console.Clear();
            MostrarColeccion(listaGente, posScreen);

            Pausa("para pedirle el [Apellidos, Nombre] de una persona y eliminarla de la lista");
            pregunta = "de una persona y eliminarla de la lista";
            string persona = CapturaCadena(posScreen, pregunta, listaGente);
            borrado = BorrarElemento(listaGente, persona);

            Console.SetCursorPosition(posScreen, 3);
            Console.Write("¿El elemento ha sido borrado?:\t" + borrado);
            MostrarColeccion(listaGente, 40);

            Pausa("para dar por finalizado este programa");
            Console.Clear();
            PararPrograma();
            Console.Clear();
        }

        /*************************************************** MÉTODOS *****************************************************/

        //1) CapturaEntero, que ya sabes cómo funciona.
        public static int CapturaEntero(int posScreen, string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                Console.SetCursorPosition(posScreen, 2);
                Console.Write("                                                                                                                                       ");
                Console.SetCursorPosition(posScreen, 2);
                Console.Write("Introduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min)
                {
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. El número no puede ser inferior a " + min + ".");
                    numOk = false;
                }
                else if (num > max)
                {
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. El número no puede ser superior a " + max + ".");
                    numOk = false;
                }
                else if (num == 0)
                {
                    numOk = true;
                }

            } while (!numOk);

            return num;
        }

        public static string CapturaCadena(int posScreen, string pregunta, List<string> listaGente)
        {
            string cadena = null;
            bool cadenaOk = false;

            do
            {
                Console.SetCursorPosition(posScreen, 2);
                Console.Write("                                                                                                                                       ");
                Console.SetCursorPosition(posScreen, 2);
                Console.Write("Introduzca un [Apellidos, Nombre], " + pregunta + ":\t");
                cadena = Convert.ToString(Console.ReadLine());

                if (listaGente.Contains(cadena) == false)
                {
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. La persona introducida no se encuentra en la lista.");
                    cadenaOk = false;
                }
                else if (cadena == null)
                {
                    cadenaOk = false;
                }
                else if (listaGente.Contains(cadena) == true)
                {
                    cadenaOk = true;
                }

            } while (!cadenaOk);

            return cadena;
        }

        //2) DevuelveListaGente, que Recibe dos vectores string de la misma longitud, uno de apellidos y otro de nombres, 
        //y devuelve lista de string que se ha cargado con los “Apellidos, Nombres” tomados de dichas tablas.
        public static List<string> DevuelveListaGente(string[] vApellidos, string[] vNombres)
        {
            List<string> listaGente = new List<string>();

            for (int i = 0; i < vApellidos.Length; i++)
            {
                listaGente.Add(vApellidos[i] + ", " + vNombres[i]);
            }

            return listaGente;
        }

        //3) MuestraColeccion, que Recibe una lista de string y un int posScreen.
        //Muestra los elementos de la lista, con su índice delante, colocados en la columna de la pantalla que indique posScreen.
        public static void MostrarColeccion(List<string> listaGente, int posScreen)
        {
            Console.SetCursorPosition(posScreen, 5);

            for (int i = 0; i < listaGente.Count; i++)
            {
                Console.SetCursorPosition(posScreen, 5 + i);
                Console.WriteLine(i + ")\t" + listaGente[i]);
            }
        }

        //4) IntercambiaPos, que Recibe una lista de string y dos enteros pos1 y pos2.
        //El método intercambia los elementos que se encuentran en las posiciones indicadas. No devuelve nada.
        public static void IntercambiarPosicion(List<string> listaGente, int posicion1, int posicion2)
        {
            string aux = listaGente[posicion1];

            listaGente.Insert(posicion1, listaGente[posicion2]);
            listaGente.RemoveAt(posicion1 + 1);

            listaGente.Insert(posicion2, aux);
            listaGente.RemoveAt(posicion2 + 1);
        }

        //5) BorraElemento, que Recibe una lista de string y un entero pos.
        //El método elimina el elemento que se encuentra en la posición indicada.
        //Devuelve true si lo ha podido borrar o false si no ha podido borrarlo (por ejemplo, porque se le haya dado una posición fuera de rango)
        public static bool BorrarElemento(List<string> listaGente, int posicion)
        {
            bool borrado = false;
            string aux = null;

            for (int i = 0; i < listaGente.Count; i++)
            {
                if (i == posicion)
                {
                    aux = listaGente[i];
                }
            }

            listaGente.RemoveAt(posicion);
            
            if (listaGente.Contains(aux) == true)
            {
                borrado = false;
            }
            else
            {
                borrado = true;
            }

            return borrado;
        }

        //6) BorraElemento, que Recibe una lista de string y un string elemento.
        //El método elimina el elemento que se indica.
        //Devuelve true si lo ha podido borrar o false si no ha podido (por ejemplo, porque dicho elemento no existe en la lista)
        public static bool BorrarElemento(List<string> listaGente, string elemento)
        {
            bool borrado = false;

            do {
                listaGente.Remove(elemento);
            
            } while(listaGente.Contains(elemento));
            

            if (listaGente.Contains(elemento) == true)
            {
                borrado = false;
            }
            else
            {
                borrado = true;
            }

            return borrado;
        }


        //7) Pausa: Recibe un texto y muestra el mensaje “Pulsa una tecla para ”+ texto.
        //Esperará una pulsación para que continúe el programa.
        public static void Pausa(string texto)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write("                                                                                                                                       ");
            Console.SetCursorPosition(0, 2);
            Console.Write("Pulsa una tecla " + texto + ".");
            Console.ReadKey(true);
        }


        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }

    }
}