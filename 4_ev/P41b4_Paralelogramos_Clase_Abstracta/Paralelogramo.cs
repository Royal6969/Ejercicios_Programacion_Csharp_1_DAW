using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b4_Paralelogramos_Clase_Abstracta
{
    abstract class Paralelogramo
    {
        // ATRIBUTOS
        string nombre;
        int ladoBase;
        int ladoLateral;
        int angulo;

        // CONSTRUCTORES
        protected Paralelogramo(string nombre, int ladoBase, int ladoLateral, int angulo) // wow, VS lo ha generado #Protected
        {
            this.nombre = nombre;
            this.ladoBase = ladoBase;
            this.ladoLateral = ladoLateral;
            this.angulo = angulo;
        }

        // GETTERS Y SETTERS
        public string Nombre { get => nombre; set => nombre = value; }
        public int LadoBase { get => ladoBase; set => ladoBase = value; }
        public int LadoLateral { get => ladoLateral; set => ladoLateral = value; }
        public int Angulo { get => angulo; set => angulo = value; }

        // PROPIEDADES
        public abstract int Perimetro { get; }
        public abstract double Area { get; }

        // MÉTODOS

        // ToString
        public override string ToString()
        {
            return string.Format
                (
                    "\t{0}{1}{2}{3}{4}{5}",

                    Tools.CuadraTexto(nombre, 16),
                    Tools.CuadraTexto(ladoBase.ToString(), 8),
                    Tools.CuadraTexto(ladoLateral.ToString(), 10),
                    Tools.CuadraTexto(angulo.ToString(), 10),
                    Tools.CuadraTexto(Perimetro.ToString(), 10),
                    Area.ToString("0.00")
                );
        }
    }
}
