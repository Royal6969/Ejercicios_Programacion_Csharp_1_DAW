using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Threading;
//using System.Threading.Tasks;

namespace P13_Presentar_Fecha_0
{
    class Program
    {
        static void Main(string[] args)
        {
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
                
                //OJO, esto podría haberse hecho más corto con la siguiente comprobación, y declarando otra variable para el nombre del mes (en cada elseIf debo escribir el nombre del mes), y sacando la frase final de la fecha fuera del if al final
                // if (dia < 1 || dia > 31 || (dia > 30 && (mes == 4 || mes == 6 || mes == 9 || mes == 11)) || dia > 28 && mes == 2 || dia > 31 && (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)) {

                if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
                {
                    if (dia > 30 || dia < 0)
                    {
                        Console.Write("\nError. Día fuera de rango, porque este mes sólo tiene 30 días");
                    }
                    else
                    {
                        if (mes == 4)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Abril del " + año);
                        } else if (mes == 6)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Junio del " + año);
                        } else if (mes == 9)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Septiembre del " + año);
                        } else if (mes == 11)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Noviembre del " + año);
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
                        if (mes == 1)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Enero del " + año);
                        } else if (mes == 3)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Marzo del " + año);
                        } else if (mes == 5)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Mayo del " + año);
                        } else if (mes == 7)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Julio del " + año);
                        } else if (mes == 8)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Agosto del " + año);
                        } else if (mes == 10)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Octubre del " + año);
                        } else if (mes == 12)
                        {
                            Console.Write("\nLa fecha introducida es: \t" + dia + " de Diciembre del " + año);
                        }
                    }
                }
            }
            else
            {
                Console.Write("\n\nError. Mes fuera de rango");
            }

            Thread.Sleep(1500);
            Console.Write("\n\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
