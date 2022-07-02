using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P45b_Piloto_De_Pruebas
{
    class Avion
    {
        // ATRIBUTOS
        string marca;
        string modelo;
        string matricula;
        int altitudMax;
        int velocidadMax; // en mi opinión (por razones de seguridad aérea), si hemos tenemos en cuenta una altitudMax, debería haber también una velocidadMax

        int altitud = 0;
        int velocidad = 0;
        bool enVuelo = false;


        // CONSTRUCTORES
        public Avion(string marca, string modelo, string matricula, int altitudMax, int velocidadMax)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.matricula = matricula;
            this.altitudMax = altitudMax;
            this.velocidadMax = velocidadMax;
        }


        // GETTERS Y SETTERS
        public string Marca { get => marca; } // en este caso, son propiedades orientadas sólo a la lectura, no van a cambiar los datos
        public string Modelo { get => modelo; }
        public string Matricula { get => matricula; }
        public int AltitudMax { get => altitudMax; set => altitudMax = value; }
        public int VelocidadMax { get => velocidadMax; set => velocidadMax = value; }
        public int Altitud { get => altitud; set => altitud = value; } // al atributo altitud sí le pongo la propiedad de escritura (setter) para el método Despegar() y Aterrizar()
        public int Velocidad { get => velocidad; set => velocidad = value; } // necesito setear la velocidad en la clase hija del AvionAutomatico
        public bool EnVuelo { get => enVuelo; set => enVuelo = value; } // necesito setear el enVuelo en la clase hija del AvionAutomatico

        // public bool EnVuelo { get => (altitud > 0); } // otra posibilidad de definir el getter de EnVuelo


        // PROPIEDADES


        // MÉTODOS
        public virtual void AumentarVelocidad(int aumento)
        {
            int total = 0;

            if (!enVuelo) // si el avión NO está en vuelo ...
            {
                if (velocidad <= 400) // ... definimos una velocidad máxima auxiliar para cuando el avión aún no ha despegado y sigue en pista
                {
                    // aumento = Tools.CapturaEntero_Normal("para la cantidad a aumentar", 1, 200); // OJO, EN LA CLASE DEL OBJETO NO DEBO PEDIR DATOS AL USUARIO, SE PIDEN MEJOR EN EL MAIN
                    total = velocidad + aumento;

                    if (total > 400)
                    {
                        Tools.Error_vProfesor2("Ya no se puede acelerar más antes de despegar... Despega ya!");
                    }
                    else
                    {
                        velocidad = total;

                        Tools.MensajeOK_vProfesor2("La velocidad del avión ha aumentado a " + velocidad + "km/h");
                    }
                }
                else
                {
                    Tools.Error_vProfesor2("El avión ya tiene suficiente velocidad para despegar");
                }
            }
            else // pero si el avión SÍ está en vuelo ...
            {
                if (velocidad <= velocidadMax) // ... utilizaremos la velocidadMax
                {
                    // aumento = Tools.CapturaEntero_Normal("para la cantidad a aumentar", 1, 200); // OJO, EN LA CLASE DEL OBJETO NO DEBO PEDIR DATOS AL USUARIO, SE PIDEN MEJOR EN EL MAIN
                    total = velocidad + aumento;

                    if (total > velocidadMax)
                    {
                        Tools.Error_vProfesor2("No se puede acelerar más del máximo de " + velocidadMax + "km/h");
                    }
                    else
                    {
                        velocidad = total;

                        Tools.MensajeOK_vProfesor2("La velocidad del avión ha aumentado a " + velocidad + "km/h");
                    }
                }
                else
                {
                    Tools.Error_vProfesor2("El avión no puede volar más rápido de " + velocidadMax + "km/h");
                }
            }
        }

        public virtual void DisminuirVelocidad(int descenso)
        {
            int total = 0;

            if (!enVuelo) // si el avión NO está en vuelo ...
            {
                if (velocidad >= 0) // vamos a definir una velocidad mínima auxiliar para cuando el avión aún no ha despegado
                {
                    // descenso = Tools.CapturaEntero_Normal("para la cantidad a reducir", 1, 200); // OJO, EN LA CLASE DEL OBJETO NO DEBO PEDIR DATOS AL USUARIO, SE PIDEN MEJOR EN EL MAIN
                    total = velocidad - descenso;

                    if (total < 0)
                    {
                        Tools.Error_vProfesor2("Las leyes de la física impiden poner la velocidad en negativo");
                    }
                    else
                    {
                        velocidad = total;

                        Tools.MensajeOK_vProfesor2("La velocidad del avión se ha reducido a " + velocidad + "km/h");
                    }
                }
                else
                {
                    Tools.Error_vProfesor2("El avión ya está parado, no puedes reducir más la velocidad");
                }
            }
            else // pero si el avión ya está en vuelo ...
            {
                if (velocidad >= 200) // ... el otro valor para la velocidad mínima auxiliar sería de 200km/h durante el vuelo
                {
                    // descenso = Tools.CapturaEntero_Normal("para la cantidad a reducir", 1, 200); // OJO, EN LA CLASE DEL OBJETO NO DEBO PEDIR DATOS AL USUARIO, SE PIDEN MEJOR EN EL MAIN
                    total = velocidad - descenso;

                    if (total < 200)
                    {
                        Tools.Error_vProfesor2("No se puede reducir menos de 200km/h la velocidad en vuelo");
                    }
                    else
                    {
                        velocidad = total;

                        Tools.MensajeOK_vProfesor2("La velocidad del avión se ha reducido a " + velocidad + "km/h");
                    }
                }
                else
                {
                    Tools.Error_vProfesor2("El avión no puede volar más lento de 200km/h");
                }
            }
        }

        public virtual void AumentarAltitud(int aumento)
        {
            int total = 0;

            if (enVuelo) // si el avión YA está en vuelo ...
            {
                // aumento = Tools.CapturaEntero_Normal("para la cantidad a aumentar", 1, 200); // OJO, EN LA CLASE DEL OBJETO NO DEBO PEDIR DATOS AL USUARIO, SE PIDEN MEJOR EN EL MAIN
                total = altitud + aumento;

                if (total > altitudMax)
                {
                    Tools.Error_vProfesor2("No se puede volar más alto de máximo permitido de " + altitudMax + "m");
                }
                else
                {
                    altitud = total;

                    Tools.MensajeOK_vProfesor2("La altitud del avión ha aumentado a " + altitud + "m");
                }
            }
            else // pero si el avión NO está en vuelo ...
            {
                Tools.Error_vProfesor2("No se puede aumentar la altitud porque el avión no ha despegado");
            }
        }

        public virtual void DisminuirAltitud(int descenso)
        {
            int total = 0;

            if (enVuelo) // si el avión YA está en vuelo ...
            {
                // descenso = Tools.CapturaEntero_Normal("para la cantidad a reducir", 1, 200); // OJO, EN LA CLASE DEL OBJETO NO DEBO PEDIR DATOS AL USUARIO, SE PIDEN MEJOR EN EL MAIN
                total = altitud - descenso;

                if (total < 100) // ... un valor para la altitud mínima auxiliar sería de 100m (altitud mínima de seguridad)
                {
                    Tools.Error_vProfesor2("No se puede volar más bajo del mínimo permitido de 100m");
                }
                else
                {
                    altitud = total;

                    Console.WriteLine("\n\n\tLa altitud del avión se ha reducido a " + altitud + "m");
                }
            }
            else // pero si el avión NO está en vuelo ...
            {
                Tools.Error_vProfesor2("No se puede reducir la altitud porque el avión no ha despegado");
            }
        }

        public virtual void Despegar()
        {
            if (!enVuelo)
            {
                if (velocidad >= 200)
                {
                    Altitud = 100; // para hacer esta asignación, necesito la propiedad de escritura (setter) del atributo altitud
                    enVuelo = true;

                    Tools.MensajeOK_vProfesor2("Acabamos de despegar, y hemos alcanzado una altura de " + altitud + "m");
                }
                else if (velocidad < 200)
                {
                    Tools.Error_vProfesor2("No podemos despegar hasta que la velocidad sea >= 200km/h");
                }
            }
            else
            {
                Tools.Error_vProfesor2("No podemos volver a despegar porque el avión ya está volando");
            }
        }

        public virtual void Aterrizar()
        {
            if (enVuelo)
            {
                if (velocidad < 400 && altitud < 200)
                {
                    altitud = 0;
                    velocidad = 0;
                    enVuelo = false;

                    Tools.MensajeOK_vProfesor2("Acabamos de aterrizar, gracias por elegir " + marca);
                }
                // else if (velocidad >= 400 && altitud >= 200) // ¿Por qué con esta comparación me aterriza el avión, en vez de fallar con el mensaje? ... en cambio en el método Despegar() si me funciona bn su equivalente else if()
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
                "{0}{1}{2}{3}{4}{5}{6}{7}",

                Tools.CuadraTexto("Estándar", 12), // si en el Program.cs hubiera hecho un método típico de MostrarListaAviones(), para que saliera el nombre de la clase (tipo) en esta casilla, utilizaría el método object.GetType().Name al recorrer la lista
                Tools.CuadraTexto(marca, 13),
                Tools.CuadraTexto(modelo, 10),
                Tools.CuadraTexto(matricula, 13),
                Tools.CuadraTexto(altitud.ToString() + " m", 11),
                Tools.CuadraTexto(altitudMax.ToString() + " m", 14),
                Tools.CuadraTexto(velocidad.ToString() + " km/h", 13),
                velocidadMax.ToString() + " km/h"
            );
        }

    }
}
