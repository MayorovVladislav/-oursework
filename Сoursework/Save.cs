using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Сoursework
{
    [Serializable]
    class SaveOpen
    {
        public Dictionary<int, Point> NodesValue;
        public List<Edge> le;

        public SaveOpen(GraphDraw graph)
        {
            NodesValue = new Dictionary<int, Point>();
            le = graph.ListEdge;

            for (int i = 0; i < graph.ListNode.Count; i++)
            {
                NodesValue.Add(graph.ListNode[i].Id, new Point(graph.ListNode[i].X, graph.ListNode[i].Y));
            }


        }
    }
}
