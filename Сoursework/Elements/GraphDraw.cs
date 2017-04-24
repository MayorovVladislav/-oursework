using System.Collections.Generic;

namespace Сoursework
{
    /// <summary>
    /// Класс, содержащий все ребра и узлы графа.
    /// </summary>
    class GraphDraw
    {
        public List<Edge> listedge = new List<Edge>();
        List<Node> listnode = new List<Node>();
        bool editing = true;

        public bool Editing { get => editing; set => editing = value; }
        public List<Edge> ListEdge { get => listedge; set => listedge = value; }
        public List<Node> ListNode { get => listnode; set => listnode = value; }
    }
}
