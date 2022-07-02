/* 
Leer Datos En Fichero.Txt Con Separadores de Campos: 

Realiza un programa que lea el fichero AlumNotas.txt que tienes en la carpeta Datos. 

Se sabe que cada fila contiene los campos: id, nombre, nota1, nota2 y nota3 separados por ‘;’. 

A partir de estas filas obtenidas, rellena una tabla de byte tabIds, 
otra de string tabAlums y otra de float tabNotas de tres columnas. 

A continuación presentar los datos con su cabecera

Importante: 
 1.	Utilizar Ruta Relativa y mantener la estructura de archivos que se te entrega. 
 2.	El archivo debe estar abierto el menor tiempo posible.
 3.	Se puede utilizar una lista auxiliar pero tienes que actuar como si no se supiera el número de alumnos que guarda el fichero.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace P33b_Leer_Datos_En_TXT_Con_Separadores_Por_Campos
{
    class Program
    {
        static void Main(string[] args)
        {
            /******************* Primero, voy a contar las líneas del fichero, para obtener la longitud que deberán tener los vectores que se me piden ******************/

            //StreamReader streamReader = File.OpenText("./Datos/AlumNotas.TXT"); // también se puede abrir así
            StreamReader streamReader = new StreamReader("./Datos/AlumNotas.TXT", Encoding.Default);

            // otro enfoque para este ejercicio, sería el de guardar en una lista cada línea del fichero para su posterior manipulación
            // List<string> listaLogs = new List<string>();

            string linea = string.Empty;
            int contLineas = 0;

            while (!streamReader.EndOfStream)
            {
                linea = streamReader.ReadLine();
                contLineas++;

                // listaLogs.Add(streamReader.ReadLine()); 
                // este otro enfoque de usar una lista es mejor, porque cuando vuelves a recoger el contenido del mismo fichero por segunda vez, puede que éste hubiera cambiado y ahora salga un resultado diferente
            }

            streamReader.Close();

            /************************ He contado las líneas del fichero y se cerró, y ahora lo vuelvo a abrir para cargar las tablas *******************************/

            streamReader = new StreamReader("./Datos/AlumNotas.TXT", Encoding.Default);

            string[] log = new string[5]; // siguiendo la cabecera ... Id + Alumno + Prog + Ed + BD + Media = 6 (aunque en esta versión, lo haremos sin las medias)
            byte[] tabIds = new byte[contLineas];
            string[] tabAlums = new string[contLineas];
            float[,] tabNotas = new float[contLineas, 3];
            int index = 0;

            // estas variables serían para hacer la media
            // float[] tabMedias = new float[contLineas];

            Console.WriteLine("\nId      Alumno\t\t\t\tProg    Ed      BD      Media");
            Console.WriteLine("-----------------------------------------------------------------------");

            while (!streamReader.EndOfStream)
            {
                linea = streamReader.ReadLine();
                log = linea.Split(';');

                tabIds[index] = byte.Parse(log[0]); // Convert.ToByte()
                tabAlums[index] = log[1];
                tabNotas[index, 0] = float.Parse(log[2]); // Convert.ToSingle()
                tabNotas[index, 1] = float.Parse(log[3]);
                tabNotas[index, 2] = float.Parse(log[4]);
                // tabMedias[index] = (float)Math.Round((float)(((tabNotas[index, 0] + tabNotas[index, 1] + tabNotas[index, 2]) / 3) * 1.1), 1);

                // Console.WriteLine(tabIds[index] + "\t" + tabAlums[index] + "   \t" + tabNotas[index, 0] + "\t" + tabNotas[index, 1] + "\t" + tabNotas[index, 2]/* + "\t" +  tabMedias[index]*/);
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}"/*\t{5}*/,tabIds[index], CuadraTexto(tabAlums[index], 30), tabNotas[index, 0], tabNotas[index, 1], tabNotas[index, 2] /*tabMedias[index]*/);

                index ++;
            }

            streamReader.Close();

            PararPrograma();
        }

        /************************************************ MÉTODOS ***************************************************/

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