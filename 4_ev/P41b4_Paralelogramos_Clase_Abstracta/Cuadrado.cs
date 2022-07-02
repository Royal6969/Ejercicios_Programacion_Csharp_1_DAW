using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41b4_Paralelogramos_Clase_Abstracta
{
    class Cuadrado : Paralelogramo
    {
        // ATRIBUTOS

        // CONSTRUCTORES
        // Cuadrado(string nombre, int ladoBase, int angulo) : base (nombre, ladoBase, ladoBase, angulo) { } // esta forma NO es la adecuada. Desventajas --> No se debería permitir poner ningún ángulo por si se pudiera poner uno diferente a 90 ... y a parte tendríamos que definir el (override) ToString
        public Cuadrado(string nombre, int ladoBase) : base(nombre, ladoBase, ladoBase, 90) { } // de esta forma no se permite poner ningún ángulo, para que sea estrictamente 90, y a parte, ya podemos quitar entero el ToString

        // GETTERS Y SETTERS
        public override int Perimetro
        {
            get
            {
                return LadoBase * 4;
            }
        }
        
        public override double Area 
        { 
            get
            {
                return Math.Pow(LadoBase, 2);
            }
        }

        // MÉTODOS

        // ToString
        /*
        public override string ToString()
        {
            return string.Format
                (
                    "\t{0}{1}{2}{3}{4}{5}",

                    Tools.CuadraTexto(Nombre, 16),
                    Tools.CuadraTexto(LadoBase.ToString(), 8),
                    Tools.CuadraTexto(LadoBase.ToString(), 10),
                    Tools.CuadraTexto(90.ToString(), 10),
                    Tools.CuadraTexto(Perimetro.ToString(), 10),
                    Area.ToString("0.00")
                );
        }
        */
    }
}
