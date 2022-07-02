﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace P51_CRUD_Pacientes_Con_Diccionarios
{
    class Tools
    {
        Random random = new Random();

        public static float GenerarNota(Random random)
        {
            //Random random = new Random(); // AQUI NOO
            // float nota = float.Parse(random.Next(3, 10).ToString("0.00"));
            // float nota = random.Next(300, 1000) / 100F; // vProfesor // para dos decimales
            float nota = random.Next(30, 100) / 10F; // vProfesor // para un decimal

            return nota;
        }

        public static float GenerarId(Random random) // es una copia del de GenerarNota() solo que cambiando el nombre
        {
            float nota = random.Next(1, 999) / 10F; // vProfesor // para un decimal

            return nota;
        }

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += "                                                                                                                                           ";

            return texto.Substring(0, nCaracteres);
        }

	public static string CuadraUnidad(int unidad)
        {
            if (unidad < 10)
            {
                return ("  " + unidad).ToString();
            }
            else if (unidad < 100)
            {
                return (" " + unidad).ToString();
            }
            else
            {
                return unidad.ToString();
            }
        }

        public static string CuadraPeso(float peso)
        {
            if (peso < 10)
            {
                return ("  " + peso).ToString();
            }
            else if (peso < 100)
            {
                return (" " + peso).ToString();
            }
            else
            {
                return peso.ToString();
            }
        }

        public static bool PreguntaSiNo(string pregunta)
        {
            char tecla;

            do
            {
                // Hacemos la pregunta
                Console.Write("\n\n\t{0} (s=Sí; n=No): ", pregunta);
                // Capturamos la respuesta (una pulsación)
                tecla = (Console.ReadKey()).KeyChar;
                if (tecla == 's' || tecla == 'S')
                    return true;
                if (tecla == 'n' || tecla == 'N')
                    return false;
                // Si llega aquí es que no ha pulsado ninguna de las teclas correctas
                Console.Write("\n\n\t** Error: por favor, responde S o N **");

            } while (true);
        }

        public static void BackToMenu(int opcion)
        {
            if (opcion > 0)
            {
                Console.WriteLine("\n\n\n\tPress any key to back to menú.");
                Console.ReadKey(true);
            } 
            else if (opcion == 0)
            {
                Console.WriteLine("\n\tPulse una tecla para salir.");
                Console.ReadKey(true);
            }
            
        }

        public static void StopProgram()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\tMuchas gracias por utilizar nuestro programa.");
            Thread.Sleep(1785);
        }

        #region CapturaEnteros
        public static string CapturaNombre()
        {
            string nombre = string.Empty;
            bool nombreOk = false;

            do
            {
                Console.Write("\n\n\tIntroduzca un nombre:\t");
                nombre = Convert.ToString(Console.ReadLine());

                if (nombre.Contains('0') || nombre.Contains('1') || nombre.Contains('2') || nombre.Contains('3') || nombre.Contains('4') || nombre.Contains('5') || nombre.Contains('6') || nombre.Contains('7') || nombre.Contains('8') || nombre.Contains('9'))
                {

                    Console.Write("\n\n\t**** Error. No puedes introducir números en un nombre.");
                    nombreOk = false;
                }
                else if (nombre == "")
                {
                    Console.Write("\n\n\t**** Error. No puedes introducir un nombre vacío.");
                    nombreOk = false;
                }
                else
                {
                    nombreOk = true;
                }

            } while (!nombreOk);

            return nombre;
        }

        public static Fecha CapturaFechaNac() // método rápido para salir del paso... esto ya lo hicimos más completo y eficiente en la 1º evaluación !!
        {
            Fecha fechaNac = new Fecha();
            int dia = 0;
            int mes = 0; 
            int año = 0;
            bool diaOk = false;
            bool mesOk = false; 
            bool añoOk = false;

            do
            {
                Console.Clear();

                do
                {
                    Console.Write("\n\n\tIntroduzca el día de nacimiento:\t");
                    diaOk = Int32.TryParse(Console.ReadLine(), out dia);

                    if (!diaOk)
                    {
                        Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                    }
                    else if (dia < 0 || dia > 31)
                    {
                        Console.Write("\n\n\tError. El mes tiene 31 días.");
                        diaOk = false;
                    }
                    else
                    {
                        diaOk = true;
                    }
                } while (!diaOk);

                do
                {
                    Console.Write("\n\n\tIntroduzca el mes de nacimiento:\t");
                    mesOk = Int32.TryParse(Console.ReadLine(), out mes);

                    if (!mesOk)
                    {
                        Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                    }
                    else if (mes < 0 || mes > 12)
                    {
                        Console.Write("\n\n\tError. El año tiene 12 meses.");
                        mesOk = false;
                    }
                    else
                    {
                        mesOk = true;
                    }
                } while (!mesOk);


                if ((mes == 2 || mes == 4 || mes == 6 || mes == 9 || mes == 11) && (dia == 31))
                {
                    Console.Write("\n\n\tError. Ese mes tienes sólo 30 días.");
                    diaOk = false;
                    mesOk = false;
                }
                else if (mes == 2 && dia > 28)
                {
                    Console.Write("\n\n\tError. Febrero tienes sólo 28 días.");
                    diaOk = false;
                    mesOk = false;
                }
                else
                {
                    diaOk = true;
                    mesOk = true;
                }

                if (diaOk && mesOk)
                {
                    do
                    {
                        Console.Write("\n\n\tIntroduzca el año de nacimiento:\t");
                        añoOk = Int32.TryParse(Console.ReadLine(), out año);

                        if (!añoOk)
                        {
                            Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                        }
                        else if (año < 1900)
                        {
                            Console.Write("\n\n\tError. ¿Seguro que nació hace tanto tiempo?.");
                            añoOk = false;
                        }
                        else if (año > fechaNac.Año)
                        {
                            Console.Write("\n\n\tError. Año introducido superior al actual.");
                            añoOk = false;
                        }
                        else
                        {
                            añoOk = true;
                        }
                    } while (!añoOk);
                }

            } while (!diaOk || !mesOk);

            fechaNac = new Fecha(dia, mes, año);

            return fechaNac;
        }

        public static int CapturaTelefonoEsp()
        {

            int num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\n\tIntroduzca un teléfono:\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                }
                else if (num < 100000000 || num > 999999999) // el nº de tlfn en España es de 9 cifras 
                {
                    Console.Write("\n\n\tError. El teléfono tiene que tener 6 cifras.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static int CapturaEntero_Normal(string pregunta, int min, int max)
        {

            int num = 0;
            bool numOk;

            do
            {
                //Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                Console.Write(pregunta + "\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                    //Error_Pro("Error. El dato introducido no es un valor numérico.", 24, 5);
                    //Error_vProfesor2("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    //Error_Pro("Error. Esa opción no se encuentra en el menú.", 24, 5);
                    //Error_vProfesor2("Error. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static int CapturaEntero_vProfesor(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                //Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                Console.Write("\n\n\t\t\t\t\t" + pregunta + ":\t");
                num = Console.ReadKey().KeyChar - '0';

                if (num < (char)0 || num > (char)9)
                {
                    Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                    numOk = false;
                }
                else if (num < min || num > max)
                {
                    Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }
                else
                {
                    numOk = true;
                }

            } while (!numOk);

            return num;
        }


        public static int CapturaEntero(int posScreen, string pregunta, int min, int max)
        {

            int num = 0;
            bool numOk;

            do
            {
                //Console.SetCursorPosition(posScreen, 2);
                //Console.Write("                                                 ");
                //Console.SetCursorPosition(posScreen, 2);
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    //Console.SetCursorPosition(posScreen, 4);
                    //Console.Write("                                             ");
                    //Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    //Console.SetCursorPosition(posScreen, 4);
                    //Console.Write("                                             ");
                    //Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static int CapturaEntero_Default(string pregunta, int min, int max, int defaultValue)
        {
            int num = 0;
            bool numOk;
            string aux = string.Empty;
            int posX;
            int posY;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                posX = Console.CursorLeft;
                posY = Console.CursorTop;
                aux = Console.ReadLine();
                numOk = Int32.TryParse(aux, out num);

                if (!numOk && aux != "")
                {
                    Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                }
                else if (!numOk && aux == "")
                {
                    Console.SetCursorPosition(posX, posY);
                    Console.WriteLine(defaultValue);
                }
                else if (num < min || num > max)
                {
                    Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk && aux != "");

            if (aux == "")
            {
                num = defaultValue;
            }

            return num;
        }

        public static int CapturaEntero(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;
            string aux = string.Empty;

            do
            {
                Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + "(escriba [fin] para terminar):\t");

                aux = Console.ReadLine().ToLower();
                numOk = Int32.TryParse(aux, out num);

                if (!numOk && aux != "fin")
                {
                    Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("\n\n\tError. Número introducido fuera de rango.");
                    numOk = false;
                }

            } while (!numOk && aux != "fin");

            return num;
        }

        public static int CapturaEntero_Limpiando_v1(string pregunta, int min, int max)
        {

            int num = 0;
            bool numOk;

            do
            {
                RowCleaner(20);
                Console.SetCursorPosition(10, 20);
                Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);
                RowCleaner(20);

                if (!numOk)
                {
                    //Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                    Error_vProfesor2("El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    //Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    Error_vProfesor2("Opción fuera del rango permitido.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static int CapturaEntero_Limpiando_v2(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                RowCleaner(0);
                Console.SetCursorPosition(10, 0);
                Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                num = Console.ReadKey(true).KeyChar - '0';

                if (num < (char)0 || num > (char)9)
                {
                    //Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                    Error_vProfesor2("El dato introducido no es un valor numérico.");
                    numOk = false;
                }
                else if (num < min || num > max)
                {
                    //Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    Error_vProfesor2("Esa opción no se encuentra en el menú.");
                    numOk = false;
                }
                else
                {
                    numOk = true;
                }

            } while (!numOk);

            return num;
        }

        public static float CapturaFloat(string pregunta, int min, int max)
        {

            float num = 0;
            bool numOk;

            do
            {
                //Console.Write("\n\n\tIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                Console.Write("\n\n\t" + pregunta + ":\t");
                numOk = Single.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("\n\n\tError. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("\n\n\tError. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////////

        /*
        public static void ShowMenu()
        {
            Console.WriteLine("\n\n\n\n\n\n\t\t\t╔════════════════════════════╗");
            Console.WriteLine("\t\t\t║ Opciones del Piloto        ║");
            Console.WriteLine("\t\t\t╠════════════════════════════╣");
            Console.WriteLine("\t\t\t║ 1) Aumentar Velocidad      ║");
            Console.WriteLine("\t\t\t║ 2) Disminuir Velocidad     ║");
            Console.WriteLine("\t\t\t║ 3) Despegar                ║");
            Console.WriteLine("\t\t\t║ 4) Aumentar Altitud        ║");
            Console.WriteLine("\t\t\t║ 5) Disminuir Altitud       ║");
            Console.WriteLine("\t\t\t║ 6) Aterrizar               ║");
            Console.WriteLine("\t\t\t║                            ║");
            Console.WriteLine("\t\t\t║ 0) Salir                   ║");
            Console.WriteLine("\t\t\t║                            ║");
            Console.WriteLine("\t\t\t╚════════════════════════════╝");
        }
        */

        public static ConsoleColor EligeColor()
        {
            ConsoleColor[] vColores = { ConsoleColor.White, ConsoleColor.Gray, ConsoleColor.DarkBlue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White }; // el primero no sirve

            Console.WriteLine("\n\tElige un color\n");

            for (int i = 1; i < vColores.Length; i++)
            {
                Console.ForegroundColor = vColores[i];
                Console.WriteLine("\t" + (i) + ")  " + "████████ ◄ " + vColores[i]);
                Console.ResetColor();
            }

            int indice = CapturaEntero_vProfesor("\t¿Color?", 1, 8);

            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\n\n\tEl color de la puerta se ha pintado en "); Console.ForegroundColor = vColores[indice];
            Console.WriteLine(vColores[indice]);
            Console.ResetColor();

            return vColores[indice];
        }

        #region Errores
        public static void Error(string texto)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n\n\t** ¡" + texto + "! **");

            Console.ResetColor();
        }

        public static void Error_vPro1(string texto, int fila, int columna)
        {
            int max = texto.Length;
            int posX = Console.CursorLeft;
            int posY = Console.CursorTop;

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.SetCursorPosition(columna, fila);
            Console.Write("╔═══ERROR");
            
            for (int j = 0; j < max + 4 - 8; j++)
                Console.Write("═");
            
            Console.WriteLine("╗");

            Console.SetCursorPosition(columna, fila + 1);
            
            Console.Write("║  ");
            Console.Write(texto);
            Console.Write("  ║");
            Console.WriteLine("█");

            Console.SetCursorPosition(columna, fila + 2);
            
            Console.Write("╚");
            
            for (int j = 0; j < max + 4; j++)
                Console.Write("═");
            
            Console.Write("╝");
            Console.WriteLine("█");
            Console.SetCursorPosition(columna + 1, fila + 3);
            
            for (int j = 0; j < max + 6; j++)
                Console.Write("▀");

            Console.ResetColor();

            Console.SetCursorPosition(posX, posY); // volvemos a poner el cursor donde estaba antes de llamar a este método

            // Nota para mejorar: hacer que previamente a mostrar el error, limpie ese espacio de la pantalla (tales filas)
        }

        public static void Error_vPro2(string texto)
        {
            int max = texto.Length;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition((Console.WindowWidth - max - 4) / 2, Console.CursorTop + 2);
            Console.Write("╔═══ERROR");
            for (int j = 0; j < max + 4 - 8; j++)
                Console.Write("═");
            Console.WriteLine("╗");
            Console.SetCursorPosition((Console.WindowWidth - max - 4) / 2, Console.CursorTop);
            Console.Write("║  ");
            Console.Write(texto);
            Console.Write("  ║");
            Console.WriteLine("█");
            Console.SetCursorPosition((Console.WindowWidth - max - 4) / 2, Console.CursorTop);
            Console.Write("╚");
            for (int j = 0; j < max + 4; j++)
                Console.Write("═");
            Console.Write("╝");
            Console.WriteLine("█");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(((Console.WindowWidth - max - 4) / 2) + 1, Console.CursorTop);
            for (int j = 0; j < max + 6; j++)
                Console.Write("▀");
            Console.Beep();
            Console.ResetColor();
        }

	public static void Error_vProfesor1(string texto)
        {
            int num = 10;
            string text = "                                                                               ";
            string text2 = "════════════════════════════════════════════════════════════════════════════════";
            string text3 = "▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀";
            texto = "   " + texto + "   ";
            int num2 = texto.Length + 1;
            string[] array = new string[3]
            {
                ("╔═ERROR" + text2).Substring(0, num2) + "╗",
            "║" + texto + "║",
            ("╚" + text2).Substring(0, num2) + "╝"
            };
            string[] array2 = new string[3]
            {
            text.Substring(0, num2) + "█",
            text.Substring(0, num2) + "█",
            text3.Substring(0, num2 + 1)
            };
            int num3 = (80 - num2) / 2;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < array2.Length; i++)
            {
                Console.SetCursorPosition(num3 + 1, num + i + 1);
                Console.Write(array2[i]);
            }
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int j = 0; j < array.Length; j++)
            {
                Console.SetCursorPosition(num3, num + j);
                Console.Write(array[j]);
            }
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorVisible = false;
            Console.Beep(400, 400);
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        public static void Error_vProfesor2(string texto)
        {
            //int num = 24;
            int num = 4;
            texto = $"*** Error: {texto} ***";
            int length = texto.Length;
            int left = (80 - length) / 2;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(left, num);
            Console.Write(texto);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Beep(400, 400);
            Console.ReadKey();
            RowCleaner(num);

            Console.ResetColor();
        }

        public static void RowCleaner(int row)
        {
            Console.SetCursorPosition(0, row);
            Console.Write("                                                                                                                                 ");
        }
        #endregion

        #region Mensajes
        public static void MensajeOK_vProfesor1(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\tOK: {0}. Pulse una tecla.", mensaje);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ReadKey();
            Console.Beep(1000, 100);
        }

        public static void MensajeOK_vProfesor2(string texto)
        {
            int num = 24;
            texto = $"{texto}";
            int length = texto.Length;
            int left = (80 - length) / 2;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(left, num);
            Console.Write(texto);
            Console.Beep(400, 400);
            Console.ReadKey();
            RowCleaner(num);

            Console.ResetColor();
        }
        #endregion
    }
}
