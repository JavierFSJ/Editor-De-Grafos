namespace EditordeGrafos
{
    partial class ConfigNodAri
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRadioNodo = new System.Windows.Forms.Label();
            this.nUDRadioNodo = new System.Windows.Forms.NumericUpDown();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnColorRellenoNodo = new System.Windows.Forms.Button();
            this.btnColorBordeNodo = new System.Windows.Forms.Button();
            this.grpBoxConfNodo = new System.Windows.Forms.GroupBox();
            this.checkLetra = new System.Windows.Forms.CheckBox();
            this.checkNum = new System.Windows.Forms.CheckBox();
            this.nUDAnchoNodo = new System.Windows.Forms.NumericUpDown();
            this.lblAnchoNodo = new System.Windows.Forms.Label();
            this.grpBoxConfArista = new System.Windows.Forms.GroupBox();
            this.chBoxPesoArista = new System.Windows.Forms.CheckBox();
            this.chBoxNombreArista = new System.Windows.Forms.CheckBox();
            this.btnColorArista = new System.Windows.Forms.Button();
            this.lblColorAista = new System.Windows.Forms.Label();
            this.nUDAnchoArista = new System.Windows.Forms.NumericUpDown();
            this.lblAnchoArista = new System.Windows.Forms.Label();
            this.btnPorDefecto = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRadioNodo)).BeginInit();
            this.grpBoxConfNodo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAnchoNodo)).BeginInit();
            this.grpBoxConfArista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAnchoArista)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRadioNodo
            // 
            this.lblRadioNodo.AutoSize = true;
            this.lblRadioNodo.Location = new System.Drawing.Point(16, 25);
            this.lblRadioNodo.Name = "lblRadioNodo";
            this.lblRadioNodo.Size = new System.Drawing.Size(99, 13);
            this.lblRadioNodo.TabIndex = 0;
            this.lblRadioNodo.Text = "Radio del nodo (px)";
            // 
            // nUDRadioNodo
            // 
            this.nUDRadioNodo.Location = new System.Drawing.Point(148, 20);
            this.nUDRadioNodo.Name = "nUDRadioNodo";
            this.nUDRadioNodo.Size = new System.Drawing.Size(75, 20);
            this.nUDRadioNodo.TabIndex = 1;
            this.nUDRadioNodo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDRadioNodo.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(417, 309);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 309);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnColorRellenoNodo
            // 
            this.btnColorRellenoNodo.Location = new System.Drawing.Point(0, 107);
            this.btnColorRellenoNodo.Name = "btnColorRellenoNodo";
            this.btnColorRellenoNodo.Size = new System.Drawing.Size(96, 23);
            this.btnColorRellenoNodo.TabIndex = 2;
            this.btnColorRellenoNodo.Text = " Color de relleno";
            this.btnColorRellenoNodo.UseVisualStyleBackColor = true;
            this.btnColorRellenoNodo.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnColorBordeNodo
            // 
            this.btnColorBordeNodo.Location = new System.Drawing.Point(137, 107);
            this.btnColorBordeNodo.Name = "btnColorBordeNodo";
            this.btnColorBordeNodo.Size = new System.Drawing.Size(94, 23);
            this.btnColorBordeNodo.TabIndex = 2;
            this.btnColorBordeNodo.Text = "Color de borde";
            this.btnColorBordeNodo.UseVisualStyleBackColor = true;
            this.btnColorBordeNodo.Click += new System.EventHandler(this.button4_Click);
            // 
            // grpBoxConfNodo
            // 
            this.grpBoxConfNodo.Controls.Add(this.checkLetra);
            this.grpBoxConfNodo.Controls.Add(this.checkNum);
            this.grpBoxConfNodo.Controls.Add(this.btnColorBordeNodo);
            this.grpBoxConfNodo.Controls.Add(this.btnColorRellenoNodo);
            this.grpBoxConfNodo.Controls.Add(this.nUDAnchoNodo);
            this.grpBoxConfNodo.Controls.Add(this.nUDRadioNodo);
            this.grpBoxConfNodo.Controls.Add(this.lblAnchoNodo);
            this.grpBoxConfNodo.Controls.Add(this.lblRadioNodo);
            this.grpBoxConfNodo.Location = new System.Drawing.Point(12, 12);
            this.grpBoxConfNodo.Name = "grpBoxConfNodo";
            this.grpBoxConfNodo.Size = new System.Drawing.Size(237, 136);
            this.grpBoxConfNodo.TabIndex = 3;
            this.grpBoxConfNodo.TabStop = false;
            this.grpBoxConfNodo.Text = "Nodo";
            // 
            // checkLetra
            // 
            this.checkLetra.AutoSize = true;
            this.checkLetra.Location = new System.Drawing.Point(6, 82);
            this.checkLetra.Name = "checkLetra";
            this.checkLetra.Size = new System.Drawing.Size(50, 17);
            this.checkLetra.TabIndex = 5;
            this.checkLetra.Text = "Letra";
            this.checkLetra.UseVisualStyleBackColor = true;
            this.checkLetra.Click += new System.EventHandler(this.checkLetra_Click);
            // 
            // checkNum
            // 
            this.checkNum.AutoSize = true;
            this.checkNum.Location = new System.Drawing.Point(144, 82);
            this.checkNum.Name = "checkNum";
            this.checkNum.Size = new System.Drawing.Size(66, 17);
            this.checkNum.TabIndex = 4;
            this.checkNum.Text = "Numero ";
            this.checkNum.UseVisualStyleBackColor = true;
            this.checkNum.CheckedChanged += new System.EventHandler(this.checkNum_CheckedChanged);
            this.checkNum.Click += new System.EventHandler(this.checkNum_Click);
            // 
            // nUDAnchoNodo
            // 
            this.nUDAnchoNodo.Location = new System.Drawing.Point(148, 46);
            this.nUDAnchoNodo.Name = "nUDAnchoNodo";
            this.nUDAnchoNodo.Size = new System.Drawing.Size(75, 20);
            this.nUDAnchoNodo.TabIndex = 1;
            this.nUDAnchoNodo.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDAnchoNodo.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // lblAnchoNodo
            // 
            this.lblAnchoNodo.AutoSize = true;
            this.lblAnchoNodo.Location = new System.Drawing.Point(16, 51);
            this.lblAnchoNodo.Name = "lblAnchoNodo";
            this.lblAnchoNodo.Size = new System.Drawing.Size(38, 13);
            this.lblAnchoNodo.TabIndex = 0;
            this.lblAnchoNodo.Text = "Ancho";
            // 
            // grpBoxConfArista
            // 
            this.grpBoxConfArista.Controls.Add(this.chBoxPesoArista);
            this.grpBoxConfArista.Controls.Add(this.chBoxNombreArista);
            this.grpBoxConfArista.Controls.Add(this.btnColorArista);
            this.grpBoxConfArista.Controls.Add(this.lblColorAista);
            this.grpBoxConfArista.Controls.Add(this.nUDAnchoArista);
            this.grpBoxConfArista.Controls.Add(this.lblAnchoArista);
            this.grpBoxConfArista.Location = new System.Drawing.Point(255, 12);
            this.grpBoxConfArista.Name = "grpBoxConfArista";
            this.grpBoxConfArista.Size = new System.Drawing.Size(237, 136);
            this.grpBoxConfArista.TabIndex = 3;
            this.grpBoxConfArista.TabStop = false;
            this.grpBoxConfArista.Text = "Arista";
            // 
            // chBoxPesoArista
            // 
            this.chBoxPesoArista.AutoSize = true;
            this.chBoxPesoArista.Location = new System.Drawing.Point(18, 102);
            this.chBoxPesoArista.Name = "chBoxPesoArista";
            this.chBoxPesoArista.Size = new System.Drawing.Size(93, 17);
            this.chBoxPesoArista.TabIndex = 3;
            this.chBoxPesoArista.Text = "Peso de arista";
            this.chBoxPesoArista.UseVisualStyleBackColor = true;
            this.chBoxPesoArista.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chBoxNombreArista
            // 
            this.chBoxNombreArista.AutoSize = true;
            this.chBoxNombreArista.Location = new System.Drawing.Point(18, 76);
            this.chBoxNombreArista.Name = "chBoxNombreArista";
            this.chBoxNombreArista.Size = new System.Drawing.Size(111, 17);
            this.chBoxNombreArista.TabIndex = 3;
            this.chBoxNombreArista.Text = "Nombre de aristas";
            this.chBoxNombreArista.UseVisualStyleBackColor = true;
            this.chBoxNombreArista.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnColorArista
            // 
            this.btnColorArista.Location = new System.Drawing.Point(136, 46);
            this.btnColorArista.Name = "btnColorArista";
            this.btnColorArista.Size = new System.Drawing.Size(88, 23);
            this.btnColorArista.TabIndex = 2;
            this.btnColorArista.Text = "Color";
            this.btnColorArista.UseVisualStyleBackColor = true;
            this.btnColorArista.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblColorAista
            // 
            this.lblColorAista.AutoSize = true;
            this.lblColorAista.Location = new System.Drawing.Point(15, 51);
            this.lblColorAista.Name = "lblColorAista";
            this.lblColorAista.Size = new System.Drawing.Size(31, 13);
            this.lblColorAista.TabIndex = 0;
            this.lblColorAista.Text = "Color";
            // 
            // nUDAnchoArista
            // 
            this.nUDAnchoArista.Location = new System.Drawing.Point(136, 21);
            this.nUDAnchoArista.Name = "nUDAnchoArista";
            this.nUDAnchoArista.Size = new System.Drawing.Size(88, 20);
            this.nUDAnchoArista.TabIndex = 1;
            this.nUDAnchoArista.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDAnchoArista.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // lblAnchoArista
            // 
            this.lblAnchoArista.AutoSize = true;
            this.lblAnchoArista.Location = new System.Drawing.Point(15, 25);
            this.lblAnchoArista.Name = "lblAnchoArista";
            this.lblAnchoArista.Size = new System.Drawing.Size(38, 13);
            this.lblAnchoArista.TabIndex = 0;
            this.lblAnchoArista.Text = "Ancho";
            // 
            // btnPorDefecto
            // 
            this.btnPorDefecto.Location = new System.Drawing.Point(336, 309);
            this.btnPorDefecto.Name = "btnPorDefecto";
            this.btnPorDefecto.Size = new System.Drawing.Size(75, 23);
            this.btnPorDefecto.TabIndex = 2;
            this.btnPorDefecto.Text = "Por defecto";
            this.btnPorDefecto.UseVisualStyleBackColor = true;
            this.btnPorDefecto.Click += new System.EventHandler(this.button6_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ConfigNodAri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 341);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnPorDefecto);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grpBoxConfArista);
            this.Controls.Add(this.grpBoxConfNodo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigNodAri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.ConfigNodAri_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConfigNodAri_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.nUDRadioNodo)).EndInit();
            this.grpBoxConfNodo.ResumeLayout(false);
            this.grpBoxConfNodo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAnchoNodo)).EndInit();
            this.grpBoxConfArista.ResumeLayout(false);
            this.grpBoxConfArista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAnchoArista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRadioNodo;
        private System.Windows.Forms.NumericUpDown nUDRadioNodo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnColorRellenoNodo;
        private System.Windows.Forms.Button btnColorBordeNodo;
        private System.Windows.Forms.GroupBox grpBoxConfNodo;
        private System.Windows.Forms.GroupBox grpBoxConfArista;
        private System.Windows.Forms.Button btnColorArista;
        private System.Windows.Forms.Label lblColorAista;
        private System.Windows.Forms.NumericUpDown nUDAnchoArista;
        private System.Windows.Forms.Label lblAnchoArista;
        private System.Windows.Forms.NumericUpDown nUDAnchoNodo;
        private System.Windows.Forms.Label lblAnchoNodo;
        private System.Windows.Forms.CheckBox chBoxPesoArista;
        private System.Windows.Forms.CheckBox chBoxNombreArista;
        private System.Windows.Forms.Button btnPorDefecto;
        private System.Windows.Forms.CheckBox checkLetra;
        private System.Windows.Forms.CheckBox checkNum;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}