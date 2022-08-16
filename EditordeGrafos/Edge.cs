using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos{
    [Serializable()]
    public class Edge{
        
        private bool painted;
        private bool visited;
        private int weight;
        private NodeP source;
        private NodeP destiny;
        private string name;

        public NodeP Source{
            get { return source; }
            set { source=value; }
        }

        public NodeP Destiny{ 
            get { return destiny; } 
            set { destiny = value; } 
        }
        
        public string Name{
            get { return name; }
            set { name=value; }
        }

        public int Weight{ 
            get { return weight; } 
            set { weight = value; } 
        }
        
        public bool Painted{ 
            get { return painted; }    
            set { painted = value; } 
        }
        
        public bool Visited{ 
            get { return visited; } 
            set { visited = value; } 
        }

        public string getOriginDestiny(){
            return "(" + source.Name + "," + destiny.Name + ")";
        }

        public Edge(){
           
        }

        public Edge(NodeP origin, NodeP destiny, string name){
            this.source = origin;
            this.destiny = destiny;
            this.name = name;
            this.weight = 0;
            this.visited = false;
        }

        public Edge(Edge ed){
            source = ed.source;
            destiny = ed.destiny;
            weight = ed.Weight;
            visited = ed.Visited;
        }
        
        //calculate center
        private PointF Punto(double angulo,int tip){
            double dy, dx;
            double an, ang, d, r;
            double p3x, p3y, p4x, p4y;
            PointF A, B;

            if(tip == 1){
                PointF pF = new PointF();
                float x1 = Source.Position.X + (float)((Math.Cos(angulo * Math.PI / 180)) * (15));
                float y1 = Source.Position.Y + (float)((Math.Sin(angulo * Math.PI / 180)) * (15));
                pF.X = x1;
                pF.Y = y1;
                return pF;
            }
            else{
                dy = Destiny.Position.Y - Source.Position.Y;
                dx = Destiny.Position.X - Source.Position.X;
                p3x = (dx * 1 / 3) + Source.Position.X;
                p3y = (dy * 1 / 3) + Source.Position.Y;
                p4x = (dx * 2 / 3) + Source.Position.X;
                p4y = (dy * 2 / 3) + Source.Position.Y;
                d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                r = .35 * d;

                if(Destiny.Position.X != Source.Position.X){
                    ang = Math.Atan((double)((double)dy / (double)dx));
                }
                else{
                    ang = 90;
                }

                if(Destiny.Position.X > Source.Position.X){
                    an = ang + 90;
                }
                else{
                    an = ang - 90;
                }

                B = new PointF((float)((r * Math.Cos(an)) + p4x), (float)((r * Math.Sin(an)) + p4y /*+ 15 * (an / Math.Abs(an))*/));
                A = new PointF((float)((r * Math.Cos(an)) + p3x), (float)((r * Math.Sin(an)) + p3y /*+ 15 * (an / Math.Abs(an))*/));                

                if (tip == 2){
                    return A;
                }
                else{
                    return B;
                }
            }
        }

        public bool Toca(Point pos){
            Rectangle mouse = new Rectangle(pos.X, pos.Y, 3, 3);
            Rectangle pix = new Rectangle(Source.Position.X, Source.Position.Y, 1, 1);

            PointF p1 = Punto(-50,1);
            PointF p2 = Punto(-140,1);
            
            int x1 = Source.Position.X;
            int y1 = Source.Position.Y;
            int x2 = Destiny.Position.X;
            int y2 = Destiny.Position.Y;

            int dx = x2 - x1; //nodo origen y destino
            int dy = y2 - y1; //nodo origen y destino


            if (Math.Abs(dx) > Math.Abs(dy)){ // si esta 90 grados hasta 46 
                float m = (float)dy / (float)dx;
                if (m == 0) {
                    
                }
                float b = y1 - m * x1;
                if (dx < 0){
                    dx = -1;
                }
                else{
                    dx = 1;
                }

                while (x1 != x2){ //calcula las pendientes de toda la linea
                    x1 += dx;
                    y1 = (int)Math.Round(m * x1 + b);

                    pix.X = x1;
                    pix.Y = y1;

                    if(mouse.IntersectsWith(pix)){
                        return true;
                    }
                }
            }
            else{
                if (dy != 0){ // si esta de 45 a 0 grados
                    float m = (float)dx / (float)dy;      
                    float b = x1 - m * y1;
                    if(dy < 0){
                        dy = -1;
                    }
                    else{
                        dy = 1;
                    }

                    while (y1 != y2){
                        y1 += dy;
                        x1 = (int)Math.Round(m * y1 + b);
                        pix.X = x1;
                        pix.Y = y1;

                        if(mouse.IntersectsWith(pix)){
                            return true;
                        }
                    }
                }
            }

            if(Destiny == Source){ // si oreja
                List<double> ptList = new List<double>();
                Bezier bc = new Bezier();

                ptList.Add(p1.X);
                ptList.Add(p1.Y);
                ptList.Add(p1.X + 20);
                ptList.Add(p1.Y - 50);
                ptList.Add(p1.X - 50);
                ptList.Add(p1.Y - 50);
                ptList.Add(p2.X);
                ptList.Add(p2.Y);

                const int Puntos = 200;
                double[] ptind = new double[ptList.Count];
                double[] p = new double[Puntos];
                ptList.CopyTo(ptind, 0);
                bc.Bezier2D(ptind, (Puntos) / 2, p);

                for(int i = 1; i != Puntos - 1; i += 2)                {
                    if(mouse.IntersectsWith(new Rectangle((int)p[i + 1], (int)p[i], 10, 10))){
                        return true;
                    }
                }
            }
            
            return false;
        }

    }
}
