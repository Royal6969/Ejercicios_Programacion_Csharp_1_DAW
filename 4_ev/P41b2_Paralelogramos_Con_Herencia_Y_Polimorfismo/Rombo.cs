using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b2_Paralelogramos_Con_Herencia_Y_Polimorfismo
{
    class Rombo : Cuadrado
    {
        // ATRIBUTOS
        int angulo;

        // CONSTRUCTORES
        public Rombo(string nombre, int ladoBase, int angulo) : base (nombre, ladoBase)
        {
            this.angulo = angulo;
        }

        // GETTERS Y SETTERS
        public int Angulo { get => angulo; set => angulo = value; }

        // PROPIEDADES

        // MÉTODOS


        // ToString
        public override string ComoString()
        {
            return string.Format
                (
                    "\t{0}{1}{2}{3}{4}{5}",

                    Tools.CuadraTexto(Nombre, 16),
                    Tools.CuadraTexto(LadoBase.ToString(), 8),
                    Tools.CuadraTexto(LadoBase.ToString(), 10),
                    Tools.CuadraTexto(angulo.ToString(), 10),
                    Tools.CuadraTexto(Perimetro.ToString(), 10),
                    Area.ToString("0.00")
                );
        }
    }
}
