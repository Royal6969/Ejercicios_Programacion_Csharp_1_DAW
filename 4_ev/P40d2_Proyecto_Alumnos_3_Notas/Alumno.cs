using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P40d2_Proyecto_Alumnos_3_Notas
{
    class Alumno
    {

		#region ATRIBUTOS
		int numDNI;
		char letraDNI;
		string nombre, apellidos;
		Fecha fechaNac; // <-- fecha de nacimiento

		float nota1, nota2, nota3;
        #endregion

        #region CONSTRUCTORES
        public Alumno(int numDNI, char letraDNI, string nombre, string apellidos, Fecha fechaNac)
		{
			this.numDNI = numDNI;
			this.letraDNI = letraDNI;
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.fechaNac = fechaNac;
		}

		public Alumno(int numDNI, char letraDNI, string nombre, string apellidos, int año, byte mes, byte dia, float nota1, float nota2, float nota3)
		{
			this.numDNI = numDNI;
			this.letraDNI = letraDNI;
			this.nombre = nombre;
			this.apellidos = apellidos;
			// fechaNac = new Fecha(año, mes, dia);
			fechaNac = new Fecha(dia, mes, año);
			this.nota1 = nota1;
			this.nota2 = nota2;
			this.nota3 = nota3;
		}

		public Alumno(string registro)
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

			// la instrucción angterior erquivale a estas cuatro líneas
			//if (año < 50)
			//	año += 2000;
			//else
			//	año += 1900;

			mes = Convert.ToByte(vLog[5]);
			dia = Convert.ToByte(vLog[6]);
			fechaNac = new Fecha(año, mes, dia);
		}
        #endregion

        #region GETTERS Y SETTERS
        public int NumDNI
		{
			get { return numDNI; }
			set { numDNI = value; }
		}

		public char LetraDNI
		{
			get { return letraDNI; }
			set { letraDNI = value; }
		}

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public string Apellidos
		{
			get { return apellidos; }
			set { apellidos = value; }
		}

		public Fecha FechaNac
		{
			get { return fechaNac; }
			set { fechaNac = value; }
		}

		// los nuevos GETTERS y SETTERS de las notas !
		public float Nota1 { get => nota1; set => nota1 = value; }
		public float Nota2 { get => nota2; set => nota2 = value; }
		public float Nota3 { get => nota3; set => nota3 = value; }

		// si quisiera en Alumno una propiedad para cada uno de los campos de la fecha ....
		public int año { get { return fechaNac.Año; } }
		public byte Mes { get { return (byte)fechaNac.Mes; } }
		public byte Dia { get { return (byte)fechaNac.Dia; } }
        #endregion

        #region PROPIEDADES
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

				//----- lo mismo pero con números
				//int fechaHoy = 100 * mesHoy + diaHoy;
				//int fechaCumple = 100 * Mes + Dia;
				// todavía no ha cumplido hay que restarle uno
				//if (fechaHoy < fechaCumple)
				//	edad--;

				return (byte)edad;
			}
		}

        // Propiedad (campo calculado) de la Media de las Notas
		public float Media
        {
            get
            {
				return (nota1 + nota2 + nota3) / 3;
            }
        }

		// Propiedad (campo calculado) para recoger cada registro del fichero
		public string Registro
        {
			get
            {
				return numDNI + ";" + letraDNI + ";" + apellidos + ";" + nombre + ";" + fechaNac.Edad + ";" + nota1.ToString("0.0") + ";" + nota2.ToString("0.0") + ";" + nota3.ToString("0.00") + ";" + Media.ToString("0.00");
			}
		} // pero a mí me gustan más lo métodos ... aunque prácticamente, es igual el resultado

		#endregion

		#region MÉTODOS
		public void Mostrar()
		{
			Console.WriteLine
			(
				"{0}-{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", 
				
				numDNI, 
				letraDNI, 
				Tools.CuadraTexto(apellidos + ", " + nombre, 27), 
				// fechaNac.Año + "/" + fechaNac.Mes + "/" + fechaNac.Dia,
				fechaNac.Edad,
				nota1.ToString("0.0"), 
				nota2.ToString("0.0"), 
				nota3.ToString("0.0"),
				Math.Round(Media, 2).ToString("0.00")
			);
		}

		public string Guardar()
		{
			return numDNI + ";" + letraDNI + ";" + nombre + ";" + apellidos + ";" + fechaNac.FechaEntero_año4cifras + ";" + nota1.ToString("0.0") + ";" + nota2.ToString("0.0") + ";" + nota3.ToString("0.0");
		}

		public static void ReadFileAndSaveStudents(List<Alumno> customersList)
		{
			StreamReader streamReader = new StreamReader("./Datos/Alums3fNotas.txt", Encoding.Default);
			string[] vLog = new string[8];

			while (!streamReader.EndOfStream)
			{
				vLog = streamReader.ReadLine().Split(';');

				Alumno alumno = new Alumno
				(
					Int32.Parse(vLog[0]),
					Convert.ToChar(vLog[1]),
					vLog[2].Trim(),
					vLog[3].Trim(),
					Int32.Parse(vLog[4].Substring(0, 4)),
					byte.Parse(vLog[4].Substring(4, 2)),
					byte.Parse(vLog[4].Substring(6, 2)),
					float.Parse(vLog[5]),
					float.Parse(vLog[6]),
					float.Parse(vLog[7])
				);

				customersList.Add(alumno);
			}

			streamReader.Close();
		}

		public static void ShowCustomerList(List<Alumno>studentsList)
		{
			Console.WriteLine("\nDNI\t\tNombre Apellidos\t\tEdad\tNota1\tNota2\tNota3\tMedia");
			Console.WriteLine("--------------------------------------------------------------------------------------");

			foreach (Alumno alumno in studentsList)
			{
				alumno.Mostrar();
			}
		}

		public void CreateFileOrExit(List<Alumno> studentsList)
		{
			bool saveOrNoSave;
			string aux = string.Empty;

			saveOrNoSave = Tools.PreguntaSiNo("\n\n¿Quiere guardar los datos antes de salir? (s=Sí, n=No):\t");

			if (!saveOrNoSave)
			{
				Console.WriteLine("\nHa elegido NO guardar el fichero.");
			}
			else
			{
				StreamWriter streamWriter = new StreamWriter("./Datos/Alums3fNotas.txt.", false, Encoding.UTF8);

				foreach (Alumno alumno in studentsList)
				{
					streamWriter.WriteLine(alumno.Guardar());
				}

				streamWriter.Close();

				Console.WriteLine("\nEl fichero se ha guardado con éxito.");
			}
		}

		public static void SaveChangesOrNo(List<Alumno> studentsList)
		{
			int dni = 0;
			Alumno studentFound = null;
			bool modified = Tools.PreguntaSiNo("\n\n¿Quieres Modificar alguna nota? (s=Sí, n=No):\t");

			if (modified)
			{
				do 
				{
					if (!modified)
					{
						Console.WriteLine("\nHa elegido NO modificar más notas.");
					}
					else 
					{
						dni = AskForDNI(studentsList);
						studentFound = SearchStudent(studentsList, dni);

						if (studentFound == null)
						{
							Console.WriteLine("El DNI no coincide con el de ningún alumno de la lista");
						}
						else 
						{
							ShowMarksAndAskForChanges(studentFound);
							ReplaceStudent(studentsList, dni, studentFound);
						}

						modified = Tools.PreguntaSiNo("\n\n¿Quieres Modificar alguna nota más? (s=Sí, n=No):\t");
					}

				} while (modified);

				if (Tools.PreguntaSiNo("¿Quieres guardar los cambios antes de salir? (s=Sí, n=No):"))
				{
					StreamWriter streamWriter = new StreamWriter("./Datos/Alums3fNotas.txt", false, Encoding.UTF8);

					foreach (Alumno alumno in studentsList)
					{
						streamWriter.WriteLine(alumno.Guardar());
					}

					streamWriter.Close();

					Console.WriteLine("\nEl fichero se ha guardado con éxito.");
				}
				
			}
		}

		public static int AskForDNI(List<Alumno> studentsList)
		{
			int dni = Tools.CapturaEntero(0, "Por favor, introduzca el nº de DNI del alumno que busca", 0, Int32.MaxValue);

			return dni;
		}

		public static Alumno SearchStudent(List<Alumno> studentsList, int dni)
		{
			Alumno studentFound = null;

			foreach (Alumno alumno in studentsList)
			{
				if (alumno.numDNI == dni)
				{
					studentFound = alumno;
					Console.WriteLine("\n\nSe ha encontrado el alumno");
					break; // por eficiencia
				}
			}

			if (studentFound == null)
			{
				Console.WriteLine("\n\nNO se ha encontrado el alumno");
			}

			return studentFound;
		}

		public static void ReplaceStudent(List<Alumno> studentsList, int dni, Alumno studentFound)
		{
			for (int i = 0; i < studentsList.Count; i++)
			{
				if (studentsList[i].numDNI == dni)
				{
					studentsList[i] = studentFound;
					Console.WriteLine("\n\nSe han actualizado las notas");
					break; // por eficiencia
				}
			}
		}

		public static void ShowMarksAndAskForChanges(Alumno studentFound)
		{
			Console.Clear();

			Console.WriteLine("\n\nLas notas del alumno " + studentFound.Apellidos + ", " + studentFound.Nombre + " son:\t" + studentFound.nota1 + ", " + studentFound.nota2 + ", " + studentFound.nota3);

			if (Tools.PreguntaSiNo("\n\n¿Desea cambiar la nota1?"))
			{
				studentFound.Nota1 = askForNewMark("nota1");
			}
			if (Tools.PreguntaSiNo("\n\n¿Desea cambiar la nota2?"))
			{
				studentFound.Nota2 = askForNewMark("nota2");
			}
			if (Tools.PreguntaSiNo("\n\n¿Desea cambiar la nota3?"))
			{
				studentFound.Nota3 = askForNewMark("nota3");
			}
		}

		public static float askForNewMark(string texto)
		{
			float mark = 0;

			mark = Tools.CapturaFloat(0, "¿Cuál es la nueva " + texto + "?", 0, 10);

			return mark;
		}

		#endregion
	}
}
