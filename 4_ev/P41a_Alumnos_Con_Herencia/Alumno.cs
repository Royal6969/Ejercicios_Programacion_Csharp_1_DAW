using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P41a_Alumnos_Con_Herencia
{
    class Alumno : Cliente
    {
        // ATRIBUTOS
        float nota1;
        float nota2;
        float nota3;


        // CONSTRUCTORES
        public Alumno(int numDNI, char letraDNI, string nombre, string apellidos, Fecha fechaNac, float nota1, float nota2, float nota3)
              : base (numDNI, letraDNI, nombre, apellidos, fechaNac)
        {
            this.nota1 = nota1;
            this.nota2 = nota2;
            this.nota3 = nota3;
        }

        #region SOBRECARGAS CONSTRUCTORES

        // el que recibe el dia, mes y año, y los usa para crear directamente una nueva Fecha
        public Alumno(int numDNI, char letraDNI, string nombre, string apellidos, int año, byte mes, byte dia, Fecha fechaNac, float nota1, float nota2, float nota3)
            : base(numDNI, letraDNI, nombre, apellidos, fechaNac)
        {
            this.NumDNI = numDNI;
            this.LetraDNI = letraDNI;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            FechaNac = new Fecha(año, mes, dia);
            this.nota1 = nota1;
            this.nota2 = nota2;
            this.nota3 = nota3;
        }

        // el que construye al alumno a partir de la línea de registro
        public Alumno(string registro, int numDNI, char letraDNI, string nombre, string apellidos, Fecha fechaNac)
            : base(numDNI, letraDNI, nombre, apellidos, fechaNac)
        {
            string[] vLog = registro.Split(';');

            numDNI = Convert.ToInt32(vLog[0]);
            letraDNI = vLog[1][0]; // el caracter estará en la primera posición de la cadena (sólo hay una)
            apellidos = vLog[2].Trim(); // <-- Hago .Trim() por si tienen espacios por los laterales
            nombre = vLog[3].Trim();

            int año;
            byte mes, dia;
            año = Convert.ToInt32(vLog[4]);

            // convertimos a cuatro cifras, porque en el fichero sólo aparecen las dos últimas
            año += año < 50 ? 2000 : 1900;

            mes = Convert.ToByte(vLog[5]);
            dia = Convert.ToByte(vLog[6]);
            fechaNac = new Fecha(año, mes, dia);
        }
        #endregion

        // GETTERS Y SETTERS
        public float Nota1 { get => nota1; set => nota1 = value; }
        public float Nota2 { get => nota2; set => nota2 = value; }
        public float Nota3 { get => nota3; set => nota3 = value; }


        // PROPIEDADES
        public float Media
        {
            get
            {
                return (nota1 + nota2 + nota3) / 3;
            }
        }


        // MÉTODOS


        // ToString
        public override string ToString()
        {
            return String.Format
            (
                " {0}-{1} {2} {3} {4} {5} {6}\t{7}",

                NumDNI, 
                LetraDNI, 
                Edad,
                Tools.CuadraTexto((Nombre + " " + Apellidos), 27),
                nota1.ToString("0.0"), 
                nota2.ToString("0.0"), 
                nota3.ToString("0.0"), 
                Media.ToString("0.00")
            );
        }
    }
}
