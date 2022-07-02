/*
Construir la clase Cliente teniendo en cuenta los siguientes...

• Campos:
    int numDNI;
    char letraDNI;
    string nombre, apellidos;
    byte año, mes, día; // <-- fecha de nacimiento

• Propiedades:
Para cada uno de los campos se construirá una propiedad de lectura escritura.
Propiedad Edad —de sólo lectura— que devuelve la edad en años del individuo. 
(Debes tener en cuenta la fecha actual, que se obtiene con la clase DateTime)

• Método Mostrar: Que presenta en pantalla los datos del cliente, con este formato:"\t{0}-{1} {2} {3}/{4}/{5}",
Para: numDNI, letraDNI, «nombre Apellidos» (cuadrados a 27), dia, mes, año (con cuatro cifras).

/-----------------------/

El Main.

Se construirá una lista de objetos de tipo Cliente. 
Para construir los objetos que se cargarán en la lista, 
se obtendrán los datos del fichero Clientes.txt (mira la práctica P37b).

A continuación, se recorrerá la lista y se mostrará cada cliente,
utilizando su método Mostrar, y la edad de cada uno, 
que debe aparecer a la derecha de su fecha de nacimiento.

Realiza otras operaciones que se te ocurran para practicar.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P40a_Proyecto_Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> customersList = new List<Cliente>();

            Cliente.ReadFileAndSaveCustomers(customersList);
            Cliente.ShowCustomerList(customersList);

            // prueba de Set()
            customersList[0].Nombre = "Manolo el del bombo";
            Console.WriteLine("\n\n");
            Cliente.ShowCustomerList(customersList);

            Tools.StopProgram();
        }
    }
}