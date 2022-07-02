using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ProyectoClientes
{
	class Program
	{

		static void Main(string[] args)
		{
			// ejemplo de construir un cliente
			Cliente c1 = new Cliente(45875214, 'H', "Filomena", "Española", 95, 2, 10);

			//Console.Write("\n\tEl primer cliente se llama {0}. \n\n\t¿Nuevo nombre? ", c1.Nombre);
			//c1.Nombre = Console.ReadLine();

			// construimos la lista de clientes y añadimos el anterior
			List<Cliente> listaClientes = new List<Cliente>();
			listaClientes.Add(c1);

			// construyo un StreamReader  para leer los datos
			StreamReader sr = new StreamReader(@".\Datos\Clientes.txt", Encoding.Default);

			// recorro el fichero leyendo todos los registros
			while (!sr.EndOfStream)
			{
				// construyo el cliente, con el segundo constructor, y lo añado a la lista
				listaClientes.Add(new Cliente(sr.ReadLine()));
			}
			sr.Close();

			// vamos a mostrar los clientes de la lista
			Console.WriteLine("\n\t   DNI         Nombre Apellidos          Fecha Nac.  Edad");
			Console.WriteLine("\t----------  -------------------------    ----------  -----");

			for (int i = 0; i < listaClientes.Count; i++)
			{
				listaClientes[i].Mostrar();
				Console.WriteLine("   " + listaClientes[i].Edad);
			}

			// lo mismo pero con foreach
			Console.WriteLine("\n\t   DNI         Nombre Apellidos          Fecha Nac.  Edad");
			Console.WriteLine("\t----------  -------------------------    ----------  -----");
			foreach (Cliente c in listaClientes)
			{
				c.Mostrar();
				Console.WriteLine("   " + c.Edad);
			}

			Console.ReadKey();
		}

	}
}
