/*
Repite el ejemplo de listas anterior (P23_Ejemplo1UsosLista_Int), realizando los siguientes cambios:

1) La lista será de char en lugar de int.

2) Se cargará de forma aleatoria con letras mayúsculas.

3) En el ejemplo de insertar, se insertará el guion (carácter '-').

4) Cuando se pida una letra para borrar o buscar, que sólo se pulse la letra (sin pulsar intro).

Para ello, construir un método llamado CapturaTecla, 
que recibe el texto de la consulta y los caracteres mínimo y máximo posibles 
(es decir, el carácter con el código mínimo y el de código máximo).

5) Que los mensajes siempre aparezcan dos líneas por debajo de la lista original, 
limpiando previamente cualquier mensaje anterior. 
De este modo se evita que unos mensajes se mezclen con otros.
*/

using System;
using System.Threading;
using System.Collections.Generic;

namespace P23_Ejemplo_Usos_List_Char
{
    class Program
    {
        static int filaMensaje;
        static Random azar = new Random();

        static void Main(string[] args)
        {
            /* 1 */
            List<char> listCaracteres = new List<char>();

            int numElements = CapturaEntero("Introduzca la cantidad de caracteres [10, 24] que tendrá List<char> listCaracteres:", 10, 24);

            filaMensaje = numElements + 3;

            Pausa("CARGAR la lista con " + numElements + " letras mayúsculas al azar");
            Console.Clear();

            /* 2 */
            listCaracteres = CargarListCaracteres(listCaracteres, numElements);

            MuestraListaEnColumna(listCaracteres, 4, "ORIGINAL");

            // Insertamos un guión en cualquier posición.
            // Por ejemplo, el carácter '-' en la posición 10
            Pausa("INSERTAR el caracter '-' en la posición 10");
            /* 3 */
            listCaracteres.Insert(10, '-');

            // Mostramos la lista a la derecha de la anterior
            MuestraListaEnColumna(listCaracteres, 14, "INSERT(3)");

            //--- Ordenamos la lista
            Pausa("ORDENAR la lista");
            listCaracteres.Sort();

            // Mostramos la lista a la derecha de la anterior
            MuestraListaEnColumna(listCaracteres, 24, "ORDENADA");

            //--- Invertimos la lista
            Pausa("INVERTIR la lista");
            listCaracteres.Reverse();

            // Mostramos la lista a la derecha de la anterior
            MuestraListaEnColumna(listCaracteres, 34, "INVERTIDA");

            // --- Eliminar un elemento indicando el elemento, no la posición.
            Pausa("ELIMINAR algún elemento");

            // si no existe, pido otro
            // Una forma de hacerlo: comprobando primero si existe
            bool existe;

            // int numBorrar = CapturaEntero("Dime el número a borrar", 10, 99);

            char letraBorrar = CapturaLetra("Selecciona una letra para eliminar sólo su 1ª ocurrencia", 65, 91);

            existe = listCaracteres.Contains(letraBorrar);

            while (!existe)
            {
                Console.WriteLine("\n\t ** La letra {0} no existe en la lista **", letraBorrar);

                letraBorrar = CapturaLetra("Selecciona una letra para eliminar sólo su 1ª ocurrencia", 65, 91);
                existe = listCaracteres.Contains(letraBorrar);
            }

            Console.WriteLine("\n\t La letra {0} estaba en la posición {1} en la lista **", letraBorrar, listCaracteres.IndexOf(letraBorrar));
            listCaracteres.Remove(letraBorrar);

            // Mostramos la lista a la derecha de la anterior
            MuestraListaEnColumna(listCaracteres, 44, "BORRAR 1");

            // Otra forma de hacerlo: comprobando si lo ha podido borrar
            do
            {
                letraBorrar = CapturaLetra("Seleccione la letra que desee para eliminar todas sus ocurrencias:", 65, 91);
                existe = listCaracteres.Remove(letraBorrar);

                if (!existe)
                {
                    Console.WriteLine("\nLa letra {0} no existe en la lista. ¿No lo estás viendo?", letraBorrar);
                }

            } while (!existe);

            Console.WriteLine("\n\t La letra {0} ha sido eliminado ", letraBorrar);
            listCaracteres.Remove(letraBorrar);

            // Mostramos la lista a la derecha de la anterior
            MuestraListaEnColumna(listCaracteres, 54, "BORRAR 2");

            //---- eliminar un elemento indicando  la posición.
            int posicion = CapturaEntero("¿Posición del elemento a eliminar?:", 0, listCaracteres.Count - 1);

            listCaracteres.RemoveAt(posicion);

            // Mostramos la lista a la derecha de la anterior
            MuestraListaEnColumna(listCaracteres, 64, "BORRAPOS");

            //---- eliminar varios elementos a partir de una posición
            posicion = CapturaEntero("¿Posición inicial de elementos a eliminar?:", 0, listCaracteres.Count - 1);

            int cantidad = CapturaEntero("¿Cantidad de elementos a eliminar?:", 0, listCaracteres.Count - posicion);

            listCaracteres.RemoveRange(posicion, cantidad);

            // Mostramos la lista a la derecha de la anterior
            MuestraListaEnColumna(listCaracteres, 74, "BORRANGO");

            ClearConsoleLine(filaMensaje, 8);

            // --- Buscar un elemento.
            Pausa("BUSCAR algún elemento");

            char letraBuscar = CapturaLetra("¿Letra a buscar?:", 65, 91);

            posicion = listCaracteres.IndexOf(letraBuscar);

            while (posicion == -1)
            {
                Console.WriteLine("\nLa letra {0} no existe en la lista", letraBorrar);

                letraBuscar = CapturaLetra("¿Letra a buscar?:", 65, 91);

                posicion = listCaracteres.IndexOf(letraBuscar);
            }

            Console.WriteLine("\n\t La letra {0} ESTÁ en la posición {1} en la lista **", letraBuscar, posicion);

            /*---- A OBSERVAR LAS VENTAJAS LOS MÉTODOS ----
                •  Ahorro de Número de líneas de código
                •  Claridad
                •  Fácil mantenimiento
            */

            PararPrograma();
        }

