using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b3_Paralelogramos_Polimorfismo_Y_Menu
{
    class Rectangulo : Rombo
    {
        // ATRIBUTOS
        int ladoLateral;

        // CONSTRUCTORES
        // public Rectangulo(string nombre, int ladoBase, int ladoLateral) : base (nombre, ladoBase, angulo) // "Rombo.romboide" angulo no es accesible debido a su nivel de protección
        public Rectangulo(string nombre, int ladoBase, int ladoLateral, int angulo) : base(nombre, ladoBase, angulo) // solución de VS --> generar el parámetro ángulo
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
        public override string ToString()
        {
            return string.Format
                (
                    "\t{0}{1}{2}{3}{4}{5}",

                    Tools.CuadraTexto(Nombre, 16),
                    Tools.CuadraTexto(LadoBase.ToString(), 8),
                    Tools.CuadraTexto(ladoLateral.ToString(), 10),
                    Tools.CuadraTexto(Angulo.ToString(), 10),
                    Tools.CuadraTexto(Perimetro.ToString(), 10),
                    Area.ToString("0.00")
                );
        }
    }
}
