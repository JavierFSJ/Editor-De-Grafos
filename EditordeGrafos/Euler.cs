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
    public partial class Euler : Form
    {
        private Graph g;
        private bool directed;
        private bool pathExist;
        private bool circuitExist;
        private List<string> euler;

        public Euler(Graph graph , bool directed)
        {
            g = graph;
            pathExist = false;
            circuitExist = false;
            this.directed = directed;
            euler = new List<string>();
            InitializeComponent();
        }

        private void Euler_Load(object sender, EventArgs e)
        {
            labelRecorrido.Text = " ";
            labelC.Text = "El grafo no tiene un circuito de euler";
            labelP.Text = "El grafo no tiene un camino de euler";

            GetEuler();
            for (int i = 0; i < euler.Count; i++)
            {
                labelRecorrido.Text += euler[i] + " " ;
            }

            if (pathExist)
            {
                labelP.Text = "El grafo tiene un camino de euler";
            }
            else if (circuitExist)
            {
                labelC.Text = "El grafo tiene un circuito de euler";
            }
            
            
        }

        private bool Conexo()
        {
            bool conexo = true;
            NodeP r = g.getMaxDegreeNode();
            int i = 0; //Nos indica en que arbol esta cada nodo
            do
            {
                DFS(r);
                r = g.getNotViseted();
                i++;
            } while (r != null);
            g.UnselectAllNodes();

            if (i > 1)
            {
                conexo = false;
            }
            return conexo;
        }

        private void DFS(NodeP start)
        {
            start.Visited = true;
            List<NodeR> rels = start.relations;
            foreach (NodeR i in rels)
            {
                if (i.Up.Visited == false)
                {
                    DFS(i.Up);
                }
            }
        }

        public bool ConexoDireted()
        {
            bool flag = true;
            List<string> crossed = new List<string>();
            NodeP r = g.getMaxDegreeNode();
            int startTime = 0;
            int i = 0; //Nos indica en que arbol esta cada nodo
            do
            {
               
                DFS_Forest(crossed, r, null, ref startTime, i, true);

                r = g.getNotViseted();

                i++;
            } while (r != null);

            if (i > 1 && crossed.Count == 0)
            {
                flag = false;
            }

            g.UnselectAllNodes();
            return flag;
        }

        private void DFS_Forest(List<string> crossed , NodeP v, NodeP parent, ref int start, int i, bool directed)
        {
            start += 1;
            v.Visited = true; //Marcamos en nodo
            v.Visit = start;
            v.Finish = -1;
            v.Tree = i;
            List<NodeR> rels = v.relations;
            foreach (NodeR r in rels)
            {
                if (r.Up.Visited == false)
                {
                    
                    DFS_Forest(crossed , r.Up, v, ref start, i, directed);
                }
                else
                {
                    if (directed) //En base a directed clasificaremos las aristas
                    {
                        
                        
                        if (r.Up.Finish > v.Finish && r.Up.Tree != v.Tree) //Para cruzada
                        {
                            crossed.Add(g.GetEdge(v, r.Up).getOriginDestiny());
                        }

                        

                    }
                    
                }

            }

            start += 1;
            v.Finish = start;
        }

        private bool EulerCircuitExists(bool directed)
        {
            bool flag = false;
            if (directed)
            {
                if (ConexoDireted())
                {
                    if (g.AllNodesInEx() == true)
                    {
                        flag = true;
                    }
                }
            }
            else
            {
                if (Conexo())
                {
                    if (g.AllNodeDegrePar() == true)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        private bool EulerPathExists(bool directed)
        {
            bool flag = false;
            if (directed)
            {
                if (ConexoDireted())
                {
                    if (g.ContNodesSameInEx() == (g.Count - 2))
                    {
                        g.GetNodesInExExIn();
                        if (g.InEx != null && g.ExIn != null)
                        {
                            flag = true;
                        }
                    }

                }
            }
            else
            {
                if (Conexo())
                {
                    if (g.ContNodesOddDegree() == 2)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        public void GetEuler()
        {
            
            if (directed)
            {
                if (EulerPathExists(directed))
                {
                    pathExist = true;
                    NodeP start = g.GetNodeOddDegree();
                    EulerPathDirected(g.ExIn, g.InEx);
                    g.UnselectAllEdges();
                }
                if (EulerCircuitExists(directed))
                {
                    circuitExist = true;
                    ///MessageBox.Show(GetMaxNodeDirected().Name);
                    EulerCircuitDirected( g.GetMaxNodeDirected(), null);
                    g.UnselectAllEdges();
                }
            }
            else
            {
                if (EulerPathExists(directed))
                {
                    pathExist = true;
                    NodeP start = g.GetNodeOddDegree();
                    EulerPath(start);
                    g.UnselectAllEdges();
                }
                if (EulerCircuitExists(directed))
                {
                    circuitExist = true;
                    EulerCirtuit(g.First(), g.First());
                    g.UnselectAllEdges();
                }
            }
            
        }

        private void EulerPath(NodeP start)
        {
            euler.Add(start.Name);
            foreach (NodeR nr in start.relations)
            {
                Edge edge = g.GetEdge(start, nr.Up);
                if (!edge.Visited)
                {
                    if (IsValid(start, nr.Up))
                    {
                        edge.Visited = true;
                        //e.path.Add(start.Name);
                        if (!start.Name.Equals(edge.Source.Name))
                        {

                            NodeP next = edge.Source;
                            EulerPath( next);
                        }
                        else
                        {

                            NodeP next = edge.Destiny;
                            EulerPath( next);
                        }

                    }
                }
            }

        }

        private void EulerCirtuit(NodeP start, NodeP AlwaysStart)
        {
            euler.Add(start.Name);
            foreach (NodeR nr in start.relations)
            {
                Edge edge = g.GetEdge(start, nr.Up);
                if (!edge.Visited)
                {
                    if (nr.Up.Name.Equals(AlwaysStart.Name) && g.ContRestForVisit(AlwaysStart) == 1)
                    {
                        if (IsValid(start, nr.Up))
                        {
                            edge.Visited = true;
                            //e.path.Add(start.Name);
                            if (!start.Name.Equals(edge.Source.Name))
                            {
                                NodeP next = edge.Source;
                                EulerCirtuit(next, AlwaysStart);
                            }
                            else
                            {
                                NodeP next = edge.Destiny;
                                EulerCirtuit(next, AlwaysStart);
                            }

                        }
                    }
                    else if (nr.Up.Name.Equals(AlwaysStart.Name) && g.ContRestForVisit() == 1)
                    {
                        if (IsValid(start, nr.Up))
                        {
                            edge.Visited = true;
                            //e.path.Add(start.Name);
                            if (!start.Name.Equals(edge.Source.Name))
                            {
                                NodeP next = edge.Source;
                                EulerCirtuit(next, AlwaysStart);
                            }
                            else
                            {
                                NodeP next = edge.Destiny;
                                EulerCirtuit(next, AlwaysStart);
                            }

                        }
                    }
                    else
                    {
                        if (IsValid(start, nr.Up))
                        {
                            edge.Visited = true;
                            //e.path.Add(start.Name);
                            if (!start.Name.Equals(edge.Source.Name))
                            {
                                NodeP next = edge.Source;
                                EulerCirtuit(next, AlwaysStart);
                            }
                            else
                            {
                                NodeP next = edge.Destiny;
                                EulerCirtuit(next, AlwaysStart);
                            }

                        }
                    }

                }
            }

        }

        public void EulerPathDirected(NodeP start, NodeP final)
        {
            if (start.Name.Equals(final.Name) && g.ContRestForVisit() == 0)
            {
                euler.Add(start.Name);
            }
            else
            {
                euler.Add(start.Name);
                foreach (NodeR nr in start.relations)
                {
                    Edge edge = g.GetEdge(start, nr.Up);
                    if (!edge.Visited)
                    {
                        edge.Visited = true;
                        EulerCircuitDirected(edge.Destiny, final);
                    }

                }
            }
        }

        public void EulerCircuitDirected(NodeP start, NodeP predecessor)
        {
            euler.Add(start.Name);

            if (predecessor == null)
            {
                predecessor = start;
                foreach (NodeR nr in start.relations)
                {
                    Edge edge = g.GetEdge(start, nr.Up);
                    if (!edge.Visited)
                    {
                        edge.Visited = true;

                        if (!start.Name.Equals(edge.Source.Name))
                        {
                            NodeP next = edge.Source;
                            EulerCircuitDirected(next, predecessor);
                        }
                        else
                        {

                            NodeP next = edge.Destiny;
                            EulerCircuitDirected( next, predecessor);
                        }


                    }

                }
            }
            else
            {

                foreach (NodeR nr in start.relations)
                {
                    Edge edge = g.GetEdge(start, nr.Up);
                    if (!edge.Visited)
                    {

                        if (nr.Up.Name.Equals(predecessor.Name))
                        {
                            if (g.ContRestForVisit(start) == 1)
                            {

                                edge.Visited = true;
                                predecessor = start;
                                if (!start.Name.Equals(edge.Source.Name))
                                {

                                    NodeP next = edge.Source;
                                    EulerCircuitDirected(next, predecessor);
                                }
                                else
                                {
                                    NodeP next = edge.Destiny;
                                    EulerCircuitDirected(next, predecessor);
                                }

                            }
                        }
                        else
                        {

                            edge.Visited = true;
                            predecessor = start;
                            if (!start.Name.Equals(edge.Source.Name))
                            {

                                NodeP next = edge.Source;
                                EulerCircuitDirected(next, predecessor);
                            }
                            else
                            {

                                NodeP next = edge.Destiny;
                                EulerCircuitDirected( next, predecessor);
                            }
                        }
                    }

                }
            }

        }

        private bool IsValid(NodeP source, NodeP destiny)
        {
            bool flag = false;
            if (g.ContRestForVisit(source) == 1)
            {

                flag = true;
            }
            else
            {
                Graph aux = new Graph(g);
                NodeP auxSource = aux.getNode(source.Name);
                NodeP auxDestiny = aux.getNode(destiny.Name);
                aux.RemoveEdge(aux.GetEdge(auxSource, auxDestiny));
                if (Conexo())
                {
                    flag = true;
                }
            }

            return flag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
