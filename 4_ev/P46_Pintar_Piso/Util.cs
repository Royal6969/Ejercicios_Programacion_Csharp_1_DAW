using System;
using System.Collections.Generic;
using System.Threading;

namespace P46_Pintar_Piso
{
    public class Util
    {
        //----DEVUELVE LA OPCION SELECCIONADA
        public static int Menu()
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t╔══════════════════════════════╗");
                Console.WriteLine("\t\t\t║             MENU             ║");
                Console.WriteLine("\t\t\t╠══════════════════════════════╣");
                Console.WriteLine("\t\t\t║                              ║");
                Console.WriteLine("\t\t\t║    1.- Lista de pinturas     ║");
                Console.WriteLine("\t\t\t║    2.- Presentar Precios     ║");
                Console.WriteLine("\t\t\t║                              ║");
                Console.WriteLine("\t\t\t║    3.- Añadir Recinto        ║");
                Console.WriteLine("\t\t\t║    4.- Eliminar Recinto      ║");
                Console.WriteLine("\t\t\t║    5.- Modificar Recinto     ║");
                Console.WriteLine("\t\t\t║                              ║");
                Console.WriteLine("\t\t\t║          0) Salir            ║");
                Console.WriteLine("\t\t\t║                              ║");
                Console.WriteLine("\t\t\t╚══════════════════════════════╝");

                opcion = CapturaEntero_vProfesor("para elegir una opción del menú", 0, 5);

            } while (opcion < 0 || opcion > 5);

            return opcion;
        }

        public static bool PreguntaSiNo(string pregunta)
        {
            char tecla;

            do
            {
                // Hacemos la pregunta
                Console.Write("\n\n\t{0} (s=Sí; n=No): ", pregunta);
                // Capturamos la respuesta (una pulsación)
                tecla = (Console.ReadKey()).KeyChar;
                if (tecla == 's' || tecla == 'S')
                    return true;
                if (tecla == 'n' || tecla == 'N')
                    return false;
                // Si llega aquí es que no ha pulsado ninguna de las teclas correctas
                Console.Write("\n\n\t** Error: por favor, responde S o N **");

            } while (true);
        }

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += "                                            ";

            return texto.Substring(0, nCaracteres);
        }

        public static void BackToMenu(int opcion)
        {
            if (opcion > 0)
            {
                Console.WriteLine("\n\n\n\tPress any key to back to menú.");
                Console.ReadKey(true);
            }
            else if (opcion == 0)
            {
                Console.WriteLine("\n\tPulse una tecla para salir.");
                Console.ReadKey(true);
            }

        }

        public static void StopProgram()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\tMuchas gracias por utilizar nuestro programa.");
            Thread.Sleep(1785);
        }


        public static int CapturaEntero(string mensaje, int min, int max)
        {
            int valor = 0;
            bool esCorrecto = false;

            do
            {
                Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "] " + mensaje + ":\t");
                esCorrecto = Int32.TryParse(Console.ReadLine(), out valor);

                if (!esCorrecto || valor < min || valor > max)
                    Console.WriteLine(" ** Error ** Debe ser un entero de {0} a {1}  **", min, max);
            }

            while (!esCorrecto || valor < min || valor > max);

            return valor;
        }

        public static int CapturaEntero_vProfesor(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                num = Console.ReadKey().KeyChar - '0';

                if (num < (char)0 || num > (char)9)
                {
                    Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                    numOk = false;
                }
                else if (num < min || num > max)
                {
                    Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }
                else
                {
                    numOk = true;
                }

            } while (!numOk);

            return num;
        }

        public static int EligePintura(CatalogoPinturas catalogo)
        {
            Console.WriteLine("\n\tElige un color\n");

            for (int i = 0; i < catalogo.ListaPinturas.Count; i++)
            {
                Console.WriteLine("\t" + (i) + ") " + catalogo.ListaPinturas[i].NombreColor + " --> " + catalogo.ListaPinturas[i].PrecioM2 + " precio/m2");
            }

            int indice = CapturaEntero("para seleccionar una pintura", 0, catalogo.ListaPinturas.Count - 1);

            return indice;
        }

        public static string CuadraUnidad(int unidad)
        {
            if (unidad < 10)
            {
                return (" " + unidad).ToString();
            }
            else
            {
                return unidad.ToString();
            }
        }

        public static string CuadraPrecio(double precio)
        {
            if (precio < 10)
            {
                return ("  " + precio).ToString();
            }
            else if (precio < 100)
            {
                return (" " + precio).ToString();
            }
            else
            {
                return precio.ToString();
            }
        }
    }
}