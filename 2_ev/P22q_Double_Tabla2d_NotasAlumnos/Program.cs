/*
Tabla 2D de Notas de Alumnos:

Construye dos vectores vApell y vNomb como hiciste en la práctica anterior.

A continuación realizamos el siguiente proceso:

1) Construimos un vector de string vAlumnos y la cargamos con los “Apellidos, Nombre” de cada alumno a partir de los dos vectores anteriores.

2) Construimos una tabla de floats tNotas con las mismas filas que la anterior pero de dos dimensiones (tres columnas), 
para guardar las notas de los alumnos, es decir, en la fila n se guardarán las tres notas del alumno de posición n. 
Esta tabla se cargará con notas obtenidas al azar, entre 3.0 y 9.9, (con un decimal).

3) Presentamos la tabla de doble entrada, alumnos/notas donde aparece cada alumno con sus tres notas y la media de las tres, con dos decimales. 
A esta presentación se le pondrá una cabecera:

Avanzado: 
que el id, en lugar del índice de las tablas, sea un número de 2 cifras al azar para cada alumno, sin repetir ninguno.
*/

using System;
using System.Threading;

namespace P22p_Tabla_floats_2d_Notas_Alumnos
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vNombres = { "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "Tomás", "Carlos", "Jose Carlos", "Juan Luis", "Daniel", "Angel", "Jacobo", "Alejandro", "Francisco", "Alfredo", "Francisco", "Antonio", "Constantino", "Roberto", "Rafael", "Antonio" };
            string[] vApellidos = { "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delgado Rodríguez", "Duque Martínez" };

            MostrarVectores(vNombres, vApellidos);
            PulsarUnaTeclaParaContinuar();

            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------------------------");

            /*1*/
            string[] vAlumnos = Cargar_vAlumnos(vApellidos, vNombres);
            Mostrar_vAlumnos(vAlumnos);
            PulsarUnaTeclaParaContinuar();

            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------------------------");

            /*2*/
            float[,] tNotas = new float[vAlumnos.Length, 3];
            tNotas = Cargar_tNotas(tNotas);

            /*3*/
            Mostrar_vAlumnos_tNotas(vAlumnos, tNotas);

            PararPrograma();
        }

        /******************************************************* MÉTODOS **************************************************************/

        public static void MostrarVectores(string[] vNombres, string[] vApellidos)
        {
            Console.WriteLine("\nLos vectores de vNombres y vApellidos son:\n");
            Console.WriteLine("vNombres - vApellidos\n");
            for (int i = 0; i < vNombres.Length; i++)
            {
                Console.Write(vNombres[i] + " " + vApellidos[i] + ",\n");
            }
        }

        /*1*/
        public static string[] Cargar_vAlumnos(string[] vApellidos, string[] vNombres)
        {
            string[] vAlumnos = new string[vApellidos.Length];

            for (int i = 0; i < vAlumnos.Length; i++)
            {
                vAlumnos[i] = vApellidos[i] + ", " + vNombres[i];
            }

            return vAlumnos;
        }

        public static void Mostrar_vAlumnos(string[] vAlumnos)
        {
            Console.WriteLine("\nEl vector de vAlumnos es:\n");
            Console.WriteLine("vApellidos - vNombres\n");

            for (int i = 0; i < vAlumnos.Length; i++)
            {
                Console.Write(vAlumnos[i] + "\n");
            }
        }

        /*2*/
        public static float[,] Cargar_tNotas(float[,] tNotas)
        {
            Random random = new Random();

            for (int i = 0; i < tNotas.GetLength(0); i++)
            {
                for (int j = 0; j < tNotas.GetLength(1); j++)
                {
                    tNotas[i, j] = (float)Math.Round((float)(random.Next(3, 10) * 1.1), 1);
                }
            }

            return tNotas;
        }

        /*3*/
        public static void Mostrar_vAlumnos_tNotas(string[] vAlumnos, float[,] tNotas)
        {
            Console.WriteLine("\nLa matriz de tNotas es:\n");
            Console.WriteLine("\nID\tAlumno\t\t\t\tProg\tED\tBBDD\tMedia");
            Console.WriteLine("--\t------\t\t\t\t----\t--\t----\t-----");

            int nCols = 3;
            int contCols = 0;

            float suma = 0;

            int[] vIds = Cargar_vIds(vAlumnos);

            for (int i = 0; i < tNotas.GetLength(0); i++)
            {
                Console.Write(vIds[i] + "\t" + vAlumnos[i] + "   \t");

                for (int j = 0; j < tNotas.GetLength(1); j++)
                {
                    Console.Write(tNotas[i, j] + "\t");
                    contCols++;
                    suma += tNotas[i, j];

                    if (contCols == nCols)
                    {
                        Console.Write(Math.Round((float)((suma / contCols) * 1.11), 2));

                        Console.WriteLine();
                        contCols = 0;
                        suma = 0;
                    }
                }
            }
        }
        /*Avanzado*/
        public static int[] Cargar_vIds(string[] vAlumnos)
        {

            Random random = new Random();
            int[] vIds = new int[vAlumnos.Length];
            bool repetido = false;

            for (int i = 0; i < vIds.Length; i++)
            {
                do
                {
                    repetido = false;

                    vIds[i] = random.Next(10, 100);

                    for (int j = 0; j < i; j++)
                    {
                        if (vIds[i] == vIds[j])
                        {
                            repetido = true;
                        }
                    }

                } while (repetido == true);
            }

            return vIds;
        }

        public static void PulsarUnaTeclaParaContinuar()
        {
            Console.Write("\n\n\nPulse una tecla si desea continuar:\t");
            Console.ReadKey();
            Console.Clear();
            Thread.Sleep(500);
        }

        public static void PararPrograma()
        {
            Console.Write("\n\n\nPress any to exit.");
            Console.ReadLine();
        }
    }
}