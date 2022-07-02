// Se le pide al usuario que introduzca un número entre 0 y 6, 
// cada uno de los cuales indica el día de la semana en que nos encontramos, 
// siendo [0 Domingo, 1 Lunes, 2 Martes, ... 6 Sábado]. 
// Luego pregunta cuántos días quiere avanzar numDias y el programa calcula, 
// de la forma más eficiente, en qué día de la semana caerá dentro de numDias.

// ahora tenemos que volver a repetir este ejercicio, pero esta vez, usando métodos!

//Resolver la práctica DiaDeLaSemana, partiendo de la solución con el switch (13b),
//ahora utilizando los métodos siguientes:
//MuestraDiasSemana: no recibe nada y presenta la tabla de los días de la semana
//con su índice correspondiente: [0→ Domingo, 1→ Lunes, ... 6→ Sábado].
//CapturaOpcion: Recibe el rango de opciones [0..6]; Devuelve la opción pulsada,
//como un entero, cuando sea correcta. Cuando se pulse un valor incorrecto dará el
//mensaje de error y permitirá volver a elegir.
//NombreDiaSemana Recibe el id (int idDiaSemana) del día de la semana y
//devuelve el nombre del día de la semana a que corresponde.
//ProximoDiaSemana Recibe el id (int idDiaSemana) del día de la semana que
//corresponde a hoy y el número de días que quieres avanzar (int numDias) y
//devuelve el nombre del día de la semana en que caerá dentro de numDias.
//El programa debe funcionar como el original.

using System;
using System.Threading;

namespace P20e_Dia_De_La_Semana_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            PresentarOpcionesDeDias();
            CapturaEntero(); // dentro del CapturaEntero() están los demás métodos para el resto del funcionamiento del programa

            PararPrograma();
        }

        /************************************** MÉTODOS **********************************/
        public static void PresentarOpcionesDeDias()
        {
            Console.Write("\n0. Domingo");
            Console.Write("\n1. Lunes");
            Console.Write("\n2. Martes");
            Console.Write("\n3. Miércoles");
            Console.Write("\n4. Jueves");
            Console.Write("\n5. Viernes");
            Console.Write("\n6. Sábado");
        }

        public static void PresentaDiaElegido(int num)
        {
            switch (num)
            {
                case 0: Console.Write("\nHa introducido el número " + num + ", que corresponde al domingo"); break;
                case 1: Console.Write("\nHa introducido el número " + num + ", que corresponde al lunes"); break;
                case 2: Console.Write("\nHa introducido el número " + num + ", que corresponde al martes"); break;
                case 3: Console.Write("\nHa introducido el número " + num + ", que corresponde al miércoles"); break;
                case 4: Console.Write("\nHa introducido el número " + num + ", que corresponde al jueves"); break;
                case 5: Console.Write("\nHa introducido el número " + num + ", que corresponde al viernes"); break;
                case 6: Console.Write("\nHa introducido el número " + num + ", que corresponde al sábado"); break;
            }
        }

        public static double CuantosDiasDeseaAvanzar()
        {
            Console.Write("\n\n¿Cuántos días desea avanzar?: \t");
            double numDias = Convert.ToDouble(Console.ReadLine());

            return numDias;
        }

        public static double AvanzarDias(int num, double numDias)
        {
            //double contDia = numDias % 7; // si no sumase a los días que el usuario quiere avanzar el día del punto de partida, no daría bien ... lo tomaría siempre como punto de partida el domingo 0
            double contDia = (numDias + num) % 7;

            return contDia;
        }

        public static void PresentarNuevoDia(int num, double numDias, double contDia)
        {
            switch (contDia)
            {

                case 0: //OJO empieza en 0 para el domingo, porque divide entre 7, fijándose en el resto, y ese resto es el día de la semana al que queremos llegar (pero además, al punto de partida también le hemos sumado los días que el usuario quería avanzar) 
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Console.Write("\n\nEl nuevo día al que llegamos es el DOMINGO !!");
                    break;

                case 1:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Console.Write("\n\nEl nuevo día al que llegamos es el LUNES !!");
                    break;

                case 2:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Console.Write("\n\nEl nuevo día al que llegamos es el MARTES !!");
                    break;

                case 3:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Console.Write("\n\nEl nuevo día al que llegamos es el MIÉRCOLES !!");
                    break;

                case 4:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Console.Write("\n\nEl nuevo día al que llegamos es el JUEVES !!");
                    break;

                case 5:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Console.Write("\n\nEl nuevo día al que llegamos es el VIERNES !!");
                    break;

                case 6:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Console.Write("\n\nEl nuevo día al que llegamos es el SÁBADO !!");
                    break;
            }
        }

        public static /*int*/ void CapturaEntero()
        {
            int num; // la declaración de variables puede hacerse mediante inyeccción en los paréntesis de la cabecera del método
            bool esUnNumero;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [0-6]: \t");
                //int año = Convert.ToInt32(Console.ReadLine());
                esUnNumero = Int32.TryParse(Console.ReadLine(), out num);

                // Verificamos la cadena de texto introducida por el teclado, a ver si el dato introducido por el usuario es o no un valor numérico, como el que se requiere
                //esUnNumero = Int32.TryParse(Console.ReadLine(), out num);

                if (!esUnNumero) // comprobamos si el dato introducido es o no realmente un valor numérico
                {
                    Console.Write("\n\nError: El dato introducido no es un valor numérico");
                    esUnNumero = false;
                }
                else if (num < 0 || num > 6)
                {
                    Console.Write("\n\nError: El número introducido no corresponde a ningún día de la semana");
                    esUnNumero = false;
                }
                else
                {
                    CleanScreen();
                    PresentaDiaElegido(num);
                    double numDias = CuantosDiasDeseaAvanzar();
                    double contDia = AvanzarDias(num, numDias);
                    PresentarNuevoDia(num, numDias, contDia);
                }

            } while (!esUnNumero);

            //return num; // no hace falta que devuelva el int num porque como el resto de la ejecución del programa lo hago a través de los métodos que hay a su vez en el else de este mismo método, no se llega nunca a la última instrucción de return
        }

        public static void CleanScreen()
        {
            Console.Clear();
            Thread.Sleep(1500);
        }

        public static void PararPrograma()
        {
            Thread.Sleep(1500);
            Console.Write("\n\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}