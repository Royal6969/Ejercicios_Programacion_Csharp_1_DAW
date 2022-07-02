/* Leer Datos En Fichero.Txt Con Campos dimensionados: (Versión básica)
Repetir la práctica pero leyendo el fichero híbrido que guardamos en la práctica 
de escritura de campos dimensionados, es decir:
@"c:\zDatosPruebas\fNotasCDs.TXT"

 * Ten en cuenta que los apellidos están separados del nombre 

  id: 3     apellidos: 18     nombre: 12  notaProg: 3   notaBD: 3  
 

pero la presentación tiene que ser la misma que antes.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Construyo una lista donde guardar las líneas del fichero (registros)
        List<string> listaReg = new List<string>();

        // Comprobamos que con File que toma bien la codificación => Usamos el constructor
        StreamReader sr = File.OpenText(@"c:\zDatosPruebas\fNotasCDs.TXT");

        //StreamReader sr = new StreamReader(@"c:\zDatosPruebas\fNotasCDs.TXT", Encoding.Default);

        // Leo hasta el final guardando en la lista cada registro
        while (!sr.EndOfStream)
            listaReg.Add(sr.ReadLine());

        // ya hemnos leído todas las líneas, por lo tanto cierro el stream
        sr.Close();

        // por comodidad, guardo el tamaño de la lista (es decir, el número de alumnos), porque lo voy a usar varias veces
        int numAlumnos = listaReg.Count;
        // construyo las tablas con el número de filas obtenidas
        byte[] tabIds = new byte[numAlumnos];
        string[] tabAlums = new string[numAlumnos];
        float[,] tabNotas = new float[numAlumnos, 3];

        for (int i = 0; i < numAlumnos; i++)
        {
            // en la primera posición del registro: lo guardo en tabIds
            tabIds[i] = Convert.ToByte(listaReg[i].Substring(0, 3));
            // a partir de la posición 3: compongo «Apellidos, Nombre», quitando los espacios
            tabAlums[i] = listaReg[i].Substring(3, 18).Trim() + ", " + listaReg[i].Substring(21, 12).Trim();
            // en las tres siguientes posiciones de vCampos están las tres notas
            tabNotas[i, 0] = Convert.ToSingle(listaReg[i].Substring(33, 3));
            tabNotas[i, 1] = Convert.ToSingle(listaReg[i].Substring(36, 3));
            tabNotas[i, 2] = Convert.ToSingle(listaReg[i].Substring(39));
        }
        //-------------- Mostramos los datos  -----------------
        Console.WriteLine("     Id  Alumno\t\t\t\tProg    Ed      BD      Media");
        Console.WriteLine("     -----------------------------------------------------------------");
        //--- Versión 1: Cuadrando sólo el nombre
        double media;
        for (int i = 0; i < numAlumnos; i++)
        {
            media = Math.Round((tabNotas[i, 0] + tabNotas[i, 1] + tabNotas[i, 2]) / 3, 2);
            Console.WriteLine("     {0} {1} {2}\t{3}\t{4}\t{5}", tabIds[i], CuadraTexto(tabAlums[i], 30), tabNotas[i, 0], tabNotas[i, 1], tabNotas[i, 2], media);
        }

        Console.WriteLine("\n\n\t Pulsa una tecla para salir");
        Console.ReadKey();
    }
    static string CuadraTexto(string texto, int numCaracteres)
    {
        texto += "                                  ";
        return texto.Substring(0, numCaracteres);
    }
}
