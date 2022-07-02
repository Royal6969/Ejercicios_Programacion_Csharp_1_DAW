/*Leer Datos En Fichero.Txt Con Campos dimensionados puros (sin salto de línea)

Si te has dado cuenta, en la práctica anterior, los datos no estaban guardados realmente 
como campos dimensionados: se les había colocado un separador de registros (el salto de línea).
Realiza un programa que lea el fichero AlumNotas_CDpuro.txt  que tienes en la carpeta Datos. 
Este archivo contiene los datos que se guardaron en la práctica de escritura de datos 
con campos dimensionados P34a (pero sin saltos de líneas):
		Dato →			id	Apellidos  Nombre  Nota1  Nota2  Nota3
		Nº Caracteres	3	   18	     12	     3	    3	   3    = 42 caracteres

A partir de estos datos, rellena las tres tablas siguientes:
  ●	Una de byte tabIds
  ●	otra de string tabAlums, con los «Apellidos, Nombre» de cada alumno, 
  ●	y otra de float tabNotas de tres columnas.

A continuación presentar los datos con su cabecera y la media de cada alumno
 Importante: 
 1.	Utilizar Ruta Relativa y mantener la estructura de archivos que se te entrega. 
 2.	El archivo debe estar abierto el menor tiempo posible.
 3.	Se puede utilizar una lista auxiliar pero tienes que actuar como si no se supiera 
    el número de alumnos que guarda el fichero.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
	static void Main(string[] args)
	{
        /******************* Primero, voy a contar las líneas del fichero, para obtener la longitud que deberán tener los vectores que se me piden ******************/

        StreamReader streamReader = new StreamReader("./Datos/AlumNotas_CDpuro.txt", Encoding.UTF8);
     
        string datos = streamReader.ReadToEnd();

        streamReader.Close();

        List<string> listaLogs = new List<string>();

        for (int j = 0; j < datos.Length; j += 42)
        {
            listaLogs.Add(datos.Substring(j, 42));
        }

        byte[] tabIds = new byte[listaLogs.Count];
        string[] tabAlums = new string[listaLogs.Count];
        float[,] tabNotas = new float[listaLogs.Count, 3];
        //float[] tabMedias = new float[listaLogs.Count];

        Console.WriteLine("\nId      Alumno\t\t\t\tProg    Ed      BD      Media");
        Console.WriteLine("-----------------------------------------------------------------------");

        int i = 0;
        foreach (string log in listaLogs)
        {
            tabIds[i] = Convert.ToByte(listaLogs[i].Substring(0, 3));
            tabAlums[i] = listaLogs[i].Substring(3, 18).Trim() + ", " + listaLogs[i].Substring(21, 12).Trim();
            tabNotas[i, 0] = Convert.ToSingle(listaLogs[i].Substring(33, 3));
            tabNotas[i, 1] = Convert.ToSingle(listaLogs[i].Substring(36, 3));
            tabNotas[i, 2] = Convert.ToSingle(listaLogs[i].Substring(39));
            //tabMedias[i] = (float)Math.Round((float)(((tabNotas[i, 0] + tabNotas[i, 1] + tabNotas[i, 2]) / 3) * 1.1), 1);

            // Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", tabIds[i], CuadraTexto(tabAlums[i], 28), CuadraTexto(tabNotas[i, 0].ToString(), 3), CuadraTexto(tabNotas[i, 1].ToString(), 3), CuadraTexto(tabNotas[i, 2].ToString(), 3)/*, tabMedias[i]*/);
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", tabIds[i], CuadraTexto(tabAlums[i], 28), CuadraTexto(tabNotas[i, 0].ToString(), 3), CuadraTexto(tabNotas[i, 1].ToString(), 3), CuadraTexto(tabNotas[i, 2].ToString(), 3), (float)Math.Round((float)(((tabNotas[i, 0] + tabNotas[i, 1] + tabNotas[i, 2]) / 3) * 1.1), 1));

            i ++;
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
