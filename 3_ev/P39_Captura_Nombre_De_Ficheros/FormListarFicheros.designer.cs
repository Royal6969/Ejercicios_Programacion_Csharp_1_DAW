namespace CapturaNombreFicheros
{
    partial class FormListarFicheros
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.btnAbrirArchivo = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.panelBotones = new System.Windows.Forms.Panel();
			this.lbNumArchivos = new System.Windows.Forms.Label();
			this.dialogoAbrirArchivo = new System.Windows.Forms.OpenFileDialog();
			this.listBoxFicheros = new System.Windows.Forms.ListBox();
			this.lbDirectorio = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panelBotones.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAbrirArchivo
			// 
			this.btnAbrirArchivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnAbrirArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAbrirArchivo.Location = new System.Drawing.Point(16, 11);
			this.btnAbrirArchivo.Name = "btnAbrirArchivo";
			this.btnAbrirArchivo.Size = new System.Drawing.Size(150, 47);
			this.btnAbrirArchivo.TabIndex = 0;
			this.btnAbrirArchivo.Text = "Elegir archivos";
			this.btnAbrirArchivo.UseVisualStyleBackColor = true;
			this.btnAbrirArchivo.Click += new System.EventHandler(this.btnAbrirArchivo_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Archivos de Texto|*.TXT|Archivos Access 2007|*.accdb|Archivos Access 2003|*.mdb|T" +
    "odos los archivos |*.*";
			this.saveFileDialog1.InitialDirectory = ".\\..\\..\\Datos";
			// 
			// btnGuardar
			// 
			this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGuardar.Enabled = false;
			this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGuardar.Location = new System.Drawing.Point(240, 11);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(159, 47);
			this.btnGuardar.TabIndex = 9;
			this.btnGuardar.Text = "Guardar Lista";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// panelBotones
			// 
			this.panelBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.panelBotones.Controls.Add(this.label2);
			this.panelBotones.Controls.Add(this.btnGuardar);
			this.panelBotones.Controls.Add(this.btnAbrirArchivo);
			this.panelBotones.Controls.Add(this.lbNumArchivos);
			this.panelBotones.Location = new System.Drawing.Point(26, 456);
			this.panelBotones.Name = "panelBotones";
			this.panelBotones.Size = new System.Drawing.Size(413, 70);
			this.panelBotones.TabIndex = 10;
			// 
			// lbNumArchivos
			// 
			this.lbNumArchivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.lbNumArchivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbNumArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbNumArchivos.Location = new System.Drawing.Point(177, 25);
			this.lbNumArchivos.Name = "lbNumArchivos";
			this.lbNumArchivos.Size = new System.Drawing.Size(52, 26);
			this.lbNumArchivos.TabIndex = 13;
			this.lbNumArchivos.Text = "0";
			this.lbNumArchivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dialogoAbrirArchivo
			// 
			this.dialogoAbrirArchivo.Multiselect = true;
			// 
			// listBoxFicheros
			// 
			this.listBoxFicheros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.listBoxFicheros.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
			this.listBoxFicheros.FormattingEnabled = true;
			this.listBoxFicheros.HorizontalScrollbar = true;
			this.listBoxFicheros.ItemHeight = 18;
			this.listBoxFicheros.Location = new System.Drawing.Point(26, 92);
			this.listBoxFicheros.Name = "listBoxFicheros";
			this.listBoxFicheros.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxFicheros.Size = new System.Drawing.Size(413, 346);
			this.listBoxFicheros.TabIndex = 30;
			// 
			// lbDirectorio
			// 
			this.lbDirectorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.lbDirectorio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbDirectorio.Location = new System.Drawing.Point(23, 32);
			this.lbDirectorio.Name = "lbDirectorio";
			this.lbDirectorio.Size = new System.Drawing.Size(416, 32);
			this.lbDirectorio.TabIndex = 31;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(23, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 16);
			this.label1.TabIndex = 32;
			this.label1.Text = "Directorio";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(176, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 33;
			this.label2.Text = "Nº archivos";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(23, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(68, 16);
			this.label3.TabIndex = 33;
			this.label3.Text = "Archivos";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// FormBuscaEmails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 561);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbDirectorio);
			this.Controls.Add(this.listBoxFicheros);
			this.Controls.Add(this.panelBotones);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(485, 600);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(485, 600);
			this.Name = "FormBuscaEmails";
			this.ShowIcon = false;
			this.Text = "Nombres de los archivos del directorio";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBuscaCorreos_FormClosing);
			this.panelBotones.ResumeLayout(false);
			this.panelBotones.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirArchivo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.OpenFileDialog dialogoAbrirArchivo;
        private System.Windows.Forms.Label lbNumArchivos;
		private System.Windows.Forms.ListBox listBoxFicheros;
		private System.Windows.Forms.Label lbDirectorio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

