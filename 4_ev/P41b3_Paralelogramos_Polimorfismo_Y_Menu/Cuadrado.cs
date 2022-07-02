using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b3_Paralelogramos_Polimorfismo_Y_Menu
{
    class Cuadrado : Rombo
    {
        // ATRIBUTOS

        // CONSTRUCTORES
        public Cuadrado(string nombre, int ladoBase, int angulo) : base (nombre, ladoBase, angulo) { } // generamos el parámetro angulo con la ayuda de VS

        // GETTERS Y SETTERS

        // PROPIEDADES

        // MÉTODOS

        // ToString
        public override string ToString()
        {
            return string.Format
                (
                    "\t{0}{1}{2}{3}{4}{5}",

                    Tools.CuadraTexto(Nombre, 16),
                    Tools.CuadraTexto(LadoBase.ToString(), 8),
                    Tools.CuadraTexto(LadoBase.ToString(), 10),
                    Tools.CuadraTexto(Angulo.ToString(), 10),
                    Tools.CuadraTexto(Perimetro.ToString(), 10),
                    Area.ToString("0.00")
                );
        }
    }
}
