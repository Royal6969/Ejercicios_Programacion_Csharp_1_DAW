using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41a_Alumnos_Con_Herencia
{
    class Fecha
    {
        // ATRIBUTOS 

        int dia = 0;
        int mes = 0;
        int año = 0;

        // public static DateTime FECHAHOY = DateTime.Now;
        public string[] meses = { "", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };
        public int[] maxDiaMes = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };


        // CONSTRUCTORES

        // 1º) uno que recibe los tres campos
        public Fecha(int dia, int mes, int año)
        {
            this.dia = dia;
            this.mes = mes;
            this.año = año;

            if (EsBisiesto)
            {
                maxDiaMes[2] = 29;
            }
        }

        // 2º) otro que recibe la fecha como un entero AAAAMMDD
        public Fecha(int fechaEntero) // Fecha como AAAAMMDD
        {
            dia = fechaEntero % 1000000;       // AAAAMMDD % 1000000 = DD --> Así me quedo con el día
            mes = (fechaEntero % 10000) / 100; // AAAAMMDD % 10000 = MMDD --> MMDD / 100 = MM --> Así me quedo con el mes
            año = fechaEntero / 10000;         // AAAAMMDD / 10000 = 1111 --> Así me quedo con el año 

            if (EsBisiesto)
            {
                maxDiaMes[2] = 29;
            }
        }

        // 3º) y otro que no recibe nada
        public Fecha() 
        {
            dia = DateTime.Now.Day;
            mes = DateTime.Now.Month;
            año = DateTime.Now.Year;
        }


        // GETTERS Y SETTERS
        public int Dia { get => dia; set => dia = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Año 
        {
            get => año;

            set
            {

                año = value;

                if (EsBisiesto)
                {
                    maxDiaMes[2] = 29;
                }
                else
                {
                    maxDiaMes[2] = 28;
                }
            }
        }


        // PROPIEDADES 
        public int FechaEntero
        {
            get
            {
                int dosCifrasAño = año % 100;

                return (dosCifrasAño * 10000 + mes * 100 + dia);
            }
        }

        public string FechaStringSp
        {
            get
            {
                return dia.ToString("00") + "/" + mes.ToString("00") + "/" + año;
            }
        }

        public string FechaStringTexto
        {
            get
            {
                string[] vMeses = { "", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };

                return dia + " de " + vMeses[mes] + " de " + año;
            }
        }

        public bool EsBisiesto
        {
            get
            {
                return ((año % 4 == 0 && año % 100 != 0 || año % 400 == 0)); // si es múltiplo de 400 tmb es bisiesto
            }
        }

        // MÉTODOS
        public void AvanzaDia()
        {
            dia++;

            if (dia > maxDiaMes[mes])
            {
                dia = 1;
                mes++;
            }

            if (mes > 12)
            {
                mes = 1;
                año++;

                if (EsBisiesto)
                {
                    maxDiaMes[2] = 29;
                }
                else
                {
                    maxDiaMes[2] = 28;
                }
            }
        }
    }
}