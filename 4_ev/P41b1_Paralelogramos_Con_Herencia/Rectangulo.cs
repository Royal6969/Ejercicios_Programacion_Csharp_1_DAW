using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b1_Paralelogramos_Con_Herencia
{
    class Rectangulo: Cuadrado
    {
        // ATRIBUTOS
        int ladoLateral;

        // CONSTRUCTORES
        public Rectangulo(string nombre, int ladoBase, int ladoLateral) :base (nombre, ladoBase)
        {
            this.ladoLateral = ladoLateral;
        }

        // GETTERS Y SETTERS
        public int LadoLateral { get => ladoLateral; set => ladoLateral = value; }

        // PROPIEDADES
        public override int Perimetro
        {
            get
            {
                return (LadoBase * 2) + (ladoLateral * 2);
            }
        }

        public override double Area
        {
            get
            {
                return LadoBase * ladoLateral;
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
                    Tools.CuadraTexto(ladoLateral.ToString(), 10),
                    Tools.CuadraTexto(90.ToString(), 10),
                    Tools.CuadraTexto(Perimetro.ToString(), 10),
                    Area.ToString("0.00")
                );
        }
    }
}
