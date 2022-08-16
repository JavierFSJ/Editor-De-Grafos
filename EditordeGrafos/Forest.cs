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
    public partial class Forest : Form
    {

        private Graph g;
        private string serach;
        private string root;
        private string arcTree;
        private string arcBack;
        private string arcForward;
        private string arcCrossed;
        private bool directed;

        public Forest(Graph graph , bool directed)
        {
            InitializeComponent();
            g = graph;
            serach = "";
            root = "";
            arcTree ="";
            arcBack = "";
            arcForward ="";
            arcCrossed ="";
            this.directed = directed;
        }

        private void Forest_Load(object sender, EventArgs e)
        {
            labelRes.Text = "";
            labelroot.Text = "";
            labelBackArc.Text = "";
            labelCrossedArc.Text = "";
            labelForwardArc.Text = "";
            labelTreeArc.Text = "";
            ControlDFS();

        }

        #region Bosque Abarcador
        private void ControlDFS()
        {
            NodeP root = g.getMaxDegreeNode();
            int visit = 0;
            if (root != null)
            {
                do
                {
                    labelroot.Text += root.Name + " ";
                    labelRes.Text += root.Name + " ";

                    DFS(root , ref visit);

                    root = g.getNotViseted();
                    if (root != null)
                    {
                        labelRes.Text += " - ";
                       
                    }

                } while (root != null);

                g.UnselectAllNodes();
                root = g.getMaxDegreeNode();

                do
                {
                    DFS_ClasifyEdges(root);
                    root = g.getNotViseted();

                } while (root != null);
                g.UnselectAllNodes();

            }
            g.UnselectAllEdges();
            g.ResetTimes();
        }

        private void DFS(NodeP node , ref int visit )
        {
            node.Visited = true;
            node.Visit = visit;
            visit++;
            List<NodeR> rels = node.relations;
            foreach (NodeR nr in rels)
            {
                if (nr.Up.Visited == false)
                {
                    labelRes.Text += nr.Up.Name + " ";
                    labelTreeArc.Text += g.GetEdge(node, nr.Up).getOriginDestiny()+" ";
                    DFS(nr.Up , ref visit);
                }
            }
            visit++;
            node.Finish = visit;
        }


        private void DFS_ClasifyEdges(NodeP node)
        {
            node.Visited = true;
            List<NodeR> rels = node.relations;
            foreach (NodeR nr in rels)
            {
                if (nr.Up.Visited == false)
                {
                    DFS_ClasifyEdges(nr.Up);
                    
                }
                else
                {
                    if (directed)
                    {
                        if (node.Visit > nr.Up.Visit && node.Finish < nr.Up.Finish)
                        {
                            labelBackArc.Text += g.GetEdge(node, nr.Up).getOriginDestiny() + " ";
                        }
                        else if (node.Visit < nr.Up.Visit && node.Finish > nr.Up.Finish)
                        {
                            labelForwardArc.Text += g.GetEdge(node, nr.Up).getOriginDestiny() + " ";
                        }
                        else if (node.Visit > nr.Up.Visit && node.Finish > nr.Up.Finish)
                        {
                            labelCrossedArc.Text += g.GetEdge(node, nr.Up).getOriginDestiny() + " ";
                        }
                    }
                    else
                    {
                        if (node.Visit < nr.Up.Visit && node.Finish > nr.Up.Finish)
                        {
                            labelBackArc.Text += g.GetEdge(node, nr.Up).getOriginDestiny() + " ";
                        }
                    }
                }

            }
        }

        #endregion



        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
