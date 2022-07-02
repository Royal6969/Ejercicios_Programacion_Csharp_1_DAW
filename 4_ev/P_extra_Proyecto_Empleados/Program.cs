using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Proyecto_Empleados
{
    class Program
    {
        static Empresa empresa = new Empresa();

        static void Main(string[] args)
        {
            empresa.LeerFicheroGuardarRegistros();
            empresa.MostrarListaEmpleados();

            Tools.StopProgram_v1();
        }
    }
}
