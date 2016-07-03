using System.Collections.Generic;

namespace Сoursework
{
    /// <summary>
    /// Class graph.
    /// </summary>
    class GraphDraw
    {
        List<Edge> listedge = new List<Edge>();
        public List<Edge> ListEdge
        {
            get
            {
                return listedge;
            }

            set
            {
                listedge = value;
            }
        }

        List<Node> listnode = new List<Node>();
        public List<Node> ListNode
        {
            get
            {
                return listnode;
            }

            set
            {
                listnode = value;
            }
        }
        public bool Editing
        {
            get
            {
                return editing;
            }

            set
            {
                editing = value;
            }
        }    

        bool editing = true;
    }
}
