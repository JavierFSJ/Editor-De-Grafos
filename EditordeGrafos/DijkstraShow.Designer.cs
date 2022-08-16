
namespace EditordeGrafos
{
    partial class DijkstraShow
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datamd = new System.Windows.Forms.DataGridView();
            this.dataMc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datamd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMc)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "MD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "MC";
            // 
            // datamd
            // 
            this.datamd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datamd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datamd.Location = new System.Drawing.Point(92, 344);
            this.datamd.Name = "datamd";
            this.datamd.Size = new System.Drawing.Size(718, 306);
            this.datamd.TabIndex = 5;
            // 
            // dataMc
            // 
            this.dataMc.AllowUserToAddRows = false;
            this.dataMc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataMc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMc.Location = new System.Drawing.Point(92, 12);
            this.dataMc.Name = "dataMc";
            this.dataMc.ReadOnly = true;
            this.dataMc.Size = new System.Drawing.Size(718, 306);
            this.dataMc.TabIndex = 4;
            // 
            // DijkstraShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 663);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datamd);
            this.Controls.Add(this.dataMc);
            this.Name = "DijkstraShow";
            this.Text = "DijkstraShow";
            this.Load += new System.EventHandler(this.DijkstraShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datamd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datamd;
        private System.Windows.Forms.DataGridView dataMc;
    }
}