        /*************************************************** MÉTODOS ****************************************************/

        static void MuestraListaEnColumna(List<char> listCaracteres, int columna, string cabecera)
        {
            int i = 0;

            Console.SetCursorPosition(columna, 0);
            Console.Write(cabecera);

            for (i = 0; i < listCaracteres.Count; i++)
            {
                Console.SetCursorPosition(columna, i + 1);

                if (i < 10)
                {
                    Console.Write(" ");
                }

                Console.Write("{0}) {1}", i, listCaracteres[i]);
            }
            ClearConsoleLine(filaMensaje, 8);

            // una forma que he encontrado para manejar el Console.SetCursorPosition()
            // https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console/8946847
        }

        static void Pausa(string texto)
        {
            ClearConsoleLine(filaMensaje, 8);
            Console.WriteLine("   Pulsa una tecla para " + texto);
            Console.ReadKey(true); // <-- true porque NO quiero que se vea la tecla pulsada
        }

        public static int CapturaEntero(string frase, int min, int max)
        {
            int num;
            bool numOk;

            do
            {
                Console.Write("\n\n" + frase + "\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico.");
                }
                else if (num < min)
                {
                    Console.Write("\n\nError. El número no puede ser inferior a " + min);
                    numOk = false;
                }
                else if (num > max)
                {
                    Console.Write("\n\nError. El número no puede ser superior a " + max);
                    numOk = false;
                }
                else if (num == 0)
                {
                    numOk = true;
                }

            } while (!numOk);

            return num;
        }

        // 4) Cuando se pida una letra para borrar o buscar, que sólo se pulse la letra (sin pulsar intro).
        public static char CapturaLetra(string frase, int min, int max)
        {
            char letra;

            do
            {
                Console.Write("\n\n" + frase + "\t");
                // letraOk = Char.TryParse(Console.ReadLine(), out letra);
                letra = (char)(Console.ReadKey().KeyChar);

                if ((int)letra < min)
                {
                    Console.Write("\n\nError. Dentro del código ASCII, empieza la A en el 65 " + min);
                }
                else if ((int)letra > max)
                {
                    Console.Write("\n\nError. Dentro del código ASCII, termina la Z en el 90" + max);
                }

            } while ((int)letra < min || (int)letra > max);

            return letra;
        }

        // 2) Se cargará de forma aleatoria con letras mayúsculas.
        public static List<char> CargarListCaracteres(List<char> listCaracteres, int numElements)
        {
            for (int i = 0; i < numElements; i++)
            {
                listCaracteres.Add((char)(azar.Next(65, 91))); // en la tabla del código ASCII las letras del alfabéto (en mayúsculas) abarcan desde el 65 hasta el 90
                //listCaracteres.Add((char)(azar.Next((int)'A', (int)'Z'+1))); // otra forma
            }

            return listCaracteres;
        }

        public static void ClearConsoleLine(int fila, int numFilas)
        {
            //limpio las líneas que me interesan
            for (int i=0; i<numFilas; i++)
            {
                Console.SetCursorPosition(0, fila + i);
                Console.Write("                                                                                                                                ");
            }
            // Volvemos a dejar el cursor 
            Console.SetCursorPosition(0, fila);
        }

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\t\tPulsa intro para salir");
            Console.ReadLine();
        }
    }
}
