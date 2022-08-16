using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//public System.Windows.Forms.Orientation Orientation { get; }
//[System.ComponentModel.Browsable(false)]
//public System.Windows.Forms.Orientation Orientation { get; }

/*
 * -Cascarón-Editor de Grafos: Se les otorga  para la implementación de algoritmos y del proyecto. 
 * -Puediera ser necesario que para dichos algoritmos se requiera implementar algunos otros 
 * (# aristas, # nodos, grado de vértices y grafo, etc.) necesarios.
 * -Se recomienda revisar las estructuras de datos, clases y construcciones de objetos implementadas 
 * editando nodos y aristas, haciendo corridas para ver el flujo.
 * -Algún código se comentó ya que se considera no necesario.
 */
namespace EditordeGrafos
{
    public partial class Editor : Form
    {
        private bool num;
        private bool band;
        private char nombre;
        private int numero;
        private bool edgeIsDirected;
        private Edge edge;
        private Bitmap bmp1;
        private Graphics graphics;
        private NodeP nu;
        private Pen fl;
        private Point pt1;
        private Point pt2;
        private Graph graph;
        private int option;

        public List<List<int>> ListAdyacencia;

        #region Structure
        // Configuraciones iniciales al editor
        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = CreateGraphics();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BackColor = Color.White;
            fl = new Pen(Brushes.Green);
            bmp1 = new Bitmap(1077, 600);
            num = false;
            numero = 0;

            band = false;
            option = 0;
            nombre = 'A';
            pt2 = new Point();
            graph = new Graph();
            DisableMenus();
        }

        public Editor()
        {
            InitializeComponent();
        }

        // Maneja la redimencion del area cliente
        private void Resize_form(object sender, EventArgs e)
        {
            if (ClientSize.Width != 0 && ClientSize.Height != 0)
            {
                bmp1 = new Bitmap(ClientSize.Width, ClientSize.Height);
                graphics = CreateGraphics();
                graphics.DrawImage(bmp1, 50, 50);
            }
        }

        #endregion

        #region Mouse

