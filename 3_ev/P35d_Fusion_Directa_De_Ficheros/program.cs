using System;
using System.IO;
using System.Text;

namespace P35d_Fusion_Directa_De_Ficheros
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader1 = File.OpenText("./Datos/n1.txt");
            StreamReader streamReader2 = File.OpenText("./Datos/n2.txt");
            StreamWriter streamWriter = File.CreateText("./Datos/n3.txt");

            int numPar = 0;
            int numImpar = 0;
            Boolean primeraVez = true;
            Boolean ultimoPar = false;
            Boolean ultimoImpar = false;
            Boolean existioUltimoImpar = false;
            Boolean existioUltimoPar = false;
            Boolean pintoPar = false;
            Boolean pintoImpar = false;

            while (!streamReader1.EndOfStream || !streamReader2.EndOfStream)
            {
                if (!primeraVez)
                {
                    if (numPar < numImpar)
                    {
                        if (!streamReader2.EndOfStream) 
                        { 
                            numPar = Convert.ToInt32(streamReader2.ReadLine());
                            if (streamReader2.EndOfStream)
                            {
                                ultimoPar = true;
                                existioUltimoPar = true;
                            }
                        }
                        else if (streamReader2.EndOfStream && !streamReader1.EndOfStream && pintoPar) 
                        {
                            pintoPar = false;

                            Console.WriteLine(numImpar);
                            streamWriter.WriteLine(numImpar);

                            numImpar = Convert.ToInt32(streamReader1.ReadLine());
                        }
                        else if (streamReader2.EndOfStream && !streamReader1.EndOfStream)
                        {
                            numImpar = Convert.ToInt32(streamReader1.ReadLine());
                        }
                        
                    }
                    else 
                    {
                        if(!streamReader1.EndOfStream)
                        { 
                            numImpar = Convert.ToInt32(streamReader1.ReadLine());
                            if (streamReader1.EndOfStream)
                            {
                                ultimoImpar = true;
                                existioUltimoImpar = true;
                            }
                        }
                        else if (streamReader1.EndOfStream && !streamReader2.EndOfStream && pintoImpar)
                        {
                            pintoImpar = false;

                            Console.WriteLine(numPar);
                            streamWriter.WriteLine(numPar);

                            numPar = Convert.ToInt32(streamReader2.ReadLine());
                        }
                        else if (streamReader1.EndOfStream && !streamReader2.EndOfStream)
                        {
                            numPar = Convert.ToInt32(streamReader2.ReadLine());
                        }
                        
                    }
                    
                }
                else
                {
                    numImpar = Convert.ToInt32(streamReader1.ReadLine());
                    numPar = Convert.ToInt32(streamReader2.ReadLine());
                    primeraVez = false;
                }

                if (numPar < numImpar)
                {
                    if(!streamReader2.EndOfStream)
                    { 
                        Console.WriteLine(numPar);
                        streamWriter.WriteLine(numPar);

                        pintoPar = true;
                        pintoImpar = false;
                    }
                    else if (ultimoPar)
                    {
                        Console.WriteLine("lo voy a probar" + numPar);
                        streamWriter.WriteLine(numPar);

                        ultimoPar = false;

                        pintoPar = true;
                        pintoImpar = false;
                    }
                    else if (!streamReader1.EndOfStream)
                    {
                        Console.WriteLine(numImpar);
                        streamWriter.WriteLine(numImpar);

                        pintoPar = false;
                        pintoImpar = true;
                        
                    }
                    
                }
                else
                {
                    if (!streamReader1.EndOfStream)
                    {
                        Console.WriteLine(numImpar);
                        streamWriter.WriteLine(numImpar);
                       
                        pintoPar = false;
                        pintoImpar = true;
                    }
                    else if (ultimoImpar)
                    {
                        Console.WriteLine(numImpar);
                        streamWriter.WriteLine(numImpar);
                        ultimoImpar = false;

                        pintoPar = false;
                        pintoImpar = true;
                    }
                    else if (!streamReader2.EndOfStream)
                    {
                        Console.WriteLine(numPar);
                        streamWriter.WriteLine(numPar);
                        
                        pintoPar = true;
                        pintoImpar = false;
                    }
                    
                }
            }
            if (existioUltimoImpar)
            {
                //esto significa que nunca llego a true ultimoPar
                Console.WriteLine(numPar);
                streamWriter.WriteLine(numPar);

            }
            else if(existioUltimoPar)
            {
                Console.WriteLine(numImpar);
                streamWriter.WriteLine(numImpar);
            }
            
            streamReader1.Close();
            streamReader2.Close();
            streamWriter.Close();

            PararPrograma();
        }

        /**************************************************************** MÉTODOS *********************************************************/

        public static string CuadraTexto(string texto, int nCaracteres)
        {
            texto += ".........................................";

            return texto.Substring(0, nCaracteres);
        }

        public static void PararPrograma()
        {
            Console.WriteLine("\n\n\nPress any key to exit.");
            Console.ReadKey(true);
        }
    }
}
