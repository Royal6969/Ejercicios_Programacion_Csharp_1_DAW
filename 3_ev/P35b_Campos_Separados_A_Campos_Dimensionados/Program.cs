/*
De Campos separados a dimensionados

Antes que nada, guardar una copia del fichero PacientesPeso_Cs.txt en una carpeta de nombre Pacientes dentro de zDatosPruebas.

Los registros de "PacientesPeso_CS.txt", tienen los campos separados por '$' en el siguiente orden:
id $ Apellidos, Nombre $ movil $ fechaNac $ altura $ peso

El proceso a seguir será el siguiente:

1) El programa leerá los registros y los guardará en un fichero que debes construir, 
en la misma carpeta, con el nombre: PacientesPeso_CD.txt". 

En este fichero se guardarán los campos dimensionados con el siguiente número de caracteres:
id Apellidos, Nombre móvil fechaNac altura peso
3 28 9 8 3 5

2) A continuación leerá los datos de este último fichero y los presentará en pantalla con su cabecera.

Importante:
Ten en cuenta que la fecha está guardada como un entero compuesto como AAAAMMDD, 
es decir, los 4 primeros dígitos son el año, los dos siguientes el mes y los dos últimos el día. 
Tú lo debes presentar como día/mes/año.

Tanto el id como la altura, que está en centímetros deben estar alineados a la derecha. 
El peso también tiene que estar bien alineado.

3) Por último, dirá el peso medio de todos los Pacientes.
*/

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
// using System.Globalization;

namespace P35b_Campos_Separados_A_Campos_Dimensionados
{
    class Program
    {
        static void Main(string[] args)
        {
            // StreamReader streamReader = File.OpenText("C:/zDatosPruebas/Pacientes/PacientesPeso_CS.txt");
            StreamReader streamReader = new StreamReader("C:/zDatosPruebas/Pacientes/PacientesPeso_CS.txt", Encoding.UTF8);

            List<string> LogsList = new List<string>();

            while (!streamReader.EndOfStream)
            {
                LogsList.Add(streamReader.ReadLine());
            }

            streamReader.Close();

            /*******************************************************************************************/

            // StreamWriter streamWriter = File.CreateText("C:/zDatosPruebas/Pacientes/PacientesPeso_CD.txt");
            StreamWriter streamWriter = new StreamWriter("C:/zDatosPruebas/Pacientes/PacientesPeso_CD.txt", false, Encoding.UTF8);

            string[] log = new string[5]; // id $ Apellidos, Nombre $ movil $ fechaNac $ altura $ peso = 6 campos
            double suma = 0;

            streamWriter.WriteLine("\nID\tApellidos, Nombre\t\tMovil\t\tFecha Nac.\tAlt.\tPeso");
            streamWriter.WriteLine("-------------------------------------------------------------------------------------");

            for (int i = 0; i < LogsList.Count; i++)
            {
                log = LogsList[i].Split('$');

                if (log[0].Length < 3)
                {
                    streamWriter.Write(" " + log[0]);
                }
                else
                {
                    streamWriter.Write(log[0]);
                }

                streamWriter.Write
                (
                    "\t{0}\t{1}\t{2}\t{3}",

                    CuadraTexto(log[1], 28),
                    CuadraTexto(log[2], 9),
                    CuadraTexto(log[3].Substring(6, 2) + "/" + log[3].Substring(4, 2) + "/" + log[3].Substring(0, 4), 10),
                    CuadraTexto(log[4], 3)
                );

                if (log[5].Length < 5)
                {
                    streamWriter.WriteLine("\t{0}\t", log[5], suma += Convert.ToDouble(log[5]));
                }
                else // aquí se debería de usar un método tipo CuadraTexto()
                {
                    streamWriter.WriteLine("    {0}\t", log[5], suma += Convert.ToDouble(log[5]));
                }
            }

            streamWriter.WriteLine("\nEl peso medio de todos los pacientes es:\t" + Math.Round((suma / LogsList.Count), 2) + " kg");
            // OJO, en vez del Math.Round() también podría fijar el formato con .ToString("0.0")

            streamWriter.Close();

            /********************************************************************************************/

            streamReader = File.OpenText("C:/zDatosPruebas/Pacientes/PacientesPeso_CD.txt");
            string texto = string.Empty;

            texto = streamReader.ReadToEnd();

            streamReader.Close();

            Console.Write(texto); // realmente el ejercicio no acaba así, lo de dimensionar los campos debo de hacerlo aquí en la presentación

            PararPrograma();
        }

        /**************************************************** MÉTODOS *****************************************************/

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

/*
Curiosidad:

para el formato de la fecha, intenté varias conversiones ...

CuadraTexto(DateTime.ParseExact(log[3], "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString(), 8),
CuadraTexto(Convert.ToDateTime(log[3]).ToString("dd, MM", CultureInfo.InvariantCulture), 8),

Enlaces de interés:

Cadenas con formato de fecha y hora estándar:
https://docs.microsoft.com/es-es/dotnet/standard/base-types/standard-date-and-time-format-strings

Parse date and time strings in .NET:
https://docs.microsoft.com/en-us/dotnet/standard/base-types/parsing-datetime

Convert.ToDateTime Método:
https://docs.microsoft.com/es-es/dotnet/api/system.convert.todatetime?view=net-6.0
*/