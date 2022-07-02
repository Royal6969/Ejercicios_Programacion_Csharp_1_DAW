using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P42a1_Prueba_De_Excepciones
{
    class Program
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
                        Console.Write("\n\n\tIntroduzca su altura en cm:\t");
                        altura = Int32.Parse(Console.ReadLine());

                        if (altura < 100 || altura > 300)
                        {
                            throw new OverflowException("El número está fuera del rango [100cm - 300cm]");
                            // OJO, ahora con este Throw new Exception, SU MENSAJE, va a saltar en el catch de OverFlowException, porque (err) sería este mensaje de aquí                        
                        }

                        Console.Write("\n\n\tIntroduzca su peso en kg:\t");
                        peso = float.Parse(Console.ReadLine());

                        if (peso < 20 || peso > 200)
                        {
                            throw new OverflowException("\n\n\t***** ERROR ***** :\tEl número está fuera del rango [20kg - 200kg]");
                            // OJO, ahora ponemos otro mensaje de error para el peso, que va a saltar en el catch de OverFlowException, porque (err) sería este mensaje de aquí 
                        }

                        imc = Math.Round(peso / Math.Pow((0.01 * altura), 2), 1);
                        hayError = false;
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
                }

            } while (Tools.PreguntaSiNo("¿Quiere repetir?"));

            Tools.StopProgram();
        }
    }
}

