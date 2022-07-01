﻿using System;

/* 
 * Se pide un número cant, entre 100 y 300, 
 * un número inicial ni, entre 1000 y 2000, 
 * un número num, entre 11 y 77 
 * y un número nc, entre 3 y 9. 
 * 
 * El programa presentará los cant múltiplos de num, 
 * a partir de ni en nc columnas.
 * 
 * Ejemplo: si cant= 200, ni = 1500, num=30 y nc =6, 
 * el programa presentará los 200 primeros múltiplos de 30 a partir del 1500 en 6 columnas.
 */

namespace P14j_Presenta_En_Columnas
{
    class Program
    {
        static void Main(string[] args)
        {

            bool todo_Ok = true; // booleano a modo de comprobación general de todos los datos requeridos al usuario

            const int MIN_N_MULTIPLOS = 100;
            const int MAX_N_MULTIPLOS = 300;
            int n_multiplos;
            bool n_multiplos_Ok;

            const int MIN_MULTIPLO_INI = 1000;
            const int MAX_MULTIPLO_INI = 2000;
            int multiplo_ini;
            bool multiplo_ini_Ok;

            const int MIN_NUM = 11;
            const int MAX_NUM = 77;
            int num;
            bool num_Ok;

            const int MIN_N_COL = 3;
            const int MAX_N_COL = 9;
            int n_col;
            bool n_col_Ok;

            // hacemos todos estos booleanos para probar en este ejercicio que aún sin haber aprendido a capturar las excepciones,
            // podemos hacer que si saltase la excepción de que, al pedir uno de los datos numéricos, el usuario introduciese el número escrito en letras, por ejemplo,
            // el programa puede continuar y no se detendría ... o sea, al detectar el error durante la ejecución, 
            // se activaría el booleano que fuese, y el programa continuaría validando el dato como false, lo que haría que saltase la excepción que controla el if,
            // y el programa continuará, mandando el mensaje de error al usuario y volviéndole a pedir los datos, tal como marca el if dentro del do/while  

            do
            {
                Console.Write("\n\n1. Introduzca el número de múltiplos que quiere presentar.");
                Console.Write("\n1. Introduzca un valor para la variable n_multiplos entre el rango [" + MIN_N_MULTIPLOS + ", " + MAX_N_MULTIPLOS + "]:\t");
                //n_multiplos = Convert.ToInt32(Console.ReadLine()); // esta sería la forma normal de hacerlo, con la cual si el usuario para poner un 100, lo escribe como "cien", saltará una excepción ni controlada y el programa se parará
                // verificamos en un boolean si el usuario está introduciendo un valor con números (true) o con letras (false) ... si es (true) se saca tal valor numérico a través de la variable n_multiplos, y si es (false), n_multiplos no recibe ningún valor, y al llegar al if, salta nuestra excepción de error
                n_multiplos_Ok = Int32.TryParse(Console.ReadLine(), out n_multiplos);

                Console.Write("\n\n2. ¿A partir de qué valor deberían presentarse los múltiplos?");
                Console.Write("\n2. Introduzca un valor para la variable multiplo_ini entre el rango [" + MIN_MULTIPLO_INI + ", " + MAX_MULTIPLO_INI + "]:\t");
                //multiplo_ini = Convert.ToInt32(Console.ReadLine());
                multiplo_ini_Ok = Int32.TryParse(Console.ReadLine(), out multiplo_ini);            

                Console.Write("\n\n3. Introduzca un valor para la variable NUM entre el rango [" + MIN_NUM + ", " + MAX_NUM + "]:\t");
                //num = Convert.ToInt32(Console.ReadLine());
                num_Ok = Int32.TryParse(Console.ReadLine(), out num);           

                Console.Write("\n\n4. Introduzca un valor para la variable NC entre el rango ["+MIN_N_COL+", "+MAX_N_COL+"]:\t");
                //nc = Convert.ToInt32(Console.ReadLine());
                n_col_Ok = Int32.TryParse(Console.ReadLine(), out n_col);

                if (n_multiplos < MIN_N_MULTIPLOS || n_multiplos > MAX_N_MULTIPLOS || multiplo_ini < MIN_MULTIPLO_INI || multiplo_ini > MAX_MULTIPLO_INI || num < MIN_NUM || num > MAX_NUM || n_col < MIN_N_COL || n_col > MAX_N_COL)
                {
                    todo_Ok = false; // si algún dato numérico de los introducidos por el usuario no se encuentra dentro de su rango preestablecido, el saltará el siguiente error
                    Console.Write("\n\nError. Debe introducir los valores para las variables dentro de los rangos permitidos.");
                }

            } while (todo_Ok == false);

            Console.WriteLine();

            // El programa presentará tantos múltiplos del número, 
            // a partir de un múltiplo inicial, 
            // presentándolos en un número de columnas.

            int i = 1; // empezamos el contador del while en 1 para que el primer dividendo no sea un 0
            int cuenta_Columnas = 0; // contador para contar el número de posiciones que tabulamos hacia la derecha cada vez que imprimimos un número con el Console.Write()

            while ( i < n_multiplos + 1) // como la i empieza en 1 para que se empiece a tomar como valor de partida el 1 como dividendo ... estaría implicando de por sí una vuelta menos del while de lo que esperábamos, por eso sumamos una más al múltiplo_ini para compensar el valor 0 que perdimos al principio y que realmente se impriman n_múltiplos
            {
                Console.Write(multiplo_ini + (num * i) + "\t"); // fórmula para presentar este ejericio de múltiplos
                cuenta_Columnas ++; // ya hemos impreso un número, y tabulando, avanazamos una posición a la derecha, así que, sumamos uno al cuenta_columnas 

                if (cuenta_Columnas == n_col) // cuando el cuenta_columnas llegue al número de columnas deseado por el usuario ... 
                {
                    Console.WriteLine(); // hacemos salto de carro, y empezamos una nueva fila
                    cuenta_Columnas = 0; // debemos resetear el cuenta_columnas para que pueda volver a empezar a contar desde cero el número de posiciones a la derecha (número de columnas)
                }

                i++; // aumentamos en uno más el contador del while en cada vuelta para que sigua girando hasta llegar al límite establecido en la condición
            }

            Console.Write("\n\n\nPress any key to exit.");
            Console.ReadLine();
        }
    }
}
