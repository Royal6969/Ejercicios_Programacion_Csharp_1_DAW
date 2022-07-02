/*
Día de la Semana con vector y métodos:

Se trata de la misma práctica que hemos realizado en varias versiones, la última vez con métodos, 
pero ahora debes resolverla de una forma mucho más simple, utilizando un vector de string con los días de la semana.

Te recuerdo el enunciado:
Resolver la práctica DiaDeLaSemana, utilizando los métodos siguientes:

MuestraDiasSemana: no recibe nada y presenta la tabla de los días de la semana con su índice correspondiente: [0→ Domingo, 1→ Lunes, ... 6→ Sábado].

CapturaOpcion: Recibe el rango de opciones [0..6]; Devuelve la opción pulsada, como un entero, cuando sea correcta.
Cuando se pulse un valor incorrecto dará el mensaje de error y permitirá volver a elegir.

NombreDiaSemana Recibe el id (int idDiaSemana) del día de la semana 
y devuelve el nombre del día de la semana a que corresponde.

ProximoDiaSemana Recibe el id (int idDiaSemana) del día de la semana que corresponde a hoy 
y el número de días que quieres avanzar (int numDias) 
y devuelve el nombre del día de la semana en que caerá dentro de numDias.

El programa debe funcionar como el original.
*/

using System;
using System.Threading;

namespace P22c_Dia_De_La_Semana_Con_Vector_Y_Metodos
{
    class Program
    {
        /******************************************* VARIABLES GLOBALES ****************************************/ 
        static string[] diasSemana = { "Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };

        /*******************************************************************************************************/

        static void Main(string[] args)
        {
            Console.WriteLine("\n");

            MuestraDiasSemana();

            int rangoMin = 0;
            int rangoMax = 6;

            int idDiaSemana = 0;
            idDiaSemana = CapturaEntero(rangoMin, rangoMax);

            string nombreDiaSemana = null;
            nombreDiaSemana = NombreDiaSemana(idDiaSemana);

            PresentarDiaElegido(idDiaSemana, nombreDiaSemana);

            int numDias = 0;
            numDias = CuantosDiasDeseaAvanzar(idDiaSemana);

            int proximoIdDiaSemana = 0;
            proximoIdDiaSemana = ProximoIdDiaSemana(idDiaSemana, numDias);

            Console.Clear();
            Thread.Sleep(500);

            string proximoDiaSemana = null;
            proximoDiaSemana = ProximoDiaSemana(proximoIdDiaSemana);

            PresentarProximoDiaSemana(numDias, idDiaSemana, proximoIdDiaSemana, proximoDiaSemana);

            PararPrograma();
        }

        /************************************************* MÉTODOS **********************************************/

        public static void MuestraDiasSemana()
        {
            for (int i = 0; i < diasSemana.Length; i++)
            {
                Console.WriteLine(i + "-->" + diasSemana[i]);
            }
        }

        public static int CapturaEntero(int min, int max)
        {
            int idDiaSemana;
            bool idDiaSemanaOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [0, 6] para para seleccionar un día del vector diasSemana[]:\t");
                idDiaSemanaOk = Int32.TryParse(Console.ReadLine(), out idDiaSemana);

                if (!idDiaSemanaOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico.");
                }
                else if (idDiaSemana < min)
                {
                    Console.Write("\n\nError. El número no puede ser inferior a " + min + ".");
                    idDiaSemanaOk = false;
                }
                else if (idDiaSemana > 99)
                {
                    Console.Write("\n\nError. El número no puede ser superior a " + max + ".");
                    idDiaSemanaOk = false;
                }

            } while (!idDiaSemanaOk);

            return idDiaSemana;
        }

        public static string NombreDiaSemana(int idDiaSemana)
        {
            string nombreDiaSemana = null;

            for (int i=0; i<diasSemana.Length; i++)
            {
                if (i == idDiaSemana)
                {
                    nombreDiaSemana = diasSemana[i];
                }
            }

            return nombreDiaSemana;
        }

        public static void PresentarDiaElegido(int idDiaSemana, string nombreDiaSemana)
        {
            Console.Write("\n\nHa introducido el número " + idDiaSemana + ", que corresponde al " + nombreDiaSemana + ".");
        }

        public static int CuantosDiasDeseaAvanzar(int idDiaSemana)
        {
            int numDias = 0;

            Console.Write("\n\n¿Cuántos días desea avanzar?: \t");
            numDias = Convert.ToInt32(Console.ReadLine());

            return numDias;
        }

        public static int ProximoIdDiaSemana(int idDiaSemana, int numDias)
        {
            int proximoIdDiaSemana = 0;

            proximoIdDiaSemana = (numDias + idDiaSemana) % 7;

            return proximoIdDiaSemana;
        }

        public static string ProximoDiaSemana(int proximoIdDiaSemana)
        {
            string nuevoDiaSemana = null;

            for (int i=0; i<diasSemana.Length; i++)
            {
                if (i == proximoIdDiaSemana)
                {
                    nuevoDiaSemana = diasSemana[i];
                }
            }

            return nuevoDiaSemana;
        }

        public static void PresentarProximoDiaSemana(int numDias, int idDiaSemana, int proximoIdDiaSemana, string proximoDiaSemana)
        {
            Console.Write("\ndouble contDia = (numDias + idDiaSemana) % 7 = proximoIdDiaSemana");
            Console.Write("\ndouble contDia = (" + numDias + " + " + idDiaSemana + ") % 7 = " + proximoIdDiaSemana);
            Console.Write("\n\nEl nuevo día al que llegamos es el " + proximoDiaSemana + " !!");
        }

        public static void PararPrograma()
        {
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
