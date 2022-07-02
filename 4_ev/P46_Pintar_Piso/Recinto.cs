using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P46_Pintar_Piso
{
    public abstract class Recinto
    {
        // ATRIBUTOS
        string nombre;    // Nombre de la habitación
        double mPared;    // metros de pared de la habitación
        int numPuertas;   // Número de puertas de 2 x 0.80 m2
        int numVentanas;  // Número de ventanas de 1x1 m2
        int tipoPintura;  // id del tipo de pintura en el catálogo [0..4]


        // CONSTRUCTOR
        public Recinto(string nombre, double mPared, int numPuertas, int numVentanas, int tipoPintura)
        {
            this.nombre = nombre;
            this.mPared = mPared;
            this.numPuertas = numPuertas;
            this.numVentanas = numVentanas;
            this.tipoPintura = tipoPintura;
        }

        public Recinto(string nombre, double mPared, int numPuertas, int numVentanas) // sin recibir ninguna pintura (pintura default blanca)
        {
            this.nombre = nombre;
            this.mPared = mPared;
            this.numPuertas = numPuertas;
            this.numVentanas = numVentanas;
            this.tipoPintura = 0;
        }


        // GETTERS Y SETTERS
        public string Nombre { get => nombre; set => nombre = value; }
        public double MPared { get => mPared; set => mPared = value; }
        public int NumPuertas { get => numPuertas; set => numPuertas = value; }
        public int NumVentanas { get => numVentanas; set => numVentanas = value; }
        public int TipoPintura { get => tipoPintura; set => tipoPintura = value; }


        // PROPIEDADES
        public virtual double SuperficiePintar { get; }


        // MÉTODOS

        public double PrecioPintura(CatalogoPinturas catalogo) // este es el nuevo método para obtener el PrecioPintura (precio habitación/terraza)
        {
            return double.Parse((SuperficiePintar * catalogo.ListaPinturas[TipoPintura].PrecioM2).ToString("0.00"));
        }


        // Método del profesor para obtener el precio de la habitación/terraza y presentarlo todo de paso (este sustituiría al método MostrarRecintos() de la clase Piso que el mismo profesor nos daba al comienzo de la primera versión de esta práctica)
        
        // public abstract double PrecioPintura(CatalogoPinturas catalogo); // si tomamos este método como vía para presentar todo ... se continua su override en las clases Habitacion y Terraza ...  



        // ToString

    }
}