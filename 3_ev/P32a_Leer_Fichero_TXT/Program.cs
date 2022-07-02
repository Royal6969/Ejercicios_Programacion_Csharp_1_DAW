/*
Construir el método: CapturaRuta:
Recibe: Nada
Hace: Pide al usuario el nombre de un fichero
• Si existe en la carpeta C:zDatosPruebas devuelve la ruta completa.
• Si no, da mensaje de error y vuelve a pedir el nombre del fichero.

Realizar el siguiente programa:
El programa pedirá un nombre de fichero utilizando CapturaRuta. Con la ruta devuelta, abrirá el
fichero indicado y...
Versión 1: Hacer que vaya leyendo las líneas del fichero indicado y las muestre en pantalla.

Versión 2:
• Instalar una carpeta Datos dentro del directorio de trabajo y colocar en dicha carpeta los
archivos a leer.
• CapturaRuta comprobará la existencia del fichero, mediante ruta relativa.
• Después de mostrar el fichero, presentará cuántos párrafos (líneas) tiene y repetirá el
párrafo más largo indicando el número de caracteres que tiene.
*/

using System;
using System.IO;
using System.Text;

namespace P32a_Leer_Fichero_TXT
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowExercisesDone();

            string pregunta = "para definir la ruta de uno de los ficheros de los ejercicios que llevamos hechos (ej: ejercicio1/fichero1)";
            string ruta = CapturaRuta(pregunta);

            StreamReader streamReader = new StreamReader("../../../../ficheros/" + ruta + ".txt", Encoding.Default);

            Console.Clear();

            // Console.WriteLine(streamReader.ReadToEnd());

            string parrafo, parrafoMayor = string.Empty;
            int nParrafos = 0;

            while (!streamReader.EndOfStream)
            {
                // Console.WriteLine(streamReader.ReadLine());
                parrafo = streamReader.ReadLine();
                Console.WriteLine(parrafo);

                nParrafos++;

                if (parrafo.Length > parrafoMayor.Length)
                {
                    parrafoMayor = parrafo;
                }
            }

            streamReader.Close();

            Console.WriteLine("\n\n\nEl texto tiene " + nParrafos + " párrafos, y el párrafo más largo contiene " + parrafoMayor.Length + " caracteres, y es el siguiente:\n");
            Console.WriteLine("\n" + parrafoMayor);

            PararPrograma();
        }

        /************************************************** MÉTODOS ************************************************/



        public static void ShowExercisesDone()
        {

            for (int i = 0; i < 40; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("                                                                                                                                                                                          ");
            }
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("\t╔═════════════════════════════════════════╗");
            Console.WriteLine("\t║         EJERCICIOS REALIZADOS           ║");
            Console.WriteLine("\t╠═════════════════════════════════════════╣");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t║    1.- P31a_Guardar_Desde_Teclado       ║");
            Console.WriteLine("\t║    2.- P31b_Guardar_N_Multiplos_Desde   ║");
            Console.WriteLine("\t║    3.- P31c_Guarda_Primos               ║");
            Console.WriteLine("\t║    4.- P32a_Leer_Fichero_TXT            ║");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t╚═════════════════════════════════════════╝");

            Console.SetCursorPosition(0, 20);
            Console.WriteLine("\t╔═════════════════════════════════════════╗\t╔═════════════════════════════════════════╗\t╔═════════════════════════════════════════╗\t╔═════════════════════════════════════════╗");
            Console.WriteLine("\t║         P31a_Guardar_Desde_Teclado      ║\t║         P31b_Guardar_N_Multiplos_Desde  ║\t║         P31c_Guarda_Primos              ║\t║         P32a_Leer_Fichero_TXT           ║");
            Console.WriteLine("\t╠═════════════════════════════════════════╣\t╠═════════════════════════════════════════╣\t╠═════════════════════════════════════════╣\t╠═════════════════════════════════════════╣");
            Console.WriteLine("\t║                                         ║\t║                                         ║\t║                                         ║\t║                                         ║");
            Console.WriteLine("\t║    1.- Frases_1                         ║\t║    1.- TestNombre-1                     ║\t║    1.- P31c_Guarda_Primos               ║\t║    1.- LeyesDePonfe                     ║");
            Console.WriteLine("\t║    2.- Frases_2                         ║\t║                                         ║\t║    2.- PrimosMenoresDe40                ║\t║                                         ║");
            Console.WriteLine("\t║    3.- Nombre-Test-1                    ║\t╚═════════════════════════════════════════╝\t║                                         ║\t╚═════════════════════════════════════════╝");
            Console.WriteLine("\t║                                         ║\t\t\t\t\t\t\t╚═════════════════════════════════════════╝");
            Console.WriteLine("\t╚═════════════════════════════════════════╝");
        }

        public static string CapturaRuta(string pregunta)
        {
            string ruta = null;
            bool rutaOk = false;

            do
            {
                Console.SetCursorPosition(0, 2);
                Console.Write("                                                                                                                                                                                                         ");
                Console.SetCursorPosition(0, 2);
                Console.Write("Introduzca una cadena de caracteres, " + pregunta + ":\t");
                ruta = Convert.ToString(Console.ReadLine());

                Console.SetCursorPosition(0, 4);
                Console.Write("                                                                                                                                                                                                         ");
                Console.SetCursorPosition(0, 4);

                if (!File.Exists("../../../../ficheros/" + ruta + ".txt"))
                {
                    Console.Write("********* Error. El ejercicio introducido no existe (o aún no lo hemos hecho a 19/01/2022 jeje) **********");
                    rutaOk = false;
                }
                else
                {
                    rutaOk = true;
                }

            } while (!rutaOk);

            return ruta;
        }

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}