
namespace EditordeGrafos
{
    partial class MST
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNode = new System.Windows.Forms.TextBox();
            this.btSelect = new System.Windows.Forms.Button();
            this.labelWeight = new System.Windows.Forms.Label();
            this.dataGridEdge = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataArista = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataArista)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nodo inicial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Coste:";
            // 
            // textBoxNode
            // 
            this.textBoxNode.Location = new System.Drawing.Point(94, 15);
            this.textBoxNode.Name = "textBoxNode";
            this.textBoxNode.Size = new System.Drawing.Size(100, 20);
            this.textBoxNode.TabIndex = 3;
            // 
            // btSelect
            // 
            this.btSelect.Location = new System.Drawing.Point(200, 15);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(93, 23);
            this.btSelect.TabIndex = 4;
            this.btSelect.Text = "Seleccionar";
            this.btSelect.UseVisualStyleBackColor = true;
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Location = new System.Drawing.Point(91, 50);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(56, 13);
            this.labelWeight.TabIndex = 6;
            this.labelWeight.Text = "Recorrido:";
            // 
            // dataGridEdge
            // 
            this.dataGridEdge.AllowUserToAddRows = false;
            this.dataGridEdge.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridEdge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEdge.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2});
            this.dataGridEdge.Location = new System.Drawing.Point(26, 78);
            this.dataGridEdge.Name = "dataGridEdge";
            this.dataGridEdge.ReadOnly = true;
            this.dataGridEdge.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridEdge.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEdge.Size = new System.Drawing.Size(396, 373);
            this.dataGridEdge.TabIndex = 7;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Num";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nodo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Coste";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dataArista
            // 
            this.dataArista.AllowUserToAddRows = false;
            this.dataArista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataArista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataArista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.dataArista.Location = new System.Drawing.Point(428, 78);
            this.dataArista.Name = "dataArista";
            this.dataArista.ReadOnly = true;
            this.dataArista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataArista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataArista.Size = new System.Drawing.Size(198, 373);
            this.dataArista.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Arista";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // MST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 461);
            this.Controls.Add(this.dataArista);
            this.Controls.Add(this.dataGridEdge);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.btSelect);
            this.Controls.Add(this.textBoxNode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arbol de expasion minima";
            this.Load += new System.EventHandler(this.MST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEdge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataArista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNode;
        private System.Windows.Forms.Button btSelect;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.DataGridView dataGridEdge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView dataArista;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}