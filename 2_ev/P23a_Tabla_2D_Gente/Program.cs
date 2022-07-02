/*
Vectores y Tablas2D Gente:

1) A partir de los apellidos y nombres que tienes más abajo,
construir respectivamente los vectores vApellidos y vNombres.

2) A continuación construye la tabla tab2dGente —con las mismas filas y dos columnas— 
y cárgalas colocando para cada alumno el nombre en la primera columna y los apellidos en la segunda. 
(Nota: se sabe que las dos tablas anteriores tienen el mismo tamaño pero no se puede contar a ojo)

3) Luego presentar «Nombre Apellidos» de cada persona a partir de la tabla tab2dGente

4) Construye el vector de string tabApellNomb y rellénala con los “Apellidos, Nombres” tomándolos de la tabla tab2dGente.

5) Muestra tabApellNomb en pantalla.

6) Muestra la persona cuyos Apellidos, Nombre tiene más caracteres. (Usa la propiedad .Length de las cadenas)

Nota: entre un paso y el siguiente pon una pausa “pulsar una tecla”

Apellidos: "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", 
"Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", 
"González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", 
"Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delgado Rodríguez", "Duque Martínez"

Nombres: "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "Tomás",
"Carlos", "Jose Carlos", "Juan Luis", "Daniel", "Angel", "Jacobo", "Alejandro", "Francisco", "Alfredo",
"Francisco", "Antonio", "Constantino", "Roberto", "Rafael", "Antonio"
*/

using System;
using System.Threading;

