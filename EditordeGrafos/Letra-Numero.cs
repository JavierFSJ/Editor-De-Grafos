using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class Letra_Numero : Form
    {
        private int bandera;


        public int Bandera {
            get { return bandera; }
            set { bandera = value; }
        }
        public Letra_Numero()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

           

            if (checkBox1.Checked == true)
            {
                Bandera = 1;
                this.Close();
            }

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Bandera = -1;
                this.Close();
            }

        }
    }
}
