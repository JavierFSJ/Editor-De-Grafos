using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EditordeGrafos.PriorityQueue;


namespace EditordeGrafos
{
    public partial class MST : Form
    {
        private List<NodeP> tree;
        private Graph g;
        private int w;
        private List<int> cont;
        private List<Edge> aristas;

        public MST(Graph graph)
        {
            InitializeComponent();
            tree = new List<NodeP>();
            cont = new List<int>();
            aristas = new List<Edge>();

            g = graph;
            w = 0;
        }

        private void MST_Load(object sender, EventArgs e)
        {
           
            labelWeight.Text = "";
        }


        private void Prim(NodeP start)
        {
            PQueue queue = new PQueue();
            queue.Enqueue(0, start , null);
            while (!queue.IsEmpty())
            {
                
                int aux = queue.getPriority();
                NodeQueue current = queue.Dequeue();
                if (!NodeInTree(current.Element))
                {
                    cont.Add(aux);
                    w += aux;
                    tree.Add(current.Element);
                    if (current.Arc != null)
                    {
                        aristas.Add(current.Arc);
                    }
                    for (int i = 0; i < current.Element.relations.Count ; i++)
                    {
                        queue.Enqueue( g.GetEdge(current.Element , current.Element.relations[i].Up ).Weight , current.Element.relations[i].Up , g.GetEdge(current.Element, current.Element.relations[i].Up));
                    }
                }

            }

        }



        private bool NodeInTree(NodeP node)
        {
            foreach (NodeP n in tree)
            {
                if (n.Name.Equals(node.Name))
                {
                    return true;
                }
            }
            return false;
        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            dataGridEdge.Rows.Clear();
            dataArista.Rows.Clear();
            if (textBoxNode.Text.Length > 0 )
            {
                NodeP node = g.getNode(textBoxNode.Text);
                if (node != null)
                {
                    Prim(node);

                    labelWeight.Text = w.ToString();

                    for (int i = 0; i < tree.Count; i++)
                    {
                       dataGridEdge.Rows.Add(i + 1 , tree[i].Name , cont[i]);
                    }

                    dataArista.Rows.Add("Inicio");
                    for (int i = 0; i < aristas.Count; i++)
                    {
                        dataArista.Rows.Add(aristas[i].getOriginDestiny());
                    }
                }
            }
            
        }
    }
}
