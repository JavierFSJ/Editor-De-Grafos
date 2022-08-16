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
    public partial class AtributosGrafo : Form
    {
        public AtributosGrafo(Graph graph)
        {
            InitializeComponent();

            List<Edge> lista = graph.edgesList;
            foreach (var dato in lista)
            {
                lblAristas.Text = lblAristas.Text + dato.Name + " = (" +  dato.Source.Name + " , "+ dato.Destiny.Name + ")\r";
            }

            foreach (NodeP nodo in graph)
            {
                lblNodos.Text = lblNodos.Text + nodo.Name + "\r";
            }                
        }
    }
}
