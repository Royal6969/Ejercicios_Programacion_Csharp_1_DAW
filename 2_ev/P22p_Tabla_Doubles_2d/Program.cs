/*
Tabla Doubles 2d:

Construir una tabla de 9 x 7 (supóngase 9 filas y 7 columnas) 
y cargarla con valores double aleatorios entre 10.0 y 99.9, 
es decir, valores con un máximo de un decimal. 

Para ello Construir el método CargaTabla.

El método MostrarValores muestra los valores de la tabla 
indicando en las cabeceras el número de fila y de columna de la tabla. 
Para ello, este método llamará a otro ColocaValor 
que recibirá la fila y la columna de la tabla 
y colocará el valor de dicha posición en su lugar correspondiente en la pantalla.

Avanzado:

Luego pregunta si quiere cambiar algún valor y, si responde que sí, 
pide fila, columna (con CapturaEntero) y valor (con CapturaDouble). 
Una vez introducido cambiará el valor en la tabla y en la pantalla (en blanco sobre rojo).
Esto se repite hasta que responda que no quiere modificar.

Sugerencia: hacer el método PreguntaSiNo, que recibe el texto de la pregunta y devuelve true si pulsas ‘s’ o ‘S’ o false si pulsas ‘n’ o ‘N’.
*/

using System;
using System.Threading;

namespace P23d_Tabla_Doubles_2d
{
    class Program
    {
        const int FILAPREGUNTA = 22; // <-- Fila donde voy a pedir los datos
        const int FILASTABLA = 9, COLUMNASTABLA = 7;

        static void Main(string[] args)
        {
            double[,] tabDoubles = new double[9, 7];

            tabDoubles = CargarTabDoubles(tabDoubles);
            MostrarTabDoubles(tabDoubles);

            bool continuar;
            int fila, columna;
            double valor;

            do
            {
                Console.SetCursorPosition(0, 22);
                string pregunta = "¿Desea cambiar algún valor? Pulse [s] para SÍ, o pulse [n] para NO:\t";
                continuar = PreguntaSiNo(pregunta);

                if (continuar == true)
                {
                    Console.SetCursorPosition(0, 22);
                    pregunta = "Por favor, introduzca el número de la fila:\t                                                         ";
                    fila = CapturaFila();

                    Console.SetCursorPosition(0, 22);
                    pregunta = "Por favor, introduzca el número de la columna:\t                                                      ";
                    columna = CapturaColumna();

                    Console.SetCursorPosition(0, 22);
                    pregunta = "Por favor, introduzca el valor decimal                                                                ";
                    valor = CapturaValor();

                    Console.Clear();
                    MostrarTabDoubles_v2(tabDoubles, fila, columna, valor);
                }

            } while (continuar);

            PararPrograma();
        }

        /********************************************* MÉTODOS ****************************************/



        public static double[,] CargarTabDoubles(double[,] tabDoubles)
        {
            Random random = new Random();

            for (int i = 0; i < tabDoubles.GetLength(0); i++)
            {
                for (int j = 0; j < tabDoubles.GetLength(1); j++)
                {
                    tabDoubles[i, j] = Math.Round((random.Next(100, 1000) * 0.1), 1);
                }
            }

            return tabDoubles;
        }

        public static void MostrarTabDoubles(double[,] tabDoubles)
        {
            Console.ForegroundColor = ConsoleColor.Green; // Pontamos en verde las cabeceras de las filas y las columnas
            Console.WriteLine("\n\n\t   c0\t   c1\t   c2\t   c3\t   c4\t   c5\t   c6\n");

            for (int ft = 0; ft < FILASTABLA; ft++)
            {
                Console.WriteLine("  f{0} -->\n", ft);
            }

            // Mostramos los datos en amarillo
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int ft = 0; ft < FILASTABLA; ft++)
            {
                for (int ct = 0; ct < COLUMNASTABLA; ct++)
                {
                    ColocaElNumero(tabDoubles, ft, ct);
                }
            }

        }

