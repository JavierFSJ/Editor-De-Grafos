using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class HashEstatico : Form
    {

        private Hash hash;
        public HashEstatico()
        {
            InitializeComponent();
        }

        private void btSelecccionar_Click(object sender, EventArgs e)
        {
            hash = new Hash(Convert.ToInt32(cajones.Value.ToString()));
            lbCubetas.Text = hash.Cubetas.ToString();
            lbRegistros.Text = hash.NumRegisro.ToString();
            lbTam.Text = hash.tamRegistro.ToString();
            lbVacios.Text = hash.Vacias.ToString();
            panel1.Enabled = true;
            Listar();
        }


        private void Listar()
        {

            List<string> values = hash.getDirecciones();
            dataRegistroPrincipal.Rows.Clear();
            for (int i = 0; i < values.Count; i++)
            {
                dataRegistroPrincipal.Rows.Add(i.ToString(), values[i]);
            }
        }

        private void ListarCubeta(int posicion)
        {

            List<string> values = hash.ListarCajon(posicion);
            dataCubetas.Rows.Clear();
            for (int i = 0; i < values.Count; i++)
            {
                dataCubetas.Rows.Add(values[i]);
            }
        }

        private void ListarCubetaVacia()
        {
            dataGridVacia.Rows.Clear();
            List<string> values = hash.getCubetasVacias();
            for (int i = 0; i < values.Count; i++)
            {
                dataGridVacia.Rows.Add(values[i]);
            }
        }

        private void btInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                int res = 0;
                int Clave = Convert.ToInt32(textBox1.Text);
                res = hash.Insetar(Clave);
                
                if (res == 1)
                {
                    Listar();
                    lbVacios.Text = hash.Vacias.ToString();
                    textBox1.Clear();
                    MessageBox.Show("Clave insertada");
                    ListarCubetaVacia();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Valor no valido");
            }
        }

        private void dataRegistroPrincipal_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                ListarCubeta(Convert.ToInt32(dataRegistroPrincipal.CurrentRow.Cells[0].Value));
            }
            catch (Exception)
            {

                MessageBox.Show("Selecciona un valor valido");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hash = new Hash();
            lbCubetas.Text = hash.Cubetas.ToString();
            lbRegistros.Text = hash.NumRegisro.ToString();
            lbTam.Text = hash.tamRegistro.ToString();
            lbVacios.Text = hash.Vacias.ToString();
            panel1.Enabled = true;
            Listar();
            ListarCubetaVacia();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                hash.GuardarArchivo();
            }
            catch (Exception)
            {

                MessageBox.Show("No ha inicializado el hash");
            }

        }

        private void dataRegistroPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int res = 0;
                int Clave = Convert.ToInt32(textBox1.Text);
                res = hash.Eliminar(Clave);
                if (res == 1)
                {
                    Listar();
                    textBox1.Clear();
                    lbVacios.Text = hash.Vacias.ToString();
                    ListarCubetaVacia();
                }
                else
                {
                    MessageBox.Show("El valor no se encuentra");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Valor no valido");
            }
        }
    }
}
