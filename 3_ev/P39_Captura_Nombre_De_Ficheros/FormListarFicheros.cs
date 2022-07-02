using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CapturaNombreFicheros
{
    public partial class FormListarFicheros : Form
    {
        List<string> listArchivos;
        string rutaDirectorio;

        void ExtraerDatos()
        {
            int posicion = listArchivos[0].LastIndexOf('\\');

            rutaDirectorio = listArchivos[0].Substring(0, posicion + 1); // el (+1) es para la barra

            for (int i = 0; i < listArchivos.Count; i++)
            {
                listArchivos[i] = listArchivos[i].Substring(posicion + 1);
            }
        }

        void GuardarListaNombres(string rutaDestino) // esta rutaDestino es la rutaDirectorio que hayo en el método anterior
        {
            StreamWriter streamWriter = new StreamWriter(rutaDestino, false, Encoding.Default);

            Console.WriteLine
            (
                "Directorio: {0}\n\nFicheros Selecccionados:\n-----------------------------------",

                rutaDirectorio
            );

            for (int i = 0; i < listArchivos.Count; i++)
            {
                streamWriter.WriteLine(listArchivos[i]);
            }

            streamWriter.Close();
        }

		#region --- Mejor que no toques lo que sigue a continuación ----
		public FormListarFicheros()
        {
            InitializeComponent();
        }

        private void btnAbrirArchivo_Click(object sender, EventArgs e)
        {
            
            if (dialogoAbrirArchivo.ShowDialog() == DialogResult.Cancel)
                return;
            listArchivos = new List<string>(dialogoAbrirArchivo.FileNames);

            ExtraerDatos();

            lbDirectorio.Text = rutaDirectorio;

            listBoxFicheros.DataSource = listArchivos;
            listBoxFicheros.SelectedIndex = -1;
            listBoxFicheros.Refresh();
            // Muestro en las etiquetas el número de archivos
            lbNumArchivos.Text = listArchivos.Count.ToString();
            // Si la lista tiene elementos activo los botones de ordenar, borrar, etc.
            if (listBoxFicheros.Items.Count > 0)
                btnGuardar.Enabled = true;

        }


		private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GuardarListaNombres(saveFileDialog1.FileName);
            }
        }

        private void FormBuscaCorreos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listBoxFicheros.Items.Count == 0)
                return;
            DialogResult dr;

            dr = MessageBox.Show("¿Deseas guardar la lista antes de salir?", "",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (dr == DialogResult.Yes)
                btnGuardar.PerformClick();
            // Si le hemos dado a Cancel, deshacemos el cierre
            else if (dr == DialogResult.Cancel)
                e.Cancel = true; // <-- Esta sencilla instrucción sehace el cierre
        }
		#endregion
	}
}
