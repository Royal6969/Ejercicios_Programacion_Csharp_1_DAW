/*
La clase Alumno es igual que la clase Cliente anterior, pero añade 3 notas (float). Además:
    • Se añadirá la propiedad Media, de solo lectura, 
      que devuelve la media de las tres notas con un máximo de dos decimales.

    • Tendrá un método llamado Mostrar, que presenta los datos siguientes:
        DNI completo; edad; apellidos, nombre; nota1; nota2; nota3; Media

      (La media con dos decimales, aunque sean 00)

El Main.
Se construirá una lista de objetos de tipo Alumno. 
Para construir los objetos que se cargarán en la lista, 
se obtendrán todos los datos, excepto las notas, del fichero Clientes.txt. 

Las notas se obtendrán aleatoriamente, entre 3.0 y 9.9, ambos inclusive.

A continuación,
    1. Se recorrerá la lista y se Mostrará cada alumno.
    2. Después preguntará “¿Quieres guardar los datos antes de salir? (s=Sí, n=No):”
    Si se responde Sí, se guardarán los datos de los alumnos, notas incluidas, 
    en un fichero de nombre Alums3fNotas.txt. En caso contrario, se sale sin guardar.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P40d_Proyecto_Alumnos_3_Notas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Alumno> studentsList = new List<Alumno>();

            Alumno studentTest1 = new Alumno(12345678, 'A', "Sergio", "Díaz Campos", 1995, 04, 17, 4, 5, 6);

            studentTest1.ReadFileAndSaveCustomers(studentsList);
            studentTest1.ShowCustomerList(studentsList);

            studentTest1.CreateFileOrExit(studentsList);

            Tools.StopProgram();
        }
    }
}
