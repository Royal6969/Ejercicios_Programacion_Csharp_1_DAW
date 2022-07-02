using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P43a2_Proyecto_Portón_Con_Herencia
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
                Console.WriteLine("\n\n\tLa puerta " + Nombre + " ya se encuentra bloqueada ...");
            }
            else
            {
                Console.WriteLine("\n\n\tHas bloqueado la puerta " + Nombre + " !!");
                situacion = true;
            }
        }

        public void Desbloquear()
        {
            if (!situacion)
            {
                Console.WriteLine("\n\n\tLa puerta " + Nombre + " ya se encuentra desbloqueada ...");
            }
            else
            {
                Console.WriteLine("\n\n\tHas Desbloqueado la puerta " + Nombre + " !!");
                situacion = false;
            }
        }

        public override void Abrir()
        {
            if (situacion)
            {
                Console.WriteLine("\n\n\tNo puedes abrir la puerta " + Nombre + " porque se encuentra bloqueada ...");
            }
            else
            {
                if (Estado)
                {
                    Console.WriteLine("\n\n\tLa puerta " + Nombre + " ya estaba abierta ...");
                }
                else
                {
                    Console.WriteLine("\n\n\tHas abierto la puerta " + Nombre + " !!");
                    Estado = true;
                }

                // base.Abrir(); // OJO! En vez de copiar/pegar todo el método entero de Abrir() de la clase padre (Puerta), podemos llamar al método Abrir() del padre, con "base"
            }
        }

        public override void Cerrar()
        {
            if (situacion)
            {
                Console.WriteLine("\n\n\tNo puedes cerrar la puerta " + Nombre + " porque se encuentra bloqueada ...");
            }
            else
            {
                if (!Estado)
                {
                    Console.WriteLine("\n\n\tLa puerta " + Nombre + " ya estaba cerrada ...");
                }
                else
                {
                    Console.WriteLine("\n\n\tHas cerrado la puerta " + Nombre + " !!");
                    Estado = false;
                }

                // base.Abrir(); // OJO! En vez de copiar/pegar todo el método entero de Cerrar() de la clase padre (Puerta), podemos llamar al método Cerrar() del padre, con "base"
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

                        "\n\t\t\t\t\t\t\t\t\t\t\t____________",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|  __ __   |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t" + Tools.CuadraTexto(Nombre, 16) + Tools.CuadraTexto("Bloqueado", 15), Tools.CuadraTexto("Abierto", 10), Tools.CuadraTexto(Alto.ToString(), 11), Tools.CuadraTexto(Ancho.ToString(), 12), Tools.CuadraTexto(Color.ToString(), 16) + "| |  ||  | |",
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
                        "\n\t" + Tools.CuadraTexto(Nombre, 16) + Tools.CuadraTexto("Bloqueado", 15), Tools.CuadraTexto("Cerrado", 10), Tools.CuadraTexto(Alto.ToString(), 11), Tools.CuadraTexto(Ancho.ToString(), 12), Tools.CuadraTexto(Color.ToString(), 16) + "| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|  __ __() |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|__________|"
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

                        "\n\t\t\t\t\t\t\t\t\t\t\t____________",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|  __ __   |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t" + Tools.CuadraTexto(Nombre, 16) + Tools.CuadraTexto("Desbloqueado", 15), Tools.CuadraTexto("Abierto", 10), Tools.CuadraTexto(Alto.ToString(), 11), Tools.CuadraTexto(Ancho.ToString(), 12), Tools.CuadraTexto(Color.ToString(), 16) + "| |  ||  | |",
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
                        "\n\t" + Tools.CuadraTexto(Nombre, 16) + Tools.CuadraTexto("Desbloqueado", 15), Tools.CuadraTexto("Cerrado", 10), Tools.CuadraTexto(Alto.ToString(), 11), Tools.CuadraTexto(Ancho.ToString(), 12), Tools.CuadraTexto(Color.ToString(), 16) + "| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|  __ __() |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |  ||  | |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t| |__||__| |",
                        "\n\t\t\t\t\t\t\t\t\t\t\t|__________|"
                    );
                }
            }
        }

    }
}