        // Eventos cuando se hace click izquierdo o derecho con el mouse
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            pt2 = e.Location;
            pt1 = pt2;
            switch (e.Button.ToString())
            {
                case "Left":
                    // Cuando es click en cualquier otra opción
                    if (option != 0 && option != 1)
                    {
                        band = true;
                        Form1_Paint(this, null);
                        band = false;
                    }
                    break;
                // Click derecho para asignar peso a la arista
                case "Right":
                    int totalEdges = graph.EdgesList.Count;
                    for (int i = 0; i < totalEdges; i++)
                    {
                        edge = graph.EdgesList[i];
                        if (edge.Toca(pt2))
                        {
                            MenuArista.Enabled = true;
                            MenuArista.ClientSize = new Size(50, 50);
                            MenuArista.Visible = true;
                            MenuArista.Show(Cursor.Position);
                            break;
                        }
                    }
                    break;
            }
        }

        // Eventos cuando se mueve el mouse
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Rectangle mouseRec;
            Rectangle nRec;
            int nX, nY; // coordenadas de los nodos iniciales o finalees
            int rad = graph.NodeRadio; // obtiene el radio del grafo;


            // Mover el grafo
            if (option == 5)
            {

                if (e.Button == MouseButtons.Left)
                {
                    foreach (NodeP nod in graph)
                    {
                        nX = nod.Position.X;
                        nY = nod.Position.Y;

                        mouseRec = new Rectangle(pt2.X, pt2.Y, 5, 5);
                        nRec = new Rectangle(nX - rad / 2, nY - rad / 2, rad, rad);

                        if ((nRec.IntersectsWith(mouseRec)))
                        {
                            pt2 = e.Location;
                            Form1_Paint(this, null);
                        }
                    }
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    pt2 = e.Location;
                    band = false;
                    Form1_Paint(this, null);

                }
            }
        }

        // Eventos cuando se levanta el mouse
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Edge ed = new Edge();
            NodeP des;
            Graphics au;
            au = Graphics.FromImage(bmp1);
            au.Clear(BackColor);
            if (graph.EdgesList.Count == 0)
            {
                tT_directedEdge.Enabled = m_directedEdge.Enabled = true;
                tT_undirectedEdge.Enabled = m_undirectedEdge.Enabled = true;
            }

            switch (option)
            {
                // Agregar nodo
                case 1:

                    pt1 = pt2;
                    pt2 = e.Location;
                    band = true;
                    Form1_Paint(this, null);
                    band = false;
                    break;
                // Mover nodo
                case 2:
                    nu = null;
                    break;
                // Arista dirigida y no dirigida
                case 3:
                    des = (NodeP)graph.Find(delegate (NodeP a) { if (e.Location.X > a.Position.X - (graph.NodeRadio / 2) && e.Location.X < a.Position.X + (graph.NodeRadio) && e.Location.Y > a.Position.Y - (graph.NodeRadio / 2) && e.Location.Y < a.Position.Y + (graph.NodeRadio)) return true; else return false; });
                    if (des != null && nu != null)
                    {
                        nu.InsertRelation(des, graph.EdgesList.Count, edgeIsDirected);
                        ed = new Edge(nu, des, "e" + graph.EdgesList.Count.ToString());
                        graph.AddEdge(ed);

                        if (!edgeIsDirected && ed.Destiny.Name != ed.Source.Name)
                        {
                            des.InsertRelation(nu, graph.EdgesList.Count - 1, edgeIsDirected);
                        }
                        Pinta(au);
                        band = false;
                        nu = null;
                    }
                    else
                    {
                        Pinta(au);
                    }
                    pt1 = pt2;
                    if (graph.EdgesList.Count > 0)
                    {
                        tT_removeEdge.Enabled = m_deleteEdge.Enabled = true;
                        if (edgeIsDirected)
                        {
                            tT_undirectedEdge.Enabled = m_undirectedEdge.Enabled = false;
                        }
                        else
                        {
                            tT_directedEdge.Enabled = m_directedEdge.Enabled = false;
                        }
                    }

                    graphics.DrawImage(bmp1, 0, 0);
                    break;
                // Eliminar nodo
                case 4:
                    nu = (NodeP)graph.Find(delegate (NodeP a) { if (e.Location.X > a.Position.X - graph.NodeRadio / 2 && e.Location.X < a.Position.X + graph.NodeRadio && e.Location.Y > a.Position.Y - graph.NodeRadio / 2 && e.Location.Y < a.Position.Y + graph.NodeRadio) return true; else return false; });
                    if (nu != null)
                    {
                        graph.RemoveNode(nu);
                        if (graph.Count < 2)
                        {
                            m_undirectedEdge.Enabled = m_directedEdge.Enabled = false;
                            tT_undirectedEdge.Enabled = tT_directedEdge.Enabled = false;
                        }
                        else
                        {
                            if (graph.EdgesList.Count == 0)
                            {
                                m_undirectedEdge.Enabled = m_directedEdge.Enabled = true;
                                tT_undirectedEdge.Enabled = tT_directedEdge.Enabled = true;
                            }

                        }
                        if (graph.Count == 0)
                        {
                            nombre = 'A';
                            DisableMenus();
                            UncheckMenus();
                        }
                        Form1_Paint(this, null);
                        band = false;
                    }
                    break;
                // Mover grafo
                case 5:
                    pt2 = pt1;
                    break;

            }
        }

        #endregion

        #region TopToolbar

        // Abrir un grafo
        private void OpenGraph(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath + "\\ProyectosGrafo",
                DefaultExt = ".grafo"
            };
            string namefile;
            OpenFile.Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                namefile = OpenFile.FileName;

                try
                {
                    using (Stream stream = File.Open(namefile, FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        graph = (Graph)bin.Deserialize(stream);
                        edgeIsDirected = graph.EdgeIsDirected;
                        int.TryParse(graph[graph.Count - 1].Name, out numero);
                        Pinta(graphics);
                    }
                }
                catch (IOException exe)
                {
                    MessageBox.Show(exe.ToString());
                }

                EnableMenus();

                // Verifica dirigido o no dirigido
                if (graph.EdgesList != null && graph.EdgesList.Count > 0 && edgeIsDirected)
                {
                    m_directedEdge.Enabled = tT_directedEdge.Enabled = true;
                    m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = false;
                }
                else
                {
                    m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = true;
                    m_directedEdge.Enabled = tT_directedEdge.Enabled = false;
                }

                option = 0;
                graph.UnselectAllNodes();
                nombre = graph[graph.Count - 1].Name[0];
                nombre++;
                graph.OrderRelationsNode();
            }
        }

        // Guarda un grafo
        private void SaveGraph(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog
            {
                Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*",
                InitialDirectory = Application.StartupPath + "\\ProyectosGrafo"
            };
            String nombr;
            if (sav.ShowDialog() == DialogResult.OK)
            {
                nombr = sav.FileName;

                try
                {
                    using (Stream stream = File.Open(nombr, FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, graph);
                    }
                }
                catch (IOException exe)
                {
                    MessageBox.Show(exe.ToString());
                }
            }
        }

        // Elimina grafo y mantiene la configuracion
        private void EraseGraph(object sender, EventArgs e)
        {
            DisableMenus();
            UncheckMenus();
            graph.Clear();
            graph = new Graph();
            graphics.Clear(BackColor);
            nombre = 'A';

        }

        // Borra grafo y restablece la configuración
        private void DeleteGraph(object sender, EventArgs e)
        {
            int r = graph.NodeRadio;
            Color nc = graph.NodeColor;
            Color ec = graph.EdgeColor;
            Color nbc = graph.NodeBorderColor;
            int bw = graph.NodeBorderWidth;
            int ew = graph.EdgeWidth;
            bool env = graph.EdgeNamesVisible;
            bool ewv = graph.EdgeWeightVisible;
            graph = new Graph();
            graphics.Clear(BackColor);
            nombre = 'A';
            graph.NodeRadio = r;
            graph.NodeColor = nc;
            graph.EdgeColor = ec;
            graph.NodeBorderColor = nbc;
            graph.NodeBorderWidth = bw;
            graph.EdgeWidth = ew;
            graph.EdgeNamesVisible = env;
            graph.EdgeWeightVisible = ewv;
        }

        // Evento salir
        private void Exit(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Salir?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        // Evento agrega nodo
        private void AddNode(object sender, EventArgs e)
        {
            UncheckMenus();
            pt2 = new Point();
            tT_addNode.Checked = true;
            option = 1;
        }
        // Evento mueve nodo
        private void MoveNode(object sender, EventArgs e)
        {
            UncheckMenus();
            band = true;
            option = 2;
            tT_moveNode.Checked = true;
        }
        // Evento mueve grafo
        private void MoveGraph(object sender, EventArgs e)
        {

            UncheckMenus();
            option = 5;
            tT_moveGraph.Checked = true;
        }

        // Evento elimina nodo
        private void DeleteNode(object sender, EventArgs e)
        {
            UncheckMenus();
            tT_deleteNode.Checked = true;
            option = 4;
        }
        // Evento elimina arista
        private void DeleteEdge(object sender, EventArgs e)
        {
            UncheckMenus();
            option = 6;
            tT_removeEdge.Checked = true;
        }

        // Evento arista dirigida
        private void DirectedEdge(object sender, EventArgs e)
        {
            option = 3;
            band = true;

            UncheckMenus();
            tT_directedEdge.Checked = true;

            fl.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            fl.StartCap = LineCap.RoundAnchor;
            fl.Width = 4;
            edgeIsDirected = true;
            graph.EdgeIsDirected = true;
        }

        // Evento arista no digirida
        private void UndirectedEdge(object sender, EventArgs e)
        {
            option = 3;
            band = true;
            UncheckMenus();
            tT_undirectedEdge.Checked = true;

            fl.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
            fl.StartCap = LineCap.NoAnchor;
            fl.Width = 4;
            edgeIsDirected = false;
            graph.EdgeIsDirected = false;
        }

       
        // Intercambia las letras por numeros en las aristas
        
        public void Exchange()
        {
            int cont = 0;
            char name = 'A';
            //Bandera para saber en que esta letras o numeros
           bool num = graph.Letter;

           
            if (num == true)
            {
                foreach (NodeP cambio in graph)
                {
                    cambio.Name = name.ToString();
                    name++;
                }
                name = 'A';
                for (int i = 0; i < graph.Count; i++)
                {
                    name++;
                }
            }
            else
            {
                numero = graph.Count;
                foreach (NodeP cambio in graph)
                {
                    cambio.Name = cont.ToString();
                    cont++;
                }
            }
            Form1_Paint(this, null);
        }

        
        // Abre la configuración del nodo y arista
        private void Configuration(object sender, EventArgs e)
        {
            using (var f2 = new ConfigNodAri(graph))
            {
               
               var result = f2.ShowDialog();

               if (f2.Bandera == -1)
               {
                    graph.Letter = false;
                }
                else if(f2.Bandera == 1 )
                {
                    graph.Letter = true;
                }
                Exchange();


                if (result == DialogResult.OK)
                {
                    foreach (NodeP colNodo in graph)
                    {
                        colNodo.Color = f2.ColNodo;
                    }
                    graph.Letter = f2.Letra;

                    graph.NodeRadio = f2.Radio;
                    graph.NodeColor = f2.ColNodo;
                    graph.EdgeColor = f2.ColArista;
                    graph.NodeBorderColor = f2.ColBordeNodo;
                    graph.NodeBorderWidth = f2.AnchoBordeNodo;
                    graph.EdgeWidth = f2.AnchoArista;
                    graph.EdgeNamesVisible = f2.NombreArista;
                    graph.EdgeWeightVisible = f2.PesoArista;
                }
            }
            Form1_Paint(this, null);
        }

        // Evento view
        private void View(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "NombreAristas":
                    graph.EdgeNamesVisible = !graph.EdgeNamesVisible;
                    break;
                case "PesoAristas":
                    graph.EdgeWeightVisible = !graph.EdgeWeightVisible;
                    break;
            }
            Pinta(graphics);
        }


        #region Paint

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics au = Graphics.FromImage(bmp1);
            int iaux;


            au.Clear(BackColor);
            if (option == 5)
            {
                Cursor.Current = Cursors.Hand;
            }
            switch (option)
            {
                // Agrega nodo
                case 1:
                    if (band)
                    {

                        if (graph.Count > 0)
                        {
                            if ((int.TryParse(graph[0].Name.ToString(), out iaux)) == true)
                            {
                                num = true;
                            }
                            else {
                                num = false;
                               // numero ++;
                            }
                        }
                        nu = new NodeP(pt2, nombre);
                        if (num == false)
                        {
                            nombre++;
                            if (nombre > 90)
                            {
                                num = true;
                            }
                        }
                        else
                        {
                            nu.Name = numero.ToString();
                            numero++;
                        }

                        if (graph.Count > 1)
                        {

                            nu.Color = graph[0].Color;
                        }


                        graph.AddNode(nu);
                    }
                    if (graph.Count >= 1)
                    {
                        tT_moveGraph.Enabled = m_moveGraph.Enabled = true;
                        tT_deleteGraph.Enabled = m_deleteGraph.Enabled = true;
                        tT_eraseGraph.Enabled = m_eraseGraph.Enabled = true;
                        tT_saveGraph.Enabled = m_saveGraph.Enabled = true;
                        tT_moveNode.Enabled = m_moveNode.Enabled = true;
                        tT_deleteNode.Enabled = true;
                        m_addEdge.Enabled = true;
                        m_deleteNode.Enabled = true;
                    }
                    break;
                // Mueve nodo
                case 2:
                    if (band)
                    {
                        nu = (NodeP)graph.Find(delegate (NodeP a) { if (pt2.X > a.Position.X - (graph.NodeRadio / 2) && pt2.X < a.Position.X + (graph.NodeRadio) && pt2.Y > a.Position.Y - (graph.NodeRadio / 2) && pt2.Y < a.Position.Y + (graph.NodeRadio)) return true; else return false; });
                    }
                    else
                    {

                        if (nu != null)
                        {
                            nu.Position = pt2;
                            au.Clear(BackColor);
                        }
                        pt2 = pt1;
                    }
                    break;
                // Arista dirigida y no dirigida
                case 3:
                    if (band)
                    {
                        nu = (NodeP)graph.Find(delegate (NodeP a) { if (pt2.X > a.Position.X - (graph.NodeRadio / 2) && pt2.X < a.Position.X + (graph.NodeRadio) && pt2.Y > a.Position.Y - (graph.NodeRadio / 2) && pt2.Y < a.Position.Y + (graph.NodeRadio)) return true; else return false; });
                        pt1 = pt2;
                    }
                    else
                    {
                        au.Clear(BackColor);
                        if (nu != null)
                        {
                            au.DrawLine(fl, pt1, pt2);
                        }
                    }
                    break;
                // Mover grafo
                case 5:
                    Point po = new Point(pt2.X - pt1.X, pt2.Y - pt1.Y);
                    foreach (NodeP n in graph)
                    {
                        Point nue = new Point(n.Position.X + po.X, n.Position.Y + po.Y);
                        n.Position = nue;
                    }
                    pt1 = pt2;
                    au.Clear(BackColor);
                    break;
                // Elimina arista
                case 6:
                    if (band)
                    {
                        Rectangle mouseRec, niRec, nfRec;
                        Point ini, fin;

                        foreach (Edge ed in graph.EdgesList)
                        {
                            //for (int i = 0; i < graph.EdgesList.Count; i++) {
                            if (ed.Toca(pt2))
                            {

                                ini = ed.Source.Position;
                                fin = ed.Destiny.Position;
                                mouseRec = new Rectangle(pt2.X, pt2.Y, 3, 3);
                                niRec = new Rectangle(ini.X - graph.NodeRadio / 2, ini.Y - graph.NodeRadio / 2, graph.NodeRadio, graph.NodeRadio);
                                nfRec = new Rectangle(ini.X - graph.NodeRadio / 2, ini.Y - graph.NodeRadio / 2, graph.NodeRadio, graph.NodeRadio);

                                if (!(nfRec.IntersectsWith(mouseRec)))
                                {
                                    graph.RemoveEdge(ed);
                                    break;
                                }

                            }
                        }
                        if (graph.EdgesList.Count == 0)
                        {
                            tT_removeEdge.Enabled = m_deleteEdge.Enabled = false;
                        }
                    }
                    break;
            }
            Pinta(au);
            graphics.DrawImage(bmp1, 0, 0);

        }

        private void Pinta(Graphics g)
        {
            Pen pendi = new Pen(graph.EdgeColor, graph.EdgeWidth);
            Pen penNdi = new Pen(graph.EdgeColor, graph.EdgeWidth);
            Pen pen = new Pen(graph.NodeBorderColor, graph.NodeBorderWidth);

            AdjustableArrowCap end = new AdjustableArrowCap(6, 6);
            SolidBrush nod;
            pendi.CustomEndCap = end;
            Size s = new Size(graph.NodeRadio, graph.NodeRadio);
            double p3x, p3y, p4x, p4y;
            double ang;
            PointF A, B;
            A = new PointF();
            double d;
            double r;
            double an;
            double dy, dx;
            dy = dx = 0;
            List<Edge> repetidas = new List<Edge>();
            // Dibuja la linea entre dos nodos
            if (graph.EdgesList != null && graph.EdgesList.Count > 0)
            {
                foreach (Edge a in graph.EdgesList)
                {
                    if (!edgeIsDirected)
                    {
                        if (a.Source.Name == a.Destiny.Name)
                        {
                            // Oreja
                            g.DrawBezier(penNdi, new Point(a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) - 10, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) - 5), new Point(a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) - 40, a.Source.Position.Y - ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) - 60), new Point(a.Source.Position.X + 40, a.Destiny.Position.Y - 60), new Point(a.Destiny.Position.X + 10, a.Destiny.Position.Y - 5));
                        }
                        else
                        {
                            // Arista no dirigida

                            g.DrawLine(penNdi, a.Source.Position.X, a.Source.Position.Y, a.Destiny.Position.X, a.Destiny.Position.Y);
                        }

                        repetidas = graph.EdgesList.FindAll(delegate (Edge repe) { if (repe.Source.Name == a.Source.Name && repe.Destiny.Name == a.Destiny.Name || (a.Source.Name == repe.Destiny.Name && a.Destiny.Name == repe.Source.Name)) return true; else return false; });

                        if (repetidas.Count > 1 && a.Painted == false)
                        {
                            if ((a.Destiny.Position.Y - a.Source.Position.Y) != 0)
                            {
                                g.DrawString(repetidas.Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) + 4, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) + 4); foreach (Edge re in repetidas)
                                    re.Painted = true;
                            }
                        }
                    }
                    else
                    {
                        if (a.Source.Name == a.Destiny.Name)
                        {
                            g.DrawBezier(pendi, new Point(a.Source.Position.X - 10, a.Source.Position.Y - 5), new Point(a.Source.Position.X - 40, a.Source.Position.Y - 60), new Point(a.Source.Position.X + 40, a.Destiny.Position.Y - 60), new Point(a.Destiny.Position.X + 10, a.Destiny.Position.Y - 10));
                        }
                        else
                        {
                            if (graph.EdgesList.Find(delegate (Edge bus) { if (bus.Source.Name == a.Destiny.Name && bus.Destiny.Name == a.Source.Name) return true; else return false; }) == null)
                            {
                                double teta1 = Math.Atan2((double)(a.Destiny.Position.Y - a.Source.Position.Y), (double)(a.Destiny.Position.X - a.Source.Position.X));
                                float x1 = a.Source.Position.X + (float)((Math.Cos(teta1)) * (s.Height / 2));
                                float y1 = a.Source.Position.Y + (float)((Math.Sin(teta1)) * (s.Height / 2));

                                double teta2 = Math.Atan2(a.Source.Position.Y - a.Destiny.Position.Y, a.Source.Position.X - a.Destiny.Position.X);
                                float x2 = a.Destiny.Position.X + (float)((Math.Cos(teta2)) * (s.Height / 2));
                                float y2 = a.Destiny.Position.Y + (float)((Math.Sin(teta2)) * (s.Height / 2));
                                //Arista dirigida draw
                                g.DrawLine(pendi, x1, y1, x2, y2);

                                if (graph.EdgesList.FindAll(delegate (Edge repe) { if (repe.Source.Name == a.Source.Name && repe.Destiny.Name == a.Destiny.Name) return true; else return false; }).Count > 1)
                                {
                                    if ((a.Destiny.Position.Y - a.Source.Position.Y) != 0)
                                    {
                                        g.DrawString(graph.EdgesList.FindAll(delegate (Edge repe) { if (repe.Source.Name == a.Source.Name && repe.Destiny.Name == a.Destiny.Name) return true; else return false; }).Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) + 4, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) + 4);
                                    }
                                }

                            }
                            else
                            {
                                if (a.Painted == false)
                                {
                                    dy = a.Destiny.Position.Y - a.Source.Position.Y;
                                    dx = a.Destiny.Position.X - a.Source.Position.X;

                                    p3x = (dx * 1 / 3) + a.Source.Position.X;
                                    p3y = (dy * 1 / 3) + a.Source.Position.Y;
                                    p4x = (dx * 2 / 3) + a.Source.Position.X;
                                    p4y = (dy * 2 / 3) + a.Source.Position.Y;

                                    d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                                    r = .35 * d;

                                    if (a.Destiny.Position.X != a.Source.Position.X)
                                    {
                                        ang = Math.Atan((double)((double)dy / (double)dx));
                                    }
                                    else
                                    {
                                        ang = 90;
                                    }

                                    if (a.Destiny.Position.X > a.Source.Position.X)
                                    {
                                        an = ang + 89.8;
                                    }
                                    else
                                    {
                                        an = ang - 89.8;
                                    }

                                    B = new PointF((float)((r * Math.Cos(an)) + p4x), (float)((r * Math.Sin(an)) + p4y /*+ 15 * (an / Math.Abs(an))*/));
                                    A = new PointF((float)((r * Math.Cos(an)) + p3x), (float)((r * Math.Sin(an)) + p3y /*+ 15 * (an / Math.Abs(an))*/));



                                    if (a.Destiny.Position.X > a.Source.Position.X)
                                    {
                                        an = ang + 89.56;
                                    }
                                    else
                                    {
                                        an = ang - 89.56;
                                    }
                                    g.DrawBezier(pendi, new PointF(a.Source.Position.X + (float)((Math.Cos(an)) * (s.Height / 2)), a.Source.Position.Y + (float)((Math.Sin(an)) * (s.Height / 2))), A, B, new PointF(a.Destiny.Position.X + (float)((Math.Cos(an)) * (s.Height / 2)), a.Destiny.Position.Y + (float)((Math.Sin(an)) * (s.Height / 2))));

                                    a.Painted = true;
                                }
                            }
                            if (graph.EdgesList.FindAll(delegate (Edge repe) { if (repe.Source.Name == a.Source.Name && repe.Destiny.Name == a.Destiny.Name) return true; else return false; }).Count > 1)
                            {
                                if ((a.Destiny.Position.Y - a.Source.Position.Y) != 0)
                                {
                                    g.DrawString(graph.EdgesList.FindAll(delegate (Edge repe) { if (repe.Source.Name == a.Source.Name && repe.Destiny.Name == a.Destiny.Name) return true; else return false; }).Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Destiny.Position.X, A.Y - 10);
                                }
                            }
                        }
                    }

                    if (graph.EdgeNamesVisible)
                    {
                        g.DrawRectangle(pen, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2 - 5), a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) - 10, 5, 10);

                        g.DrawString(a.Name, new Font("Bold", 10), Brushes.Blue, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) - 5, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) - 10);
                    }
                    if (graph.EdgeWeightVisible)
                    {
                        if (graph.EdgesList.Find(delegate (Edge bus) { if (bus.Source.Name == a.Destiny.Name && bus.Destiny.Name == a.Source.Name) return true; else return false; }) == null)
                        {
                            g.DrawString(a.Weight.ToString(), new Font("Bold", 10), Brushes.Blue, a.Source.Position.X + ((a.Destiny.Position.X - a.Source.Position.X) / 2) + 4, a.Source.Position.Y + ((a.Destiny.Position.Y - a.Source.Position.Y) / 2) + 4);
                        }
                        else
                        {
                            g.DrawString(a.Weight.ToString(), new Font("Bold", 10), Brushes.Blue, a.Destiny.Position.X, A.Y - 10);
                        }
                    }

                }
            }
            if (graph.EdgesList != null)
            {
                foreach (Edge des in graph.EdgesList)
                {
                    des.Painted = false;
                }
            }
            if (graph.Count > 0 && graph.NodeRadio != 0)
            {
                foreach (NodeP n in graph)
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
                    g.FillEllipse(nod, re);
                    g.DrawEllipse(pen, re);
                    g.DrawString(n.Name, new Font("Bold", graph.NodeRadio / 4), new SolidBrush(graph.NodeBorderColor), (n.Position.X - graph.NodeRadio / 4 + graph.NodeRadio / 12), (n.Position.Y - graph.NodeRadio / 4 + graph.NodeRadio / 12));
                }
            }
            pendi.Dispose();
            penNdi.Dispose();
            pen.Dispose();
        }

        #endregion

        #region Interface

        private void MenuArista_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (toolStripTextBox1.Text.Length > 0)
            {
                edge.Weight = int.Parse(toolStripTextBox1.Text);
                edge = null;
                toolStripTextBox1.Text = "";
            }
        }
        // Método que activa todos los menús de toolstrip y del menu, cuando hay algo en el editor.
        public void EnableMenus()
        {
            tT_saveGraph.Enabled = m_saveGraph.Enabled = true;
            tT_deleteNode.Enabled = m_deleteNode.Enabled = true;
            tT_moveNode.Enabled = m_moveNode.Enabled = true;
            tT_addNode.Enabled = m_addNode.Enabled = true;
            // Si hay mas de un nodo
            if (graph.Count >= 1)
            {
                // Si no hay aristas
                if (graph.EdgesList.Count == 0)
                {
                    m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = true;
                    m_directedEdge.Enabled = tT_directedEdge.Enabled = true;
                }
                else
                {
                    // Si hay aristas dirigidas
                    if (edgeIsDirected)
                    {
                        m_directedEdge.Enabled = m_pesoAristas.Enabled = true;
                        m_directedEdge.Enabled = tT_directedEdge.Enabled = true;
                        m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = false;

                    }
                    // Si hay aristas no dirigidas
                    else
                    {
                        m_directedEdge.Enabled = m_pesoAristas.Enabled = true;
                        m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = true;
                        m_directedEdge.Enabled = tT_directedEdge.Enabled = false;
                    }
                }
            }

            // Si hay mas de una arista
            if (graph.EdgesList.Count > 0)
            {
                m_deleteEdge.Enabled = tT_removeEdge.Enabled = true;
            }

            m_moveGraph.Enabled = tT_moveGraph.Enabled = true;
            m_deleteGraph.Enabled = tT_deleteGraph.Enabled = true;
            m_eraseGraph.Enabled = tT_eraseGraph.Enabled = true;

        }

        // Descativa la mayoría de los botones y reinicializa el grafo
        private void DisableMenus()
        {
            m_addNode.Enabled = tT_addNode.Enabled = true;
            m_moveNode.Enabled = tT_moveNode.Enabled = false;
            m_directedEdge.Enabled = tT_directedEdge.Enabled = false;
            m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = false;
            m_deleteNode.Enabled = tT_deleteNode.Enabled = false;
            m_moveGraph.Enabled = tT_moveGraph.Enabled = false;
            m_deleteEdge.Enabled = tT_removeEdge.Enabled = false;
            m_deleteGraph.Enabled = tT_deleteGraph.Enabled = false;
            m_saveGraph.Enabled = tT_saveGraph.Enabled = false;
            m_nombreAristas.Enabled = m_pesoAristas.Enabled = false;
            m_eraseGraph.Enabled = tT_eraseGraph.Enabled = false;
            m_addEdge.Enabled = false;
        }

        public void UncheckMenus()
        {
            tT_addNode.Checked = false;
            tT_moveNode.Checked = false;
            tT_deleteNode.Checked = false;
            tT_directedEdge.Checked = false;
            tT_undirectedEdge.Checked = false;
            tT_removeEdge.Checked = false;
            tT_moveGraph.Checked = false;
            tT_eraseGraph.Checked = false;
            tT_deleteGraph.Checked = false;
        }

        #endregion


        private void MostrarAtributos(object sender, EventArgs e)
        {
            using (var f2 = new AtributosGrafo(graph))
            {
                var result = f2.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
            }
            Form1_Paint(this, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            List<string> nodes = new List<string>();
            foreach (NodeP nodeP in graph)
            {
                nodes.Add(nodeP.Name);
            }
            Form mS = new AdjacencyMatrix(graph.GetAdjacencyMatrix() , nodes.Count, nodes);
            mS.Show();

        }

        private void menuStripMenuGeneralConfiguracion_Click(object sender, EventArgs e)
        {


        }


        #endregion

        #region ByMe

        #endregion

        private void recorridoEnProfundidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Search(true , graph);
            f.Show();
        }

        private void recorridoEnAnchuraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Search(false , graph);
            f.Show();
        }

        private void bosqueAbarcadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Forest(graph , edgeIsDirected);
            f.Show();
        }

        private void primToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new MST(graph);
            f.Show();
            //PintaMST(graphics);
        }

        private void simulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Silmulation(graph);
            f.Show();
        }

        private void eulerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Euler(graph , edgeIsDirected);
            f.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
            
            List<string> nodes = new List<string>();
            foreach (NodeP nodeP in graph)
            {
                nodes.Add(nodeP.Name);
            }
            Form mS = new MatrixWeightcs(graph.GetWeightMatrix(), nodes.Count, nodes);
            mS.Show();
        }

        private void dijkstraToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                int[,] Pesos = graph.GetWeightMatrix();
                int[,] md = new int[graph.Count, graph.Count];
                Dijkstra dj = new Dijkstra(graph.Count, Pesos, graph[0].Name);
                int[,] mc = dj.MatrizRelacion;

                for (int i = 0; i < graph.Count; i++)
                {
                    Dijkstra x = new Dijkstra(graph.Count, Pesos, graph[i].Name);
                    x.ALgoritmoDIjkstra();
                    int[] ditancia = x.Distancias;
                    for (int j = 0; j < graph.Count; j++)
                    {
                        md[i, j] = ditancia[j];
                    }
                }


                List<string> cad = new List<string>();
                foreach (NodeP i in graph)
                {
                    cad.Add(i.Name);
                }

                Form dijkstra = new DijkstraShow(Pesos, md, graph.Count, cad);
                dijkstra.Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Carga un grafo primero");
            }
        }


        private void arbolToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form f = new Archivos();
            f.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form f = new HashEstatico();
            f.Show();
        }
    }
}
