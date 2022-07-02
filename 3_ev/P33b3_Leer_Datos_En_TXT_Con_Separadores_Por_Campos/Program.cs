using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace P33b3_Leer_Datos_En_TXT_Con_Separadores_Por_Campos
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("./Datos/AlumNotas.TXT", Encoding.Default);
            string[] log = new string[5]; // siguiendo la cabecera ... Id + Alumno + Prog + Ed + BD = 5
            List<string> logsList = new List<string>();

            while (!streamReader.EndOfStream) 
            {
                log = streamReader.ReadLine().Split(';');   // por cada línea que lee del fichero, guarda los diferentes campos en un vector
                SwapVectorValuePosition(log);               // intercambio el ID por el Nombre y Apellidos en el vector
                logsList.Add(string.Join(";", log));        // vuelvo a unir los campos del vector en un string y añado la línea a la lista
            }

            streamReader.Close();

            /**************************************************************************************************/

            logsList.Sort();

            Console.WriteLine("\nId      Alumno\t\t\t\tProg    Ed      BD      Media");
            Console.WriteLine("-----------------------------------------------------------------------");

            for (int i = 0; i < logsList.Count; i++)
            {
                log = logsList[i].Split(';');               // cada línea del LogsList, la separo por campos y la vuelco en un vector
                SwapVectorValuePosition(log);               // vuelvo a poner el ID y el Nombre y Apellidos en las posiciones que estaban inicialmente
                logsList[i] = string.Join(";", log);        // vuelvo a unir todos los campos en un solo string a modo de línea 
                // (con esto ya lo tengo todo como al principio, pero con los Nombres y Apellidos ordenados alfabéticamente)               
                log = logsList[i].Split(';');               // separo por última vez los campos de cada línea y los vuelvo en un vector

                Console.WriteLine                           // finalmente, para cada línea, voy mostrando los campos del vector, tal como en el ejercicio de origen P33b
                (
                    "{0}\t{1}\t{2}\t{3}\t{4}\t{5}", 
                    
                    log[0], 
                    CuadraTexto_v2(log[1], 30, '▒'), 
                    log[2], 
                    log[3], 
                    log[4], 
                    (float)Math.Round((float)(((float.Parse(log[2]) + float.Parse(log[3]) + float.Parse(log[4])) / 3) * 1.1), 1)
                );
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
            /*else // opcional
            {
                for (int i = texto.Length; i < nCaracteres; i++)
                {
                    //texto = texto + " ";
                    texto = caracter + texto;
                }
            }*/

            for (int i = 0; i < nCaracteres - texto.Length; i++)
            {
                texto += caracter;
            }

            return texto;
        }

        public static void SwapVectorValuePosition(string[] log)
        {
            string aux = string.Empty;

            aux = log[1];
            log[1] = log[0];
            log[0] = aux;
        }

        public static bool PreguntaSiNo(string pregunta)
        {
            char tecla;

            do
            {
                // Hacemos la pregunta
                Console.Write("\n\n{0} (s=Sí; n=No): ", pregunta);
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

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}