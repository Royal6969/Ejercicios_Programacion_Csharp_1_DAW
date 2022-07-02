/*
Películas1:

Guarda una copia del fichero pelis.txt en una carpeta de nombre Datos en el directorio de trabajo.

Se te entrega un fichero pelis.TXT en el que hemos copiado el contenido de un directorio de películas, 
con todos sus datos, tal como sale de la instrucción:
dir G:\Peliculas > pelis.TXT (Nota: hemos quitado las líneas que sobran)

Observa las líneas del fichero para ver lo que ocupa cada concepto y los separadores que aparecen.

El programa actuará del siguiente modo:

Desglosará cada campo* y mostrará en pantalla la tabla de películas como en la siguiente muestra:

Donde
     No es el número de orden en que está la película en el fichero
     Película es el nombre de la película. 
      Como ves en la muestra, se le ha dado un ancho de 37 rellenando con puntos.
     Valor. Valoración que se le ha dado: Sólo la/s letra/s sin los paréntesis.
     Form.: Formato, en mayúsculas, en el que está grabada la película: 
      AVI o MKV o MPG... (viene indicado por la extensión del fichero).
     Tamaño: En Gb con dos decimales.

Después de presentar las películas, preguntará:
¿Nombre del fichero donde guardar los datos? (Intro = salir sin guardar)

El programa actuará en consecuencia, es decir:
     Si el usuario sólo pulsa Intro, el programa concluirá sin guardar los datos.
     Si, por el contrario, el usuario introduce un nombre, construirá el fichero en la carpeta Datos, 
      con el nombre indicado y la extensión “.TXT”. 
      Si ya existía un fichero con ese nombre, sería reemplazado.
      En este caso guardará los registros con campos separados por ‘;’. 
      No se guarda el número de orden.

 * Recuerda que el tipo string tiene métodos para buscar, reemplazar, eliminar, etc. subcadenas o caracteres.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace P35c_Peliculas_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = File.OpenText("./Datos/pelis.TXT");
            List<string> logsList = new List<string>();

            while (!streamReader.EndOfStream)
            {
                logsList.Add(streamReader.ReadLine());
            }

            streamReader.Close();

            /*******************************************************************/

            PresentarFicheroEnConsola(logsList);
            
            string nombreFichero = RecogerNombreFichero("\n\n¿Nombre del fichero donde guardar los datos? (Intro = salir sin guardar):\t");

            CrearFichero_o_Salir(nombreFichero, logsList);

            PararPrograma();
        }

        /******************************************************************** MÉTODOS *******************************************************************/

        public static void PresentarFicheroEnConsola(List<string> logsList)
        {
            string[] log = new string[4]; // este ejercicio me pide que presente el nombre de la película, su valoración, su formato y su tamaño = 4 campos (la numeración es simplemente presentar la i del for por la que va recorriendo)
            string nombreValorFormato = string.Empty;
            string[] peliculaYformato = new string[2];
            string[] nombreYvaloracion = new string[2];

            Console.WriteLine("\nNº\tPelícula\t\t\t\tValor\tForm.\tTamaño");
            Console.WriteLine("----------------------------------------------------------------------");

            for (int i = 0; i < logsList.Count; i++)
            {
                nombreValorFormato = logsList[i].Substring(36).Replace(".", " "); // aquí he guardado el nombre+valoración+formato sin puntos --> [extendida(BB) avi]
                peliculaYformato = nombreValorFormato.Split(')');                 // aquí he guardado el nombre+valoración y el formato --> extendida(BB) avi --> [extendida(BB] [ avi]
                nombreYvaloracion = peliculaYformato[0].Split('(');               // aquí he guardado el nombre y la valoración --> extendida(BB) --> [extendida] [BB]

                log[0] = nombreYvaloracion[0].Trim();                             // aquí he guardado el nombre
                log[1] = nombreYvaloracion[1];                                    // aquí he guardado la valoración
                log[2] = peliculaYformato[1].Trim();                              // aquí he guardado el formato
                log[3] = logsList[i].Substring(22, 13);                           // aquí he guardado el tamaño

                Console.WriteLine
                (
                    "{0}\t{1}\t{2}\t{3}\t{4}", 
                    
                    i, 
                    CuadraTexto(log[0], 34),
                    log[1],
                    log[2],
                    Math.Round((Convert.ToDouble(log[3].Replace(".", "")) / 1073741824) * 1.11, 2) // 1Gb = 1.073.741.824 bytes
                );
            }
        }

        public static string RecogerNombreFichero(string pregunta)
        {
            string nombreFichero = string.Empty;

            Console.Write(pregunta);
            nombreFichero = Console.ReadLine();

            return nombreFichero;
        }

        public static void CrearFichero_o_Salir(string nombreFichero, List<string> logsList)
        {
            if (nombreFichero == "")
            {
                Console.WriteLine("\nHa elegido NO guardar el fichero.");
            }
            else 
            {
                StreamWriter streamWriter = new StreamWriter("./Datos/" + nombreFichero + ".TXT", false, Encoding.UTF8);

                string[] log = new string[4]; // este ejercicio me pide que presente el nombre de la película, su valoración, su formato y su tamaño = 4 campos (la numeración es simplemente presentar la i del for por la que va recorriendo)
                string nombreValorFormato = string.Empty;
                string[] peliculaYformato = new string[2];
                string[] nombreYvaloracion = new string[2];

                // streamWriter.WriteLine("Nº;Película;Valor;Form.;Tamaño");
                // streamWriter.WriteLine("---------------------------------");

                for (int i = 0; i < logsList.Count; i++)
                {
                    nombreValorFormato = logsList[i].Substring(36).Replace(".", " "); // aquí he guardado el nombre+valoración+formato sin puntos --> [extendida(BB) avi]
                    peliculaYformato = nombreValorFormato.Split(')');                 // aquí he guardado el nombre+valoración y el formato --> extendida(BB) avi --> [extendida(BB] [ avi]
                    nombreYvaloracion = peliculaYformato[0].Split('(');               // aquí he guardado el nombre y la valoración --> extendida(BB) --> [extendida] [BB]

                    log[0] = nombreYvaloracion[0].Trim();                                    // aquí he guardado el nombre
                    log[1] = nombreYvaloracion[1];                                    // aquí he guardado la valoración
                    log[2] = peliculaYformato[1].Trim();                              // aquí he guardado el formato
                    log[3] = logsList[i].Substring(22, 13);                           // aquí he guardado el tamaño

                    streamWriter.WriteLine
                    (
                        "{0};{1};{2};{3}", 
                        
                        log[0],
                        log[1],
                        log[2],
                        Math.Round((Convert.ToDouble(log[3].Replace(".", "")) / 1073741824) * 1.11, 2) // 1Gb = 1.073.741.824 bytes
                    );
                }

                streamWriter.Close();

                Console.WriteLine("\nEl fichero se ha guardado con éxito.");
            }
        }

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += ".........................................";

            return texto.Substring(0, nCaracteres);
        }

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}