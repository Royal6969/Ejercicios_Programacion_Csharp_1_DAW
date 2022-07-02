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

namespace LeerDatosEnTxtSeparadoresCampos_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            /******************* Primero, voy a contar las líneas del fichero, para obtener la longitud que deberán tener los vectores que se me piden ******************/

            StreamReader streamReader = new StreamReader("./Datos/AlumNotas.TXT", Encoding.Default);

            string linea = string.Empty;
            int contLineas = 0;

            while(!streamReader.EndOfStream)
            {
                linea = streamReader.ReadLine();
                contLineas ++;
            }

            streamReader.Close();

            /************************ He contado las líneas del fichero y se cerró, y ahora lo vuelvo a abrir para cargar las tablas *******************************/

            Console.WriteLine("\nId      Alumno\t\t\t\tProg    Ed      BD      Media");
            Console.WriteLine("-----------------------------------------------------------------------");

            streamReader = new StreamReader("./Datos/AlumNotas.TXT", Encoding.Default);

            string[] log = new string[5]; // siguiendo la cabecera ... Id + Alumno + Prog + Ed + BD = 5
            byte[] tabIds = new byte[contLineas];
            string[] tabAlums = new string[contLineas];
            float[,] tabNotas = new float[contLineas, 3];
            int index = 0;

            while(!streamReader.EndOfStream)
            {
                linea = streamReader.ReadLine();
                log = linea.Split(';');

                tabIds[index] = byte.Parse(log[0]);
                tabAlums[index] = log[1];
                tabNotas[index, 0] = float.Parse(log[2]);
                tabNotas[index, 1] = float.Parse(log[3]);
                tabNotas[index, 2] = float.Parse(log[4]);

                Console.WriteLine
                (
                    tabIds[index] + "\t" + 
                    tabAlums[index] + "   \t" + 
                    tabNotas[index,0].ToString("0.00") + "\t" + 
                    tabNotas[index,1].ToString("0.00") + "\t" + 
                    tabNotas[index,2].ToString("0.00") + "\t" +
                    ((tabNotas[index, 0] + tabNotas[index, 1] + tabNotas[index, 2]) / 3).ToString("0.00")
                );

                index ++;
            }        

            streamReader.Close();

            PararPrograma();
        }

        /************************************************ MÉTODOS ***************************************************/
        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}