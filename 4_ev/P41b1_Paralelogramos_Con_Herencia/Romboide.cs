using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b1_Paralelogramos_Con_Herencia
{
    class Romboide: Rectangulo
    {
        // ATRIBUTOS
        int angulo;

        // CONSTRUCTORES
        public Romboide(string nombre, int ladoBase, int ladoLateral, int angulo) : base (nombre, ladoBase, ladoLateral)
        {
            this.angulo = angulo;
        }

        // GETTERS Y SETTERS
        public int Angulo { get => angulo; set => angulo = value; }

        // PROPIEDADES
        public override double Area
        {
            get
            {
                return LadoBase * LadoLateral * Math.Sin(angulo * Math.PI / 180);
            }
        }

        // MÉTODOS


        // ToString
        public override string ComoString()
        {
            return string.Format
                (
                    "\t{0}{1}{2}{3}{4}{5}",

                    Tools.CuadraTexto(Nombre, 16),
                    Tools.CuadraTexto(LadoBase.ToString(), 8),
                    Tools.CuadraTexto(LadoLateral.ToString(), 10),
                    Tools.CuadraTexto(angulo.ToString(), 10),
                    Tools.CuadraTexto(Perimetro.ToString(), 10),
                    Area.ToString("0.00")
                );
        }
    }
}
