using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos.PriorityQueue
{
    class NodeQueue
    {
        private int p;
        private NodeP e;
        private Edge ed;


        public NodeQueue(int priority , NodeP element , Edge edge)
        {
            p = priority;
            e = element;
            ed = edge;
        }

        public int Priority { get => p;}
        public NodeP Element { get => e;}

        public Edge Arc { get => ed; }
        
    }
}
