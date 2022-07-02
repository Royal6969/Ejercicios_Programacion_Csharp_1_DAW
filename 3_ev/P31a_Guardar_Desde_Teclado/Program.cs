using System;
using System.IO; // necesario para el tema de ficheros
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P31a_Guardar_Desde_Teclado
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> listaFrases = new List<string>();

            StreamWriter streamWriter1 = File.CreateText("../../../../ficheros/P31a_Guardar_Desde_Teclado/Frases_1.txt"); // recordar el detalle de que el métod de CreateText() escribe y sobreescribe !!
            // si ya existiera el archivo .txt, con el método AppendText() no sobreescribiríamos, se añadiría lo nuevo al final de lo anterior.
            // recordar que el RootFolder por default donde se guardaría el archivo .txt es en el proyecto, en bin --> debug

            StreamWriter streamWriter2 = new StreamWriter("../../../../ficheros/P31a_Guardar_Desde_Teclado/Frases_2.txt", true, Encoding.Default);
            // el parámetro booleano, si es true, este StreamWriter llevará el método AppendText()
            // 

            // vamos hacer un 3º StreamWriter para que el usuario le ponga el nombre
            StreamWriter streamWriter3;

            Console.WriteLine("Comience a escribir el texto. Escribe [fin] para terminar");

            // para detectar la palabra [fin] necesitaré un string auxiliar
            string frase = Console.ReadLine();

            while (frase != "fin")
            {
                listaFrases.Add(frase);

                streamWriter1.WriteLine(frase); // y con esto escribimos la frase del usuario en el fichero_1
                streamWriter2.WriteLine(frase); // y con esto escribimos la misma frase del usuario pero en el fichero_2
                
                frase = Console.ReadLine();
            }


            Console.WriteLine("\n\n¿Nombre del fichero?\t");
            string nombreFichero = Console.ReadLine();
            streamWriter3 = new StreamWriter("../../../../ficheros/P31a_Guardar_Desde_Teclado/" + nombreFichero + ".txt", true, Encoding.Default);

            for (int i=0; i<listaFrases.Count; i++)
            {
                streamWriter3.WriteLine(listaFrases[i]);
            }

            streamWriter1.Close();
            streamWriter2.Close();
            streamWriter3.Close();

            StopProgram();
        }

        /************************************************ MÉTODOS ********************************************/

        public static void StopProgram()
        {
            Console.WriteLine("\n\n\n\n\nMuchas gracias por utilizar nuestra aplicación");
            Console.ReadKey(true);
        }
    }
}
