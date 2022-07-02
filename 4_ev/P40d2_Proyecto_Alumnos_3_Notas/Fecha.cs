using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P40d2_Proyecto_Alumnos_3_Notas
{
    class Fecha
    {
        #region ATRIBUTOS
        int dia;
        int mes;
        int año;
        public static DateTime FECHAHOY = DateTime.Now;
        public string[] meses = { "", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };
        public int[] maxDiaMes = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        #endregion

        #region CONSTRUCTORES
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

        public Fecha()
        {
            dia = FECHAHOY.Day;
            mes = FECHAHOY.Month;
            año = FECHAHOY.Year;
        }
        #endregion

        #region GETTERS_Y_SETTERS
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
        #endregion

        #region PROPIEDADES
        public int FechaEntero
        {
            get
            {
                int dosCifrasAño = año % 100;

                return (dosCifrasAño * 10000 + mes * 100 + dia);
            }
        }

        public int FechaEntero_año4cifras
        {
            get
            {
                return (año * 10000 + mes * 100 + dia);
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

        public int Año4cifras
        {
            get
            {
                return (año > FECHAHOY.Year % 100) ? 1900 + año : 2000 + año;
            }
        }

        public byte Edad
        {
            get
            {
                int añoHoy = FECHAHOY.Year;
                int mesHoy = FECHAHOY.Month;
                int diaHoy = FECHAHOY.Day;

                // int edad = añoHoy - Año4cifras;
                int edad = añoHoy - año;

                // el enfoque correcto está en NO calcular dias o meses "excedentes" para sumar meses o días, sino el de restar para corregir el desfase de dias y meses
                if ((mesHoy < mes) || (mesHoy == mes && diaHoy < dia))
                {
                    edad--;
                }

                return (byte)edad;
            }
        }
        #endregion

        #region MÉTODOS
        public void AvanzaDia()
        {
            dia ++;

            if (dia > maxDiaMes[mes])
            {
                dia = 1;
                mes ++;
            }

            if (mes > 12)
            {
                mes = 1;
                año ++;

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

        #endregion



    }
}