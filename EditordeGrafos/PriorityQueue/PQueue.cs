using System;
using System.Collections.Generic;
using System.Linq;


namespace EditordeGrafos.PriorityQueue
{
    class PQueue
    {
        private List<NodeQueue> queue;

        public PQueue()
        {
            queue = new List<NodeQueue>();
        }

        public void Enqueue(int priority, NodeP node , Edge edge)
        {
            queue.Add(new NodeQueue(priority, node , edge));
            queue = queue.OrderBy(x => x.Priority).ToList();
        }


        public NodeQueue Dequeue()
        {
            NodeQueue node = null;
            if (!IsEmpty())
            {
                node = queue.First();
                queue.RemoveAt(0);
            }
            return node;
        }


        public int getPriority()
        {
            
            if (!IsEmpty())
            {
                return queue.ElementAt(0).Priority;
            }
            return -1;
        }

        public bool IsEmpty()
        {
            bool empty = false;
            if (queue.Count == 0)
            {
                empty = true;
            }
            return empty;
        }
    }
}