namespace P23a_Tabla_2D_Gente
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 1)*/
            string[] vNombres = { "Álvaro", "Daniel Luis", "Juan Manuel", "Agustín", "Fco. Javier", "José Manuel", "Tomás", "Carlos", "Jose Carlos", "Juan Luis", "Daniel", "Angel", "Jacobo", "Alejandro", "Francisco", "Alfredo", "Francisco", "Antonio", "Constantino", "Roberto", "Rafael", "Antonio" };
            /* 1)*/
            string[] vApellidos = { "Sánchez Elegante", "Arenas Mata", "García Solís", "Rodríguez Vázquez", "Hurtado Miranda", "Pinto Mirinda", "Barrios Garrobo", "Márquez Salazar", "Medina Gómez", "Alonso Pérez", "López Mora", "González Chaparro", "Ferrer Jiménez", "Morales Moncayo", "Fernández Perea", "Blanco Roldán", "Navarro Romero", "Aguilar Rubio", "Baena Fernández", "Barco Ramírez", "Delgado Rodríguez", "Duque Martínez" };

            MostrarVectores(vNombres, vApellidos);
            PulsarUnaTeclaParaContinuar();

            /* 2)*/
            string[,] tab2dGente = new string[vNombres.Length, 2]; // Declaro la matriz de string llamada tab2dGente y le decimos que sus dimensiones sean [la cantidad de elementos de vNombres serán las filas, y 2 columnas]

            /* 2)*/
            tab2dGente = CargarTab2dGente(tab2dGente, vNombres, vApellidos);

            /* 3)*/
            MostrarTab2dGente(tab2dGente);

            PulsarUnaTeclaParaContinuar();

            /* 4)*/
            string[] tabApellNomb = CargarTabApellNomb(tab2dGente, vNombres);

            /* 5)*/
            MostrarTabApellNomb(tabApellNomb);

            PulsarUnaTeclaParaContinuar();

            /* 6)*/
            string persona = MostrarPersonaConMasCaracteres(tabApellNomb);
            /* 6)*/
            Console.Write("\n\nLa persona que sus [apellidos, nombre] contienen más cantidad de caracteres es: \t" + persona);

            PararPrograma();
        }

        /*********************************************** MÉTODOS ********************************************/

        public static void MostrarVectores(string[] vNombres, string[] vApellidos)
        {
            Console.WriteLine("\nLos vectores de vNombres y vApellidos son:\n");
            Console.WriteLine("vNombres - vApellidos\n");
            for (int i = 0; i < vNombres.Length; i++)
            {
                Console.Write(vNombres[i] + " " + vApellidos[i] + ",\n");
            }
        }

        /* 2)*/
        public static string[,] CargarTab2dGente(string[,] tab2dGente, string[] vNombres, string[] vApellidos)
        {
            for (int i = 0; i < tab2dGente.GetLength(0); i++) // recorro el número de filas que tenga la matriz
            {
                for (int j = 0; j < tab2dGente.GetLength(1); j++) // recorro el número de columnas que tenga la matriz
                {
                    tab2dGente[i, 0] = vNombres[i]; // le decimos que por esta fila por la que van los For, pero sólo en la primera columna (columna 0), ponga el nombre correspondiente de tal posición de vNombres por la que van los For 
                    tab2dGente[i, 1] = vApellidos[i]; // le decimos que por esta fila por la que van los For, pero sólo en la segunda columna (columna 1), ponga el apellido correspondiente a la posición del vApellidos por la que van también los For

                }
            }

            return tab2dGente;
        }

        /*2)*//*public static string[,] CargarTab2dGente(string[,] tab2dGente, string[] vNombres, string[] vApellidos)
                {
                    for (int i=0; i<tab2dGente.GetLength(0); i++) // recorro el número de filas que tenga la matriz
                    {
                        for (int j=0; j<tab2dGente.GetLength(1); j++) // recorro el número de columnas que tenga la matriz
                        {
                            for (int k=0; k<vNombres.Length; k++){
                                for (int l=0; l<vApellidos.Length; l++){
                                    tab2dGente[i, 0] = vNombres[i]; // le decimos que por esta fila por la que van los For, pero sólo en la primera columna (columna 0), ponga el nombre correspondiente de tal posición de vNombres por la que van los For 
                                    tab2dGente[i, j] = vApellidos[i]; // le decimos que por esta fila y también por esta columna por la que van los For, ponga el apellido correspondiente a la posición del vApellidos por la que van también los For
                                }
                            }

                        }
                    }

                    return tab2dGente;  

                    // hay quien podría imaginarse la lógica de los otros dos For para recorrer los arrays unidimensionales dentro, a su vez, del recorrido de la matriz, y aunque también funcionaría también así, no son necesarios los For para recorrer los vectores, si no que éstos ya son recorridos al ponerlos dentro del recorrido de una matriz 
                }*/

        /* 3)*/
        public static void MostrarTab2dGente(string[,] tab2dGente)
        {
            Console.WriteLine("\n\nLa matriz de Tab2dGente es la siguiente:\n");
            Console.Write("\n\nNombre\t\t--\tApellidos\n\n");
            for (int i = 0; i < tab2dGente.GetLength(0); i++)
            {
                for (int j = 0; j < tab2dGente.GetLength(1); j++)
                {
                    Console.Write(tab2dGente[i, j] + "\t\t\t");
                }
                Console.WriteLine();
            }
        }

        /* 4)*/
        public static string[] CargarTabApellNomb(string[,] tab2dgente, string[] vNombres)
        {
            string[] tabApellNomb = new string[vNombres.Length];

            for (int i=0; i<tabApellNomb.Length; i++)
            {

                tabApellNomb[i] = tab2dgente[i, 1] + ", " + tab2dgente[i, 0];
            }

            return tabApellNomb;
        }


        /* 5)*/
        public static void MostrarTabApellNomb(string[] tabApellNomb)
        {
            Console.WriteLine("\n\nEl vector de TabApellNomb es el siguiente:\n");

            for (int i = 0; i < tabApellNomb.Length; i++)
            {
                Console.WriteLine(tabApellNomb[i]);
            }
        }

        /* 6)*/
        public static string MostrarPersonaConMasCaracteres(string[] tabApellNomb)
        {
            string persona = "";

            for (int i = 0; i < tabApellNomb.Length; i++)
            {
                if (tabApellNomb[i].Length > persona.Length) // si al elemento de la posición por la que va recorriendo el array de tabApellNomb, tuviese una cantidad mayor de caracteres que la cantidad de caracteres que tiene nuestro string persona ...
                {
                    persona = tabApellNomb[i]; // pues que ese elemento por el que vamos que sea el que más cantidad de caracteres tenga de todos, al final final de todas las vueltas del array tabApellNomb
                }
            }

            return persona;
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
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}