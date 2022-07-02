using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P45b_Tripulacion
{
    class AvionAutomatico : Avion
    {
        // ATRIBUTOS


        // CONSTRUCTORES
        public AvionAutomatico(string marca, string modelo, string matricula, int altitudMax, int velocidadMax) 
                : base(marca, modelo, matricula, altitudMax, velocidadMax)
        { }

        // GETTERS Y SETTERS


        // PROPIEDADES


        // MÉTODOS
        public override void Despegar()
        {
            if (!EnVuelo)
            {
                if (Velocidad >= 200)
                {
                    Altitud = 100; // para hacer esta asignación, necesito la propiedad de escritura (setter) del atributo altitud
                    EnVuelo = true;

                    Tools.MensajeOK_vProfesor2("Acabamos de despegar, y hemos alcanzado una altura de " + Altitud + "m");
                }
                // else if (Velocidad < 200)
                else
                {
                    Altitud = 100;
                    Velocidad = 200;
                    EnVuelo = true;

                    Tools.MensajeOK_vProfesor2("Hemos despegado! Altura: " + Altitud + "m y Velocidad: " + Velocidad + "km/h");
                }
            }
            else
            {
                Tools.Error_vProfesor2("No podemos volver a despegar porque el avión ya está volando");
            }
        }

        public override void Aterrizar()
        {
            if (EnVuelo)
            {
                Altitud = 0;
                Velocidad = 0;
                EnVuelo = false;

                Tools.MensajeOK_vProfesor2("Acabamos de aterrizar, gracias por elegir " + Marca);
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
                "{0}{1}{2}{3}{4}{5}{6}{7}",

                Tools.CuadraTexto("Automático", 12),
                Tools.CuadraTexto(Marca, 13),
                Tools.CuadraTexto(Modelo, 10),
                Tools.CuadraTexto(Matricula, 13),
                Tools.CuadraTexto(Altitud.ToString() + " m", 11),
                Tools.CuadraTexto(AltitudMax.ToString() + " m", 14),
                Tools.CuadraTexto(Velocidad.ToString() + " km/h", 13),
                VelocidadMax.ToString() + " km/h"
            );
        }
    }
}
