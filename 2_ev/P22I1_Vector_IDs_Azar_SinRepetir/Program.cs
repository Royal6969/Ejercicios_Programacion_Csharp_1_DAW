/* Vector de id’s al azar sin repetir
   Primera parte
    Construye una vector de 90 enteros.
    Carga el vector con números de dos cifras sin repetir ninguno.
    Presenta los valores en la pantalla, horizontalmente y separados por tabuladores.
*/

using System;

namespace P22I1_Vector_IDs_Azar_SinRepetir
{
    class Program
    {
        const int TAMAÑO = 90;

        static void Main(string[] args)
        {
            Random azar = new Random();

            int[] vIDs = new int[TAMAÑO];
            int[] valoresPosibles = new int[90];

            for (int i=0; i<TAMAÑO; i++)
            {
                valoresPosibles[i] = i + 10;

                Console.Write(valoresPosibles[i] + "\t");
            }

            int contTotal = 0;
            int contAnterior = 0;
            int posAleatoria;

            Console.WriteLine("\n\nAlumno: Díaz Campos, Sergio\n\n");

            for (int i=0; i<TAMAÑO; i++)
            {
                contTotal++;

                posAleatoria = azar.Next(90 - 1);
                
                vIDs[i] = valoresPosibles[posAleatoria];
                IntercambiarNumero(valoresPosibles, posAleatoria, valoresPosibles.Length - 1 - i);

                if (i < 10)
                {
                    Console.WriteLine(" " + i + ")  " + vIDs[i] + "\t\t" + (contTotal - contAnterior) + "\t" + contTotal);
                } 
                else
                {
                    Console.WriteLine(i + ")  " + vIDs[i] + "\t\t" + (contTotal - contAnterior) + "\t" + contTotal);
                }

                

                contAnterior = contTotal;
            }



            Console.Write("\n\n\n\t\tPulsa tecla para salir");
            Console.ReadKey();
        }

        /*************************************************** MÉTODOS ***************************************************/

        public static void IntercambiarNumero(int[] vector, int pos1, int pos2)
        {
            int aux = vector[pos1];
            vector[pos1] = vector[pos2];
            vector[pos2] = aux;
        }
    }
}