using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Persona_Entrenamiento
{
    class Persona
    {
        // ATRIBUTOS
        string nombre;
        string apellidos;
        int dia, mes, año;

        // CONSTRUCTOR
        public Persona(string nombre, string apellidos, int dia, int mes, int año) 
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.dia = dia;
            this.mes = mes;
            this.año = año;
        }

        public Persona(string nombre, string apellidos) // sobrecarga 2
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            dia = 1;
            mes = 1;
            año = 1500;
        }

        // MÉTODOS
        public void Mostrar()
        {
            Console.WriteLine("\n\n" + nombre + " " + apellidos + ", nacido el " + dia + " de " + mes + " el " + año);
        }
    }

    /***************************************************************************************************************/

    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona("Sergio", "Díaz Campos", 17, 4, 1995);
            //p1.Mostrar();

            Persona p2 = new Persona("Jaime", "el Cocainómano");
            //p2.Mostrar();

            Persona[] vPersonas = { p1, p2 };

            foreach (Persona persona in vPersonas)
            {
                persona.Mostrar();
            }

            /*
            for (int i = 0; i < vPersonas.Length; i++)
            {
                vPersonas[i].Mostrar();
            }
            */

            StopProgram();
        }

        /********************************** MÉTODOS *****************************/

        public static void StopProgram()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}
