/* Leer Datos En Fichero.Txt Con Separadores de Campos: 
Se trata de repetir la práctica del mismo nombre, 
pero sin guardar los datos en listas ni tablas: simplemente leer y presentar. 
El único vector que se permite es el de los campos.  
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
            // el StreamReader para leer los datos
            StreamReader sr = File.OpenText(@".\Datos\AlumNotas.txt");

            string registro;
            string[] vCampos; // <-- tabla donde guardaremos los campos de cada registro

            Console.WriteLine("     Id  Alumno\t\t\t\tProg    Ed      BD      Media");
            Console.WriteLine("     -----------------------------------------------------------------");

            // Leemos todas las lineas del fichero y las desglosamos para mostrar los datos
            while (!sr.EndOfStream)
            {
                registro = sr.ReadLine();
                vCampos = registro.Split(';');
                Console.WriteLine("     {0} {1} {2}\t{3}\t{4}\t{5}",
                    vCampos[0],
                    CuadraTexto(vCampos[1], 30, '.'),
                    vCampos[2], vCampos[3], vCampos[4],
                    Math.Round((Convert.ToSingle(vCampos[2]) + Convert.ToSingle(vCampos[3]) + Convert.ToSingle(vCampos[4])) / 3, 2));

            }
            // ya hemnos leído todas las líneas, por lo tanto cierro el stream
            sr.Close();

            Console.WriteLine("\n\n\t Pulsa tecla para salir");
            Console.ReadKey();
        }

        static string CuadraTexto(string texto, int numCaracteres, char caracter)
        {
            if (texto.Length > numCaracteres)
                return texto.Substring(0, numCaracteres);
            while (texto.Length < numCaracteres)
                texto += caracter;
            return texto;
        }
    }
}
