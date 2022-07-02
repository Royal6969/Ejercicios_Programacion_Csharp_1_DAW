using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P42a2_CapturaEntero_Con_Excepciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int altura;
            float peso;
            double imc;

            bool hayError;

            do
            {
                Console.Clear();
                hayError = true;

                while (hayError)
                {
                    try
                    {
                        altura = Tools.CapturaEntero_ConExcepciones("para introducir la altura en cm", 100, 300);
                        // if (altura < 100 || altura > 300) throw new ArgumentOutOfRangeException();

                        peso = Tools.CapturaFloat_ConExcepciones("para introducir el peso en kg", 20, 200);
                        // if (peso < 100 || peso > 300) throw new ArgumentOutOfRangeException();

                        imc = Math.Round(peso / Math.Pow((0.01 * altura), 2), 1);
                        hayError = false;

                        Console.WriteLine("\n\n\tTu índice de masa corporal es:\t" + imc);
                        if (imc < 18.5) Console.WriteLine("\n\tTE FALTA PESO");
                        else if (imc < 25) Console.WriteLine("\n\tPESO SALUDABLE");
                        else if (imc < 30) Console.WriteLine("\n\tTIENES SOBREPESO");
                        else if (imc < 31) Console.WriteLine("\n\tLEVE OBESIDAD");
                        else Console.WriteLine("\n\t¡¡ERES OBESO!!");
                    }
                    catch (FormatException err)
                    {
                        hayError = true;
                        Console.WriteLine("\n\n\t***** ERROR ***** :\t" + err.Message);
                    }
                    catch (OverflowException err)
                    {
                        hayError = true;
                        Console.WriteLine("\n\n\t***** ERROR ***** :\t" + err.Message);
                    }
                    catch (ArgumentOutOfRangeException err)
                    {
                        hayError= true;
                        Console.WriteLine("\n\n\t***** ERROR ***** :\t" + err.Message);
                    }
                }

            } while (Tools.PreguntaSiNo("¿Quiere repetir?"));

            Tools.StopProgram();
        }
    }
}
