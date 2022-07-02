using System;

namespace P46_Pintar_Piso
{
    public class Pintura
    {
        // ATRIBUTOS
        string nombreColor;
        double precioM2;


        // CONSTRUCTORES
        public Pintura(string nombreColor, double precioM2)
        {
            this.nombreColor = nombreColor;
            this.precioM2 = precioM2;
        }


        // GETTERS Y SETTERS
        public string NombreColor { get => nombreColor; set => nombreColor = value; }
        public double PrecioM2 { get => precioM2; set => precioM2 = value; }


        // MÉTODOS


        // ToString


    }
}