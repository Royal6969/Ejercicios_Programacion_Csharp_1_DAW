using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P40f_Menu_Dinamico
{
    class Porton : Puerta
    {
        // ATRIBUTOS
        bool situacion = false; // desbloqueada


        // CONSTRUCTORES
        public Porton(string nombre, int alto, int ancho, ConsoleColor color) // recibe el color
              : base(nombre, alto, ancho, color)
        { }

        public Porton(string nombre, int alto, int ancho) // no recibe el color
              : base(nombre, alto, ancho)
        { }


        // GETTERS Y SETTERS
        public bool Situacion { get => situacion; set => situacion = value; }


        // PROPIEDADES


        // MÉTODOS
        public void Bloquear()
        {
            if (situacion)
            {
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\n\tLa puerta " + Nombre + " ya se encuentra bloqueada ...");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n\n\tHas bloqueado la puerta " + Nombre + " !!");
                Console.ResetColor();
                situacion = true;
            }
        }

        public void Desbloquear()
        {
            if (!situacion)
            {
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\n\tLa puerta " + Nombre + " ya se encuentra desbloqueada ...");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n\n\tHas Desbloqueado la puerta " + Nombre + " !!");
                Console.ResetColor();
                situacion = false;
            }
        }

        public override void Abrir()
        {
            if (situacion)
            {
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\n\tNo puedes abrir la puerta " + Nombre + " porque se encuentra bloqueada ...");
                Console.ResetColor();
            }
            else
            {
                base.Abrir();
            }
        }

        public override void Cerrar()
        {
            if (situacion)
            {
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\n\tNo puedes cerrar la puerta " + Nombre + " porque se encuentra bloqueada ...");
                Console.ResetColor();
            }
            else
            {
                base.Cerrar();
            }
        }

        public override void Mostrar()
        {
            Console.ForegroundColor = Color;

            if (situacion)
                Console.WriteLine("\n\n\tSituación: BLOQUEADA");
            else
                Console.WriteLine("\tSituación: DESBLOQUEADA");

            if (Estado)
                Console.WriteLine("\tEstado: ABIERTA");
            else
                Console.WriteLine("\tEstado: CERADA");

            Console.WriteLine("\tNombre: " + Nombre);
            Console.WriteLine("\tAlto: " + Alto);
            Console.WriteLine("\tAncho: " + Ancho);

            Console.Write("\tColor: ████████ ");
            Console.Write(Color);
            Console.WriteLine(" ◄ Este color");

            Console.ResetColor();
        }


        // ToString
        public override string ToString_ConDibujo()
        {
            if (situacion)
            {
                if (Estado)
                {
                    Console.ForegroundColor = Color;

                    return string.Format
                    (
                        "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",

                        "\n\t\t\t\t\t\t\t\t\t\t\t     ____________",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |  __ __   |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t" + Tools.CuadraTexto(Nombre, 16) + Tools.CuadraTexto("Bloqueado", 15), Tools.CuadraTexto("Abierto", 10), Tools.CuadraTexto(Alto.ToString(), 11), Tools.CuadraTexto(Ancho.ToString(), 12), Tools.CuadraTexto(Color.ToString(), 10), Tools.CuadraTexto("Porton", 11) + "| | ()() | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |  __ __() |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |__________|"
                    );
                }
                else
                {
                    Console.ForegroundColor = Color;

                    return string.Format
                    (
                        "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",

                        "\n\t\t\t\t\t\t\t\t\t\t\t     ____________",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |  __ __   |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t" + Tools.CuadraTexto(Nombre, 16) + Tools.CuadraTexto("Bloqueado", 15), Tools.CuadraTexto("Cerrado", 10), Tools.CuadraTexto(Alto.ToString(), 11), Tools.CuadraTexto(Ancho.ToString(), 12), Tools.CuadraTexto(Color.ToString(), 10), Tools.CuadraTexto("Porton", 11) + "| | ()() | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |  __ __() |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |__________|"
                    );
                }
            }
            else
            {
                if (Estado)
                {
                    Console.ForegroundColor = Color;

                    return string.Format
                    (
                        "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",

                        "\n\t\t\t\t\t\t\t\t\t\t\t     ____________",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |  __ __   |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t" + Tools.CuadraTexto(Nombre, 16) + Tools.CuadraTexto("Desbloqueado", 15), Tools.CuadraTexto("Abierto", 10), Tools.CuadraTexto(Alto.ToString(), 11), Tools.CuadraTexto(Ancho.ToString(), 12), Tools.CuadraTexto(Color.ToString(), 10), Tools.CuadraTexto("Porton", 11) + "| | ()() | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |  __ __() |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |__________|"
                    );
                }
                else
                {
                    Console.ForegroundColor = Color;

                    return string.Format
                    (
                        "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}",

                        "\n\t\t\t\t\t\t\t\t\t\t\t     ____________",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |  __ __   |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t" + Tools.CuadraTexto(Nombre, 16) + Tools.CuadraTexto("Desbloqueado", 15), Tools.CuadraTexto("Cerrado", 10), Tools.CuadraTexto(Alto.ToString(), 11), Tools.CuadraTexto(Ancho.ToString(), 12), Tools.CuadraTexto(Color.ToString(), 10), Tools.CuadraTexto("Porton", 11) + "| | ()() | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |  __ __() |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     | |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t     |__________|"
                    );
                }
            }
        }

    }
}
