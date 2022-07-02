﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P40e1_Proyecto_Rectangulo
{
    class Tools
    {

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

        public static string CapturaNombreRectangulo(int posScreen, string pregunta)
        {

            string nombreRectangulo = string.Empty;
            bool nombreOk;

            do
            {
                Console.Write("\n\nIntroduzca un nombre, " + pregunta + ":\t");
                nombreRectangulo = Console.ReadLine().Trim();

                if (nombreRectangulo == "")
                {
                    Console.Write("Error. El nombre introducido para el Rectángulo no puede dejarse en blanco.");
                    nombreOk = false;
                }
                else if (nombreRectangulo.Length > 8)
                {
                    Console.Write("Error. El nombre introducido para el Rectángulo no puede tener más de 8 caracteres.");
                    nombreOk = false;
                }
                else
                {
                    nombreOk = true;
                }

            } while (!nombreOk);

            return nombreRectangulo;
        }

        public static float CapturaFloat(int posScreen, string pregunta, int min, int max)
        {

            float num = 0;
            bool numOk;

            do
            {
                //Console.SetCursorPosition(posScreen, 2);
                //Console.Write("                                                 ");
                //Console.SetCursorPosition(posScreen, 2);
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Single.TryParse(Console.ReadLine(), out num);

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

        public static double CapturaDouble(int posScreen, string pregunta, int min, int max)
        {

            double num = 0;
            bool numOk;

            do
            {
                Console.Write("\n\nIntroduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Double.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min || num > max)
                {
                    Console.Write("Error. El número introducido no puede ser superior a " + max + " ni inferior a " + min);
                    numOk = false;
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
