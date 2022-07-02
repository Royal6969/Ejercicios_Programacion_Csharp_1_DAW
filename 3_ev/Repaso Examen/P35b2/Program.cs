/*
De Campos separados a dimensionados

Antes que nada, guardar una copia del fichero PacientesPeso_Cs.txt en una carpeta de nombre Pacientes dentro de zDatosPruebas.

Los registros de "PacientesPeso_CS.txt", tienen los campos separados por '$' en el siguiente orden:
id $ Apellidos, Nombre $ movil $ fechaNac $ altura $ peso

El proceso a seguir será el siguiente:

1) El programa leerá los registros y los guardará en un fichero que debes construir, 
en la misma carpeta, con el nombre: PacientesPeso_CD.txt". 

En este fichero se guardarán los campos dimensionados con el siguiente número de caracteres:
id Apellidos, Nombre móvil fechaNac altura peso
3 28 9 8 3 5

2) A continuación leerá los datos de este último fichero y los presentará en pantalla con su cabecera.

Importante:
Ten en cuenta que la fecha está guardada como un entero compuesto como AAAAMMDD, 
es decir, los 4 primeros dígitos son el año, los dos siguientes el mes y los dos últimos el día. 
Tú lo debes presentar como día/mes/año.

Tanto el id como la altura, que está en centímetros deben estar alineados a la derecha. 
El peso también tiene que estar bien alineado.

3) Por último, dirá el peso medio de todos los Pacientes.
*/

StreamReader streamReader = new StreamReader("./Pacientes/PacientesPeso_CS.txt");
StreamWriter streamWriter = new StreamWriter("./Pacientes/PacientesPeso_CD.txt", false);
string[] vLog = new string[6];

while (!streamReader.EndOfStream)
{
    vLog = streamReader.ReadLine().Split("$");
    
    streamWriter.WriteLine
    (
        "{0}{1}{2}{3}{4}{5}",

        CuadraTexto(vLog[0], 6),
        CuadraTexto(vLog[1], 32),
        CuadraTexto(vLog[2], 12),
        CuadraTexto(vLog[3], 12),
        CuadraTexto(vLog[4], 6),
        vLog[5]
    );
}

streamReader.Close();
streamWriter.Close();


streamReader = new StreamReader("./Pacientes/PacientesPeso_CD.txt");
string line = string.Empty;
double sumaPesos = 0;
int contLines = 0;

while (!streamReader.EndOfStream)
{
    line = streamReader.ReadLine();
    contLines ++;

    if (Int32.Parse(line.Substring(0, 3).Trim()) < 99)
        Console.Write(" " + line.Substring(0, 3).Trim());
    else if (line.Substring(0, 3).Length == 3)
        Console.Write(line.Substring(0, 3));

    Console.Write
    (
        "\t{0}\t{1}\t{2}\t",

        line.Substring(6, 28),
        line.Substring(38, 9),
        line.Substring(56, 2) + "/" + line.Substring(54, 2) + "/" + line.Substring(50, 4),
        line.Substring(62, 3)
    );

    if (line.Substring(68).Length < 5)
        Console.WriteLine(" " + double.Parse(line.Substring(68)).ToString("00.00"));
                
    else
        Console.WriteLine(double.Parse(line.Substring(68)).ToString("00.00"));
    
    sumaPesos += double.Parse(line.Substring(68));
}

Console.WriteLine("\n\n\tEl peso medio de todos los pacientes es de:\t" + (sumaPesos / contLines).ToString("00.00"));

streamReader.Close();

StopProgram();

/****************************************** MÉTODOS *************************************/

static string CuadraTexto(string texto, int nCaracteres)
{
    texto += "                                  ";

    return texto.Substring(0, nCaracteres);
}

static void StopProgram()
{
    Console.Write("\n\n\tPress any key to exit.");
    Console.ReadKey(true);
}