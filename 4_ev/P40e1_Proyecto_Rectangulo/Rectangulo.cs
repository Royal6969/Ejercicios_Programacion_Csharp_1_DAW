using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P40e1_Proyecto_Rectangulo
{
    class Rectangulo
    {
        // ATRIBUTOS
        string nombre;
        double ladoBase;
        double ladoLateral;

        // CONSTRUCTOR
        public Rectangulo(string nombre, double ladoBase, double ladoLateral)
        {
            this.nombre = nombre;
            this.ladoBase = ladoBase;
            this.ladoLateral = ladoLateral;
        }

        // GETTERS Y SETTERS
        public string Nombre { get => nombre; set => nombre = value; }
        public double LadoBase { get => ladoBase; set => ladoBase = value; }
        public double LadoLateral { get => ladoLateral; set => ladoLateral = value; }

        // PROPIEDADES
        public double Perimetro
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
                return ladoBase * ladoLateral;
            }
        }

        // MÉTODOS
        public void RectanguloAString()
        {
            Console.WriteLine("\n\n\tnombre\t\tladoBase\tladoLateral\tPerimetro\tArea");
            Console.WriteLine("\t----------------------------------------------------------------------\n");
            
            Console.WriteLine
            (
                "\t{0}\t{1}\t\t{2}\t\t{3}\t\t{4}",

                Tools.CuadraTexto(nombre, 8),
                ladoBase,
                ladoLateral,
                Perimetro,
                Area
            );
        }

        public string RectanguloAString_vProfesor()
        {
            return string.Format // OJO con esta técnica que es nueva
                (
                    "\t{0}\t{1}\t\t{2}\t\t{3}\t\t{4}",

                    Tools.CuadraTexto(nombre, 8),
                    ladoBase,
                    ladoLateral,
                    Perimetro,
                    Area
                );
        }

    }
}
