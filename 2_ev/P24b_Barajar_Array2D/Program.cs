/*
BarajaArray2D:
Construye, además de CapturaEntero, los métodos siguientes: 

GeneraArray2D, que
• Recibe: 4 enteros: num y numInicial, nFilas, nColumnas
• Hace: Construye una tabla bidimensional de enteros, de tamaño nFilas x nColumnas 
y la carga con los primeros múltiplos de num a partir de numInicial.
• Devuelve: La tabla construida.

BarajaArray2D, que no devuelve nada y...
• Recibe: una tabla bidimensional de enteros array2D
• Hace: Baraja los valores de la tabla. Para esto puedes utilizar una lista auxiliar.

MuestraArray, que no devuelve nada y...
• Recibe: una tabla bidimensional de enteros array2D
• Hace: Coloca una cabecera con las filas y columnas, 
y presenta los valores del array en sus posiciones correspondientes.

El programa:

1) Pide un número de filas filas, [2..9], y columnas, [2..9], 
un número inicial ni, [100..200], un número num, [11..77].
Utilizando el método GeneraArray2D, 
obtendrá un array bidimensional de filas x columnas cargado con los primeros múltiplos de num, a partir de ni.

2) Utilizando MuestraArray, mostrará los valores del array.

3) Barajará el vector utilizando BarajaArray

4) Volverá a mostrar los valores del array.

5) Ordenará los valores del array. Para esto puedes utilizar una lista auxiliar.

6) Volverá a mostrar los valores del array.
Nota: Cada vez que se vaya a mostrar el array haz una pausa previa,
en la que el usuario tenga que pulsar una tecla
*/

using System;
using System.Collections.Generic;

namespace P24b_Barajar_Array_Bidimensional
{
    class Program
    {
        static void Main(string[] args)
        {
            // ATENCIÓN: Ejecutar el programa con la terminal emergente maximizada en pantalla
            // de no maximizarla, el SetCursorPosition() del método ColocarElNumero() se saldrá de la terminal, nos dará un error y se parará el programa

            string pregunta = "definir el número para mostrar sus múltiplos";
            int num = CapturaEntero(0, pregunta, 11, 77);

            pregunta = "para definir un número a partir del cual se presentarán los múltiplos";
            int numInicial = CapturaEntero(0, pregunta, 100, 200);

            pregunta = "para definir el número de filas de la matriz";
            int nFilas = CapturaEntero(0, pregunta, 2, 9);

            pregunta = "para definir el número de columnas de la matriz";
            int nColumnas = CapturaEntero(0, pregunta, 2, 9);

            Console.Clear();

            int[,] array2D = GeneraArray2D(num, numInicial, nFilas, nColumnas);
            MostrarArray2D(array2D, 10, 2, 0, 10);
            
            Console.WriteLine("\n\n");
            List<int> listAux = ExtraerListAux(array2D);

            Console.WriteLine("\n");
            MostrarListAux(listAux);

            Console.WriteLine("\n");
            BarajarListAux(listAux);
            MostrarListAux(listAux);

            DevolverListAux(array2D, listAux);
            MostrarArray2D(array2D, 75, 2, 65, 10);

            HacerLaMagia();

            MostrarArray2D(array2D, 10, 2, 0, 10);
            
            OrdenarListAux(listAux);
            DevolverListAux(array2D, listAux);
            MostrarArray2D(array2D, 75, 2, 65, 10);
            
            PararPrograma();
        }

        /************************************************ MÉTODOS ******************************************************/

        public static int CapturaEntero(int posScreen, string pregunta, int min, int max)
        {
            int num = 0;
            bool numOk;

            do
            {
                Console.SetCursorPosition(posScreen, 2);
                Console.Write("                                                                                                                                                                        ");
                Console.SetCursorPosition(posScreen, 2);
                Console.Write("Introduzca un número entre el [" + min + ", " + max + "], " + pregunta + ":\t");
                numOk = Int32.TryParse(Console.ReadLine(), out num);

                if (!numOk)
                {
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("                                                                                                                                                                        ");
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. El dato introducido no es un valor numérico.");
                }
                else if (num < min)
                {
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("                                                                                                                                                                        ");
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. El número no puede ser inferior a " + min + ".");
                    numOk = false;
                }
                else if (num > max)
                {
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("                                                                                                                                                                        ");
                    Console.SetCursorPosition(posScreen, 4);
                    Console.Write("Error. El número no puede ser superior a " + max + ".");
                    numOk = false;
                }
                else if (num == 0)
                {
                    numOk = true;
                }

            } while (!numOk);

            return num;
        }

