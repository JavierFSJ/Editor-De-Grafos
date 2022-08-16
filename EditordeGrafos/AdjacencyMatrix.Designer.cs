
namespace EditordeGrafos
{
    partial class AdjacencyMatrix
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
            this.btAcept = new System.Windows.Forms.Button();
            this.dtMatrix = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // btAcept
            // 
            this.btAcept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAcept.Location = new System.Drawing.Point(688, 401);
            this.btAcept.Name = "btAcept";
            this.btAcept.Size = new System.Drawing.Size(89, 23);
            this.btAcept.TabIndex = 3;
            this.btAcept.Text = "Aceptar";
            this.btAcept.UseVisualStyleBackColor = true;
            this.btAcept.Click += new System.EventHandler(this.btAcept_Click);
            // 
            // dtMatrix
            // 
            this.dtMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMatrix.Location = new System.Drawing.Point(23, 26);
            this.dtMatrix.Name = "dtMatrix";
            this.dtMatrix.Size = new System.Drawing.Size(754, 355);
            this.dtMatrix.TabIndex = 2;
            // 
            // AdjacencyMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btAcept);
            this.Controls.Add(this.dtMatrix);
            this.Name = "AdjacencyMatrix";
            this.Text = "AdjacencyMatrix";
            this.Load += new System.EventHandler(this.AdjacencyMatrix_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtMatrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAcept;
        private System.Windows.Forms.DataGridView dtMatrix;
    }
}