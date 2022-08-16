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
    public partial class Search : Form
    {
        private bool t;
        private string search;
        private string root;
        private Graph g;

        public Search(bool type , Graph graph)
        {
            InitializeComponent();
            t = type;
            g = graph;
            search = "";
            root = "";
        }

        private void Search_Load(object sender, EventArgs e)
        {
            labelRes.Text = "";
            labelroot.Text = "";
            if (t){
                this.Text = "Recorrido en profundidad";
            }
            else{
                this.Text = "Recorrido en anchura";
            }
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            search = "";
            root = "";
            labelRes.Text = "";
            labelroot.Text = "";
            if (textBox1.Text.Length > 0)
            {
                if (t)
                {
                    ControlDFS();
                }
                else
                {
                    BFS();
                }
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #region Recorridos
        private void ControlDFS()
        {
            labelRes.Text = "";
            labelroot.Text = "";
            NodeP root = g.getNode(textBox1.Text);
            if (root != null)
            {
                do
                {
                    labelroot.Text += root.Name + " ";
                    labelRes.Text += root.Name + " ";

                    DFS(root);

                    root = g.getNotViseted();
                    if (root != null)
                    {
                        labelRes.Text += " - ";
                    }

                
                } while (root != null);
            }
            g.UnselectAllNodes();
        }

        private void DFS(NodeP node)
        {
            node.Visited = true;
            List<NodeR> rels = node.relations;
            foreach (NodeR nr in rels)
            {
                if (nr.Up.Visited == false)
                {
                    labelRes.Text += nr.Up.Name+" ";
                    DFS(nr.Up);
                }
            }
        }

        private void BFS()
        {
            NodeP root = g.getNode(textBox1.Text);
            if (root != null) 
            {
                do
                {
                    Queue<NodeP> queue = new Queue<NodeP>();
                    queue.Enqueue(root);
                    root.Visited = true;
                    labelroot.Text += root.Name + " ";
                    labelRes.Text += root.Name + " ";

                    while(queue.Count != 0)
                    {
                        NodeP node = queue.Dequeue();
                        List<NodeR> rels = node.relations;
                        foreach (NodeR nr in rels)
                        {
                            if (nr.Up.Visited == false)
                            {
                                nr.Up.Visited = true;
                                queue.Enqueue(nr.Up);
                                labelRes.Text += nr.Up.Name+" ";
                            }
                        }
                    }

                    root = g.getNotViseted();
                    if (root != null)
                    {
                        labelRes.Text += "   ";
                    }

                } while (root != null);
            }
            g.UnselectAllNodes();
        }

        #endregion

        
    }
}
