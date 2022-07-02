using System;

/* CapturaEntero: 
 * 
 * Construir este método que sirve para que el usuario introduzca por teclado un entero entre dos límites dados, de manera correcta, 
 * controlando los errores de formato y rango:
 * 
 * •	Recibe: Una cadena texto y dos enteros min y max y 
 * •	Hace: Presenta el texto al usuario indicándole que los límites son min y max, ambos incluidos. 
 * 
 * Cuando el usuario introduce un valor por teclado, 
 * se comprueba si hay error de formato (no es un entero lo que ha puesto) 
 * o de rango (no está entre los límites indicados).
 * 
 * Si hay error, se le muestra el mensaje correspondiente y se vuelve a pedir que introduzca el valor. 
 * Esto se repite hasta que introduzca un valor correcto.
 * •	Devuelve: El valor correcto introducido.
 * 
 * Para probar el método, lo incorporamos a la práctica de Impares Entre Límites.
*/

namespace P22a_Captura_Entero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n\nConstruir este método que sirve para que el usuario introduzca por teclado un entero entre dos límites dados, de manera correcta, controlando los errores de formato y rango");

            int rangoInferior = 100;
            int rangoSuperior = 999;

            //Console.Write("\n\tIntroduzca un valor de tres cifras para el rango inferior:\t");
            //rangoInferior = Convert.ToInt32(Console.ReadLine());

            //while (rangoInferior < 100 || rangoInferior > 999)
            //{
            //    Console.Write("\n\n\tError: El valor numérico introducido para el rango inferior no tiene tres cifras");
            //    Console.Write("\n\n\tIntroduzca un valor de tres cifras para el rango inferior:\t");
            //    rangoInferior = Convert.ToInt32(Console.ReadLine());
            //}

            //Console.Write("\n\tIntroduzca un valor de tres cifras para el rango superior:\t");
            //rangoSuperior = Convert.ToInt32(Console.ReadLine());

            //while (rangoSuperior < rangoInferior || rangoSuperior > 999)
            //{
            //    Console.Write("\n\n\t*** Error: El valor numérico introducido para el rango superior no tiene tres cifras o es menor al rangoInferior");
            //    Console.Write("\n\n\tIntroduzca un valor de tres cifras para el rango superior:\t");
            //    rangoSuperior = Convert.ToInt32(Console.ReadLine());
            //}
            
            rangoInferior = capturaEntero("\n\tDime el límite inferior de tres cifras", rangoInferior, rangoSuperior);
            rangoSuperior = capturaEntero("\n\tDime el límite superior de tres cifras", rangoInferior, rangoSuperior);
            // Con estas dos sentencias hemos sustituído todo el código anterior comentado, que además no controlaba el formato.

            cleanScreen();

            imparesEnElRango(rangoInferior, rangoSuperior);

            pararPrograma();
        }

        /************************************************** MÉTODOS ******************************************************/
        public static int capturaEntero(string texto, int min, int max) // aquí lo del string texto, parece que es para poder poner dentro de la llamada al método de capturaEntero(), el mensaje informando sobre cuál es el mínimo y el máximo del rango
        {
            int num;
            bool esUnNumero;

            do
            {
                Console.Write("\n\nEl texto es:\t" + texto);
                Console.Write("\nEl mínimo es:\t" + min);
                Console.Write("\nEl máximo es:\t" + max);
                Console.WriteLine("\n");

                // Verificamos la cadena de texto introducida por el teclado, a ver si el dato introducido por el usuario es o no un valor numérico, como el que se requiere
                esUnNumero = Int32.TryParse(Console.ReadLine(), out num);

                if (esUnNumero)
                {
                    // como se ha introducido un entero, ahora comprobamos si está en el rango correcto
                    if (num < min || num > max)
                    {
                        Console.Write("\n\nError: El número introducido está fuera del rango permitido");
                        esUnNumero = false; // aprovechamos este booleano para darle otro uso más aquí y evitar crear otro, tan solo por cambiar de true a false ...
                    }
                }
                else
                {
                    Console.WriteLine("\n\nError: El número introducido no es un valor numérico.");
                }

            } while (!esUnNumero);

            return num;
        }

        public static void imparesEnElRango(int min, int max)
        {
            int imparInicial;
            if (min % 2 == 0) // si el número del mínimo del rango es par, ya cogeré mejor el siguiente número
            {
                imparInicial = min + 1; 
            }      
            else
            {
                imparInicial = min + 2; // si el número del mínimo del rango es impar, ya cogeré mejor el siguiente número impar
            }

            Console.WriteLine("\n\tNúmeros impares entre [" + min + ", " + max + "]"); 

            presentarImparesEnColumnas(imparInicial, min, max);
        }

        public static void pararPrograma()
        {
            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }
        public static void cleanScreen()
        {
            Console.Clear();
        }
        public static void presentarImparesEnColumnas(int imparInicial, int min, int max)
        {
            Console.Write("\n\n¿En cuantas columnas desea que se presenten los números impares?:\t");
            int n_columnas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            int cuentaColumnas = 0;
            int i;
            for (i = imparInicial; i < max; i += 2) // tanto los números pares como los impares, siguen un patrón de aparación cada 2 números (uno sí y uno no), así que con solo ir sumando más 2 al contador, estaré posicionandome siempre en un número impar
            {
                Console.Write(i + "\t");
                cuentaColumnas ++;

                if (cuentaColumnas == n_columnas)
                {
                    Console.WriteLine();
                    cuentaColumnas = 0;
                }
            }

            if (i == imparInicial) // si de por sí se llega al for, y el contador fuese igual que en impar por el que se empezaría, no entraría en el for
            {
                Console.WriteLine("\n\tNo existen números impares entre [" + min + ", " + max + "]");
            }
        }
    }
}
