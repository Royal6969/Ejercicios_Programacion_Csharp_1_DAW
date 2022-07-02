using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P_Proyecto_Empleados
{
    abstract class Empleado
    {
		// ATRIBUTOS
		int numDNI;
		char letraDNI;
		string nombre, apellidos;
		Fecha fechaNac; // <-- fecha de nacimiento
		string nivel;
		double sueldoBase = 1250;


        // CONSTRUCTORES
        public Empleado(int numDNI, char letraDNI, string nombre, string apellidos, Fecha fechaNac, string nivel)
		{
			this.numDNI = numDNI;
			this.letraDNI = letraDNI;
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.fechaNac = fechaNac;
			this.nivel = nivel;
		}

		public Empleado(int numDNI, char letraDNI, string nombre, string apellidos, int año, byte mes, byte dia, string nivel)
		{
			this.numDNI = numDNI;
			this.letraDNI = letraDNI;
			this.nombre = nombre;
			this.apellidos = apellidos;
			fechaNac = new Fecha(año, mes, dia);
			this.nivel= nivel;
		}

		public Empleado(string registro)
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

			nivel = vLog[7];
		}


		// GETTERS Y SETTERS
		public int NumDNI { get => numDNI; set => numDNI = value; }
		public char LetraDNI { get => letraDNI; set => letraDNI = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Apellidos { get => apellidos; set => apellidos = value; }
		public Fecha FechaNac { get => fechaNac; set => fechaNac = value; }
		public string Nivel { get => nivel; set => nivel = value; }
		public double SueldoBase { get => sueldoBase; set => sueldoBase = value; }

		// si quisieramos un Get/Set por el día/mes/año...
		public int Año { get { return fechaNac.Año; } }
		public byte Mes { get { return (byte)fechaNac.Mes; } }
		public byte Dia { get { return (byte)fechaNac.Dia; } }


		// PROPIEDADES
		public abstract double Salario { get; }

		// Propiedad (campo calculado) de la edad
		public byte Edad
		{
			get
			{
				int añoHoy = DateTime.Now.Year;
				int mesHoy = DateTime.Now.Month;
				int diaHoy = DateTime.Now.Day;

				int edad = añoHoy - Año;

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
				return numDNI + ";" + letraDNI + ";" + apellidos + ";" + nombre + ";" + fechaNac.Edad + ";" + nivel;
			}
		} // pero a mí me gustan más lo métodos ... aunque prácticamente, es igual el resultado


        // MÉTODOS
        public void Mostrar()
		{
			Console.WriteLine
			(
				"{0}-{1}\t{2}\t{3}\t{4}", 
				
				numDNI, 
				letraDNI, 
				Tools.CuadraTexto(apellidos + ", " + nombre, 27), 
				fechaNac.Edad,
				nivel
			);
		}


        // ToString
        public override string ToString()
        {
			return string.Format
			(
				"{0}-{1}\t{2}\t{3}\t{4}\t{5}",

				numDNI,
				letraDNI,
				Tools.CuadraTexto(apellidos + ", " + nombre, 27),
				fechaNac.Edad,
				nivel,
				Salario
			);
        }


    }
}
