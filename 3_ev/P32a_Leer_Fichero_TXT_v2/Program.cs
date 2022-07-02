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
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace P32a_Leer_Fichero_TXT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listaEjercicios = CargarListaEjercicios();
            List<string> listaFicheros = CargarListaFicheros();

            ShowExercisesDone();

            string pregunta = "para definir el nombre de uno de los ejercicios que llevamos hechos";
            string nombreEjercicio = CapturaEjercicio(pregunta, listaEjercicios);

            ShowFiles();

            pregunta = "para definir el nombre del fichero que vamos a LEER del ejercicio que ELEGISTE";
            string nombreFichero = CapturaFichero(pregunta, listaFicheros);

            StreamReader streamReader = new StreamReader("../ficheros/"+nombreEjercicio+"/"+nombreFichero+".txt", Encoding.Default );

            Console.Clear();

            Console.WriteLine(streamReader.ReadToEnd());

            streamReader.Close();

            PararPrograma();
        }

        /************************************************** MÉTODOS ************************************************/

        public static List<string> CargarListaEjercicios(){

            List<string> listaEjercicios = new List<string>();

            listaEjercicios.Add("P31a_Guardar_Desde_Teclado");
            listaEjercicios.Add("P31b_Guardar_N_Multiplos_Desde");
            listaEjercicios.Add("P31c_Guarda_Primos");
            listaEjercicios.Add("P32a_Leer_Fichero_TXT");

            return listaEjercicios;
        }

        public static List<string> CargarListaFicheros(){

            List<string> listaFicheros = new List<string>();

            listaFicheros.Add("Frases_1");
            listaFicheros.Add("Frases_2");
            listaFicheros.Add("Nombre-Test-1");
            listaFicheros.Add("TestNombre-1");
            listaFicheros.Add("P31c_Guarda_Primos");
            listaFicheros.Add("PrimosMenoresDe40");
            listaFicheros.Add("LeyesDePonfe");

            return listaFicheros;
        }

        public static void ShowExercisesDone(){
            
            for (int i = 0; i < 40; i++) {
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
        }

        public static void ShowFiles(){
            
            for (int i = 0; i < 40; i++) {
                Console.SetCursorPosition(0, i);
                Console.Write("                                                                                                                                                                                   ");
            }
            
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("\t╔═════════════════════════════════════════╗");
            Console.WriteLine("\t║         P31a_Guardar_Desde_Teclado      ║");
            Console.WriteLine("\t╠═════════════════════════════════════════╣");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t║    1.- Frases_1                         ║");
            Console.WriteLine("\t║    2.- Frases_2                         ║");
            Console.WriteLine("\t║    3.- Nombre-Test-1                    ║");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t╚═════════════════════════════════════════╝");

            Console.SetCursorPosition(0, 15);
            Console.WriteLine("\t╔═════════════════════════════════════════╗");
            Console.WriteLine("\t║         P31b_Guardar_N_Multiplos_Desde  ║");
            Console.WriteLine("\t╠═════════════════════════════════════════╣");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t║    1.- TestNombre-1                     ║");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t╚═════════════════════════════════════════╝");

            Console.SetCursorPosition(0, 22);
            Console.WriteLine("\t╔═════════════════════════════════════════╗");
            Console.WriteLine("\t║         P31c_Guarda_Primos              ║");
            Console.WriteLine("\t╠═════════════════════════════════════════╣");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t║    1.- P31c_Guarda_Primos               ║");
            Console.WriteLine("\t║    2.- PrimosMenoresDe40                ║");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t╚═════════════════════════════════════════╝");

            Console.SetCursorPosition(0, 30);
            Console.WriteLine("\t╔═════════════════════════════════════════╗");
            Console.WriteLine("\t║         P32a_Leer_Fichero_TXT           ║");
            Console.WriteLine("\t╠═════════════════════════════════════════╣");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t║    1.- LeyesDePonfe                     ║");
            Console.WriteLine("\t║                                         ║");
            Console.WriteLine("\t╚═════════════════════════════════════════╝");
        }

        public static string CapturaEjercicio(string pregunta, List<string> listaEjercicios)
        {
            string ejercicio = null;
            bool ejercicioOk = false;

            do
            {
                Console.SetCursorPosition(0, 2);
                Console.Write("                                                                                                                                       ");
                Console.SetCursorPosition(0, 2);
                Console.Write("Introduzca una cadena de caracteres, " + pregunta + ":\t");
                ejercicio = Convert.ToString(Console.ReadLine());

                Console.SetCursorPosition(0, 4);
                Console.Write("                                                                                                                                       ");
                Console.SetCursorPosition(0, 4);

                if (!listaEjercicios.Contains(ejercicio))
                {
                    Console.Write("********* Error. El ejercicio introducido no existe (o aún no lo hemos hecho a 19/01/2022 jeje) **********");
                    ejercicioOk = false;
                }
                else if (ejercicio == null)
                {
                    Console.Write("********* Error. No has introducido ningún ejercicio **********");
                    ejercicioOk = false;
                }
                else if (listaEjercicios.Contains(ejercicio))
                {
                    ejercicioOk = true;
                }

            } while (!ejercicioOk);

            return ejercicio;
        }

        public static string CapturaFichero(string pregunta, List<string> listaFicheros)
        {
            string fichero = null;
            bool ficheroOk = false;

            do
            {
                Console.SetCursorPosition(0, 2);
                Console.Write("                                                                                                                                       ");
                Console.SetCursorPosition(0, 2);
                Console.Write("Introduzca una cadena de caracteres, " + pregunta + ":\t");
                fichero = Convert.ToString(Console.ReadLine());

                Console.SetCursorPosition(0, 4);
                Console.Write("                                                                                                                                       ");
                Console.SetCursorPosition(0, 4);

                if (!listaFicheros.Contains(fichero))
                {
                    Console.Write("********* Error. El fichero introducido no existe **********");
                    ficheroOk = false;
                }
                else if (fichero == null)
                {
                    Console.Write("********* Error. No has introducido ningún fichero **********");
                    ficheroOk = false;
                }
                else if (listaFicheros.Contains(fichero))
                {
                    ficheroOk = true;
                }

            } while (!ficheroOk);

            return fichero;
        }

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}