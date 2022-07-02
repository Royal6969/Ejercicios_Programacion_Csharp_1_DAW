using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b2_Paralelogramos_Con_Herencia_Y_Polimorfismo
{
    class Rectangulo
    {
        // ATRIBUTOS
        string nombre;
        int ladoBase;
        int ladoLateral;

        // CONSTRUCTORES
        public Rectangulo(string nombre, int ladoBase, int ladoLateral)
        {
            this.nombre = nombre;
            this.ladoBase = ladoBase;
            this.ladoLateral = ladoLateral;
        }

        // GETTERS Y SETTERS
        public string Nombre { get => nombre; set => nombre = value; }
        public int LadoBase { get => ladoBase; set => ladoBase = value; }
        public int LadoLateral { get => ladoLateral; set => ladoLateral = value; }

        // PROPIEDADES
        public virtual int Perimetro
        {
            get
            {
                return (ladoBase * 2) + (ladoLateral * 2);
            }
        }

        public virtual double Area
        {
            get
            {
                return ladoBase * ladoLateral;
            }
        }

        // MÉTODOS


        // ToString
        public virtual string ComoString()
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
