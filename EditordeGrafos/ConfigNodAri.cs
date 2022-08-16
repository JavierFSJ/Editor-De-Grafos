using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos{
    public partial class ConfigNodAri : Form{
        private Color colNodo;
        private Color colArista;
        private Color colBordeNodo;
        private Graphics g;
        private Rectangle r, r1, r2;
        private int borde;
        private int radio;
        private int anchoBordeNodo;
        private int anchoArista;
        private bool nombreArista;
        private bool pesoArista;
        private bool letra;
        private Graph graph;
        private int bandera ;
      

        public Graph Fraph {
            get { return graph;  }
            set { graph = value;  }
        }
        

        public bool Letra {
            get { return letra; }
            set { letra = value; }
        }

        public int Bandera {
            get { return bandera; }
            set { bandera = value; }
        }

     

        public bool PesoArista {
            get { return pesoArista; }
            set { pesoArista = value; }
        }

        public bool NombreArista {
            get { return nombreArista; }
            set { nombreArista = value; }
        }
     
	    public Color ColBordeNodo{
		    get { return colBordeNodo;}
		    set { colBordeNodo = value;}
	    }


        public int AnchoBordeNodo{
            get { return anchoBordeNodo; }
            set { anchoBordeNodo = value; }
        }

        public int AnchoArista {
            get { return anchoArista; }
            set { anchoArista = value; }
        }

        public int Radio {
            get { return radio; }
            set { radio = value; }
        }

        public Color ColArista {
            get { return colArista; }
            set { colArista = value; }
        }
        
        public Color ColNodo {
            get { return colNodo; }
            set { colNodo = value; }
        }

        private void ConfigNodAri_Load(object sender, EventArgs e) {
            
        }

        public ConfigNodAri(Graph graph){
            InitializeComponent();
            g = CreateGraphics();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            borde = 12; //separacion del rectangulo del area cliente
            r = r1 = r2 = this.ClientRectangle;

            r1.X += borde;
            r1.Width = r.Width / 2 - borde;
            r1.Y += 160;
            r1.Height = 100;

            r2.X = r.Width / 2;
            r2.Width = r.Width / 2 - borde;
            r2.Y = 160;
            r2.Height = 100;
           
            nUDRadioNodo.Maximum = 100;
            nUDRadioNodo.Minimum = 10;
            nUDRadioNodo.Increment = 10;

            nUDAnchoNodo.Maximum = 10;
            nUDAnchoNodo.Minimum = 1;
            nUDAnchoNodo.Increment = 1;

            nUDAnchoArista.Maximum = 10;
            nUDAnchoArista.Minimum = 1;
            nUDAnchoArista.Increment = 1;

            nUDAnchoArista.Value = graph.EdgeWidth;
            nUDAnchoNodo.Value = graph.NodeBorderWidth;
            nUDRadioNodo.Value = graph.NodeRadio;

            colBordeNodo = graph.NodeBorderColor;
            colNodo = graph.NodeColor;
            colArista = graph.EdgeColor;

            chBoxNombreArista.Checked = graph.EdgeNamesVisible;
            chBoxPesoArista.Checked = graph.EdgeWeightVisible;

            btnColorRellenoNodo.BackColor = graph.NodeColor;
            if ((graph.NodeColor.R + graph.NodeColor.B + graph.NodeColor.G) / 3 < 100) {
                btnColorRellenoNodo.ForeColor = Color.White;
            }
            else {
                btnColorRellenoNodo.ForeColor = Color.Black;
            }
            btnColorBordeNodo.BackColor = graph.NodeBorderColor;
            if ((graph.NodeBorderColor.R + graph.NodeBorderColor.B + graph.NodeBorderColor.G) / 3 < 100) {
                btnColorBordeNodo.ForeColor = Color.White;
            }
            else {
                btnColorBordeNodo.ForeColor = Color.Black;
            }
            btnColorArista.BackColor = graph.EdgeColor;
            if ((graph.EdgeColor.R + graph.EdgeColor.B + graph.EdgeColor.G) / 3 < 100) {
                btnColorArista.ForeColor = Color.White;
            }
            else {
                btnColorArista.ForeColor = Color.Black;
            }
            btnColorArista.ForeColor = Color.White;
            Invalidate();
            
        }

        private void ConfigNodAri_Paint(object sender, PaintEventArgs e) {
            g.Clear(BackColor);
            g.DrawRectangle(new Pen(Color.LightGray), r1);
            g.DrawRectangle(new Pen(Color.LightGray), r2);
            g.FillEllipse(new SolidBrush(colNodo), (r1.X + r1.Width / 2) - radio / 2, (r1.Y + r1.Height / 2) - radio / 2, radio, radio);
            g.DrawEllipse(new Pen(colBordeNodo, anchoBordeNodo), (r1.X + r1.Width / 2) - radio / 2, (r1.Y + r1.Height / 2) - radio / 2, radio, radio);
            g.DrawLine(new Pen(colArista, anchoArista), r2.Left + 10, r2.Top + r2.Height / 2, r2.Right - 10, r2.Bottom - r2.Height / 2);
            g.DrawString("A", new Font("Bold", radio/4), Brushes.Black, (r1.X + r1.Width / 2) - radio/6, (r1.Y + r1.Height / 2) - radio/5);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e){ //tamaño del nodo
            radio = decimal.ToInt32(nUDRadioNodo.Value);
            Invalidate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) { // ancho del bode del nodo
            anchoBordeNodo = decimal.ToInt32(nUDAnchoNodo.Value);
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e) { //color nodo
            using(var c = new ColorDialog()){
                var result = c.ShowDialog();
                if (result == DialogResult.OK) {
                    colNodo = c.Color;
                    btnColorRellenoNodo.BackColor = c.Color;
                    if ((c.Color.R + c.Color.B + c.Color.G)/3 < 100) {
                        btnColorRellenoNodo.ForeColor = Color.White;
                    }
                    else {
                        btnColorRellenoNodo.ForeColor = Color.Black;
                    }
                }
            }
            Invalidate();
            
        }

        private void button4_Click(object sender, EventArgs e) { // color borde nodo
            using (var c = new ColorDialog()) {
                var result = c.ShowDialog();
                if (result == DialogResult.OK) {
                    colBordeNodo = c.Color;
                    btnColorBordeNodo.BackColor = c.Color;
                    if ((c.Color.R + c.Color.B + c.Color.G) / 3 < 100) {
                        btnColorBordeNodo.ForeColor = Color.White;
                    }
                    else {
                        btnColorBordeNodo.ForeColor = Color.Black;
                    }
                }
            }
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e) { // OK
            this.DialogResult = DialogResult.OK;

            
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e) { // color aris|atara
            using (var c = new ColorDialog()) {
                var result = c.ShowDialog();
                if (result == DialogResult.OK) {
                    colArista = c.Color;
                    btnColorArista.BackColor = c.Color;
                    if ((c.Color.R + c.Color.B + c.Color.G) / 3 < 100) {
                        btnColorArista.ForeColor = Color.White;
                    }
                    else {
                        btnColorArista.ForeColor = Color.Black;
                    }
                }
            }
            Invalidate();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e) { // ancho de la arista
            anchoArista = decimal.ToInt32(nUDAnchoArista.Value);
            Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) { // nombre de arista
            nombreArista = chBoxNombreArista.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void checkLetra_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void checkNum_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkNum_Click(object sender, EventArgs e)
        {
            if (checkNum.Checked == true)
            {
                Bandera = -1;
            }

        }

        private void checkLetra_Click(object sender, EventArgs e)
        {
            if (checkLetra.Checked == true)
            {
                Bandera = 1;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) { // peso de la arista
            pesoArista = chBoxPesoArista.Checked;
        }

        private void button6_Click(object sender, EventArgs e) { // por defecto
            nUDRadioNodo.Value = 30;
            radio = decimal.ToInt32(nUDRadioNodo.Value);
            nUDAnchoNodo.Value = 1;
            anchoBordeNodo = decimal.ToInt32(nUDAnchoNodo.Value);
            colNodo = Color.White;
            colBordeNodo = Color.Black;
            colArista = Color.Black;
            nUDAnchoArista.Value = 1;
            anchoArista = decimal.ToInt32(nUDAnchoArista.Value);
            btnColorRellenoNodo.BackColor = Color.White;
            btnColorRellenoNodo.ForeColor = Color.Black;
            btnColorBordeNodo.BackColor = Color.Black;
            btnColorBordeNodo.ForeColor = Color.White;
            btnColorArista.BackColor = Color.Black;
            btnColorArista.ForeColor = Color.White;
            Invalidate();
        }

        
    }
}
