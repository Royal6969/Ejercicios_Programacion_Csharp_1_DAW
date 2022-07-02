using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P43a2_Proyecto_Portón_Con_Herencia
{
    class Puerta
    {
        // ATRIBUTOS
        string nombre;
        int alto;
        int ancho;
        ConsoleColor color;
        bool estado = false; // cerrada


        // CONSTRUCTORES

        public Puerta(string nombre, int alto, int ancho, ConsoleColor color)
        {
            this.nombre = nombre;
            this.alto = alto;
            this.ancho = ancho;
            this.color = color;
        }

        public Puerta(string nombre, int alto, int ancho)
        {
            this.nombre= nombre;
            this.alto = alto;
            this.ancho = ancho;
            color = ConsoleColor.White;
        }


        // GETTERS Y SETTERS
        public int Alto { get => alto; set => alto = value; }
        public int Ancho { get => ancho; set => ancho = value; }
        public ConsoleColor Color { get => color; set => color = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string Nombre { get => nombre; set => nombre = value; }


        // PROPIEDADES


        // MÉTODOS
        public virtual void Abrir()
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

        public virtual void Cerrar()
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

        public virtual void Mostrar()
        {
            Console.ForegroundColor = color;

            if (estado)
                Console.WriteLine("\n\n\tEstado: ABIERTA");
            else
                Console.WriteLine("\n\n\tEstado: CERADA");

            Console.WriteLine("\n\tNombre: " + nombre);
            Console.WriteLine("\n\tAlto: " + alto);
            Console.WriteLine("\tAncho: " + ancho);

            Console.Write("\tColor: ████████ ");
            Console.Write(color);
            Console.WriteLine(" ◄ Este color");

            Console.ResetColor();
        }

        // ToString normal (original)
        public override string ToString()
        {
            if (estado)
            {
                Console.ForegroundColor = color;

                return String.Format
                (
                    "{0}{1}{2}{3}{4}",

                    "\n\n\tEstado: Abierta",
                    "\n\tNombre: " + nombre,
                    "\n\tAlto: " + alto,
                    "\n\tAncho: " + ancho,
                    "\n\tColor: ████████ " + color + " ◄ Este color"
                );
            }
            else
            {
                Console.ForegroundColor = color;

                return String.Format
                (
                    "{0}{1}{2}{3}{4}",

                    "\n\n\tEstado: Cerrada",
                    "\n\tNombre: " + nombre,
                    "\n\tAlto: " + alto,
                    "\n\tAncho: " + ancho,
                    "\n\tColor: ████████ " + color + " ◄ Este color"
                );
            }
        }

        // ToString CON DIBUJO - Vertical
        public string ToString_ConDibujo_Vertical()
        {
            if (estado)
            {
                Console.ForegroundColor = color;

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
                    "\n\tColor: ████████ " + color + " ◄ Este color\t| |__||__| |",

                    "\n\t\t\t\t\t\t|__________|"
                );
            }
            else
            {
                Console.ForegroundColor = color;

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
                    "\n\tColor: ████████ " + color + " ◄ Este color\t| |__||__| |",

                    "\n\t\t\t\t\t\t|__________|"
                );
            }
        }

        // ToString CON DIBUJO - Horizontal
        public virtual string ToString_ConDibujo()
        {
            if (estado)
            {
                Console.ForegroundColor = Color;

                return string.Format
                    (
                        "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",

                        "\n\t\t\t\t\t\t\t\t\t\t\t____________",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|  __ __   |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t" + Tools.CuadraTexto(Nombre, 31) + Tools.CuadraTexto("Abierto", 25), Tools.CuadraTexto(Alto.ToString(), 11), Tools.CuadraTexto(Ancho.ToString(), 11), Tools.CuadraTexto(Color.ToString(), 17) + "| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|  __ __() |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|__________|"
                    );
            }
            else
            {
                Console.ForegroundColor = Color;

                return string.Format
                    (
                        "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",

                        "\n\t\t\t\t\t\t\t\t\t\t\t____________",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|  __ __   |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t" + Tools.CuadraTexto(Nombre, 31) + Tools.CuadraTexto("Cerrado", 25), Tools.CuadraTexto(Alto.ToString(), 11), Tools.CuadraTexto(Ancho.ToString(), 11), Tools.CuadraTexto(Color.ToString(), 17) + "| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|  __ __() |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|__________|"
                    );
            }
        }

        /*
        ____________
        |  __ __   |
        | |  ||  | |
        | |  ||  | |
        | |__||__| |
        |  __ __()||
        | |  ||  | |
        | |  ||  | |
        | |__||__| |
        |__________|
        */
    }
}
