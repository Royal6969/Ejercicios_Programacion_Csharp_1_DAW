using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P41a_Alumnos_Con_Herencia
{
    class Program2
    {
        static void Main2(string[] args)
        {
            StreamReader streamReader = new StreamReader("./Datos/Alums3fNotas.txt", Encoding.Default);
            // List<Alumno> studentsList = new List<Alumno>();
            Alumno alumno;

            string[] vLog = new string[8]; // numDNI + letraDNI + nombre + apellidos + fechaNacimiento + nota1 + nota2 + nota3 = 8 campos

            Console.WriteLine(" DNI\t  Edad Nombre Apellidos\t\t   N1  N2  N3 \tMedia");
            Console.WriteLine(" ---------- -- --------------------------- --- --- ---\t----");

            while (!streamReader.EndOfStream)
            {
                vLog = streamReader.ReadLine().Split(';');

                // studentsList.Add(...)
                alumno = new Alumno
                (
                    Int32.Parse(vLog[0]),
                    char.Parse(vLog[1]),
                    vLog[2],
                    vLog[3],
                    new Fecha(Int32.Parse(vLog[4])),
                    float.Parse(vLog[5]),
                    float.Parse(vLog[6]),
                    float.Parse(vLog[7])
                );

                Console.WriteLine(alumno);
            }

            streamReader.Close();

            Tools.StopProgram();
        }

	}
}
