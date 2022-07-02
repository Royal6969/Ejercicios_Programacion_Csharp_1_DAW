using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P_Proyecto_Empleados
{
    class Empresa
    {
        // ATRIBUTOS
        List<Empleado> listaEmpleados = new List<Empleado>();


		// CONSTRUCTOR
		public Empresa(List<Empleado> listaEmpleados)
		{
			this.listaEmpleados = listaEmpleados;
		}

		public Empresa() { }


		// GETTERS y SETTERS
		public List<Empleado> ListaEmpleados { get => listaEmpleados; set => listaEmpleados = value; }


		// PROPIEDADES


		// MÉTODOS
		/*
		public string Guardar()
		{
			return numDNI + ";" + letraDNI + ";" + apellidos + ";" + nombre + ";" + fechaNac.Edad;
		}
		*/

		public void LeerFicheroGuardarRegistros()
		{
			StreamReader streamReader = new StreamReader("./Datos/Empleados.txt", Encoding.Default);
			string[] vLog;

			while (!streamReader.EndOfStream)
			{
				vLog = streamReader.ReadLine().Split('/');

				if (vLog.Length < 8)
                {
					Empleado becario = new Becario
					(
						Int32.Parse(vLog[0]),
						Convert.ToChar(vLog[1]),
						vLog[2].Trim(),
						vLog[3].Trim(),
						byte.Parse(vLog[6]),
						byte.Parse(vLog[5]),
						byte.Parse(vLog[4]),
						"becario"
					);

				 listaEmpleados.Add(becario);
                }
				
				else if (vLog.Length == 8 && vLog[7] == "junior")
                {
					Empleado junior = new Junior
					(
						Int32.Parse(vLog[0]),
						Convert.ToChar(vLog[1]),
						vLog[2].Trim(),
						vLog[3].Trim(),
						byte.Parse(vLog[6]),
						byte.Parse(vLog[5]),
						byte.Parse(vLog[4]),
						vLog[7]
					);

					listaEmpleados.Add(junior);
				}

				else if (vLog.Length == 8 && vLog[7] == "senior")
				{
					Empleado senior = new Senior
					(
						Int32.Parse(vLog[0]),
						Convert.ToChar(vLog[1]),
						vLog[2].Trim(),
						vLog[3].Trim(),
						byte.Parse(vLog[6]),
						byte.Parse(vLog[5]),
						byte.Parse(vLog[4]),
						vLog[7]
					);

					listaEmpleados.Add(senior);
				}

				else if (vLog.Length == 8 && vLog[7] == "jefe")
				{
					Empleado jefe = new Jefe
					(
						Int32.Parse(vLog[0]),
						Convert.ToChar(vLog[1]),
						vLog[2].Trim(),
						vLog[3].Trim(),
						byte.Parse(vLog[6]),
						byte.Parse(vLog[5]),
						byte.Parse(vLog[4]),
						vLog[7]
					);

					listaEmpleados.Add(jefe);
				}
			}
			streamReader.Close();
		}

		public void MostrarListaEmpleados()
		{
			Console.WriteLine("\nDNI\t\tNombre Apellidos\t\tEdad\tNivel\tSalario");
			Console.WriteLine("--------------------------------------------------------------------------------------");

			foreach (Empleado empleado in listaEmpleados)
			{
				Console.WriteLine(empleado.ToString());
			}
		}


		// ToString
	}
}
