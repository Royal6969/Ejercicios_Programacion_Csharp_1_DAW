using System;

namespace P46_Pintar_Piso
{
    public class Terraza : Recinto
    {
        // ATRIBUTOS
        double mPetril;


        // CONSTRUCTORES
        public Terraza(string nombre, double mPared, int numPuertas, int numVentanas, int tipoPintura, double mPetril)
            : base(nombre, mPared, numPuertas, numVentanas, tipoPintura)
        { 
            this.mPetril = mPetril;
        }

        public Terraza(string nombre, double mPared, int numPuertas, int numVentanas, double mPetril) 
            : base(nombre, mPared, numPuertas, numVentanas)
        {
            this.mPetril = mPetril;
        }


        // GETTERS Y SETTERS
        public double MPetril { get => mPetril; set => mPetril = value; }


        // PROPIEDADES
        public override double SuperficiePintar
        {
            get
            {
                return MPared * 2.5 - NumPuertas * 1.6 - NumVentanas + mPetril * 1.5;
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
                MPretil
                precio
            );

            return precio;
        }
        */

        // ToString
    }
}