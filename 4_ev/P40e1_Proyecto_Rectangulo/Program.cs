/*
El tipo Rectángulo

Campos:
string nombre; int ladoBase; int ladoLateral;
Constructores: Tendrá sólo el constructor “típico”.

Propiedades de los campos: 
Serán de lectura y escritura.

Propiedades de solo lectura:
• Perímetro: La suma de sus 4 lados.
• Area: ladoBase * ladoLateral.

Métodos:
• RectanguloAString, que devuelve los campos del rectángulo como una cadena con el formato siguiente:
\tnombre\tladoBase\tladoLateral\t\tPerimetro\tArea

Cuando se entre en el proyecto se construirá un objeto con los siguientes campos: "Rectan-1", 10, 20. 
A continuación...
1. Se limpia la pantalla y, utilizando RectanguloAString se mostrará el rectángulo.
2. Utilizando PreguntaSiNo preguntará: ¿Quieres Modificar?

En caso afirmativo:
te pedirá los nuevos datos con las siguientes condiciones:
• El nombre no puede dejarse en banco ni tener más de 8 caracteres.
• Las longitudes de los lados tiene que estar entre 1 y 100.
Luego se volverá al punto 1

En caso negativo:
Se sale del programa.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace P40e1_Proyecto_Rectangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangulo rectangulo1 = new Rectangulo("Rectan-1", 10, 20);

            rectangulo1.RectanguloAString();

            while (Tools.PreguntaSiNo("¿Quieres Modificar?"))
            {
                string nombreRectangulo = Tools.CapturaNombreRectangulo(0, "para modificar el nombre del rectángulo");
                double ladoBase = Tools.CapturaDouble(0, "para modificar el Lado Base del rectángulo", 1, 100);
                double ladoLateral = Tools.CapturaDouble(0, "para modificar el Lado Lateral", 1, 100);

                rectangulo1.Nombre = nombreRectangulo;
                rectangulo1.LadoBase = ladoBase;
                rectangulo1.LadoLateral = ladoLateral;

                Console.Clear();

                rectangulo1.RectanguloAString();
                Thread.Sleep(5000);
            }

            Console.Clear();
            Console.WriteLine("\n\tMuchas gracias por utilizar nuestro programa.");

            Tools.StopProgram();
        }
    }
}
