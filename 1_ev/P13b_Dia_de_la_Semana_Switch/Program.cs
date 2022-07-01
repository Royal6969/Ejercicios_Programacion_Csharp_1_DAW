// Se le pide al usuario que introduzca un número entre 0 y 6, 
// cada uno de los cuales indica el día de la semana en que nos encontramos, 
// siendo [0 Domingo, 1 Lunes, 2 Martes, ... 6 Sábado]. 
// Luego pregunta cuántos días quiere avanzar numDias y el programa calcula, 
// de la forma más eficiente, en qué día de la semana caerá dentro de numDias.

using System;
using System.Threading;

namespace P13b_Dia_de_la_Semana_Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n0. Domingo");
            Console.Write("\n1. Lunes");
            Console.Write("\n2. Martes");
            Console.Write("\n3. Miércoles");
            Console.Write("\n4. Jueves");
            Console.Write("\n5. Viernes");
            Console.Write("\n6. Sábado");
            Thread.Sleep(1500);
            Console.Write("\n\nIntroduzca un número entre el [0-6]: \t");

            int num = Convert.ToInt32(Console.ReadLine());

            Thread.Sleep(1500);
            switch (num)
            {
                case 0:
                    Console.Write("\nHa introducido el número " + num + ", que corresponde al domingo");
                    break;

                case 1:
                    Console.Write("\nHa introducido el número " + num + ", que corresponde al lunes");
                    break;

                case 2:
                    Console.Write("\nHa introducido el número " + num + ", que corresponde al martes");
                    break;

                case 3:
                    Console.Write("\nHa introducido el número " + num + ", que corresponde al miércoles");
                    break;

                case 4:
                    Console.Write("\nHa introducido el número " + num + ", que corresponde al jueves");
                    break;

                case 5:
                    Console.Write("\nHa introducido el número " + num + ", que corresponde al viernes");
                    break;

                case 6:
                    Console.Write("\nHa introducido el número " + num + ", que corresponde al sábado");
                    break;
            }
            //if (num == 0)
            //{
            //    Console.Write("\nHa introducido el número " + num + ", que corresponde al domingo");
            //}
            //else if (num == 1)
            //{
            //    Console.Write("\nHa introducido el número " + num + ", que corresponde al lunes");
            //}
            //else if (num == 2)
            //{
            //    Console.Write("\nHa introducido el número " + num + ", que corresponde al martes");
            //}
            //else if (num == 3)
            //{
            //    Console.Write("\nHa introducido el número " + num + ", que corresponde al miércoles");
            //}
            //else if (num == 4)
            //{
            //    Console.Write("\nHa introducido el número " + num + ", que corresponde al jueves");
            //}
            //else if (num == 5)
            //{
            //    Console.Write("\nHa introducido el número " + num + ", que corresponde al viernes");
            //}
            //else if (num == 6)
            //{
            //    Console.Write("\nHa introducido el número " + num + ", que corresponde al sábado");
            //}

            Thread.Sleep(1500);
            // Console.Write("\n\nEl número "+num+" corresponde al "+dia);
            Console.Write("\n\n¿Cuántos días desea avanzar?: \t");
            double numDias = Convert.ToDouble(Console.ReadLine());

            //double contDia = numDias % 7; // si no sumase a los días que el usuario quiere avanzar el día del punto de partida, no daría bien ... lo tomaría siempre como punto de partida el domingo 0
            double contDia = (numDias + num) % 7;

            Console.Clear();
            Thread.Sleep(1500);
            switch (contDia)
            {

                case 0: //OJO empieza en 0 para el domingo, porque divide entre 7, fijándose en el resto, y ese resto es el día de la semana al que queremos llegar (pero además, al punto de partida también le hemos sumado los días que el usuario quería avanzar) 
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Thread.Sleep(1500);
                    Console.Write("\n\nEl nuevo día al que llegamos es el DOMINGO !!");
                    break;

                case 1:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Thread.Sleep(1500);
                    Console.Write("\n\nEl nuevo día al que llegamos es el LUNES !!");
                    break;

                case 2:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Thread.Sleep(1500);
                    Console.Write("\n\nEl nuevo día al que llegamos es el MARTES !!");
                    break;

                case 3:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Thread.Sleep(1500);
                    Console.Write("\n\nEl nuevo día al que llegamos es el MIÉRCOLES !!");
                    break;

                case 4:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Thread.Sleep(1500);
                    Console.Write("\n\nEl nuevo día al que llegamos es el JUEVES !!");
                    break;

                case 5:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Thread.Sleep(1500);
                    Console.Write("\n\nEl nuevo día al que llegamos es el VIERNES !!");
                    break;

                case 6:
                    Console.Write("\ndouble contDia = (numDias + num) % 7 = contDia");
                    Console.Write("\ndouble contDia = (" + numDias + " + " + num + ") % 7 = " + contDia);
                    Thread.Sleep(1500);
                    Console.Write("\n\nEl nuevo día al que llegamos es el SÁBADO !!");
                    break;
            }
            Thread.Sleep(1650);
            Console.Write("\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}