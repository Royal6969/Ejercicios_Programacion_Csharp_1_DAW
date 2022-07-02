using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b4_Paralelogramos_Clase_Abstracta
{
    class Romboide : Paralelogramo
    {
        // ATRIBUTOS

        // CONSTRUCTORES
        public Romboide(string nombre, int ladoBase, int ladoLateral, int angulo) : base (nombre, ladoBase, ladoLateral, angulo) { }

        // GETTERS Y SETTERS

        // PROPIEDADES
        public override int Perimetro
        {
            get
            {
                return (LadoBase * 2) + (LadoLateral * 2);
            }
        }

        public override double Area
        {
            get
            {
                return LadoBase * LadoLateral * Math.Sin(Angulo * Math.PI / 180);
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
                    Tools.CuadraTexto(LadoLateral.ToString(), 10),
                    Tools.CuadraTexto(Angulo.ToString(), 10),
                    Tools.CuadraTexto(Perimetro.ToString(), 10),
                    Area.ToString("0.00")
                );
        }
    }
}
