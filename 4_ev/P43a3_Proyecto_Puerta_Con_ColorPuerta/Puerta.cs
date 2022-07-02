using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P43a3_Proyecto_Puerta_Con_ColorPuerta
{
    class Puerta
    {
        // ATRIBUTOS
        string nombre;
        int alto;
        int ancho;
        bool estado = false;
        //ConsoleColor color;
        ColorPuerta color;


        // CONSTRUCTORES
        public Puerta(string nombre, int alto, int ancho)
        {
            this.nombre = nombre;
            this.alto = alto;
            this.ancho = ancho;
        }

        public Puerta(string nombre, int alto, int ancho, ColorPuerta color)
        {
            this.nombre = nombre;
            this.alto = alto;
            this.ancho = ancho;
            this.color = color;
        }

        /*
        public Puerta(string nombre, int alto, int ancho) // vProfesor
        {
            this.nombre = nombre;
            this.alto = alto;
            this.ancho = ancho;
            this.color = new ColorPuerta("white", ConsoleColor.White);
        }
        */


        // GETTERS Y SETTERS
        public int Alto { get => alto; set => alto = value; }
        public int Ancho { get => ancho; set => ancho = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public ColorPuerta Color { get => color; set => color = value; }


        // PROPIEDADES
        /*
        public string Estado
        {
            get
            {
                if (estado)
                {
                    return "abierta";
                }
                else
                {
                    return "cerrada";
                }
            }
        }
        */

        // MÉTODOS
        public void Abrir()
        {
            if (estado)
            {
                Console.WriteLine("\n\n\tLa puerta " + nombre + " ya estaba abierta ...");
            }
            else
            {
                Console.WriteLine("\n\n\tHas abierto la puerta " + nombre + " !!");
                estado = true;
            }
        }

        public void Cerrar()
        {
            if (!estado)
            {
                Console.WriteLine("\n\n\tLa puerta " + nombre + " ya estaba cerrada ...");
            }
            else
            {
                Console.WriteLine("\n\n\tHas cerrado la puerta " + nombre + " !!");
                estado = false;
            }
        }

        public void Mostrar()
        {
            Console.ForegroundColor = color.Color;

            if (estado)
                Console.WriteLine("\n\n\tEstado: ABIERTA");
            else
                Console.WriteLine("\n\n\tEstado: CERADA");

            Console.WriteLine("\n\tNombre: " + nombre);
            Console.WriteLine("\n\tAlto: " + alto);
            Console.WriteLine("\tAncho: " + ancho);

            Console.Write("\tColor: ████████ ");
            Console.Write(color.Nombre);
            Console.WriteLine(" ◄ Este color");

            Console.ResetColor();
        }

        // ToString
        public override string ToString()
        {
            if (estado)
            {
                Console.ForegroundColor = color.Color;

                return String.Format
                (
                    "{0}{1}{2}{3}{4}",

                    "\n\n\tEstado: Abierta",
                    "\n\tNombre: " + nombre,
                    "\n\tAlto: " + alto,
                    "\n\tAncho: " + ancho,
                    // "\n\tColor: ████████ " + color + " ◄ Este color"
                    "\n\tColor: " + color.Nombre + " ◄ Este color"
                );
            }
            else
            {
                Console.ForegroundColor = color.Color;

                return String.Format
                (
                    "{0}{1}{2}{3}{4}",

                    "\n\n\tEstado: Cerrada",
                    "\n\tNombre: " + nombre,
                    "\n\tAlto: " + alto,
                    "\n\tAncho: " + ancho,
                    // "\n\tColor: ████████ " + color + " ◄ Este color"
                    "\n\tColor: " + color.Nombre + " ◄ Este color"
                );
            }
        }

        // ToString
        public string ToString_ConDibujo()
        {
            if (estado)
            {
                Console.ForegroundColor = color.Color;

                return String.Format
                (
                    "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",

                    "\n\n\t\t\t\t\t\t____________",
                    "\n\t\t\t\t\t\t|  __ __   |",
                    "\n\t\t\t\t\t\t| |  ||  | |",
                    "\n\t\t\t\t\t\t| |  ||  | |",

                    "\n\tEstado: Abierta\t\t\t\t| |__||__| |",
                    "\n\tNombre: " + nombre + "\t\t\t\t|  __ __() |",
                    "\n\tAlto: " + alto + "\t\t\t\t| |  ||  | |",
                    "\n\tAncho: " + ancho + "\t\t\t\t| |  ||  | |",
                    // "\n\tColor: ████████ " + color + " ◄ Este color\t| |__||__| |",
                    "\n\tColor: " + color.Nombre + " ◄ Este color\t| |__||__| |",

                    "\n\t\t\t\t\t\t|__________|"
                );
            }
            else
            {
                Console.ForegroundColor = color.Color;

                return String.Format
                (
                    "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",

                    "\n\n\t\t\t\t\t\t____________",
                    "\n\t\t\t\t\t\t|  __ __   |",
                    "\n\t\t\t\t\t\t| |  ||  | |",
                    "\n\t\t\t\t\t\t| |  ||  | |",

                    "\n\tEstado: Cerrada\t\t\t\t| |__||__| |",
                    "\n\tNombre: " + nombre + "\t\t\t\t|  __ __() |",
                    "\n\tAlto: " + alto + "\t\t\t\t| |  ||  | |",
                    "\n\tAncho: " + ancho + "\t\t\t\t| |  ||  | |",
                    // "\n\tColor: ████████ " + color + " ◄ Este color\t| |__||__| |",
                    "\n\tColor: " + color.Nombre + " ◄ Este color\t\t| |__||__| |",

                    "\n\t\t\t\t\t\t|__________|"
                );
            }
        }

    }
}
