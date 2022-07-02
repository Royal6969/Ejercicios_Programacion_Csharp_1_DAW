/*
Construir el método: CapturaRuta:
Recibe: Nada
Hace: Pide al usuario el nombre de un fichero
• Si existe en la carpeta C:zDatosPruebas devuelve la ruta completa.
• Si no, da mensaje de error y vuelve a pedir el nombre del fichero.

Realizar el siguiente programa:
El programa pedirá un nombre de fichero utilizando CapturaRuta. Con la ruta devuelta, abrirá el
fichero indicado y...
Versión 1: Hacer que vaya leyendo las líneas del fichero indicado y las muestre en pantalla.

Versión 2:
• Instalar una carpeta Datos dentro del directorio de trabajo y colocar en dicha carpeta los
archivos a leer.
• CapturaRuta comprobará la existencia del fichero, mediante ruta relativa.
• Después de mostrar el fichero, presentará cuántos párrafos (líneas) tiene 
y repetirá el párrafo más largo indicando el número de caracteres que tiene.
*/

StreamReader streamReader;
string nombreFichero = string.Empty;
string linea = string.Empty;
int contLineas = 0;
string parrafoMayor = string.Empty;

ShowExercisesDone();
nombreFichero = CapturaRuta();

while (nombreFichero != "")
{
    Console.Clear();
    ShowExercisesDone();
    streamReader = new StreamReader("./Datos/" + nombreFichero + ".txt");

    while (!streamReader.EndOfStream)
    {
        linea = streamReader.ReadLine();
        Console.WriteLine(linea);
        contLineas ++;

        if (linea.Length > parrafoMayor.Length)
        {
            parrafoMayor = linea;
        }
    }

    streamReader.Close();

    Console.WriteLine("\n\n\nEl texto tiene " + contLineas + " párrafos, y el párrafo más largo contiene " + parrafoMayor.Length + " caracteres, y es el siguiente:\n");
    Console.WriteLine("\n" + parrafoMayor);

    contLineas = 0;
    linea = string.Empty;
    parrafoMayor = string.Empty;
    nombreFichero = CapturaRuta();
}

StopProgram();

/***************************************** MÉTODOS *************************************/

static void ShowExercisesDone()
{
    Console.WriteLine("\n\n");
    Console.WriteLine("\t╔═════════════════════════════════════════╗");
    Console.WriteLine("\t║         EJERCICIOS REALIZADOS           ║");
    Console.WriteLine("\t╠═════════════════════════════════════════╣");
    Console.WriteLine("\t║                                         ║");
    Console.WriteLine("\t║    1.- AlumNotas_CD                     ║");
    Console.WriteLine("\t║    2.- AlumNotas_CS                     ║");
    Console.WriteLine("\t║    3.- Pacientes                        ║");
    Console.WriteLine("\t║    4.- PacientesPeso_CD                 ║");
    Console.WriteLine("\t║    5.- PacientesPeso_CS                 ║");
    Console.WriteLine("\t║    6.- Pelis-Test-1                     ║");
    Console.WriteLine("\t║    7.- Pelis                            ║");
    Console.WriteLine("\t║                                         ║");
    Console.WriteLine("\t╚═════════════════════════════════════════╝");
}

static string CapturaRuta()
{
    string ruta = string.Empty;
    bool rutaOk = false;

    do 
    {
        Console.Write("\n\nPor favor, introduzca el nombre de uno de los archivos para leerlo:\t");
        ruta = Console.ReadLine();

        if (!File.Exists("./Datos/" + ruta + ".txt") && ruta != "")
        {
            Console.WriteLine("\n\nError: El nombre introducido no coincide con ningún archivo.");
            rutaOk = false;
        }
        else if (ruta == "")
        {
            Console.Clear();
            Console.WriteLine("\n\nMuchas gracias por utilizar nuestra aplicación");
            rutaOk = true;
        }
        else 
        {
            rutaOk = true;
        }

    } while (!rutaOk);

    return ruta;
}

static void StopProgram()
{
    Console.WriteLine("\n\n\tPress any key to exit.");
    Console.ReadKey(true);
}