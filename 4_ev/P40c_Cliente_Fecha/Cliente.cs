using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P40c_Cliente_Fecha
{
    class Cliente
    {
        // ATRIBUTOS
        int numDNI;
        char letraDNI;
        string nombre, apellidos;
        byte dia, mes, año; // <-- fecha de nacimiento

        // atributos extra vProfesor
        string[] vLog;
        Fecha fechaNac;// <-- fecha de nacimiento


        // CONSTRUCTORES

        // el mío
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

        // vProfesor classic
        public Cliente(int numDNI, char letraDNI, string nombre, string apellidos, Fecha fechaNac)
        {
            this.numDNI = numDNI;
            this.letraDNI = letraDNI;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNac = fechaNac;
        }

        // vProfesor recibir la línea del registro
        public Cliente(string registro)
        {
            vLog = registro.Split('/');
            numDNI = Convert.ToInt32(vLog[0]);
            letraDNI = vLog[1][0]; // el caracter estará en la primera posición de la cadena (sólo hay una)
            apellidos = vLog[2].Trim(); // <-- Hago .Trim() por si tienen espacios por los laterales
            nombre = vLog[3].Trim();

            int año = Convert.ToByte(vLog[4]);
            año = (año < 30) ? año + 2000 : año + 1900;
            // fechaNac = new Fecha(año, Convert.ToInt32(vLog[5]), Convert.ToInt32(vLog[6]));
            fechaNac = new Fecha(Convert.ToInt32(vLog[6]), Convert.ToInt32(vLog[5]), año);
        }

        // GETTERS Y SETTERS
        public int NumDNI { get => numDNI; set => numDNI = value; }
        public char LetraDNI { get => letraDNI; set => letraDNI = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public byte Dia { get => dia; set => dia = value; }
        public byte Mes { get => mes; set => mes = value; }
        public byte Año { get => año; set => año = value; }
        public string[] VLog { get => vLog; set => vLog = value; }
        public Fecha FechaNac { get => fechaNac; set => fechaNac = value; }

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

        // vprofesor
        public void Mostrar_vProfesor()
        {
            Console.WriteLine("{0}-{1} {2} {3}\t{4}", numDNI, letraDNI, Tools.CuadraTexto(nombre + ", " + apellidos, 27), fechaNac.FechaStringSp, fechaNac.Edad);
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

                return (año > Fecha.FECHAHOY.Year % 100) ? 1900 + año : 2000 + año;
            }
        }

        public byte Edad
        {
            get
            {
                int añoHoy = Fecha.FECHAHOY.Year;
                int mesHoy = Fecha.FECHAHOY.Month;
                int diaHoy = Fecha.FECHAHOY.Day;

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
                
                while (!streamReader.EndOfStream) // vProfesor con el constructor del registro
                {
                    // construyo el cliente, con el segundo constructor, y lo añado a la lista
                    customersList.Add(new Cliente(streamReader.ReadLine()));
                }
                

                /*
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
                */
            }

            /*
                while (!streamReader.EndOfStream)
			    {
				    // construyo el cliente, con el segundo constructor, y lo añado a la lista
				    listaClientes.Add(new Cliente(sr.ReadLine()));
			    }
            */

            streamReader.Close();
        }

        public static void ShowCustomerList(List<Cliente> customersList)
        {
            foreach (Cliente cliente in customersList)
            {
                // cliente.Mostrar_v1();
                // cliente.Mostrar_v2();
                cliente.Mostrar_vProfesor();
            }
        }
    }
}
