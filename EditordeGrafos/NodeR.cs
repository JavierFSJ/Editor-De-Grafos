using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos{
    [Serializable()]

    public class NodeR{
        private bool visited;
        private string name;
        private NodeP up;

        public string Name{ 
            get { return name; } 
            set { name = value; } 
        }
        public NodeP Up{
            get { return up; }
        }
        public bool Visited{ 
            get { return visited; } 
            set { visited = value; } 
        }
        
        public NodeR(NodeP np, string nam){
            up = np;
            visited = false;
            name = nam;
        }
    }
}
