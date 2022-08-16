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
    public partial class Silmulation : Form
    {
        private List<NodeP> tree;
        private Graph g;
        private int w;
        private List<int> cont;
        private int index;
        private List<Edge> edges;
        public Silmulation(Graph graph)
        {
            InitializeComponent();
            tree = new List<NodeP>();
            cont = new List<int>();
            edges = new List<Edge>();
            g = graph;
            w = 0;
            index = 0;
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
                    for (int i = 0; i < current.Element.relations.Count; i++)
                    {
                        queue.Enqueue(g.GetEdge(current.Element, current.Element.relations[i].Up).Weight, current.Element.relations[i].Up , null);
                    }
                }

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            paintGraph(graphics);
        }

        private void Silmulation_Load(object sender, EventArgs e)
        {
            labelW.Text = "";
            w = 0;
        }

        private void Seleccionar_Click(object sender, EventArgs e)
        {
            dataGridEdge.Rows.Clear();
            edges.Clear();
            tree.Clear();
            if (textBoxNode.Text.Length > 0)
            {
                NodeP node = g.getNode(textBoxNode.Text);
                if (node != null)
                {
                    
                    Prim(node);

                    labelW.Text = w.ToString();

                    for (int i = 0; i < tree.Count; i++)
                    {
                        dataGridEdge.Rows.Add(i + 1, tree[i].Name, cont[i]);
                        if (i > 0)
                        {
                            edges.Add(g.getEdgeWeight(cont[i]));
                        }
                    }
                    timer1.Start();
                    index = 0;
                }
                
            }
        }

        public void PaintMST(List<Edge> e)
        {
            Graphics graphics = panel1.CreateGraphics();
            
            Pen pendi = new Pen(Color.Red, 5);
            Size s = new Size(g.NodeRadio, g.NodeRadio);
            foreach (Edge a in e)
            {
                double teta1 = Math.Atan2((double)(a.Destiny.Position.Y - a.Source.Position.Y), (double)(a.Destiny.Position.X - a.Source.Position.X));
                float x1 = a.Source.Position.X + (float)((Math.Cos(teta1)) * (s.Height / 2));
                float y1 = a.Source.Position.Y + (float)((Math.Sin(teta1)) * (s.Height / 2));

                double teta2 = Math.Atan2(a.Source.Position.Y - a.Destiny.Position.Y, a.Source.Position.X - a.Destiny.Position.X);
                float x2 = a.Destiny.Position.X + (float)((Math.Cos(teta2)) * (s.Height / 2));
                float y2 = a.Destiny.Position.Y + (float)((Math.Sin(teta2)) * (s.Height / 2));
                //Arista dirigida draw
                graphics.DrawLine(pendi, x1, y1, x2, y2);
            }

        }

        public void PaintEdge(List<Edge> e)
        {
            Graphics graphics = panel1.CreateGraphics();

            Pen pendi = new Pen(Color.Red, 5);
            Size s = new Size(g.NodeRadio, g.NodeRadio);
            double teta1 = Math.Atan2((double)(e[index].Destiny.Position.Y - e[index].Source.Position.Y), (double)(e[index].Destiny.Position.X - e[index].Source.Position.X));
            float x1 = e[index].Source.Position.X + (float)((Math.Cos(teta1)) * (s.Height / 2));
            float y1 = e[index].Source.Position.Y + (float)((Math.Sin(teta1)) * (s.Height / 2));

            double teta2 = Math.Atan2(e[index].Source.Position.Y - e[index].Destiny.Position.Y, e[index].Source.Position.X - e[index].Destiny.Position.X);
            float x2 = e[index].Destiny.Position.X + (float)((Math.Cos(teta2)) * (s.Height / 2));
            float y2 = e[index].Destiny.Position.Y + (float)((Math.Sin(teta2)) * (s.Height / 2));
            //Arista dirigida draw
            graphics.DrawLine(pendi, x1, y1, x2, y2);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (index < edges.Count)
            {
                PaintEdge(edges);
                index++;
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("TERMINADO");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();
            graphics.Clear(Color.White);
            paintGraph(graphics);
            labelW.Text = "0";
        }

        private void paintGraph(Graphics graphics)
        {
            Pen pendi = new Pen(Color.Black, 1);
            PointF A;
            A = new PointF();
            Size s = new Size(g.NodeRadio, g.NodeRadio);
            foreach (Edge a in g.edgesList)
            {
                double teta1 = Math.Atan2((double)(a.Destiny.Position.Y - a.Source.Position.Y), (double)(a.Destiny.Position.X - a.Source.Position.X));
                float x1 = a.Source.Position.X + (float)((Math.Cos(teta1)) * (s.Height / 2));
                float y1 = a.Source.Position.Y + (float)((Math.Sin(teta1)) * (s.Height / 2));

                double teta2 = Math.Atan2(a.Source.Position.Y - a.Destiny.Position.Y, a.Source.Position.X - a.Destiny.Position.X);
                float x2 = a.Destiny.Position.X + (float)((Math.Cos(teta2)) * (s.Height / 2));
                float y2 = a.Destiny.Position.Y + (float)((Math.Sin(teta2)) * (s.Height / 2));
                //Arista dirigida draw
                graphics.DrawLine(pendi, x1, y1, x2, y2);
                graphics.DrawString(a.Weight.ToString(), new Font("Bold", 10), Brushes.Blue, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) + 4, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) + 4);
                graphics.DrawString(a.Weight.ToString(), new Font("Bold", 10), Brushes.Blue, a.Destiny.Position.X, A.Y - 10);
            }

            Pen pen = new Pen(Color.Red, g.NodeBorderWidth);
            SolidBrush nod;
            if (g.Count > 0 && g.NodeRadio != 0)
            {
                foreach (NodeP n in g)
                {
                    pendi.Width = 3;
                    if (n.Selected == false)
                    {
                        nod = new SolidBrush(n.Color);
                    }
                    else
                    {
                        nod = new SolidBrush(Color.Red);
                    }

                    Rectangle re = new Rectangle(n.Position.X - (s.Height / 2), n.Position.Y - (s.Height / 2), s.Width, s.Height);
                    graphics.FillEllipse(nod, re);
                    graphics.DrawEllipse(pen, re);
                    graphics.DrawString(n.Name, new Font("Bold", g.NodeRadio / 4), new SolidBrush(g.NodeBorderColor), (n.Position.X - g.NodeRadio / 4 + g.NodeRadio / 12), (n.Position.Y - g.NodeRadio / 4 + g.NodeRadio / 12));
                }
            }
        }
    }
}