        public static int[,] GeneraArray2D(int num, int numInicial, int nFilas, int nColumnas)
        {
            int[,] array2D = new int[nFilas, nColumnas];
            int mul = num * (numInicial / num);
            int suma = num;

            if (mul < numInicial)
            {
                mul += num;
            }

            for (int i = 0; i < array2D.GetLength(0); i++) {
                for (int j = 0; j < array2D.GetLength(1); j++) {
                    if (array2D[i,j] == array2D[0,0]){
                        array2D[i,j] = mul;
                    } else {
                        array2D[i,j] = mul + suma;
                        suma += num;
                    }
                }
            }

            return array2D;
        }

        public static void MostrarArray2D(int[,] array2D, int posScreenX, int posScreenY, int posScreenMargenXmultiplos, int posScreenMargenXfilas) {
            
            Console.SetCursorPosition(posScreenX, posScreenY);
            for (int ct = 0; ct < array2D.GetLength(1); ct++) {
                Console.Write("c" + ct + "\t  ");
            }
            Console.SetCursorPosition(posScreenX - posScreenMargenXfilas, posScreenY + 2);
            for (int ft = 0; ft < array2D.GetLength(0); ft++) {
                Console.WriteLine("f" + ft + " -->\n");
            }

            for (int ft = 0; ft < array2D.GetLength(0); ft++)
            {
                for (int ct = 0; ct < array2D.GetLength(1); ct++)
                {
                    ColocaElNumero(array2D, ft, ct, posScreenMargenXmultiplos);
                }
            }
        }

        public static List<int> ExtraerListAux(int[,] array2D) {
            List<int> listAux = new List<int>();

            for(int i = 0; i < array2D.GetLength(0); i++) {
                for(int j = 0; j < array2D.GetLength(1); j++) {
                    listAux.Add(array2D[i,j]);
                }
            }

            return listAux;
        }

        public static void MostrarListAux(List<int> listAux) {
            for(int i = 0; i < listAux.Count; i++) {
                Console.Write(listAux[i] + "\t");
            }
        }

        public static void BarajarListAux(List<int> listAux)
        {
            Random random = new Random();
            int posAleatoria = 0;
            int aux = 0;
            bool posRepetida = false;

            for (int i=0; i<listAux.Count; i++) {
                do {
                    posRepetida = false;
                    posAleatoria = random.Next(listAux.Count);

                    for (int j=0; j<i; j++) {
                        if (posAleatoria == j) {
                            posRepetida = true;
                        }
                    }

                } while (posRepetida);

                aux = listAux[posAleatoria];
                listAux[posAleatoria] = listAux[0];
                listAux[0] = aux;
            }
        }

        // Método de Ordenación Burbuja
        public static void OrdenarListAux(List<int> listAux) 
        {
            int aux = 0;

            for (int i=0; i<listAux.Count-1; i++) {
                for (int j=0; j<listAux.Count-1; j++) {
                    if (listAux[j] > listAux[j+1]) {
                        aux = listAux[j];
                        listAux[j] = listAux[j+1];
                        listAux[j+1] = aux;
                    }
                }
            }
        }

        public static void DevolverListAux(int[,] array2D, List<int> listAux)
        {
            int index = 0;

            for(int i = 0; i < array2D.GetLength(0); i++) {
                for(int j = 0; j < array2D.GetLength(1); j++) {
                    array2D[i,j] = listAux[index];
                    index ++;
                }
            }
        }


        public static void ColocaElNumero(int[,] array2D, int ft, int ct, int posScreenMargenXmultiplos)
        {
            int filaPantalla, columnaPantalla; // <-- fila y columna de la pantalla

            columnaPantalla = 10 + 8 * ct;// columna de la pantalla en función de la columna de la tabla
            filaPantalla = 4 + 2 * ft; // fila de la pantalla en función de la fila de la tabla

            Console.SetCursorPosition(columnaPantalla + posScreenMargenXmultiplos, filaPantalla);
            Console.Write(array2D[ft, ct]);
        }

        public static void HacerLaMagia()
        {
            Console.SetCursorPosition(0, 35);
            Console.Write("Pulsa cualquier tecla para ver como pasamos del Array2D barajado al Array2D ordenado de nuevo");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nPress any key to exit.");
            Console.ReadLine();
        }

    }
}