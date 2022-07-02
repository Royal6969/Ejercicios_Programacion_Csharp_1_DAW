using System;

namespace P21_Metodos_Entrenamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            char option;

            do
            {
                showMenu();
                option = Console.ReadKey().KeyChar;

                if (option != '0')
                {
                    cleanScreen();

                    switch (option)
                    {
                        case '0':
                            Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Salir""");
                            salirPrograma();
                            pararPrograma();
                            break;

                        case '1':
                            Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Perímetro y Área del Círculo""");
                            Console.Write("\n\nThis program will calculate the longitude and area for a circle");

                            const double PI = 3.141592;

                            Console.Write("\n\nWrite the radius of the circle: \t");
                            double radius = Convert.ToDouble(Console.ReadLine());

                            double longitude = perimetroCirculo(radius, PI);

                            double area = areaCirculo(radius, PI);

                            pararPrograma();
                            break;

                        case '2':

                            Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Desglosa Euros""");

                            Console.Write("\n\nThis program will separate a total amount in 20€, 5€ and 1€ coins\n");

                            Console.Write("\nWrite the amount (€) without cents\t");
                            int total = Convert.ToInt32(Console.ReadLine());

                            desglosaEuros(total);
                            pararPrograma();
                            break;

                        case '3':

                            Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Presentar Fecha""");

                            Console.Write("\n\nPor favor, introduzca el año de su nacimiento:\t");
                            int año = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nPor favor, introduzca el mes de su nacimiento:\t");
                            int mes = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nPor favor, introduzca el día de su nacimiento:\t");
                            int dia = Convert.ToInt32(Console.ReadLine());

                            presentarFecha(año, mes, dia);
                            pararPrograma();
                            break;

                        case '4':

                            Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Presentar Día de la Semana""");

                            Console.Write("\n\n0. Domingo");
                            Console.Write("\n1. Lunes");
                            Console.Write("\n2. Martes");
                            Console.Write("\n3. Miércoles");
                            Console.Write("\n4. Jueves");
                            Console.Write("\n5. Viernes");
                            Console.Write("\n6. Sábado");
                            Console.Write("\n\nIntroduzca un número entre el [0-6]: \t");

                            int num = Convert.ToInt32(Console.ReadLine());

                            presentarDiaDeLaSemana(num);
                            pararPrograma();
                            break;

                        case '5':

                            Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""Media entre tres números""");

                            Console.Write("\n\n1. Introduzca el primer número:\t");
                            double num1 = Convert.ToDouble(Console.ReadLine());
                            Console.Write("\n2. Introduzca el segundo número:\t");
                            double num2 = Convert.ToDouble(Console.ReadLine());
                            Console.Write("\n3. Introduzca el tercer número:\t");
                            double num3 = Convert.ToDouble(Console.ReadLine());

                            double suma = 0;
                            suma = sumaNumeros(num1, num2, num3, suma);
                            Console.Write("\nLa suma de todos los números es:\t" + suma);

                            double media = 0;
                            media = mediaNumeros(suma, media);
                            Console.Write("\nLa media de los tres números es:\t" + media);

                            pararPrograma();
                            break;

                        case '6':
                            Console.Write("\n\nHa elegido la opción nº: \t" + option + @": ""¿Es Mayor de Edad?""");

                            Console.Write("\n\nPor favor, introduzca su edad actual:\t");
                            int edad = Convert.ToInt32(Console.ReadLine());
                            bool mayorDeEdad = false;

                            mayorDeEdad = esMayorDeEdad(edad, mayorDeEdad);
                            confirmacionEdad(edad, mayorDeEdad);

                            pararPrograma();
                            break;

                        default:
                            Console.Write("\n\nError. la opción nº " + option + " no existe en el menú.");
                            reiniciarPrograma();
                            break;
                    }

                }

            } while (option != '0');


        }
        /********************************** MÉTODOS CASE '0' *********************************/
        public static void salirPrograma()
        {
            Console.Write("\n\nMuchas gracias por utilizar nuestro programa");
        }
        /********************************** MÉTODOS CASE '1' *********************************/
        public static double perimetroCirculo(double radius, double PI)
        {
            double longitude = 2 * radius * PI;
            Console.Write("\nThe longitude for the circle is: \t2 x " + radius + " x " + PI + " = \t" + longitude);

            return longitude;
        }

        public static double areaCirculo(double radius, double PI)
        {
            double area = 3.14 * (radius * radius);
            Console.Write("\nThe area for the circle is: \t\t3,14 x (" + radius + " x " + radius + ") = \t" + area);

            return area;
        }

        public static void pararPrograma()
        {
            Console.Write("\n\nPress any key to exit.");
            Console.ReadLine();
        }
        /********************************** MÉTODOS CASE '2' *********************************/
        public static void desglosaEuros(int total)
        {
            int billetes20 = total / 20;
            int restoBilletes20 = total % 20;

            int billetes5 = restoBilletes20 / 5;
            int restoBilletes5 = restoBilletes20 % 5;

            Console.Write(total + " euros son ");

            if (billetes20 > 1)
            {
                Console.Write(billetes20 + " billetes de 20 euros");
            }
            else if (billetes20 == 1)
            {
                Console.Write(billetes20 + " billete de 20 euros");
            }

            if (billetes5 >= 1 && billetes20 >= 0)
            {
                Console.Write(", " + billetes5 + " billetes de 5 euros");

            }
            else if (billetes5 == 0 && billetes20 >= 1)
            {
                Console.Write(", y ");
            }

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
        }
        /********************************** MÉTODOS CASE '3' *********************************/
        public static void presentarFecha(int año, int mes, int dia)
        {
            if (mes > 0 && mes < 13)
            {
                cleanScreen();

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
        }
        /********************************** MÉTODOS CASE '4' *********************************/
        public static void presentarDiaDeLaSemana(int num)
        {
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

            Console.Write("\n\n¿Cuántos días desea avanzar?: \t");
            double numDias = Convert.ToDouble(Console.ReadLine());

            double contDia = (numDias + num) % 7;

            cleanScreen();
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

                    Console.Write("\n\n\nPress any key to come back to menu.");
                    Console.ReadLine();

                    break;
            }
        }
        /********************************** MÉTODOS CASE '5' *********************************/
        public static double sumaNumeros(double num1, double num2, double num3, double suma)
        {
            suma = num1 + num2 + num3;

            return suma;
        }
        public static double mediaNumeros(double suma, double media)
        {
            media = suma / 3;

            return media;
        }
        /********************************** MÉTODOS CASE '6' *********************************/
        public static bool esMayorDeEdad(int edad, bool mayorDeEdad)
        {
            //if (edad >= 18)
            //{
            //    mayorDeEdad = true;
            //}
            //else
            //{
            //    mayorDeEdad = false;
            //}

            //return mayorDeEdad;

            return (edad > 17); // esta sería otra forma de trasladar el true/false al boolean, reduciendo código
        }
        public static void confirmacionEdad(int edad, bool mayorDeEdad)
        {
            //if (mayorDeEdad == true)
            if (mayorDeEdad)
            {
                Console.Write("\n\nYa tienes " + edad + ", así que ya eres mayor de edad!");
            }
            else
            {
                Console.Write("\n\nAún no eres mayor de edad... te quedan " + (18 - edad) + " años para cumplir los 18!");
            }
        }
        /*********************************************************************************/
        public static void showMenu()
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
            Console.WriteLine("\t\t\t║    5.- Media entre tres números         ║");
            Console.WriteLine("\t\t\t║    6.- ¿Es mayor de edad?               ║");
            Console.WriteLine("\t\t\t║                                         ║");
            Console.WriteLine("\t\t\t║          0) Salir                       ║");
            Console.WriteLine("\t\t\t║                                         ║");
            Console.WriteLine("\t\t\t╚═════════════════════════════════════════╝");
            Console.Write("\n\nIntroduce una opción: \t");
        }
        public static void reiniciarPrograma()
        {
            Console.Write("\n\nPor favor, reinicie el programa y vuelva a intentarlo");
        }
        public static void cleanScreen()
        {
            Console.Clear();
        }
    }
}