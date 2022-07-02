using System;

namespace P20d_Presentar_Fecha_En_Texto
{
    class Program
    {
        static void Main(string[] args)
        {
            capturaEntero();
        }

        /************************************************* MÉTODOS ****************************************************/

        public static void presentarFechaEnTexto(int miles, int centenas, int decenas, int unidades, int mes, int dia)
        {
            if(mes > 0 && mes < 13)
            {
                cleanScreen();
                if(mes == 4 || mes == 6 || mes == 9 || mes == 11)
                {
                    if(dia < 30 || dia > 0)
                    {
                        Console.Write("La fecha introducida en texto es: ");
                        Console.Write(diasEnTexto(dia));
                        Console.Write(mesesEnTexto(mes));
                        Console.Write(milesDelAñoEnTexto(miles));
                        Console.Write(centenasDelAñoEnTexto(centenas));
                        Console.Write(decenasDelAñoEnTexto(decenas));
                        Console.WriteLine(unidadesDelAñoEnTexto(unidades));
                    }
                    else
                    {
                        Console.Write("\nError. Día fuera de rango, porque este mes sólo tiene 30 días");
                    }
                }
                else if(mes == 2)
                {
                    if (dia < 28 || dia > 0)
                    {
                        Console.Write("La fecha introducida en texto es: ");
                        Console.Write(diasEnTexto(dia));
                        Console.Write(mesesEnTexto(mes));
                        Console.Write(milesDelAñoEnTexto(miles));
                        Console.Write(centenasDelAñoEnTexto(centenas));
                        Console.Write(decenasDelAñoEnTexto(decenas));
                        Console.WriteLine(unidadesDelAñoEnTexto(unidades));
                    }
                    else
                    {
                        Console.Write("\nError. Día fuera de rango, porque Febrero sólo tiene 28 días");
                    }
                }else if(mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                {
                    if (dia < 31 || dia > 0)
                    {
                        Console.Write("La fecha introducida en texto es: ");
                        Console.Write(diasEnTexto(dia));
                        Console.Write(mesesEnTexto(mes));
                        Console.Write(milesDelAñoEnTexto(miles));
                        Console.Write(centenasDelAñoEnTexto(centenas));
                        Console.Write(decenasDelAñoEnTexto(decenas));
                        Console.WriteLine(unidadesDelAñoEnTexto(unidades));
                    }
                    else
                    {
                        Console.Write("\nError. Día fuera de rango, porque este mes sólo tiene 31 días");
                    }
                }
            }
            else
            {
                Console.Write("\n\nError. Mes fuera de rango");
            }
            pararPrograma();
        }


        public static string diasEnTexto(int dia)
        {
            switch (dia)
            {
                case 1: return "uno "; break;
                case 2: return "dos "; break;
                case 3: return "tres "; break;
                case 4: return "cuatro "; break;
                case 5: return "cinco "; break;
                case 6: return "seis "; break;
                case 7: return "siete "; break;
                case 8: return "ocho "; break;
                case 9: return "nueve "; break;
                case 10: return "diez "; break;
                case 11: return "once "; break;
                case 12: return "doce "; break;
                case 13: return "trece "; break;
                case 14: return "catorce "; break;
                case 15: return "quince "; break;
                case 16: return "diesciseis "; break;
                case 17: return "diescisiete "; break;
                case 18: return "diescisiocho "; break;
                case 19: return "diescinueve "; break;
                case 20: return "veinte "; break;
                case 21: return "veintiuno "; break;
                case 22: return "veintidos "; break;
                case 23: return "veintitres "; break;
                case 24: return "veinticuatro "; break;
                case 25: return "veinticinco "; break;
                case 26: return "veintiseis "; break;
                case 27: return "veintisiete "; break;
                case 28: return "veintiocho "; break;
                case 29: return "veintinueve "; break;
                case 30: return "treinta "; break;
                case 31: return "treinta y uno "; break;
                default: return " "; break;
            }
        }

        public static string mesesEnTexto(int mes)
        {
            switch (mes)
            {
                case 1: return "de Enero "; break;
                case 2: return "de Febrero "; break;
                case 3: return "de Marzo "; break;
                case 4: return "de Abril "; break;
                case 5: return "de Mayo "; break;
                case 6: return "de Junio "; break;
                case 7: return "de Julio "; break;
                case 8: return "de Agosto "; break;
                case 9: return "de Septiembre "; break;
                case 10: return "de Octubre "; break;
                case 11: return "de Noviembre "; break;
                case 12: return "de Diciembre "; break;
                default: return " "; break;
            }
        }

        public static string milesDelAñoEnTexto(int miles)
        {
            switch (miles)
            {
                case 1000: return "de mil "; break;
                case 2000: return "de dos mil "; break;
                default: return " "; break;
            }
        }

        public static string centenasDelAñoEnTexto(int centenas)
        {
            switch (centenas)
            {
                case 100: return "ciento "; break;
                case 200: return "doscientos "; break;
                case 300: return "trescientos "; break;
                case 400: return "cuatrocientos "; break;
                case 500: return "Quinientos "; break;
                case 600: return "seicientos "; break;
                case 700: return "setecientes "; break;
                case 800: return "ochocientos "; break;
                case 900: return "noviencientos "; break;
                default: return " "; break;
            }
        }

        public static string decenasDelAñoEnTexto(int decenas)
        {
            switch (decenas)
            {
                case 10: return "diez "; break;
                case 20: return "veinte "; break;
                case 30: return "treinta "; break;
                case 40: return "cuarenta "; break;
                case 50: return "cincuenta "; break;
                case 60: return "sesenta "; break;
                case 70: return "setenta "; break;
                case 80: return "ochenta "; break;
                case 90: return "noventa "; break;
                default: return " "; break;
            }
        }

        public static string unidadesDelAñoEnTexto(int unidades)
        {
            switch (unidades)
            {
                case 1: return "u uno "; break;
                case 2: return "y dos "; break;
                case 3: return "y tres "; break;
                case 4: return "y cuatro "; break;
                case 5: return "y cinco "; break;
                case 6: return "y seis "; break;
                case 7: return "y siete "; break;
                case 8: return "y ocho "; break;
                case 9: return "y nueve "; break;
                default: return " "; break;
            }
        }


        public static void capturaEntero()
        {
            //int año;
            int miles, centenas, decenas, unidades;
            int mes;
            int dia;
            bool esUnNumero;

            do
            {
                Console.Write("\n\nPor favor, introduzca el año (miles) de su nacimiento:\t");
                //int año = Convert.ToInt32(Console.ReadLine());
                esUnNumero = Int32.TryParse(Console.ReadLine(), out miles);
                Console.Write("\n\nPor favor, introduzca el año (centenas) de su nacimiento:\t");
                //int año = Convert.ToInt32(Console.ReadLine());
                esUnNumero = Int32.TryParse(Console.ReadLine(), out centenas);
                Console.Write("\n\nPor favor, introduzca el año (decenas) de su nacimiento:\t");
                //int año = Convert.ToInt32(Console.ReadLine());
                esUnNumero = Int32.TryParse(Console.ReadLine(), out decenas);
                Console.Write("\n\nPor favor, introduzca el año (unidades) de su nacimiento:\t");
                //int año = Convert.ToInt32(Console.ReadLine());
                esUnNumero = Int32.TryParse(Console.ReadLine(), out unidades);
                Console.Write("\nPor favor, introduzca el mes de su nacimiento:\t");
                //int mes = Convert.ToInt32(Console.ReadLine());
                esUnNumero = Int32.TryParse(Console.ReadLine(), out mes);
                Console.Write("\nPor favor, introduzca el día de su nacimiento:\t");
                //int dia = Convert.ToInt32(Console.ReadLine());
                esUnNumero = Int32.TryParse(Console.ReadLine(), out dia);

                // Verificamos la cadena de texto introducida por el teclado, a ver si el dato introducido por el usuario es o no un valor numérico, como el que se requiere
                //esUnNumero = Int32.TryParse(Console.ReadLine(), out num);

                if (!esUnNumero) // comprobamos si el dato introducido es o no realmente un valor numérico
                {
                    Console.Write("\n\nError: El dato introducido no es un valor numérico");
                    esUnNumero = false;
                }
                else
                {
                    presentarFechaEnTexto(miles, centenas, decenas, unidades, mes, dia);
                }

            } while (!esUnNumero);
        }

        public static void pararPrograma()
        {
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }

        public static void cleanScreen()
        {
            Console.Clear();
        }
    }
}
