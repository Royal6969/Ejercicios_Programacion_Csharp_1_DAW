/*
ProyClienteFecha (El tipo Cliente utilizando el tipo Fecha)

Repetir la práctica de Clientes, 
pero utilizando el tipo Fecha en lugar de los enteros anyo, mes, día.

Por tanto, los campos de Cliente serán:
    int numDNI;
    char letraDNI;
    string nombre, apellidos;
    Fecha fechaNac; // <-- fecha de nacimiento
                    // Donde fechaNac sería un objeto de la clase Fecha ya definida
*/

using System;
using System.Collections.Generic;

namespace P40c_Cliente_Fecha
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> customersList = new List<Cliente>();

            Cliente.ReadFileAndSaveCustomers(customersList);
            Cliente.ShowCustomerList(customersList);

            Tools.StopProgram();
        }
    }
}
