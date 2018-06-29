namespace CapturaCalificaciones
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSeleccionarExcel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbHojas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciarCapturaDeCalificaciones = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExcelSeleccionado = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkCapturaDefault = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtUrl_DetallesPagos = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnIr_DetallesPagos = new System.Windows.Forms.ToolStripButton();
            this.btnDetener_DetallesPagos = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar_DetallesPagos = new System.Windows.Forms.ToolStripButton();
            this.btnAtras_DetallesPagos = new System.Windows.Forms.ToolStripButton();
            this.btnAdelante_DetallesPagos = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSeleccionarExcel
            // 
            this.btnSeleccionarExcel.Location = new System.Drawing.Point(18, 31);
            this.btnSeleccionarExcel.Name = "btnSeleccionarExcel";
            this.btnSeleccionarExcel.Size = new System.Drawing.Size(134, 43);
            this.btnSeleccionarExcel.TabIndex = 0;
            this.btnSeleccionarExcel.Text = "Seleccionar Excel";
            this.btnSeleccionarExcel.UseVisualStyleBackColor = true;
            this.btnSeleccionarExcel.Click += new System.EventHandler(this.btnSeleccionarExcel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(2, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "-- Seleccione un excel --";
            // 
            // cmbHojas
            // 
            this.cmbHojas.ForeColor = System.Drawing.Color.Red;
            this.cmbHojas.FormattingEnabled = true;
            this.cmbHojas.Location = new System.Drawing.Point(7, 141);
            this.cmbHojas.Name = "cmbHojas";
            this.cmbHojas.Size = new System.Drawing.Size(152, 23);
            this.cmbHojas.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(2, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "-- Seleccione una hoja --";
            // 
            // btnIniciarCapturaDeCalificaciones
            // 
            this.btnIniciarCapturaDeCalificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarCapturaDeCalificaciones.Location = new System.Drawing.Point(22, 188);
            this.btnIniciarCapturaDeCalificaciones.Name = "btnIniciarCapturaDeCalificaciones";
            this.btnIniciarCapturaDeCalificaciones.Size = new System.Drawing.Size(133, 55);
            this.btnIniciarCapturaDeCalificaciones.TabIndex = 4;
            this.btnIniciarCapturaDeCalificaciones.Text = "Iniciar Captura de Calificaciones";
            this.btnIniciarCapturaDeCalificaciones.UseVisualStyleBackColor = true;
            this.btnIniciarCapturaDeCalificaciones.Click += new System.EventHandler(this.btnIniciarCapturaDeCalificaciones_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(7, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Excel seleccionado:";
            // 
            // lblExcelSeleccionado
            // 
            this.lblExcelSeleccionado.AutoSize = true;
            this.lblExcelSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExcelSeleccionado.ForeColor = System.Drawing.Color.Red;
            this.lblExcelSeleccionado.Location = new System.Drawing.Point(17, 94);
            this.lblExcelSeleccionado.Name = "lblExcelSeleccionado";
            this.lblExcelSeleccionado.Size = new System.Drawing.Size(0, 13);
            this.lblExcelSeleccionado.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkCapturaDefault);
            this.panel1.Controls.Add(this.lblExcelSeleccionado);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnIniciarCapturaDeCalificaciones);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbHojas);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSeleccionarExcel);
            this.panel1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(837, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 376);
            this.panel1.TabIndex = 1;
            // 
            // chkCapturaDefault
            // 
            this.chkCapturaDefault.AutoSize = true;
            this.chkCapturaDefault.Checked = true;
            this.chkCapturaDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCapturaDefault.Location = new System.Drawing.Point(4, 264);
            this.chkCapturaDefault.Name = "chkCapturaDefault";
            this.chkCapturaDefault.Size = new System.Drawing.Size(172, 19);
            this.chkCapturaDefault.TabIndex = 7;
            this.chkCapturaDefault.Text = "Captura normal en parcial";
            this.chkCapturaDefault.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.webBrowser1);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Location = new System.Drawing.Point(12, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(822, 575);
            this.panel2.TabIndex = 2;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 46);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(822, 507);
            this.webBrowser1.TabIndex = 7;
            this.webBrowser1.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser1_ProgressChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtUrl_DetallesPagos,
            this.toolStripSeparator1,
            this.btnIr_DetallesPagos,
            this.btnDetener_DetallesPagos,
            this.btnActualizar_DetallesPagos,
            this.btnAtras_DetallesPagos,
            this.btnAdelante_DetallesPagos});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(822, 46);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtUrl_DetallesPagos
            // 
            this.txtUrl_DetallesPagos.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl_DetallesPagos.Name = "txtUrl_DetallesPagos";
            this.txtUrl_DetallesPagos.Size = new System.Drawing.Size(350, 46);
            this.txtUrl_DetallesPagos.Text = "http://controlescolar.itesi.edu.mx";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // btnIr_DetallesPagos
            // 
            this.btnIr_DetallesPagos.Image = ((System.Drawing.Image)(resources.GetObject("btnIr_DetallesPagos.Image")));
            this.btnIr_DetallesPagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIr_DetallesPagos.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnIr_DetallesPagos.Name = "btnIr_DetallesPagos";
            this.btnIr_DetallesPagos.Size = new System.Drawing.Size(51, 43);
            this.btnIr_DetallesPagos.Text = "Ir";
            this.btnIr_DetallesPagos.Click += new System.EventHandler(this.btnIr_DetallesPagos_Click);
            // 
            // btnDetener_DetallesPagos
            // 
            this.btnDetener_DetallesPagos.Image = ((System.Drawing.Image)(resources.GetObject("btnDetener_DetallesPagos.Image")));
            this.btnDetener_DetallesPagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDetener_DetallesPagos.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnDetener_DetallesPagos.Name = "btnDetener_DetallesPagos";
            this.btnDetener_DetallesPagos.Size = new System.Drawing.Size(87, 43);
            this.btnDetener_DetallesPagos.Text = "Detener";
            this.btnDetener_DetallesPagos.Click += new System.EventHandler(this.btnDetener_DetallesPagos_Click);
            // 
            // btnActualizar_DetallesPagos
            // 
            this.btnActualizar_DetallesPagos.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar_DetallesPagos.Image")));
            this.btnActualizar_DetallesPagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualizar_DetallesPagos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar_DetallesPagos.Name = "btnActualizar_DetallesPagos";
            this.btnActualizar_DetallesPagos.Size = new System.Drawing.Size(101, 43);
            this.btnActualizar_DetallesPagos.Text = "Actualizar";
            this.btnActualizar_DetallesPagos.Click += new System.EventHandler(this.btnActualizar_DetallesPagos_Click);
            // 
            // btnAtras_DetallesPagos
            // 
            this.btnAtras_DetallesPagos.Image = ((System.Drawing.Image)(resources.GetObject("btnAtras_DetallesPagos.Image")));
            this.btnAtras_DetallesPagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAtras_DetallesPagos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAtras_DetallesPagos.Name = "btnAtras_DetallesPagos";
            this.btnAtras_DetallesPagos.Size = new System.Drawing.Size(71, 43);
            this.btnAtras_DetallesPagos.Text = "Atras";
            this.btnAtras_DetallesPagos.Click += new System.EventHandler(this.btnAtras_DetallesPagos_Click);
            // 
            // btnAdelante_DetallesPagos
            // 
            this.btnAdelante_DetallesPagos.Image = ((System.Drawing.Image)(resources.GetObject("btnAdelante_DetallesPagos.Image")));
            this.btnAdelante_DetallesPagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdelante_DetallesPagos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdelante_DetallesPagos.Name = "btnAdelante_DetallesPagos";
            this.btnAdelante_DetallesPagos.Size = new System.Drawing.Size(93, 43);
            this.btnAdelante_DetallesPagos.Text = "Adelante";
            this.btnAdelante_DetallesPagos.Click += new System.EventHandler(this.btnAdelante_DetallesPagos_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 553);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(822, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(845, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 123);
            this.label3.TabIndex = 6;
            this.label3.Text = "Autor:\r\n   Ing. Néstor León Vega\r\n\r\n©Copyright 2015\r\n\r\nE-mail:\r\n   neleon@itesi.e" +
    "du.mx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1027, 594);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Captura de Calificaciones CONECBU";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSeleccionarExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHojas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciarCapturaDeCalificaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblExcelSeleccionado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtUrl_DetallesPagos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton btnIr_DetallesPagos;
        private System.Windows.Forms.ToolStripButton btnDetener_DetallesPagos;
        private System.Windows.Forms.ToolStripButton btnActualizar_DetallesPagos;
        private System.Windows.Forms.ToolStripButton btnAtras_DetallesPagos;
        private System.Windows.Forms.ToolStripButton btnAdelante_DetallesPagos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkCapturaDefault;

    }
}

