using System;

namespace P46_Pintar_Piso
{
    public class Habitacion : Recinto
    {
        // ATRIBUTOS


        // CONSTRUCTOR
        public Habitacion(string nombre, double mPared, int numPuertas, int numVentanas, int tipoPintura)
            : base(nombre, mPared, numPuertas, numVentanas, tipoPintura)
        { }

        public Habitacion(string nombre, double mPared, int numPuertas, int numVentanas) // el constructor de habitacion que no recibe pintura
            : base(nombre, mPared, numPuertas, numVentanas)
        { }


        // GETTERS Y SETTERS


        // PROPIEDADES
        public override double SuperficiePintar
        {
            get
            {
                return MPared * 2.5 - NumPuertas * 1.6 - NumVentanas;
            }
        }


        // MÉTODOS

        // Método del profesor para obtener el precio de la habitación/terraza y presentarlo todo de paso (este sustituiría al método MostrarRecintos() de la clase Piso que el mismo profesor nos daba al comienzo de la primera versión de esta práctica)
        
        /*
        public override double PrecioPintura(CatalogoPinturas catalogo)
        {
            Pintura pintura = catalogo.ListaPinturas[TipoPintura];

            double precio = SuperficiePintar * pintura.PrecioM2;
            
            Console.WriteLine
            (
                "   {0}{1}\t{2}\t{3}\t{4}\t{5}\t\t  {6}", 
                
                Nombre, 
                MPared, 
                NumPuertas, 
                NumVentanas, 
                pintura.NombreColor, 
                pintura.PrecioM2, 
                // en la clase Terraza, pondremos aquí los metros de petril
                precio
            );
            
            return precio;
        }
        */



        // ToString


    }
}