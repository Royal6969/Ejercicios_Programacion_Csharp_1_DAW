using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Proyecto_Empleados
{
    class Junior : Empleado
    {
        // ATRIBUTOS


        // CONSTRUCTORES
        public Junior(int numDNI, char letraDNI, string nombre, string apellidos, Fecha fechaNac, string nivel) 
            : base(numDNI, letraDNI, nombre, apellidos, fechaNac, nivel)
        { }

        public Junior(int numDNI, char letraDNI, string nombre, string apellidos, int año, byte mes, byte dia, string nivel) 
            : base(numDNI, letraDNI, nombre, apellidos, año, mes, dia, nivel)
        { }

        public Junior(string registro) 
            : base(registro)
        { }


        // PROPIEDADES
        public override double Salario
        {
            get
            {
                return SueldoBase;
            }
        }

    }
}
