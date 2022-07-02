/* Prueba de distintos métodos "CuadraTexto"
 Nota: El relleno se va a hacer, por defecto, con puntos.
*/
using System;

class Program
{
    const int NUMCHAR = 15, POSICIONX = 0;
    static void Main(string[] args)
    {
        string frase;

        do
        {
            #region --- NO TOCAR ESTE BLOQUE DE CÓDIGO ---
            Console.Clear();
            Console.Write("¿texto?: ");
            frase = Console.ReadLine();
            Console.WriteLine("        10        20        30        40        50        60");
            Console.WriteLine("123456789 123456789 123456789 123456789 123456789 123456789 ");
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.SetCursorPosition(POSICIONX, 3);
            #endregion

            Console.WriteLine(CuadraTexto(frase, NUMCHAR));

        } while (PreguntaSiNo("¿Quieres repetir?"));

    }

    // Modifica y sube este método
    static string CuadraTexto(string texto, int numChar)
    {
        // Alumno: Alberto Talamino

        if (texto.Length > numChar)
            texto = texto.Substring(0, numChar);
        else
        {
            for (int i = texto.Length; i < numChar; i++)
            {
                //texto = texto + " ";
                texto = " " + texto;
            }
        }



        return texto;
    }


    #region --- NO TOCAR ESTE BLOQUE DE CÓDIGO ---
    public static bool PreguntaSiNo(string pregunta)
    {
        char tecla;

        do
        {
            // Hacemos la pregunta
            Console.Write("\n\n{0} (s=Sí; n=No): ", pregunta);
            // Capturamos la respuesta (una pulsación)
            tecla = (Console.ReadKey()).KeyChar;
            if (tecla == 's' || tecla == 'S')
                return true;
            if (tecla == 'n' || tecla == 'N')
                return false;
            // Si llega aquí es que no ha pulsado ninguna de las teclas correctas
            Console.Write("\n\n\t** Error: por favor, responde S o N **");

        } while (true);

    }
    #endregion
}
