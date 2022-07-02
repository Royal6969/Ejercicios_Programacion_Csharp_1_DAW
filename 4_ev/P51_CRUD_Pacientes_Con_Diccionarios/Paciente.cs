using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P51_CRUD_Pacientes_Con_Diccionarios
{
	class Paciente
	{
		// ATRIBUTOS
		byte id;
		string nombre; // <-- formato Apellidos, Nombre
		int telefono;
		Fecha fechaNac; // <-- fecha de nacimiento
		byte altura;
		float peso;


		// CONSTRUCTORES
		public Paciente(byte id, string nombre, int telefono, Fecha fechaNac, byte altura, float peso)
		{
			this.id = id;
			this.nombre = nombre;
			this.fechaNac = fechaNac;
			this.telefono = telefono;
			this.altura = altura;
			this.peso = peso;
		}
		public Paciente(byte id, string nombre, int telefono, int año, byte mes, byte dia, byte altura, float peso)
		{
			this.id = id;
			this.nombre = nombre;
			this.telefono = telefono;
			fechaNac = new Fecha(año, mes, dia);
			this.altura = altura;
			this.peso = peso;
		}

		public Paciente(string registro)
		{
			string[] vLog = registro.Split(';');

			id = Convert.ToByte(vLog[0]);
			nombre = vLog[1].Trim(); // <-- Hago .Trim() por si tienen espacios por los laterales
			telefono = Convert.ToInt32(vLog[2]);

			int año;
			byte mes, dia;
			año = Convert.ToInt32(vLog[3].Substring(0, 4));

			// convertimos a cuatro cifras, porque en el fichero sólo aparecen las dos últimas
			año += año < 50 ? 2000 : 1900;

			mes = Convert.ToByte(vLog[3].Substring(4, 2));
			dia = Convert.ToByte(vLog[3].Substring(6, 2));
			fechaNac = new Fecha(año, mes, dia);

			altura = Convert.ToByte(vLog[4]);
			peso = Convert.ToSingle(vLog[5]);
		}


		// GETTERS Y SETTERS
		public byte Id { get => id; set => id = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public int Telefono { get => telefono; set => telefono = value; }
		internal Fecha FechaNac { get => fechaNac; set => fechaNac = value; }
		public byte Altura { get => altura; set => altura = value; }
		public float Peso { get => peso; set => peso = value; }

		// si quisiera en Paciente una propiedad para cada uno de los campos de la fecha ....
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

		// Propiedad para recoger cada registro del fichero
		public string Registro
		{
			get
			{
				return id + ";" + nombre + ";" + telefono + ";" + fechaNac.FechaEntero + ";" + altura + ";" + peso;
			}
		} // pero a mí me gustan más lo métodos ... aunque prácticamente, es igual el resultado


        // MÉTODOS
		public string Guardar()
		{
			return id + ";" + nombre + ";" + telefono + ";" + fechaNac.FechaEntero + ";" + altura + ";" + peso;
		}

		public static void LeerFicheroGuardarRegistros(Dictionary<byte, Paciente> dicPacientes)
		{
			StreamReader streamReader = new StreamReader("./Datos/Pacientes.txt", Encoding.Default);
			string[] vLog;

			while (!streamReader.EndOfStream)
			{
				vLog = streamReader.ReadLine().Split(';');

				Paciente paciente = new Paciente
				(
					byte.Parse(vLog[0]),
					vLog[1].Trim(),
					Int32.Parse(vLog[2]),
					new Fecha
					(
						Convert.ToByte(vLog[3].Substring(6, 2)),
						Convert.ToByte(vLog[3].Substring(4, 2)),
						Convert.ToInt32(vLog[3].Substring(0, 4))
					),
					byte.Parse(vLog[4]),
					Single.Parse(vLog[5])
				);

				dicPacientes.Add(paciente.id ,paciente);
			}

			streamReader.Close();
		}


        // ToString
        public override string ToString()
        {
			return string.Format
			(
				"\t{0}{1}{2}{3}{4}{5}{6}",

				Tools.CuadraTexto(Tools.CuadraUnidad(id).ToString(), 5),
				Tools.CuadraTexto(nombre, 24),
				Tools.CuadraTexto("  " + telefono.ToString(), 14),
				Tools.CuadraTexto(fechaNac.FechaStringSp, 14),
				Tools.CuadraTexto(Tools.CuadraUnidad(fechaNac.Edad).ToString(), 8),
				Tools.CuadraTexto(Tools.CuadraUnidad(altura).ToString(), 10),
				Tools.CuadraTexto(Tools.CuadraPeso(peso).ToString(), 8)
			);
        }
	}
}