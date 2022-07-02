using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b1_Paralelogramos_Con_Herencia
{
    class Cuadrado
    {
        // ATRIBUTOS
        string nombre;
        int ladoBase;

        // CONSTRUCTORES
        public Cuadrado(string nombre, int ladoBase)
        {
            this.nombre = nombre;
            this.ladoBase = ladoBase;
        }

        // GETTERS Y SETTERS
        public string Nombre { get => nombre; set => nombre = value; }
        public int LadoBase { get => ladoBase; set => ladoBase = value; }

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
        public virtual string ComoString()
        {
            return string.Format
                (
                    "\t{0}{1}{2}{3}{4}{5}",

                    Tools.CuadraTexto(nombre, 16),
                    Tools.CuadraTexto(ladoBase.ToString(), 8),
                    Tools.CuadraTexto(ladoBase.ToString(), 10),
                    Tools.CuadraTexto(90.ToString(), 10),
                    Tools.CuadraTexto(Perimetro.ToString(), 10),
                    Area.ToString("0.00")
                );
        }
    }
}
