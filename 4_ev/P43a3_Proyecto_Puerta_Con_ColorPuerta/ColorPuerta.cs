using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P43a3_Proyecto_Puerta_Con_ColorPuerta
{
    class ColorPuerta
    {
        // ATRIBUTOS
        string nombre;
        ConsoleColor color;

        // CONSTRUCTORES
        public ColorPuerta(string nombre, ConsoleColor color)
        {
            this.nombre = nombre;
            this.color = color;
        }

        // GETTERS Y SETTERS
        public string Nombre { get => nombre; set => nombre = value; }
        public ConsoleColor Color { get => color; set => color = value; }

        // PROPIEDADES

        // MÉTODOS
        public void Mostrar()
        {
            Console.ForegroundColor = color;
            Console.WriteLine("\t████████ ◄ " + nombre);
            Console.ResetColor();
        }

        // ToString
    }
}
