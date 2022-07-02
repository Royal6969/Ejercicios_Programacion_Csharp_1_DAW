using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b0_Paralelogramos_Sin_Herencia
{
    class Romboide
    {
        // ATRIBUTOS
        string nombre;
        int ladoBase;
        int ladoLateral;
        int angulo;

        // CONSTRUCTORES
        public Romboide(string nombre, int ladoBase, int ladoLateral, int angulo)
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
        public int Perimetro
        {
            get
            {
                return (ladoBase * 2) + (ladoLateral * 2);
            }
        }

        public double Area
        {
            get
            {
                return ladoBase * LadoLateral * Math.Sin(angulo * Math.PI / 180);
            }
        }

        // MÉTODOS


        // ToString
        public string RomboideAString()
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
