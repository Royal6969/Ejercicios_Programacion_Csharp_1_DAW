using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Threading;

namespace P13d_Menu_1_ReadKey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n\n\n\n");
            Console.WriteLine("\t\t\t╔═════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t║             MENU                        ║");
            Console.WriteLine("\t\t\t╠═════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t║                                         ║");
            Console.WriteLine("\t\t\t║    1.- Perímetro y Área del Círculo     ║");
            Console.WriteLine("\t\t\t║    2.- Desglosa Euros                   ║");
            Console.WriteLine("\t\t\t║    3.- Presentar Fecha                  ║");
            Console.WriteLine("\t\t\t║    4.- Presentar Día de la Semana       ║");
            Console.WriteLine("\t\t\t║                                         ║");
            Console.WriteLine("\t\t\t║          0) Salir                       ║");
            Console.WriteLine("\t\t\t║                                         ║");
            Console.WriteLine("\t\t\t╚═════════════════════════════════════════╝");
            Thread.Sleep(1500);
            Console.Write("\n\nIntroduce una opción: \t");

            char option = Console.ReadKey().KeyChar;

            if (option == '0' || option == '1' || option == '2' || option == '3' || option == '4')
            {
                Console.Clear();
                Thread.Sleep(1500);

                switch (option)
                {
                    case '0':
                        Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Salir""");
                        Console.Write("\n\nMuchas gracias por utilizar nuestro programa");
                        break;

                    //case 1:
                    case '1':
                        Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Perímetro y Área del Círculo""");

                        Console.Write("\n\nThis program will calculate the longitude and area for a circle\n\n");

                        Console.Write("Write the radius of the circle: \t");
                        double radius = Convert.ToDouble(Console.ReadLine());

                        const double PI = 3.141592;

                        double longitude = 2 * radius * PI;
                        Console.Write("\nThe longitude for the circle is: \t2 x " + radius + " x " + PI + " = \t" + longitude);

                        double area = 3.14 * (radius * radius);
                        Console.Write("\nThe area for the circle is: \t\t3,14 x (" + radius + " x " + radius + ") = \t" + area);

                        break;

                    //case 2:
                    case '2':
                        Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Desglosa Euros""");

                        Console.Write("\n\nThis program will separate a total amount in 20€, 5€ and 1€ coins\n");

                        Thread.Sleep(1250);
                        Console.Write("\nWrite the amount (€) without cents\t");
                        int total = Convert.ToInt32(Console.ReadLine());

                        int billetes20 = total / 20;
                        int restoBilletes20 = total % 20;

                        int billetes5 = restoBilletes20 / 5;
                        int restoBilletes5 = restoBilletes20 % 5;

                        Console.Write(total + " euros son ");

                        Thread.Sleep(1500);
                        if (billetes20 > 1)
                        {
                            Console.Write(billetes20 + " billetes de 20 euros");
                        }
                        else if (billetes20 == 1)
                        {
                            Console.Write(billetes20 + " billete de 20 euros");
                        }

                        Thread.Sleep(1500);
                        if (billetes5 >= 1 && billetes20 >= 0)
                        {
                            Console.Write(", " + billetes5 + " billetes de 5 euros");

                        }
                        else if (billetes5 == 0 && billetes20 >= 1)
                        {
                            Console.Write(", y ");
                        }

                        Thread.Sleep(1500);
                        if (restoBilletes5 >= 1 && billetes5 >= 1)
                        {
                            Console.Write(", y " + restoBilletes5 + " monedas de 1 euro.");
                        }

                        else if (restoBilletes5 == 0 && billetes5 >= 1)
                        {
                            Console.Write(".");
                        }
                        else if (billetes20 == 0 && billetes5 == 0 && restoBilletes5 >= 0)
                        {
                            Console.Write(restoBilletes5 + " monedas de 1 euro");
                        }
                        else if (billetes20 == 0 && billetes5 == 0 && restoBilletes5 == 1)
                        {
                            Console.Write("Solo hay 1 moneda de un euro.");
                        }

                        break;

                    //case 3:
                    case '3':
                        Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Presentar Fecha""");

                        int año, mes, dia;

                        Console.Write("\nIntroduzca el año: \t");
                        año = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nIntroduzca el mes: \t");
                        mes = Convert.ToInt32(Console.ReadLine());

                        if (mes > 0 && mes < 13)
                        {
                            Console.Write("\nIntroduzca el día: \t");
                            dia = Convert.ToInt32(Console.ReadLine());

                            Console.Clear();
                            Thread.Sleep(1250);

                            if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
                            {
                                if (dia > 30 || dia < 0)
                                {
                                    Console.Write("\nError. Día fuera de rango, porque este mes sólo tiene 30 días");
                                }
                                else
                                {
                                    switch (mes)
                                    {
                                        case 4:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Abril del " + año);
                                            break;

                                        case 6:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Junio del " + año);
                                            break;

                                        case 9:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Septiembre del " + año);
                                            break;

                                        case 11:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Noviembre del " + año);
                                            break;

                                    }
                                }
                            }
                            else if (mes == 2)
                            {
                                if (dia > 28 || dia < 0)
                                {
                                    Console.Write("\nError. Día fuera de rango, porque Febrero sólo tiene 28 días");
                                }
                                else
                                {
                                    Console.Write("\nLa fecha introducida es: \t" + dia + " de Febrero del " + año);
                                }
                            }
                            else if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                            {
                                if (dia > 31 || dia < 0)
                                {
                                    Console.Write("\nError. Día fuera de rango, porque este mes sólo tiene 31 días");
                                }
                                else
                                {
                                    switch (mes)
                                    {
                                        case 1:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Enero del " + año);
                                            break;

                                        case 3:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Marzo del " + año);
                                            break;

                                        case 5:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Mayo del " + año);
                                            break;

                                        case 7:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Julio del " + año);
                                            break;

                                        case 8:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Agosto del " + año);
                                            break;

                                        case 10:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Octubre del " + año);
                                            break;

                                        case 12:
                                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Diciembre del " + año);
                                            break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.Write("\n\nError. Mes fuera de rango");
                        }

                        break;

                    //case 4:
                    case '4':
                        Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Presentar Día de la Semana""\n\n");

                        Console.Write("\n\n0. Domingo");
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

                        Thread.Sleep(1500);
                        Console.Write("\n\n¿Cuántos días desea avanzar?: \t");
                        double numDias = Convert.ToDouble(Console.ReadLine());

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
                        break;
                }

            } else
            {
                Thread.Sleep(1500);
                Console.Write("\n\nError. la opción nº " + option + " no existe en el menú.");
                Console.Write("\n\nPor favor, reinicie el programa y vuelva a intentarlo");
            }
            
            Thread.Sleep(1500);
            Console.Write("\n\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
