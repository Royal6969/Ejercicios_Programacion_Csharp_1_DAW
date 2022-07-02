/*
De Campos Dimensionados a Campos Separados

Antes que nada, guardar una copia del fichero AlumNotas_CD.txt en una carpeta de nombre AlumnosNotas dentro de zDatosPruebas.

El programa leerá los registros del fichero de campos dimensionados AlumNotas_CD.txt , 
cuyos campos están guardados con las dimensiones siguientes:

id: 3; alumno: 28; notaProg: 3; notaED: 3; notaBD: 3 ------------------> 3 + 28 + 3 + 3 + 3 = 40 (en realidad cada linea tiene 38 caracteres)

y los guardará en un fichero de campos separados AlumNotas_CS.txt 
de modo que los campos, sin espacios laterales, estén separados por el carácter ';'.

A continuación, leerá los datos del fichero resultante AlumNotas_CS.txt 
y los mostrará en pantalla con su cabecera.

Nota: Utilizar el menor número de recursos posible. 
Evidentemente, no hace falta utilizar listas ni tablas.
*/

using System;
using System.IO;
using System.Text;

namespace P35a_Campos_Dimensionados_A_Campos_Separados
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("C:/zDatosPruebas/AlumnosNotas/AlumNotas_CD.txt", Encoding.UTF8);
            StreamWriter streamWriter = File.CreateText("C:/zDatosPruebas/AlumnosNotas/AlumNotas_CS.txt");

            string linea = string.Empty;

            while (!streamReader.EndOfStream)
            {
                linea = streamReader.ReadLine();

                streamWriter.WriteLine
                (
                    "{0};{1};{2};{3};{4}", 
                    
                    linea.Substring(0, 3).Trim(), 
                    linea.Substring(3, 26).Trim(), 
                    linea.Substring(29, 3).Trim(), 
                    linea.Substring(32, 3).Trim(), 
                    linea.Substring(35).Trim()
                );
            }
            streamReader.Close();
            streamWriter.Close();

            /***************************************************************************************************************************************************************************************/

            streamReader = File.OpenText("C:/zDatosPruebas/AlumnosNotas/AlumNotas_CS.txt");
            string[] vLog = new string[5]; // para presentar un fichero de campos separados, si nos hace falta un vector donde recoger el Split()

            Console.WriteLine("\nId\tAlumno\t\t\t\tProg\tEd\tBD");
            Console.WriteLine("-----------------------------------------------------------");

            while (!streamReader.EndOfStream)
            {
                vLog = streamReader.ReadLine().Split(';');

                Console.WriteLine
                (
                    "{0}\t{1}\t{2}\t{3}\t{4}", 
                    
                    vLog[0], 
                    CuadraTexto(vLog[1], 26),
                    CuadraTexto(vLog[2], 3),
                    CuadraTexto(vLog[3], 3),
                    CuadraTexto(vLog[4], 3)
                );
            }

            streamReader.Close();
            
            PararPrograma();
        }

        /*********************************************************** MÉTODOS ************************************************************/

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
