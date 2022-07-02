using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b4_Paralelogramos_Clase_Abstracta
{
    class Rombo : Paralelogramo
    {
        // ATRIBUTOS

        // CONSTRUCTORES
        public Rombo(string nombre, int ladoBase, int angulo) : base (nombre, ladoBase, ladoBase, angulo) { }

        // GETTERS Y SETTERS

        // PROPIEDADES
        public override int Perimetro
        {
            get
            {
                return LadoBase * 4;
            }
        }

        public override double Area
        {
            get
            {
                return Math.Pow(LadoBase, 2);
            }
        }

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
