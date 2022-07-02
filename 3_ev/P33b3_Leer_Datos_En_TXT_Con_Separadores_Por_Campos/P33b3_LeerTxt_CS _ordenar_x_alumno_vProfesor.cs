/* Leer Datos enTxt Campos Separados y mostrar ordenados
Versión 2: reordenando los campos
Como  en la primera versión de esta práctica P33b_LeerDeTxtSeparadoresCampos, realiza un programa que lea el fichero AlumNotas.txt que tienes en la carpeta Datos dentro del directorio de trabajo. Se sabe que cada registro contiene los siguientes campos: id, nombre, nota1, nota2 y nota3. Estos campos están separados por ‘;’. 
Estas son las dos diferencias de esta práctica respecto a la primera versión:
    1.	No hace falta guardar los datos en tablas. Basta mostrarlos en pantalla.
    2.	Los datos se mostrarán en orden alfabético de alumno. 
Por tanto, la cabecera de los datos a mostrar, será la misma que en la primera versión: 

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LeerDatosEnTxtSeparadoresCampos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Construyo una lista donde guardar las líneas del fichero (registros)
            List<string> listaReg = new List<string>();
            List<string> listaOrdenados = new List<string>();

            // el StreamReader para leer los datos
            StreamReader sr = File.OpenText(@".\Datos\AlumNotas.txt");

            // Leemos todas las lineas del fichero y las guardamos en la lista
            while (!sr.EndOfStream)
                listaReg.Add(sr.ReadLine());
            // ya hemnos leído todas las líneas, por lo tanto cierro el stream
            sr.Close();
            // por comodidad, guardo el tamaño de la lista (es decir, el número de alumnos), porque lo voy a usar varias veces
            int numAlumnos = listaReg.Count;

            string[] vCampos; // <-- tabla donde guardaremos los campos de cada registro
            // Reordenamos los campos poniendo en primer lugar «Apellidos, Nombre»
            for (int i = 0; i < numAlumnos; i++)
            {
                vCampos = listaReg[i].Split(';');
                listaOrdenados.Add(vCampos[1] + ";" + vCampos[0] + ";" + vCampos[2] + ";" + vCampos[3] + ";" + vCampos[4]);

            }
            listaOrdenados.Sort();


            // construyo las tablas con el número de filas obtenidas
            byte[] tabIds = new byte[numAlumnos];
            string[] tabAlums = new string[numAlumnos];
            float[,] tabNotas = new float[numAlumnos, 3];

            // ahora vamos a rellenar las tres tablas desglosando las líneas que tengo en listaReg
            // LO ÚNICO QUE HAY QUE TENER EN CUENTA ES QUE EL ORDEN DE LOS DOS PRIMEROS ESTÁN INTERCAMBIADOS
            for (int i = 0; i < numAlumnos; i++)
            {
                vCampos = listaOrdenados[i].Split(';');
                // DE LA PRIMERA POSICIÓN NOS OLVIDAMOS sólo la hemos utilizado para ordenar
                // en la SEGUNDA posición de vCampos está el id: lo guardo en tabIds
                tabIds[i] = Convert.ToByte(vCampos[1]);
                // en la TERCERA posición de vCampos está el alumno: lo guardo en tabAlumnos
                tabAlums[i] = vCampos[0];
                // en las tres siguientes posiciones de vCampos están las tres notas
                tabNotas[i, 0] = Convert.ToSingle(vCampos[2]);
                tabNotas[i, 1] = Convert.ToSingle(vCampos[3]);
                tabNotas[i, 2] = Convert.ToSingle(vCampos[4]);


            }

            //-------------- Mostramos los datos  -----------------
            double media;
            Console.WriteLine("     Id  Alumno\t\t\t\tProg    Ed      BD      Media");
            Console.WriteLine("     -----------------------------------------------------------------");
            //--- Versión 1: Cuadrando sólo el nombre
            for (int i = 0; i < numAlumnos; i++)
            {
                media = Math.Round((tabNotas[i, 0] + tabNotas[i, 1] + tabNotas[i, 2]) / 3, 2);
                Console.WriteLine("     {0} {1} {2}\t{3}\t{4}\t{5}", tabIds[i], CuadraTexto(tabAlums[i], 30), tabNotas[i, 0], tabNotas[i, 1], tabNotas[i, 2], media);
            }

            //--- Versión 2: Cuadrándolo todo
            //for (int i = 0; i < numAlumnos; i++)
            //{
            //    media = Math.Round((tabNotas[i, 0] + tabNotas[i, 1] + tabNotas[i, 2]) / 3, 2);
            //    Console.WriteLine("     {0} {1} {2}{3}{4}{5}", tabIds[i], 
            //        CuadraTexto(tabAlums[i], 30),
            //        CuadraTexto(tabNotas[i, 0].ToString(), 8),
            //        CuadraTexto(tabNotas[i, 1].ToString(), 8),
            //        CuadraTexto(tabNotas[i, 2].ToString(), 8),
            //        media.ToString());
            //}

            //--- Versión 3: Sin cuadrar pero  usando SetCursorPosition
            //int filaPantalla = 2;
            //         for (int i = 0; i < numAlumnos; i++)
            //         {
            //             media = Math.Round((tabNotas[i, 0] + tabNotas[i, 1] + tabNotas[i, 2]) / 3, 2);
            //             Console.SetCursorPosition(5, filaPantalla);
            //             Console.Write("{0} {1}", tabIds[i], tabAlums[i]);
            //             Console.SetCursorPosition(40, filaPantalla);
            //             Console.Write("{0}\t{1}\t{2}\t{3}", tabNotas[i, 0], tabNotas[i, 1], tabNotas[i, 2], media);
            //             filaPantalla++;
            //         }

            Console.WriteLine("\n\n\t Pulsa tecla para salir");
            Console.ReadKey();
        }

        static string CuadraTexto(string texto, int numCaracteres)
        {
            texto += ".................................";
            return texto.Substring(0, numCaracteres);
        }
    }
}
