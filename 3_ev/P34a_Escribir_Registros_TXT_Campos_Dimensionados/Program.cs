/*
Construye dos tablas tApell y tNomb con los datos que tienes más abajo.

A continuación realizamos el siguiente proceso:

1) Construimos una tabla de byte tIds con el id de cada alumno, 
que serán números al azar de tres cifras (no dos) sin que exista ninguno repetido.

2) Construimos una tabla de floats tNotas con las mismas filas que la anterior, 
pero de dos dimensiones (tres columnas), 
para guardar las notas de los alumnos, es decir, 
en la fila n se guardarán las tres notas del alumno de posición n. 
Esta tabla se cargará con notas obtenidas al azar, entre 0.0 y 9.9, (con un decimal).

3) Guardamos los datos dentro de la carpeta «zDatosPruebas» en un fichero, que se llamará fNotasCD.TXT, 
dándole el siguiente orden y tamaño a los datos:
Dato → id Apellidos Nombre Nota1 Nota2 Nota3
No Caracteres 3 18 12 3 3 3

Apellidos: "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto
Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González
Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero",
"Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delegado Rodríguez", "Duque Martínez"

Nombres: "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "María", "Carlos",
"José Carlos", "Juan Luis", "Daniel", "Carmen", "Jacobo", "Alejandro", "Francisco", "Alicia", "Francisco", "Ángela",
"Constantino", "Mariló", "Rafaela", "Antonio"
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace P34a_Escribir_Registros_TXT_Campos_Dimensionados
{
    class Program
    {
        static void Main(string[] args)
        {
            /************************ He contado las líneas del fichero y se cerró, y ahora lo vuelvo a abrir para cargar las tablas *******************************/

            string[] tabApell = { "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delegado Rodríguez", "Duque Martínez" };
            string[] tabNomb = { "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "María", "Carlos", "José Carlos", "Juan Luis", "Daniel", "Carmen", "Jacobo", "Alejandro", "Francisco", "Alicia", "Francisco", "Ángela", "Constantino", "Mariló", "Rafaela", "Antonio" };
            
            int tamaño = tabApell.Length;
            byte[] tIds = Cargar_tIds_vProfesor(tamaño);

            float[,] tNotas = new float[tabApell.Length, 3];
            tNotas = Cargar_tNotas(tNotas);

            StreamWriter streamWriter = File.CreateText(@"C:/zDatosPruebas/fNotasCD.txt"); // vProfesor

            VolcarDatosEnElFichero(streamWriter, tIds, tabApell, tabNomb, tNotas);

            streamWriter.Close();

            PararPrograma();
        }

        /************************************************ MÉTODOS ***************************************************/

        public static byte[] Cargar_tIds_vProfesor(int tamaño)
        {
            byte[] tIds = new byte[tamaño];
            Random random = new Random();
            List<byte> listIds = new List<byte>();

            for (int i = 100; i < 1000; i++)
            {
                listIds.Add((byte)i);
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

        public static void VolcarDatosEnElFichero(StreamWriter streamWriter, byte[] tIds, string[] tabApell, string[] tabNomb, float[,] tNotas)
        {
            streamWriter.WriteLine("ID\tApellidos\t\tNombre\t\tNota1\tNota2\tNota3\tMedia");
            streamWriter.WriteLine("----------------------------------------------------------------------------------------------");

            int nCols = 3;
            int contCols = 0;

            float suma = 0;

            for (int i = 0; i < tNotas.GetLength(0); i++)
            {
                streamWriter.Write("{0}\t{1}\t{2}\t", tIds[i], CuadraTexto(tabApell[i], 18), CuadraTexto(tabNomb[i], 12));

                for (int j = 0; j < tNotas.GetLength(1); j++)
                {
                    streamWriter.Write("{0}\t", CuadraTexto(Convert.ToString(tNotas[i, j]), 3));
                    contCols++;
                    suma += tNotas[i, j];

                    if (contCols == nCols)
                    {
                        streamWriter.Write(Math.Round((float)((suma / contCols) * 1.11), 2));

                        streamWriter.WriteLine();
                        contCols = 0;
                        suma = 0;
                    }
                }
            }
        }

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += ".........................................";

            return texto.Substring(0, nCaracteres);
        }

        static string CuadraTexto_v2(string texto, int nCaracteres, char caracter)
        {
            if (texto.Length > nCaracteres)
            {
                texto = texto.Substring(0, nCaracteres);
            }
            /*else // opcional
            {
                for (int i = texto.Length; i < nCaracteres; i++)
                {
                    //texto = texto + " ";
                    texto = caracter + texto;
                }
            }*/

            for (int i = 0; i < nCaracteres - texto.Length; i++)
            {
                texto += caracter;
            }

            return texto;
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

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}