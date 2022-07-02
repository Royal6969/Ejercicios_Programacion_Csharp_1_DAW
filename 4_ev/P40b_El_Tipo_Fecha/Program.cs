using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P40b_El_Tipo_Fecha
{
    class Program
    {
        static void Main(string[] args)
        {
            Fecha fecha1 = new Fecha();
            int diasAvance = 0;

            do
            {

                Console.WriteLine("\n\n\tLa fecha actual es... :");

                Console.WriteLine("\n\t" + fecha1.FechaEntero.ToString("000000"));
                Console.WriteLine("\n\t" + fecha1.FechaStringSp);
                Console.WriteLine("\n\t" + fecha1.FechaStringTexto);

                if (Tools.PreguntaSiNo("\t¿ Quieres cambiar la fecha ?"))
                {
                    Console.WriteLine("\n\nPor favor, indica los datos de la nueva fecha");

                    fecha1.Año = Tools.CapturaEntero(0, "\n\tDime el año: ", 1900, 2500);
                    fecha1.Mes = Tools.CapturaEntero(0, "\n\tDime el mes: ", 1, 12);
                    fecha1.Dia = Tools.CapturaEntero(0, "\n\tDime el dia: ", 1, 31);

                    Console.WriteLine("\n\tLa nueva fecha es:\t" + fecha1.FechaStringTexto);
                }

                diasAvance = Tools.CapturaEntero(0, "\n\t¿ Número de días a avanzar ? (pulse 0 para salir): ", 0, 2500);

                for (int i = 0; i < diasAvance; i++)
                {
                    fecha1.AvanzaDia();
                }

                Console.WriteLine("\n\tLa nueva fecha es:\t" + fecha1.FechaStringTexto);

            } while (diasAvance != 0);

            Tools.StopProgram();
        }

    }
}