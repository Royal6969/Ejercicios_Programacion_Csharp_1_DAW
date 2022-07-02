/*
De Campos Dimensionados a Campos Separados

Antes que nada, guardar una copia del fichero AlumNotas_CD.txt en una carpeta de nombre AlumnosNotas dentro de zDatosPruebas.

El programa leerá los registros del fichero de campos dimensionados AlumNotas_CD.txt , 
cuyos campos están guardados con las dimensiones siguientes:

id: 3; alumno: 28; notaProg: 3; notaED: 3; notaBD: 3 ------------------> 3 + 28 + 3 + 3 + 3 = 40 (en realidad cada linea tiene 38 caracteres)

y los guardará en un fichero de campos separados AlumNotas_CS.txt 
de modo que los campos, sin espacios laterales, estén separados por el carácter ';'.

A continuación, leerá los datos del fichero resultante AlumNotas_CS.txt 
y los mostrará en pantalla con su cabecera.

Nota: Utilizar el menor número de recursos posible. 
Evidentemente, no hace falta utilizar listas ni tablas.
*/

StreamReader streamReader = new StreamReader("./Datos/AlumNotas_CD.TXT");
StreamWriter streamWriter = new StreamWriter("./Datos/AlumNotas_CS.txt", false);
string line = string.Empty;

while (!streamReader.EndOfStream)
{
    line = streamReader.ReadLine();

    streamWriter.WriteLine
    (
        "{0};{1};{2};{3};{4}",

        line.Substring(0, 3),
        line.Substring(3, 26).Trim(),
        line.Substring(29, 3).Trim(),
        line.Substring(32, 3).Trim(),    
        line.Substring(35).Trim()
    );
}

streamReader.Close();
streamWriter.Close();


streamReader = new StreamReader("./Datos/AlumNotas_CS.txt");
string[] vLog = new string[5];
float sumaNotas1 = 0;
float sumaNotas2 = 0;
float sumaNotas3 = 0;
int contLines = 0;

while (!streamReader.EndOfStream)
{
    vLog = streamReader.ReadLine().Split(";");
    contLines ++;

    Console.WriteLine
    (
        "{0}\t{1}\t{2}\t{3}\t{4}\t{5}",

        vLog[0],
        CuadraTexto(vLog[1], 30),
        float.Parse(vLog[2]).ToString("0.0"),
        float.Parse(vLog[3]).ToString("0.0"),    
        float.Parse(vLog[4]).ToString("0.0"),
        
        ( ( float.Parse(vLog[2]) + float.Parse(vLog[3]) + float.Parse(vLog[4]) ) / 3 ).ToString("0.0"), // para presentar la media de las tres notas de cada alumno

        sumaNotas1 += float.Parse(vLog[2]),
        sumaNotas2 += float.Parse(vLog[3]),
        sumaNotas3 += float.Parse(vLog[4])
    );
}

Console.WriteLine("\n\n\tLa media de las notas del primer examen es:\t" + (sumaNotas1 / contLines).ToString("0.00"));
Console.WriteLine("\n\tLa media de las notas del segundo examen es:\t" + (sumaNotas2 / contLines).ToString("0.00"));
Console.WriteLine("\n\tLa media de las notas del tercer examen es:\t" + (sumaNotas3 / contLines).ToString("0.00"));

streamReader.Close();

StopProgram();

/******************************************* MÉTODOS *************************************/

static string CuadraTexto(string texto, int nCaracteres)
{
    texto += ".....................................";

    return texto.Substring(0, nCaracteres);
}

static void StopProgram()
{
    Console.Write("\n\n\tPress any key to exit.");
    Console.ReadKey(true);
}