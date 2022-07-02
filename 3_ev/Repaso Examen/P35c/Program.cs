using System.Text;

StreamReader streamReader = new StreamReader("./Datos/pelis.txt", Encoding.Default);
List<string> logsList = new List<string>();

ReadFileAndSaveLogs(streamReader, logsList);

ShowFilmsData(logsList);

string fileName = SetFileName("¿Nombre del fichero donde guardar los datos? (Intro = salir sin guardar)");

SaveDataOrExit(fileName, logsList);

StopProgram();

/*************************************** MÉTODOS *************************************/

static void ReadFileAndSaveLogs(StreamReader streamReader, List<string> logsList)
{
    while (!streamReader.EndOfStream)
    {
        logsList.Add(streamReader.ReadLine());
    }

    streamReader.Close();
}

static void ShowFilmsData(List<string> logsList)
{
    string nameRateFormat = string.Empty;
    string weight = string.Empty;
    string[] nameRate_Format = new string[2];
    string[] name_rate = new string[2];
    string nameRate = string.Empty;
    string format = string.Empty;
    string name = string.Empty;
    string rate = string.Empty;

    for (int i = 0; i < logsList.Count; i++)
    {
        nameRateFormat = logsList[i].Substring(36).Replace(".", " ");
        weight = logsList[i].Substring(22, 13).Replace(".", "");

        nameRate_Format = nameRateFormat.Split(")"); // --> nameRate_Format = [300 extendida(BB] + [ avi]
        nameRate = nameRate_Format[0];               // --> nameRate        = [300 extendida(BB]
        format = nameRate_Format[1].Trim();          // --> format          = [avi]

        name_rate = nameRate.Split("(");             // --> name_rate       = [300 extendida] + [BB]
        name = name_rate[0].Trim();                  // --> name            = [300 extendida]
        rate = name_rate[1].Trim();                  // --> rate            = [BB]

        Console.WriteLine
        (
            "{0}\t{1}\t{2}\t{3}\t{4}",

            i + 1,
            CuadraTexto(name, 30),
            rate,
            format,
            (double.Parse(weight) / 1073741824).ToString("0.00") // 1Gb = 1.073.741.824 bytes
        );
    }
}

static void SaveDataOrExit(string fileName, List<string> logsList)
{
    if (fileName == "")
    {
        Console.WriteLine("\n\n\tHa elegido NO guardar el fichero.");
    }
    else 
    {
        StreamWriter streamWriter = new StreamWriter("./Datos/" + fileName + ".txt", false, Encoding.Default);

        string nameRateFormat = string.Empty;
        string weight = string.Empty;
        string[] nameRate_Format = new string[2];
        string[] name_rate = new string[2];
        string nameRate = string.Empty;
        string format = string.Empty;
        string name = string.Empty;
        string rate = string.Empty;

        for (int i = 0; i < logsList.Count; i++)
        {
            nameRateFormat = logsList[i].Substring(36).Replace(".", " ");
            weight = logsList[i].Substring(22, 13).Replace(".", "");

            nameRate_Format = nameRateFormat.Split(")"); // --> nameRate_Format = [300 extendida(BB] + [ avi]
            nameRate = nameRate_Format[0];               // --> nameRate        = [300 extendida(BB]
            format = nameRate_Format[1].Trim();          // --> format          = [avi]

            name_rate = nameRate.Split("(");             // --> name_rate       = [300 extendida] + [BB]
            name = name_rate[0].Trim();                  // --> name            = [300 extendida]
            rate = name_rate[1].Trim();                  // --> rate            = [BB]

            streamWriter.WriteLine
            (
                "{0};{1};{2};{3}",

                name,
                rate,
                format,
                (double.Parse(weight) / 1073741824).ToString("0.00") // 1Gb = 1.073.741.824 bytes
            );
        }

        streamWriter.Close();

        Console.WriteLine("\n\n\tEl fichero se ha guardado con éxito.");
    }
}

static string SetFileName(string pregunta)
{
    Console.Write("\n\n\t" + pregunta + ":\t");

    string fileName = Console.ReadLine();

    return fileName;
}

static string CuadraTexto(string texto, int nCaracteres)
{
    texto += "..........................................";

    return texto.Substring(0, nCaracteres);
}

static void StopProgram()
{
    Console.WriteLine("\n\n\tPress any key to exit.");
    Console.ReadKey(true);
}
