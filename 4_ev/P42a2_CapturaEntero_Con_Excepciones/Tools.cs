﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P42a2_CapturaEntero_Con_Excepciones
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

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += ".........................................";

            return texto.Substring(0, nCaracteres);
        }

        public static bool PreguntaSiNo(string pregunta)
        {
            char tecla;

            do
            {
                // Hacemos la pregunta
                Console.Write("\n\n{0} (s=Sí; n=No): ", pregunta);
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

        public static int CapturaEntero_Normal(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("Error. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static int CapturaEntero_ConExcepciones(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    throw new FormatException();
                }
                else if (num < min || num > max)
                {
                    numOk = false;
                    throw new ArgumentOutOfRangeException();
                }
                else if (num > Int32.MaxValue || num < Int32.MinValue)
                {
                    numOk = false;
                    throw new OverflowException();
                }

            } while (!numOk);

            return num;
        }

        public static int CapturaEntero_DefaultValue(string pregunta, int min, int max, int defaultValue)
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
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (!numOk && aux == "")
                {
                    Console.SetCursorPosition(posX, posY);
                    Console.WriteLine(defaultValue);
                }
                else if (num < min || num > max)
                {
                    Console.Write("Error. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk && aux != "");

            if (aux == "")
            {
                num = defaultValue;
            }

            return num;
        }

        /*
        public static int CapturaEntero(string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;
            string aux = string.Empty;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + "(escriba [fin] para terminar):\t");

                aux = Console.ReadLine().ToLower();
                numOk = Int32.TryParse(aux, out num);

                if (!numOk && aux != "fin")
                {
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("Error. Número introducido fuera de rango.");
                    numOk = false;
                }

            } while (!numOk && aux != "fin");

            return num;
        }
        */

        public static float CapturaFloat_Normal(string pregunta, int min, int max)
        {

            float num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Single.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("Error. Esa opción no se encuentra en el menú.");
                    numOk = false;
                }

            } while (!numOk);

            return num;
        }

        public static float CapturaFloat_ConExcepciones(string pregunta, int min, int max)
        {

            float num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Single.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    throw new FormatException();
                }
                else if (num < min || num > max)
                {
                    numOk = false;
                    throw new ArgumentOutOfRangeException();
                }
                else if (num > float.MaxValue || num < float.MinValue)
                {
                    numOk = false;
                    throw new OverflowException();
                }

            } while (!numOk);

            return num;
        }

        public static void StopProgram()
        {
            Console.WriteLine("\n\n\n\tPress any key to exit.");
            Console.ReadKey(true);
        }

    }
}
