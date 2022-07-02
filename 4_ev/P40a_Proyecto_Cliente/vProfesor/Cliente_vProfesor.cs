using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoClientes
{
	class Cliente
	{
		// Campos de la clase
		int numDNI;
		char letraDNI;
		string nombre, apellidos;
		byte anyo, mes, dia; // <-- fecha de nacimiento

		string[] vCampos;
		// Constructor/es
		public Cliente(int numDNI, char letraDNI, string nombre, string apellidos, byte anyo, byte mes, byte dia)
		{
			this.numDNI = numDNI;
			this.letraDNI = letraDNI;
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.anyo = anyo;
			this.mes = mes;
			this.dia = dia;
		}

		// Instalamos este constructor que construirá los objetos a partir del registro
		public Cliente(string registro)
		{
			vCampos = registro.Split('/');
			numDNI = Convert.ToInt32(vCampos[0]);
			letraDNI = vCampos[1][0]; // el caracter estará en la primera posición de la cadena (sólo hay una)
			apellidos = vCampos[2].Trim(); // <-- Hago .Trim() por si tienen espacios por los laterales
			nombre = vCampos[3].Trim();
			anyo = Convert.ToByte(vCampos[4]);
			mes = Convert.ToByte(vCampos[5]);
			dia = Convert.ToByte(vCampos[6]);
		}

		#region Propiedades de los campos
		public int NumDNI { get => numDNI; set => numDNI = value; }
		public char LetraDNI { get => letraDNI; set => letraDNI = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Apellidos { get => apellidos; set => apellidos = value; }
		public byte Anyo { get => anyo; set => anyo = value; }
		public byte Mes { get => mes; set => mes = value; }
		public byte Dia { get => dia; set => dia = value; }

		#endregion

		// Propiedad (campo calculado) del año con 4 cifras
		public int Anyo4cifras
		{
			get
			{
				int anyoHoy2cifras = DateTime.Now.Year % 100;
				//si el año es mayor que el actual, es que es del siglo pasado
				if (anyo > anyoHoy2cifras)
					return 1900 + anyo;
				return 2000 + anyo;
			}

		}

		// Propiedad (campo calculado) de la edad
		public byte Edad
		{
			get
			{
				int anyoHoy = DateTime.Now.Year;  // <-- Usando DateTime.Now
				int mesHoy = DateTime.Now.Month;
				int diaHoy = Util.FECHAHOY.Day;   // <-- Usando FECHAHOY que hemos puesto en Util

				int edad = anyoHoy - Anyo4cifras;

				// todavía no ha cumplido hay que restarle uno
				if ((mesHoy < mes) || (mesHoy == mes && diaHoy < dia))
					edad--;

				////----- la misma comprobación pero con números
				//int fechaHoy = 100 * mesHoy + diaHoy;
				//int fechaCumple = 100 * mes + dia;
				//// todavía no ha cumplido hay que restarle uno
				//if (fechaHoy < fechaCumple)
				//	edad--;

				return (byte)edad;
			}
			
		}


		// Método Mostrar
		public void Mostrar()
		{
			Console.Write("\t{0}-{1}  {2}  {3}/{4}/{5}", numDNI, letraDNI, Util.CuadraTexto(nombre + " " + apellidos, 27), dia.ToString("00"), mes.ToString("00"), Anyo4cifras);
		}
	}

}
