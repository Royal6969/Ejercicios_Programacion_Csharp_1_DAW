using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P42b_vProfesor_Division_De_Enteros_Desde_Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vNums = new int[20];
            vNums = Cargar_vNums(vNums);

            int posicion = 0;
            int num = 0;
            int divisor = 0;

            bool repetir = false;
            bool numOk = false;
            bool divisorOk = false;

            string aux = string.Empty;

            do
            {
                Console.Clear();
                MostrarVector(vNums);
                repetir = false;

                do      /////////////////// este do { while() } es para el primer número (posición) ///////////////////////
                {
                    numOk = false;
                    try
                    {
                        Console.Write("\n\nIntroduzca un número entre el [0 - 20], para saber el valor en tal posición del vector (escriba [fin] para terminar):\t");
                        aux = Console.ReadLine().ToLower();
                        numOk = Int32.TryParse(aux, out posicion);

                        if (!numOk && aux != "fin")
                        {
                            throw new FormatException("El dato introducido no es un valor numérico.");
                        }
                        else if (posicion < 0 || posicion > 20)
                        {
                            numOk = false;
                            throw new OverflowException("Número introducido fuera de rango.");
                        }
                        else if (numOk)
                        {
                            numOk = true;
                            repetir |= true;
                        }
                        else if (aux == "fin")
                        {
                            numOk = true;
                            repetir = false;
                        }
                    }
                    catch (FormatException err) // para los error de formato
                    {
                        Console.Write("\n\n\t**** Error ****\t" + err);
                    }
                    catch (OverflowException err) // para los errores de fuera rango
                    {
                        Console.Write("\n\n\t**** Error ****\t" + err);
                    }

                } while (!numOk && aux != "fin"); ///////////////////////////////////////////////////////////////////////////////


                if (aux == "fin")
                {
                    break;
                }
                else
                {
                    num = BuscarPosiciónDevolverValor(vNums, posicion);
                    Console.Write("\n\n\tEl número que hay en la posición " + posicion + ", es el:\t" + num);
                }

                //////////////////// este do { while() } es para el segundo número (divisor) /////////////////////
                do
                {
                    if (aux == "fin")
                    {
                        break;
                    }
                    else
                    {
                        divisorOk = false;
                        try
                        {
                            Console.Write("\n\n\tIntroduzca un divisor para dividir el número encontrado (" + num + "):\t");
                            divisorOk = Int32.TryParse(Console.ReadLine(), out divisor);

                            if (!divisorOk)
                            {
                                throw new FormatException("El dato introducido no es un valor numérico.");
                            }
                            else if (divisor < 0)
                            {
                                divisorOk = false;
                                throw new OverflowException("¿Cómo vas a dividir entre un número negativo miarma?!");
                            }
                            else if (divisor == 0)
                            {
                                divisorOk = false;
                                throw new DivideByZeroException("¿Cómo vas a dividir entre 0 chiquillo?!");
                            }

                            Console.Write("\n\n\tEl resultado de (" + num + " / " + divisor + ") es:\t" + ((num / divisor) * 1.11).ToString("0.00"));
                        }
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
                    }
                    

                } while (!divisorOk && aux != "fin"); ////////////////////////////////////////////////////////////////////////////


                Console.WriteLine("\n\n\tPulse una tecla para continuar");
                Console.ReadKey();

            } while (aux != "fin");

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

        public static void MostrarVector(int[] vNums)
        {
            for (int i = 0; i < vNums.Length; i++)
            {
                Console.Write("\t" + vNums[i]);
            }
        }
    }
}
