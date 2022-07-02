using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P40a_Proyecto_Cliente
{
    class Tools
    {
        public static DateTime FECHAHOY = DateTime.Now;

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += ".........................................";

            return texto.Substring(0, nCaracteres);
        }

        public static void StopProgram()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }

        /******************* Ejercicio extra Classroom **************************/

        public static byte Edad(byte anyo, byte mes, byte dia)
        {
            int anyoHoy = 2022;
            int mesHoy = 2;
            int diaHoy = 16;

            int anyo4cifras;

            if (anyo > 22)
            {
                anyo4cifras = 1900 + anyo;
            }
            else
            {
                anyo4cifras = 2000 + anyo;
            }

            int edad = anyoHoy - anyo4cifras;

            // el enfoque correcto está en NO calcular dias o meses "excedentes" para sumar meses o días, sino el de restar para corregir el desfase de dias y meses
            if ((mesHoy < mes) || (mesHoy == mes && diaHoy < dia))
            {
                edad--;
            }

            return (byte)(edad % 100);
        }
    }
}
