/*
Construye dos tablas tApell y tNomb con los datos que tienes más abajo. 

A continuación realizamos el siguiente proceso:

1) Construimos una tabla de byte tIds con las mismas filas que las tablas anteriores. 
Se cargará con números al azar de dos cifras sin que exista ninguno repetido. 
Cada número se considerá el id del alumno de la misma fila.

2) Construimos una tabla de float tNotas con las mismas filas que la anterior, 
pero de dos dimensiones (tres columnas), para guardar las notas de los alumnos, es decir, 
en la fila n se guardarán las tres notas del alumno de posición n. 
Esta tabla se cargará con notas obtenidas al azar, entre 0.0 y 9.9, (con un decimal).

3) Guardamos los datos en un fichero formando registros con la siguiente estructura:
id;Apellidos;Nombre;n0;n1;n2
El fichero se llamará fNotasCS.TXT. 
Se guardará en una carpeta de nombre Datos, en el directorio de trabajo por defecto.
Los campos irán separados por el carácter ‘;’ y los registros por salto de línea.

Apellidos: "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto
Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González
Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero",
"Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delegado Rodríguez", "Duque Martínez"

Nombres: "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "María", "Carlos",
"Jose Carlos", "Juan Luis", "Daniel", "Carmen", "Jacobo", "Alejandro", "Francisco", "Alicia", "Francisco", "Ángela",
"Constantino", "Mariló", "Rafaela", "Antonio"
*/

using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace P33a_Escribir_En_TXT_Con_Separadores
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tApell = { "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delegado Rodríguez", "Duque Martínez" };
            string[] tNomb = { "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "María", "Carlos", "Jose Carlos", "Juan Luis", "Daniel", "Carmen", "Jacobo", "Alejandro", "Francisco", "Alicia", "Francisco", "Ángela", "Constantino", "Mariló", "Rafaela", "Antonio" };

            byte[] tIds = Cargar_tIds(tNomb);

            float[,] tNotas = new float[tNomb.Length, 3];
            tNotas = Cargar_tNotas(tNotas);

            StreamWriter streamWriter = new StreamWriter("../../../../ficheros/P33a_Escribir_En_TXT_Con_Separadores/fNotasCS.txt", false, Encoding.Default);
            // StreamWriter streamWriter = File.CreateText("../../../../ficheros/P33a_Escribir_En_TXT_Con_Separadores/fNotasCS.txt"); // vProfesor

            VolcarDatosEnElFichero(streamWriter, tIds, tApell, tNomb, tNotas);

            streamWriter.Close();

            PararPrograma();
        }

        /******************************************************************* MÉTODOS *******************************************************************/

        public static byte[] Cargar_tIds(string[] tNomb)
        {
            byte[] tIds = new byte[tNomb.Length];
            Random random = new Random();
            bool repetido = false;

            for (int i = 0; i < tIds.Length; i++)
            {
                do
                {
                    repetido = false;
                    tIds[i] = (byte)random.Next(10, 100);

                    for (int j = 0; j < i; j++)
                    {
                        if (tIds[i] == tIds[j])
                        {
                            repetido = true;
                        }
                    }

                } while (repetido == true);
            }

            return tIds;
        }

        public static byte[] Cargar_tIds_vProfesor(int tamaño)
        {
            byte[] tIds = new byte[tamaño];
            Random random = new Random();
            List<byte> listIds = new List<byte>();

            for (byte i = 10; i < 100; i++)
            {
                listIds.Add(i);
            }

            int posAzar;

            for (int i = 0; i < tamaño; i++)
            {
                posAzar = random.Next(listIds.Count);
                tIds[i] = listIds[posAzar];
                listIds.RemoveAt(posAzar);
            }

            return tIds;
        }

        public static float[,] Cargar_tNotas(float[,] tNotas)
        {
            Random random = new Random();

            for (int i = 0; i < tNotas.GetLength(0); i++)
            {
                for (int j = 0; j < tNotas.GetLength(1); j++)
                {
                    tNotas[i, j] = (float)Math.Round((float)(random.Next(10) * 1.1), 1);
                    // tNotas[i, j] = random.Next(100) * 0.1F; // vProfesor
                }
            }

            return tNotas;
        }

        public static void VolcarDatosEnElFichero(StreamWriter streamWriter, byte[] tIds, string[] tApell, string[] tNomb, float[,] tNotas)
        {
            streamWriter.WriteLine("\nLa matriz de tNotas es:\n");
            streamWriter.WriteLine("\nID\tApellidos\tNombre\t\tn0\tm1\tn2\tMedia");
            streamWriter.WriteLine("--\t------\t\t------\t\t---\t---\t---\t-----");

            int nCols = 3;
            int contCols = 0;

            float suma = 0;

            for (int i = 0; i < tNotas.GetLength(0); i++)
            {
                streamWriter.Write(tIds[i] + ";\t" + tApell[i] + ";" + tNomb[i] + ";   \t");

                for (int j = 0; j < tNotas.GetLength(1); j++)
                {
                    streamWriter.Write(tNotas[i, j] + ";\t");
                    contCols++;
                    suma += tNotas[i, j];

                    if (contCols == nCols)
                    {
                        streamWriter.Write(Math.Round((float)((suma / contCols) * 1.11), 2) + ";");

                        streamWriter.WriteLine();
                        contCols = 0;
                        suma = 0;
                    }
                }
            }
        }

        public static void PararPrograma()
        {
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}