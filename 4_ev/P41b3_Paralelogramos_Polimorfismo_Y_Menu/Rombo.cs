using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b3_Paralelogramos_Polimorfismo_Y_Menu
{
    class Rombo
    {
        // ATRIBUTOS
        string nombre;
        int ladoBase;
        int angulo;

        // CONSTRUCTORES
        public Rombo(string nombre, int ladoBase, int angulo)
        {
            this.nombre = nombre;
            this.ladoBase = ladoBase;
            this.angulo = angulo;
        }

        // GETTERS Y SETTERS
        public string Nombre { get => nombre; set => nombre = value; }
        public int LadoBase { get => ladoBase; set => ladoBase = value; }
        public int Angulo { get => angulo; set => angulo = value; }

        // PROPIEDADES
        public virtual int Perimetro
        {
            get
            {
                return ladoBase * 4;
            }
        }

        public virtual double Area
        {
            get
            {
                return Math.Pow(ladoBase, 2);
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
                    Tools.CuadraTexto(angulo.ToString(), 10),
                    Tools.CuadraTexto(Perimetro.ToString(), 10),
                    Area.ToString("0.00")
                );
        }
    }
}
