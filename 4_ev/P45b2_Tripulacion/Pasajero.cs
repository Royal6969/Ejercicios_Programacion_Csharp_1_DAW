using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P45b_Tripulacion
{
	class Pasajero
	{
		// ATRIBUTOS
		int numDNI;
		char letraDNI;
		string nombre, apellidos;
		Fecha fechaNac; // <-- fecha de nacimiento


		// CONSTRUCTORES
		public Pasajero(int numDNI, char letraDNI, string nombre, string apellidos, Fecha fechaNac)
		{
			this.numDNI = numDNI;
			this.letraDNI = letraDNI;
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.fechaNac = fechaNac;
		}
		public Pasajero(int numDNI, char letraDNI, string nombre, string apellidos, int año, byte mes, byte dia)
		{
			this.numDNI = numDNI;
			this.letraDNI = letraDNI;
			this.nombre = nombre;
			this.apellidos = apellidos;
			fechaNac = new Fecha(año, mes, dia);
		}

		public Pasajero(string registro)
		{
			string[] vLog = registro.Split('/');

			numDNI = Convert.ToInt32(vLog[0]);
			letraDNI = vLog[1][0]; // el caracter estará en la primera posición de la cadena (sólo hay una)
			apellidos = vLog[2].Trim(); // <-- Hago .Trim() por si tienen espacios por los laterales
			nombre = vLog[3].Trim();

			int año;
			byte mes, dia;
			año = Convert.ToInt32(vLog[4]);

			// convertimos a cuatro cifras, porque en el fichero sólo aparecen las dos últimas
			año += año < 50 ? 2000 : 1900;

			mes = Convert.ToByte(vLog[5]);
			dia = Convert.ToByte(vLog[6]);
			fechaNac = new Fecha(año, mes, dia);
		}


		// GETTERS Y SETTERS
		public int NumDNI { get => numDNI; set => numDNI = value; }
		public char LetraDNI { get => letraDNI; set => letraDNI = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Apellidos { get => apellidos; set => apellidos = value; }
		internal Fecha FechaNac { get => fechaNac; set => fechaNac = value; }

		// si quisiera en Pasajero una propiedad para cada uno de los campos de la fecha ....
		public int año { get { return fechaNac.Año; } }
		public byte Mes { get { return (byte)fechaNac.Mes; } }
		public byte Dia { get { return (byte)fechaNac.Dia; } }


		// PROPIEDADES

		// Propiedad (campo calculado) de la edad
		public byte Edad
		{
			get
			{
				int añoHoy = DateTime.Now.Year;
				int mesHoy = DateTime.Now.Month;
				int diaHoy = DateTime.Now.Day;

				int edad = añoHoy - año;

				// todavía no ha cumplido hay que restarle uno
				if ((mesHoy < Mes) || (mesHoy == Mes && diaHoy < Dia))
					edad--;

				return (byte)edad;
			}
		}

		// Propiedad (campo calculado) para recoger cada registro del fichero
		public string Registro
		{
			get
			{
				return numDNI + ";" + letraDNI + ";" + apellidos + ";" + nombre + ";" + fechaNac.Edad;
			}
		} // pero a mí me gustan más lo métodos ... aunque prácticamente, es igual el resultado


        // MÉTODOS
        public void Mostrar()
		{
			Console.WriteLine
			(
				"\t{0}-{1}\t{2}\t{3}",

				numDNI,
				letraDNI,
				Tools.CuadraTexto(apellidos + ", " + nombre, 27),
				fechaNac.Edad
			);
		}
		public string Guardar()
		{
			return numDNI + ";" + letraDNI + ";" + apellidos + ";" + nombre + ";" + fechaNac.Edad;
		}

		public void LeerFicheroGuardarRegistros(List<Pasajero> listaPasajeros)
		{
			StreamReader streamReader = new StreamReader("./Datos/Heridos.txt", Encoding.Default);
			string[] vLog = new string[7];

			while (!streamReader.EndOfStream)
			{
				vLog = streamReader.ReadLine().Split('/');

				Pasajero pasajero = new Pasajero
				(
					Int32.Parse(vLog[0]),
					Convert.ToChar(vLog[1]),
					vLog[2].Trim(),
					vLog[3].Trim(),
					byte.Parse(vLog[6]),
					byte.Parse(vLog[5]),
					byte.Parse(vLog[4])
				);

				listaPasajeros.Add(pasajero);
			}

			streamReader.Close();
		}

		public void MostrarListaPasajeros(List<Pasajero> listaPasajeros)
		{
			Console.WriteLine("\n\tDNI\t\tNombre Apellidos\t\tEdad");
			Console.WriteLine("--------------------------------------------------------------------------------------");

			foreach (Pasajero pasajero in listaPasajeros)
			{
				pasajero.Mostrar();
			}
		}

	}
}