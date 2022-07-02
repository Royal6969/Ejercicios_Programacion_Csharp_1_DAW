using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P42b_Division_De_Enteros_Desde_Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vNums = new int[20];
            vNums = Cargar_vNums(vNums);

            int posicion;
            int num;
            bool numOk = false;
            string aux = string.Empty;
            int divisor;
            bool divisorOk = false;

            do
            {
                Console.Clear();

                for (int i = 0; i < vNums.Length; i++) // para comprobar que coge bien el número
                {
                    Console.Write("\t" + vNums[i]);
                }

                try
                {
                    // pido la posición a buscar y la guardo en un string en minúsculas, y justo después le hacemos su TryParse()
                    Console.Write("\n\nIntroduzca un número entre el [0 - 20], para saber el valor en tal posición del vector (escriba [fin] para terminar):\t");
                    aux = Console.ReadLine().ToLower();
                    numOk = Int32.TryParse(aux, out posicion);

                    // comenzamos las comprobaciones y el programa actúa según el caso que se de
                    if (!numOk && aux != "fin")
                    {
                        // mandamos una excepción con un mesaje específico para ella
                        throw new FormatException("El dato introducido no es un valor numérico.");
                    }
                    else if (posicion < 0 || posicion > 20) // longitud del vector
                    {
                        numOk = false;
                        // mandamos una excepción con un mesaje específico para ella
                        throw new OverflowException("Número introducido fuera de rango.");
                    }
                    else if (numOk) // la posición a buscar se ha introducido bien, y procedemos con la introducción del divisor
                    {
                        ///////////////////////////////////////////////////////////////////////////////////////////////////
                        num = BuscarPosiciónDevolverValor(vNums, posicion);
                        Console.Write("\n\n\tEl número que hay en la posición " + posicion + ", es el:\t" + num);

                        do
                        {
                            Console.Write("\n\n\tIntroduzca un divisor para dividir el número encontrado (" + num + "):\t");
                            divisorOk = Int32.TryParse(Console.ReadLine(), out divisor);

                            if (!divisorOk)
                            {
                                // mandamos una excepción con un mesaje específico para ella
                                throw new FormatException("El dato introducido no es un valor numérico.");
                            }
                            else if (divisor < 0)
                            {
                                divisorOk = false;
                                // mandamos una excepción con un mesaje específico para ella
                                throw new OverflowException("¿Cómo vas a dividir entre un número negativo miarma?!");
                            }
                            else if (divisor == 0)
                            {
                                divisorOk = false;
                                // mandamos una excepción con un mesaje específico para ella
                                throw new DivideByZeroException("¿Cómo vas a dividir entre 0 chiquillo?!");
                            }

                        } while (!divisorOk);

                        Console.Write("\n\n\tEl resultado de (" + num + " / " + divisor + ") es:\t" + ((num / divisor) * 1.11).ToString("0.00"));
                        ////////////////////////////////////////////////////////////////////////////////////////////////////
                    }
                    else if (aux == "fin")
                    {
                        numOk = true;
                    }
                
                }
                // ahora aquí controlamos cada posible ámbito de excepción
                
                catch (FormatException err) // para los error de formato
                {
                    Console.Write("\n\n\t**** Error ****\t" + err);
                }
                catch (OverflowException err) // para los errores de fuera rango
                {
                    Console.Write("\n\n\t**** Error ****\t" + err);
                }
                catch (DivideByZeroException err) // para los errores de dividir entre 0
                {
                    Console.Write("\n\n\t**** Error ****\t" + err);
                }

                Console.WriteLine("\n\n\tPulse una tecla para continuar");
                Console.ReadKey();

            } while (!numOk || aux != "fin"); // aquí es el operador OR para que funcione bien

            Console.Clear();
            Tools.StopProgram();
        }

        /************************************************* MÉTODOS **********************************************/

        public static int[] Cargar_vNums(int[] vNums) // sin repetir los números
        {
            Random random = new Random();
            List<int> numsList = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                numsList.Add(i);
            }

            int posAzar;

            for (int i = 0; i < vNums.Length; i++)
            {
                posAzar = random.Next(numsList.Count);
                vNums[i] = numsList[posAzar];
                numsList.RemoveAt(posAzar);
            }

            return vNums;
        }

        public static int BuscarPosiciónDevolverValor(int[] vNums, int posicion)
        {
            int numEncontrado = 0;

            for (int i = 0; i < vNums.Length; i++)
            {
                if (i == posicion)
                {
                    numEncontrado = vNums[i];
                }
            }

            return numEncontrado;
        }
    }
}
