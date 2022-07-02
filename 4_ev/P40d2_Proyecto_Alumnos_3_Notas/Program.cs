/*
Modificar la práctica anterior del siguiente modo:

El Main.

Se construirá una lista de objetos de tipo Alumno. 
Para construir los objetos que se cargarán en la lista, se obtendrán todos los datos del fichero Alums3fNotas.txt.

A continuación,
    
1. Se recorrerá la lista y se Mostrará cada alumno.
2. Después preguntará “¿Quieres Modificar alguna nota? (s=Sí, n=No):”

Si se responde Sí, Pedirá el número de dni del alumno cuya nota se quiere modificar 
y se presentará cada nota preguntando “¿Modificar? (s=Sí, n=No):” y se actuará en consecuencia.

3. Se repetirá el punto 2 hasta que se responda que no.
4. Si se ha modificado alguna nota preguntará 
“¿Quieres guardar los cambios antes de salir? (s=Sí, n=No):” y se actuará en consecuencia.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P40d2_Proyecto_Alumnos_3_Notas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Alumno> studentsList = new List<Alumno>();

            Alumno.ReadFileAndSaveStudents(studentsList);
            Alumno.ShowCustomerList(studentsList);

            Alumno.SaveChangesOrNo(studentsList);

            Tools.StopProgram();
        }
    }
}

