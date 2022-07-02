using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P40a_Proyecto_Cliente
{
    class Cliente
    {
        // ATRIBUTOS
        int numDNI;
        char letraDNI;
        string nombre, apellidos;
        byte dia, mes, año; // <-- fecha de nacimiento
        

        // CONSTRUCTORES
        public Cliente(int numDNI, char letraDNI, string apellidos, string nombre, byte dia, byte mes, byte año)
        {
            this.numDNI = numDNI;
            this.letraDNI = letraDNI;
            this.apellidos = apellidos;
            this.nombre = nombre;
            this.dia = dia;
            this.mes = mes;
            this.año = año;
        }

        // GETTERS Y SETTERS
        public int NumDNI { get => numDNI; set => numDNI = value; }
        public char LetraDNI { get => letraDNI; set => letraDNI = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public byte Dia { get => dia; set => dia = value; }
        public byte Mes { get => mes; set => mes = value; }
        public byte Año { get => año; set => año = value; }

        // MÉTODOS
        public void Mostrar_v1()
        {
            Console.Write
            (
                numDNI + "-" + letraDNI + " " + Tools.CuadraTexto((apellidos + ", " + nombre), 27) + " " + dia.ToString("00") + "/" + mes.ToString("00")/* + "/" + año.ToString("0000")*/
            );

            // para decidir si las dos últimas cifras del año, pertenecen al SXX o al SXXI, he seguido la regla de Microsoft Excel
            // https://docs.microsoft.com/es-es/office/troubleshoot/excel/two-digit-year-numbers
            if (año >= 0 && año <= 29)
            {
                Console.WriteLine("/" + año.ToString("2000"));
            }
            else
            {
                Console.WriteLine("/" + año.ToString("1900"));
            }
        }

        public void Mostrar_v2()
        {
            Console.WriteLine
            (
                numDNI + "-" + letraDNI + " " + Tools.CuadraTexto((apellidos + ", " + nombre), 27) + " " + dia.ToString("00") + "/" + mes.ToString("00") + "/" + Año4cifras + "\t" + Edad
            );
        }

        public int Año4cifras
        {
            get
            {
                /*
                if (año > FECHAHOY.Year % 100)
                {
                    año4cifras = 1900 + año;
                }
                else
                {
                    año4cifras = 2000 + año;
                }
                */

                return (año > Tools.FECHAHOY.Year % 100) ? 1900 + año : 2000 + año;
            }
        }

        public byte Edad
        {
            get
            {
                int añoHoy = Tools.FECHAHOY.Year;
                int mesHoy = Tools.FECHAHOY.Month;
                int diaHoy = Tools.FECHAHOY.Day;

                int edad = añoHoy - Año4cifras;

                // el enfoque correcto está en NO calcular dias o meses "excedentes" para sumar meses o días, sino el de restar para corregir el desfase de dias y meses
                if ((mesHoy < mes) || (mesHoy == mes && diaHoy < dia))
                {
                    edad--;
                }

                return (byte)edad;
            }
        }

        // los dos siguientes métodos, como son utilidades propias de Cliente, y no utilizan ningún atributo en concreto, pues por todo ello los declaro como estatic
        public static void ReadFileAndSaveCustomers(List<Cliente> customersList)
        {
            StreamReader streamReader = new StreamReader("./Datos/Clientes.txt", Encoding.Default);
            string[] vLog = new string[7];

            while (!streamReader.EndOfStream)
            {
                vLog = streamReader.ReadLine().Split('/');

                Cliente cliente = new Cliente
                (
                    Int32.Parse(vLog[0]),
                    Convert.ToChar(vLog[1]),
                    vLog[2].Trim(),
                    vLog[3].Trim(),
                    byte.Parse(vLog[6]),
                    byte.Parse(vLog[5]),
                    byte.Parse(vLog[4])
                );

                customersList.Add(cliente);
            }

            streamReader.Close();
        }

        public static void ShowCustomerList(List<Cliente> customersList)
        {
            foreach (Cliente cliente in customersList)
            {
                // cliente.Mostrar_v1();
                cliente.Mostrar_v2();
            }
        }
    }
}
