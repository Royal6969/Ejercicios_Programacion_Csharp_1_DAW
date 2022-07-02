using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P46_Pintar_Piso
{
    public class CatalogoPinturas
    {
        // ATRIBUTOS
        List<Pintura> listaPinturas = new List<Pintura>();


        // CONSTRUCTORES
        
        // no hacemos ningún contructor !! y eso significaría que el constructor sería el vacío !! ...
        // no necesito construir un objeto catálogo con una List dentro, tan sólo contruiré en el main un objeto catálogo simple para manejar la ListaPinturas


        // GETTERS Y SETTERS
        public List<Pintura> ListaPinturas { get => listaPinturas; set => listaPinturas = value; }


        // PROPIEDADES


        // MÉTODOS
        public void Mostrar()
        {
            Console.WriteLine("\n--------- PRESENTACION LISTA DE PINTURAS ----------\n");
            Console.WriteLine("\tid\tColor\t  precioM2");
            Console.WriteLine("\t--\t------\t  --------");

            for (int i = 0; i < listaPinturas.Count; i++)
            {
                Console.WriteLine
                (
                    "\t{0}{1}{2}",

                    Util.CuadraTexto(Util.CuadraUnidad(i), 8),
                    Util.CuadraTexto(listaPinturas[i].NombreColor, 12),
                    listaPinturas[i].PrecioM2.ToString("0.0")
                );
            }
        }


        // se podría añadir aquí un método para añadir la pintura (y así ocultar el uso de la ListaPinturas en el main)

    }
}