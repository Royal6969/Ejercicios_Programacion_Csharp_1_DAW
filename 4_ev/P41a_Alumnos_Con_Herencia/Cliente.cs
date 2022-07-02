using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P41a_Alumnos_Con_Herencia
{
    class Cliente
    {
        // ATRIBUTOS
        int numDNI; 
        char letraDNI; 
        string nombre; 
        string apellidos;
        Fecha fechaNac;


        // CONSTRUCTORES

        // el constructor que recibe todos los campos
        public Cliente(int numDNI, char letraDNI, string nombre, string apellidos, Fecha fechaNac)
        {
            this.numDNI = numDNI;
            this.letraDNI = letraDNI;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
        }


        // GETTERS Y SETTERS
        public int NumDNI { get => numDNI; set => numDNI = value; }
        public char LetraDNI { get => letraDNI; set => letraDNI = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public Fecha FechaNac { get => fechaNac; set => fechaNac = value; }


        // PROPIEDADES 
        public byte Edad
        {
            get
            {
                int diaHoy = DateTime.Now.Day;
                int mesHoy = DateTime.Now.Month;
                int añoHoy = DateTime.Now.Year;

                // int edad = añoHoy - fechaNac;
                int edad = añoHoy - fechaNac.Año;

                // todavía no ha cumplido este año así que hay que restarle uno
                // el enfoque correcto está en NO calcular dias o meses "excedentes" para sumar meses o días, sino el de restar para corregir el desfase de dias y meses
                // if ((mesHoy < mes) || (mesHoy == mes && diaHoy < dia))
                if ((mesHoy < fechaNac.Mes) || (mesHoy == fechaNac.Mes && diaHoy < fechaNac.Dia))
                {
                    edad --;
                }

                return (byte)edad;
            }
        }

        // ToString
        public override string ToString()
        {
            return String.Format
            (
                "\t{0}-{1} {2} {3}", 
                
                numDNI, 
                letraDNI,
                Tools.CuadraTexto((nombre + " " + apellidos), 27),
                fechaNac.FechaStringSp
            );
        }
    }
}
