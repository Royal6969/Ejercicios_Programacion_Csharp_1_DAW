using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P43a1_Proyecto_Puerta
{
    class Puerta
    {
        // ATRIBUTOS
        int alto;
        int ancho;
        ConsoleColor color;
        bool estado = false;


        // CONSTRUCTORES

        // Uno que recibe alto, ancho y color
        public Puerta(int alto, int ancho, ConsoleColor color)
        {
            this.alto = alto;
            this.ancho = ancho;
            this.color = color;
        }

        // Otro que sólo recibe los dos primeros, y se le asignará color blanco
        public Puerta(int alto, int ancho)
        {
            this.alto = alto;
            this.ancho = ancho;
            color = ConsoleColor.White;
        }


        // GETTERS Y SETTERS
        public int Alto { get => alto; set => alto = value; }
        public int Ancho { get => ancho; set => ancho = value; }
        public ConsoleColor Color { get => color; set => color = value; }
        public bool Estado { get => estado; set => estado = value; }


        // PROPIEDADES


        // MÉTODOS
        public void Abrir()
        {
            if (estado)
            {
                Console.WriteLine("\n\n\tLa puerta ya estaba abierta ...");
            }
            else
            {
                Console.WriteLine("\n\n\tHas abierto la puerta !!");
                estado = true;
            }
        }

        public void Cerrar()
        {
            if (!estado)
            {
                Console.WriteLine("\n\n\tLa puerta ya estaba cerrada ...");
            }
            else
            {
                Console.WriteLine("\n\n\tHas cerrado la puerta !!");
                estado = false;
            }
        }

        public void Mostrar()
        {
            Console.ForegroundColor = color;

            if (estado)
                Console.WriteLine("\n\n\tEstado: ABIERTA");
            else
                Console.WriteLine("\n\n\tEstado: CERADA");

            Console.WriteLine("\n\tAlto: " + alto);
            Console.WriteLine("\tAncho: " + ancho);

            Console.Write("\tColor: ████████ ");
            Console.Write(color);
            Console.WriteLine(" ◄ Este color");

            Console.ResetColor();
        }

        
    }
}
