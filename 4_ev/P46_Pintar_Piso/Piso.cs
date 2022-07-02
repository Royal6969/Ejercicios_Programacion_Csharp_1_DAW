using System;
using System.Collections.Generic;

namespace P46_Pintar_Piso
{
    public class Piso
    {
        // ATRIBUTOS
        string direccion;
        List<Recinto> listaRecintos = new List<Recinto>(); // este atributo de List, NO lo metemos en el constructor


        // CONSTRUCTORES
        public Piso(string direccion) // con este construiremos un objeto Piso simple (con una dirección), y con él, manejaremos la ListaRecintos
        {
            this.direccion = direccion;
        }


        // GETTERS Y SETTERS
        public string Direccion { get => direccion; set => direccion = value; }
        public List<Recinto> ListaRecintos { get => listaRecintos; set => listaRecintos = value; }


        // PROPIEDADES


        // MÉTODOS
        public void MostrarRecintos(CatalogoPinturas catalogo)
        {
            double suma = 0;
            Terraza terrazaAux = null;

            // cabecera
            Console.WriteLine("\n   -- Precio de pintura del piso: {0} --\n", direccion);
            Console.WriteLine("   Recinto    ------ PARED -------      -- PINTURA --   PRETIL    TOTAL");
            Console.WriteLine("   Nombre     metros   nºP     nºV      Color  Precio   metros    Precio");
            Console.WriteLine("   -------    ------   ---     ---      -----  ------   ------    ------");

            for (int i = 0; i < listaRecintos.Count; i++)
            {
                if (listaRecintos[i].GetType().Name == "Habitacion") // debo evitar hacer estas comprobaciones para no repetir tanto código ... mejor virtualizar y cambiar el método en el hijo 
                {
                    // aquí no es necesario que creemos una "habitacionAux" porque los atributos de la Habitación son los mismos que los de su padre Recinto

                    Console.WriteLine
                    (
                        "   {0}{1}{2}{3}{4}{5}{6}",

                        Util.CuadraTexto(listaRecintos[i].Nombre, 13),
                        Util.CuadraTexto(listaRecintos[i].MPared.ToString("00.0"), 8),
                        Util.CuadraTexto(listaRecintos[i].NumPuertas.ToString(), 8),
                        Util.CuadraTexto(listaRecintos[i].NumVentanas.ToString(), 9),
                        Util.CuadraTexto(catalogo.ListaPinturas[i].NombreColor, 7),
                        Util.CuadraTexto(Util.CuadraPrecio(double.Parse(catalogo.ListaPinturas[i].PrecioM2.ToString("0.0"))), 18),
                        Util.CuadraPrecio(listaRecintos[i].PrecioPintura(catalogo)).ToString()
                    );
                }
                else
                {
                    terrazaAux = (Terraza)listaRecintos[i];

                    Console.WriteLine
                    (
                        "   {0}{1}{2}{3}{4}{5}{6}{7}",

                        Util.CuadraTexto(terrazaAux.Nombre, 13),
                        Util.CuadraTexto(terrazaAux.MPared.ToString("00.0"), 8),
                        Util.CuadraTexto(terrazaAux.NumPuertas.ToString(), 8),
                        Util.CuadraTexto(terrazaAux.NumVentanas.ToString(), 9),
                        Util.CuadraTexto(catalogo.ListaPinturas[i].NombreColor, 7),
                        Util.CuadraTexto(Util.CuadraPrecio(double.Parse(catalogo.ListaPinturas[i].PrecioM2.ToString("0.0"))), 8),
                        Util.CuadraTexto(Util.CuadraUnidad(Int32.Parse(terrazaAux.MPetril.ToString())), 10),
                        Util.CuadraPrecio(listaRecintos[i].PrecioPintura(catalogo)).ToString()
                    );
                }

                suma += listaRecintos[i].PrecioPintura(catalogo);
            }

            // Pie
            Console.WriteLine("                                                                  ------");
            Console.WriteLine("                                             TOTAL Euros Pintura: {0}", suma);
        }


        // ToString

    }
}
