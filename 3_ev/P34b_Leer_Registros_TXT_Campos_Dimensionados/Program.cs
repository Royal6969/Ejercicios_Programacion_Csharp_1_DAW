/*
Leer Datos En Txt Campos Dimensionados (se entrega carpeta proyecto)

(Nota: Es como la práctica LeerDatosEnTxtConSeparadores 
pero la carpeta Datos está colocada en distinta posición 
y los datos se obtienen del fichero de campos dimensionados AlumNotas_CD.txt).

Realiza un programa que lea el fichero AlumNotas_CD.txt que tienes en la carpeta Datos (dentro de la carpeta del proyecto). 

Cada fila contiene un registro en el que cada campo se ha dimensionado con el siguiente número de caracteres:
id: 3; alumno: 28; notaProg: 3; notaED: 3; notaBD: 3.

A partir de las filas obtenidas, rellena una tabla de byte tabIds, otra de string tabAlums y otra de float tabNotas de tres columnas. 
A continuación presentar los datos del siguiente modo:

Importante:
1. Utilizar Ruta Relativa y mantener la estructura de archivos que se te entrega. 
2. El archivo debe estar abierto el menor tiempo posible.
3. Se puede utilizar una lista auxiliar pero tienes que actuar como si no se supiera el número de alumnos que guarda el fichero
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace P34b_Leer_Registros_TXT_Campos_Dimensionados
{
    class Program
    {
        static void Main(string[] args)
        {
            /******************* Primero, voy a contar las líneas del fichero, para obtener la longitud que deberán tener los vectores que se me piden ******************/

            StreamReader streamReader = new StreamReader("../../Datos/AlumNotas_CD.txt", Encoding.Default);
            List<string> listaLogs = new List<string>();

            string linea = string.Empty;
            int contLineas = 0;

            while (!streamReader.EndOfStream)
            {
                listaLogs.Add(streamReader.ReadLine());
                contLineas++;
            }

            streamReader.Close();

            linea = string.Empty;
            byte[] tabIds = new byte[contLineas];
            string[] tabAlums = new string[contLineas];
            float[,] tabNotas = new float[contLineas, 3];
            float[] tabMedias = new float[contLineas];

            Console.WriteLine("\nId      Alumno\t\t\t\tProg    Ed      BD      Media");
            Console.WriteLine("-----------------------------------------------------------------------");

            for (int i = 0; i < listaLogs.Count; i++)
            {
                tabIds[i] = Convert.ToByte(listaLogs[i].Substring(0, 3));
                tabAlums[i] = listaLogs[i].Substring(3, 28);
                tabNotas[i, 0] = Convert.ToSingle(listaLogs[i].Substring(31, 3));
                tabNotas[i, 1] = Convert.ToSingle(listaLogs[i].Substring(34, 3));
                tabNotas[i, 2] = Convert.ToSingle(listaLogs[i].Substring(37, 3));
                tabMedias[i] = (float)Math.Round((float)(((tabNotas[i, 0] + tabNotas[i, 1] + tabNotas[i, 2]) / 3) * 1.1), 1);

                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", tabIds[i], CuadraTexto(tabAlums[i], 28), CuadraTexto(tabNotas[i, 0].ToString(), 3), CuadraTexto(tabNotas[i, 1].ToString(), 3), CuadraTexto(tabNotas[i, 2].ToString(), 3), tabMedias[i]);
            }

            PararPrograma();
        }

        /************************************************ MÉTODOS ***************************************************/

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += ".........................................";

            return texto.Substring(0, nCaracteres);
        }

        static string CuadraTexto_v2(string texto, int nCaracteres, char caracter)
        {
            if (texto.Length > nCaracteres)
            {
                texto = texto.Substring(0, nCaracteres);
            }

            for (int i = 0; i < nCaracteres - texto.Length; i++)
            {
                texto += caracter;
            }

            return texto;
        }

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}