        public static void MostrarTabDoubles_v2(double[,] tabDoubles, int fila, int columna, double valor)
        {
            Console.ForegroundColor = ConsoleColor.Green; // Pontamos en verde las cabeceras de las filas y las columnas
            Console.WriteLine("\n\n\t   c0\t   c1\t   c2\t   c3\t   c4\t   c5\t   c6\n");

            for (int ft = 0; ft < FILASTABLA; ft++)
            {
                Console.WriteLine("  f{0} -->\n", ft);
            }

            // Mostramos los datos en amarillo
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int ft = 0; ft < FILASTABLA; ft++)
            {
                for (int ct = 0; ct < COLUMNASTABLA; ct++)
                {
                    ColocaElNumero(tabDoubles, ft, ct);

                    if (fila == ft)
                    {
                        if (columna == ct)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;

                            ColocaElNumero_v2(tabDoubles, fila, columna, valor);
                        }
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ColocaElNumero(double[,] tabDoubles, int ft, int ct)
        {
            int filaPantalla, columnaPantalla; // <-- fila y columna de la pantalla

            columnaPantalla = 10 + 8 * ct;// columna de la pantalla en función de la columna de la tabla
            filaPantalla = 4 + 2 * ft; // fila de la pantalla en función de la fila de la tabla

            Console.SetCursorPosition(columnaPantalla, filaPantalla);
            Console.Write(tabDoubles[ft, ct]);
        }

        static void ColocaElNumero_v2(double[,] tabDoubles, int fila, int columna, double valor)
        {
            int filaPantalla, columnaPantalla; // <-- fila y columna de la pantalla

            filaPantalla = 4 + 2 * fila; // fila de la pantalla en función de la fila de la tabla
            columnaPantalla = 10 + 8 * columna;// columna de la pantalla en función de la columna de la tabla

            Console.SetCursorPosition(columnaPantalla, filaPantalla);
            Console.Write("    ");
            Console.SetCursorPosition(columnaPantalla, filaPantalla);
            Console.Write(valor);
        }

        public static int CapturaFila()
        {
            int fila;
            bool filaOk;

            do
            {
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Introduzca el número de la fila:\t                                                              ");
                Console.SetCursorPosition(40, 22);
                filaOk = Int32.TryParse(Console.ReadLine(), out fila);

                if (!filaOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico                                                             ");
                }
                else if (fila < 0 || fila > 8)
                {
                    Console.Write("\n\nError. El número introducido no corresponde a ninguna de las filas                                                            ");
                    filaOk = false;
                }

            } while (!filaOk);

            return fila;
        }

        public static int CapturaColumna()
        {
            int columna;
            bool columnaOk;

            do
            {
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Introduzca el número de la columna:\t                                                      ");
                Console.SetCursorPosition(40, 22);
                columnaOk = Int32.TryParse(Console.ReadLine(), out columna);

                if (!columnaOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico                                                   ");
                }
                else if (columna < 0 || columna > 6)
                {
                    Console.Write("\n\nError. El número introducido no corresponde a ninguna de las columnas                                            ");
                    columnaOk = false;
                }

            } while (!columnaOk);

            return columna;
        }

        public static int CapturaEntero()
        {
            int num;
            bool numOk;

            do
            {
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Introduzca un valor entre el [-100, 100] para la casilla seleccionada:\t                                                      ");
                Console.SetCursorPosition(85, 22);
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico                                                               ");
                }
                else if (num <= -100 || num >= 100)
                {
                    Console.Write("\n\nError. El número introducido está fuera del rango [-100, 100]                                                       ");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static double CapturaValor()
        {
            double num;
            bool numOk;

            do
            {
                Console.SetCursorPosition(0, 22);
                Console.WriteLine("Introduzca un valor entre el [-100, 100] para la casilla seleccionada:\t                                                             ");
                Console.SetCursorPosition(85, 22);
                numOk = Double.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor numérico                                                      ");
                }
                else if (num <= -100 || num >= 100)
                {
                    Console.Write("\n\nError. El número introducido está fuera del rango [-100, 100]                                                                                  ");
                    numOk = false;
                }

            } while (!numOk);

            return Math.Round(num, 1);
        }

        public static bool PreguntaSiNo(string pregunta)
        {
            bool continuar = true;
            char letra;
            bool letraOk;

            do
            {
                Console.Write(pregunta);
                letraOk = Char.TryParse(Console.ReadLine(), out letra);

                if (!letraOk)
                {
                    Console.Write("\n\nError. El dato introducido no es un valor alfabético                                                                 ");
                }
                else if ((letra != 's' && letra != 'S') && (letra != 'n' && letra != 'N'))
                {
                    Console.Write("\n\nError. El carácter introducido no es ni una [s] ni una [n]                                                           ");
                    letraOk = false;
                }
                else if (letra == 's' || letra == 'n')
                {
                    letraOk = true;
                }

            } while (!letraOk);

            if (letra == 's' || letra == 'S')
            {
                continuar = true;
            }
            else if (letra == 'n' || letra == 'N')
            {
                continuar = false;
            }

            // Console.Clear();
            return continuar;
        }

        public static void PararPrograma()
        {
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}