using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos{
    [Serializable()]

    public class NodeP{
        private bool visited;
        private bool selected;
        private int degree;
        private int degreeIn;
        private int degreeEx;
        private string name; /// tomar este 
        private Point position;
        private Color color;
        public List<NodeR> relations;
        private int visitTime = -1;
        private int finishTime = -1;
        public int Tree { get; set; }

        public Point Position { 
            get { return position; } 
            set { position = value; } 
        }

        public string Name {
            get { return name; } 
            set { name = value; } 
        }
        public int Degree {
            get { return degree; } 
            set { degree = value; } 
        }

        public int Visit
        {
            get { return visitTime; }
            set { visitTime = value; }
        }

        public int Finish
        {
            get { return finishTime; }
            set { finishTime = value; }
        }


       

        public Color Color{
            get { return color; } 
            set { color=value; }
        }

        public int DegreeIn {
            get { return degreeIn; } 
            set { degreeIn = value; } 
        }
        public int DegreeEx {
            get { return degreeEx; } 
            set { degreeEx = value; } 
        }
        public bool Selected{
            get { return selected; }
            set { selected=value; }
        }
        public bool Visited { 
            get { return visited; } 
            set { visited = value; } 
        }

        #region constructores

        public NodeP(){

        }

        public NodeP(NodeP co){
            position = co.Position;
            name = co.Name;
            relations = new List<NodeR>();
            degree = co.Degree;
            degreeEx = co.DegreeEx;
            degreeIn = co.DegreeIn;
            color = co.Color;
            selected = false;
        }

        public NodeP(Point p, char n){
            position = p;
            name = n.ToString();
            relations = new List<NodeR>();
            degree = 0;
            color = Color.White;
            selected = false;
        }

        #endregion

        #region operaciones

        public void InsertRelation(NodeP newRel, int num, bool isDirected){
            Degree++;
            if(isDirected){
                DegreeEx++;
                newRel.DegreeIn++;
            }

            relations.Add(new NodeR(newRel, "e" + num.ToString()));
            OrderRelations();
        }

        public void RemoveRelation(NodeR delRel, bool isDirected) {
            Degree--;
            if (isDirected) {
                delRel.Up.DegreeIn--;
                this.degreeEx--;
            }
            relations.Remove(delRel);
        }

        public void OrderRelations()
        {
            relations = relations.OrderBy(x => x.Up.Name).ToList(); //Ordena la relaciones de manera acendente
        }

        public bool ExisteRelacion(string node)
        {
            foreach (NodeR nr in relations)
            {
                if (node.Equals(nr.Up.name))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
