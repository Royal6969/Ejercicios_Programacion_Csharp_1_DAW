using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P41a_Alumnos_Con_Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("./Datos/Alums3fNotas.txt", Encoding.Default);
            List<Alumno> studentsList = new List<Alumno>();

            string[] vLog = new string[8]; // numDNI + letraDNI + nombre + apellidos + fechaNacimiento + nota1 + nota2 + nota3 = 8 campos

            while (!streamReader.EndOfStream)
            {
                vLog = streamReader.ReadLine().Split(';');

                studentsList.Add
                (
                    new Alumno
                    (
                        Int32.Parse(vLog[0]),               // numDNI
                        char.Parse(vLog[1]),                // letraDNI
                        vLog[2],                            // nombre
                        vLog[3],                            // apellidos
                        new Fecha(Int32.Parse(vLog[4])),    // fechaNacimiento
                        float.Parse(vLog[5]),               // nota1
                        float.Parse(vLog[6]),               // nota2
                        float.Parse(vLog[7])                // nota3
                    )
                );
            }

            streamReader.Close();

            
            Console.WriteLine(" DNI\t  Edad Nombre Apellidos\t\t   N1  N2  N3 \tMedia");
            Console.WriteLine(" ---------- -- --------------------------- --- --- ---\t----");

            foreach (Alumno student in studentsList)
            {
                Console.WriteLine(student.ToString()); // podríamos no llamar al ToString() porque automáticamente coge el ToString definido con override en la clase Alumno
            }

            Tools.StopProgram();
        }

	}
}
