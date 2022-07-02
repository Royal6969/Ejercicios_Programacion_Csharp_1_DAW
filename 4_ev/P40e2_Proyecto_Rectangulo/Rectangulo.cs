using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P40e2_Proyecto_Rectangulo
{
    class Rectangulo
    {
        // ATRIBUTOS
        string nombre;
        int ladoBase;
        int ladoLateral;

        // CONSTRUCTOR
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
        public int Perimetro
        {
            get
            {
                return (ladoBase * 2) + (ladoLateral * 2);
            }
        }

        public int Area
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

        public void ModifyRectangle()
        {
            string nombreRectangulo = Tools.CapturaNombreRectangulo(0, "para modificar el nombre del rectángulo", nombre);
            int ladoBaseRectangulo = Tools.CapturaEntero(0, "para modificar el Lado Base del rectángulo", 1, 100, ladoBase);
            int ladoLateralRectangulo = Tools.CapturaEntero(0, "para modificar el Lado Lateral", 1, 100, ladoLateral);

            nombre = nombreRectangulo;
            ladoBase = ladoBaseRectangulo;
            ladoLateral = ladoLateralRectangulo;
        }

    }
}
