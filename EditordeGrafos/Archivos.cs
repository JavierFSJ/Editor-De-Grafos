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
    public partial class Archivos : Form
    {
        Archivo archivo = new Archivo();
        public Archivos()
        {
            InitializeComponent();
            archivo = new Archivo();
            panel1.Enabled = false;
        }

        private void OnlyNumbers(KeyPressEventArgs V)
        {
            if (char.IsNumber(V.KeyChar) || char.IsControl(V.KeyChar) )
            {
                V.Handled = false;
            }
            else
            {
                V.Handled = true;
            }

        }

        private void textBoxClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(e);
        }

        private void CrearNuevo_Click(object sender, EventArgs e)
        {
            if (archivo.CrearArchivos())
            {
                panel1.Enabled = true;
                Listar();
            }
        }

        private void Insertar_Click(object sender, EventArgs e)
        {
            char[] dato = { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' };
            List<string> numeros = textBoxClave.Text.Split().ToList();
            for (int i = 0; i < numeros.Count; i++)
            {
                int res = archivo.Insertar(Convert.ToInt32(numeros[i]), dato);
                if (res != 1)
                {
                    break;
                }
            }
            Listar();
            textBoxClave.Clear();
        }

        private void Abrir_Click(object sender, EventArgs e)
        {
            if (archivo.AbrirArchivo())
            {
                MessageBox.Show("Entre");
                panel1.Enabled = true;
                Listar();
            }
        }

        public void Listar()
        {
            List<Elemento> elementos = archivo.Listar();
            dataGridView.Rows.Clear();
            for (int i = 0; i < elementos.Count; i++)
            {

                if (elementos[i].Tipo == 'R')
                {

                    Registro r = (Registro)elementos[i].Dato;
                    dataGridView.Rows.Add(r.Direccion, r.Clave, r.GetDatoString(), r.Siguiente);
                }
                else
                {
                    
                    NodoArbol n = (NodoArbol)elementos[i].Dato;
                    List<object> Aux = new List<object>();
                    Aux.Add(n.DirNodo);
                    Aux.Add(n.Tipo);
                    List<int> Claves = n.GetClavesToPrint();
                    List<long> Direcciones = n.GetDireccionesToPrint();
                    for (int j = 0; j < Direcciones.Count; j++)
                    {
                        if (Direcciones[j] != -1)
                            Aux.Add(Direcciones[j]);
                        if (j != 4)
                        {
                            if (Claves[j] != -1)
                                Aux.Add(Claves[j]);
                        }
                    }
                    dataGridView.Rows.Add(Aux.ToArray());
                }
            }
        }

    }
}
