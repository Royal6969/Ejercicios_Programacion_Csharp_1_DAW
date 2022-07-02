/*Leer Datos En Fichero.Txt Con Campos dimensionados puros (sin salto de línea)
//---- Versión 1: Sin usando lista, como en la práctica con fichero híbrido

Si te has dado cuenta, en la práctica anterior, los datos no estaban guardados realmente 
como campos dimensionados: se les había colocado un separador de registros (el salto de línea).
Realiza un programa que lea el fichero AlumNotas_CDpuro.txt  que tienes en la carpeta Datos. 
Este archivo contiene los datos que se guardaron en la práctica de escritura de datos 
con campos dimensionados P34a (pero sin saltos de líneas):
		Dato →			id	Apellidos  Nombre  Nota1  Nota2  Nota3
		Nº Caracteres	3	   18	     12	     3	    3	   3

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
		// el StreamReader para leer los datos. Comprobamos que con File no toma bien la codificación => Usamos el constructor
		//StreamReader sr = File.OpenText(@".\Datos\AlumNotas_CD.txt");
		StreamReader sr = new StreamReader(@".\Datos\AlumNotas_CDpuro.txt", Encoding.UTF8);

		// la primera novedad respecto al fichero híbrido es esta lectura
		// Leo hasta el final guardando en un string
		string toElFichero = sr.ReadToEnd();
		// ya hemnos leído el fichero, por lo tanto cierro el stream
		sr.Close();

		/* Nota: la longitud del registro es las suma de sus campos, es decir,
		  3 + 18 + 12 + 3 + 3 + 3 = 42 caracteres				*/

		List<string> listaReg = new List<string>();
		// la última novedad respecto al fichero híbrido es este bucle
		for (int i = 0; i < toElFichero.Length; i += 42)
			listaReg.Add(toElFichero.Substring(i, 42));

		// El nº de alumnos será el tamaño de la lista
		int numAlumnos = listaReg.Count;
		// ---- Construimos las tablas
		byte[] tabIds = new byte[numAlumnos];
		string[] tabAlumnos = new string[numAlumnos];
		float[,] tabNotas = new float[numAlumnos, 3];

		//------------ El resto es como en la prática anterior -----------------------

		//---- Cargamos las tablas Recorriendo la lista de registros.
		for (int i = 0; i < numAlumnos; i++)
		{
			// en la primera posición de tabCampos está el id: lo guardo en tabIds
			tabIds[i] = Convert.ToByte(listaReg[i].Substring(0, 3));
			// en la segunda posición de tabCampos está el nombre: lo guardo en tabAlumnos
			tabAlumnos[i] = listaReg[i].Substring(3, 18).Trim() + ", " + listaReg[i].Substring(21, 12).Trim();
			// en las tres siguientes posiciones de tabCampos están las tres notas
			tabNotas[i, 0] = Convert.ToSingle(listaReg[i].Substring(33, 3));
			tabNotas[i, 1] = Convert.ToSingle(listaReg[i].Substring(36, 3));
			tabNotas[i, 2] = Convert.ToSingle(listaReg[i].Substring(39));
		}

		//---- Mostramos los datos ----
		Console.WriteLine("\n     Id  Alumno\t\t\t        Prog    Ed      BD      Media");
		Console.WriteLine("     -----------------------------------------------------------------");

		for (int i = 0; i < numAlumnos; i++)
		{
			Console.Write("     {0} {1} ", tabIds[i], CuadraTexto(tabAlumnos[i], 30)); ;//       ┌---------- media con dos decimales ---------------------------------┐
			Console.WriteLine("{0}\t{1}\t{2}\t{3}", tabNotas[i, 0], tabNotas[i, 1], tabNotas[i, 2], Math.Round((tabNotas[i, 0] + tabNotas[i, 1] + tabNotas[i, 2]) / 3, 2));
		}

		Console.WriteLine("\n\n\t Pulsa una tecla para salir");
		Console.ReadKey();
	}
	static string CuadraTexto(string texto, int numChars)
	{
		texto += "......................................";
		return texto.Substring(0, numChars);
	}
}
