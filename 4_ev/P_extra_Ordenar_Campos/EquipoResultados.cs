using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P_Ordenar_Campos
{
	class EquipoResultados : IComparable
	{
		// ATRIBUTOS // https://brainly.lat/tarea/47779295
		string nombre;
		byte puntos;
		byte partidosGanados;
		byte partidosEmpatados;
		byte partidosPerdidos;
		byte golesAfavor;
		byte golesEnContra;


		// CONSTRUCTORES
		public EquipoResultados(string nombre, byte puntos, byte partidosGanados, byte partidosEmpatados, byte partidosPerdidos, byte golesAfavor, byte golesEnContra)
        {
			this.nombre = nombre;
            this.puntos = puntos;
            this.partidosGanados = partidosGanados;
            this.partidosEmpatados = partidosEmpatados;
            this.partidosPerdidos = partidosPerdidos;
            this.golesAfavor = golesAfavor;
            this.golesEnContra = golesEnContra;
        }

		public EquipoResultados(string registro)
		{
			string[] vLog = registro.Split(';');

			nombre = vLog[0].Trim();
			puntos = byte.Parse(vLog[1]);
			partidosGanados = byte.Parse(vLog[2]);
			partidosEmpatados = byte.Parse(vLog[3]);
			partidosPerdidos = byte.Parse(vLog[4]);
			golesAfavor = byte.Parse(vLog[5]);
			golesEnContra = byte.Parse(vLog[6]);
		}


		// GETTERS Y SETTERS
		public string Nombre { get => nombre; set => nombre = value; }
		public byte Puntos { get => puntos; set => puntos = value; }
		public byte PartidosGanados { get => partidosGanados; set => partidosGanados = value; }
		public byte PartidosEmpatados { get => partidosEmpatados; set => partidosEmpatados = value; }
		public byte PartidosPerdidos { get => partidosPerdidos; set => partidosPerdidos = value; }
		public byte GolesAfavor { get => golesAfavor; set => golesAfavor = value; }
		public byte GolesEnContra { get => golesEnContra; set => golesEnContra = value; }


		// PROPIEDADES


		// Propiedad para recoger cada registro del fichero
		public string Registro
		{
			get
			{
				return nombre + ";" + puntos + ";" + partidosGanados + ";" + partidosEmpatados + ";" + partidosPerdidos + ";" + golesAfavor + ";" + golesEnContra;
			}
		}


        // MÉTODOS
        public string Guardar()
		{
			return nombre + ";" + puntos + ";" + partidosGanados + ";" + partidosEmpatados + ";" + partidosPerdidos + ";" + golesAfavor + ";" + golesEnContra;
		}

		public static void LeerFicheroGuardarRegistros(List<EquipoResultados> listaEquiposResultados)
		{
			StreamReader streamReader = new StreamReader("./Datos/ClasificLiga1617jornada9.txt", Encoding.Default);
			string[] vLog;

			while (!streamReader.EndOfStream)
			{
				vLog = streamReader.ReadLine().Split(';');

				EquipoResultados equipoResultados = new EquipoResultados
				(
					vLog[0],
					byte.Parse(vLog[1]),
					byte.Parse(vLog[2]),
					byte.Parse(vLog[3]),
					byte.Parse(vLog[4]),
					byte.Parse(vLog[5]),
					byte.Parse(vLog[6])
				);

				listaEquiposResultados.Add(equipoResultados);
			}

			streamReader.Close();
		}


        // ToString
        public override string ToString()
        {
			return string.Format
			(
				"\t{0}{1}{2}{3}{4}{5}{6}",

				Tools.CuadraTexto(nombre, 17),
				Tools.CuadraTexto(" " + Tools.CuadraUnidad(puntos).ToString(), 5),
				Tools.CuadraTexto(Tools.CuadraUnidad(partidosGanados).ToString(), 4),
				Tools.CuadraTexto(Tools.CuadraUnidad(partidosEmpatados).ToString(), 4),
				Tools.CuadraTexto(Tools.CuadraUnidad(partidosPerdidos).ToString(), 5),
				Tools.CuadraTexto(Tools.CuadraUnidad(golesAfavor).ToString(), 4),
				Tools.CuadraUnidad(GolesEnContra)
			);
        }


		// Métodos de interfaces
        public int CompareTo(object obj) // para que funcionase el .Sort() con el campo que tratemos en este método
        {
			// return nombre.CompareTo(obj);
			return nombre.CompareTo((obj as EquipoResultados).nombre);
        }

	}
}