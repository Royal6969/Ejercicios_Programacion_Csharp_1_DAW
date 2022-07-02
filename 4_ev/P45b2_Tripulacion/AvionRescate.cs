using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P45b_Tripulacion
{
    class AvionRescate : Avion
    {
        // ATRIBUTOS
        List<Pasajero> listaPasajeros;

        // CONSTRUCTOR
        public AvionRescate(string marca, string modelo, string matricula, int altitudMax, int velocidadMax, List<Pasajero> listaPasajeros)
            : base(marca, modelo, matricula, altitudMax, velocidadMax)
        {
            this.listaPasajeros = listaPasajeros;
        }


        // GETTERS Y SETTERS
        public List<Pasajero> ListaPasajeros { get => listaPasajeros; set => listaPasajeros = value; }


        // PROPIEDADES


        // MÉTODOS
        public override void Aterrizar()
        {
            if (EnVuelo)
            {
                if (Velocidad < 400 && Altitud < 200)
                {
                    Altitud = 0;
                    Velocidad = 0;
                    EnVuelo = false;
                    listaPasajeros.Clear();
                    MisionCumplida = true;

                    Tools.MensajeOK_vProfesor2("MISIÓN CUMPLIDA. TODOS LOS HERIDOS ESTÁN A SALVO");
                }
                else
                {
                    Tools.Error_vProfesor2("Para aterrizar --> velocidad <= 400 y altitud <= 200");
                }
            }
            else
            {
                Tools.Error_vProfesor2("No podemos aterrizar porque el avión no ha despegado aún");
            }

        }

        // ToString
        public override string ToString()
        {
            return string.Format
            (
                "{0}{1}{2}{3}{4}{5}{6}{7}{8}",

                Tools.CuadraTexto("Rescate", 12),
                Tools.CuadraTexto(Marca, 9),
                Tools.CuadraTexto(Modelo, 10),
                Tools.CuadraTexto(Matricula, 13),
                Tools.CuadraTexto(Altitud.ToString() + " m", 11),
                Tools.CuadraTexto(AltitudMax.ToString() + " m", 14),
                Tools.CuadraTexto(Velocidad.ToString() + " km/h", 13),
                Tools.CuadraTexto(VelocidadMax.ToString() + " km/h", 16),
                listaPasajeros.Count
            );
        }
    }
}
