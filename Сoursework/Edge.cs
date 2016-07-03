using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System;

namespace Сoursework
{
    /// <summary>
    ///An edge of the graph.
    /// </summary>

    [Serializable]
    class Edge
    {
        [NonSerialized]
        private Line liner;

        private List<Node> listnode;

        public Line Liner
        {
            get
            {
                return liner;
            }

            set
            {
                liner = value;
            }
        }

        internal List<Node> Listnode
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

        public Edge(List<Node> v)
        {
            Liner = new Line();
            Liner.X1 = v[0].node.Margin.Left + 14;
            Liner.Y1 = v[0].node.Margin.Top + 14;
            Liner.X2 = v[1].node.Margin.Left + 14;
            Liner.Y2 = v[1].node.Margin.Top + 14;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            Liner.Stroke = blackBrush;
            Liner.StrokeThickness = 4;            
            Listnode = new List<Node>() { v[0], v[1] };
        }
        /// <summary>
        /// The comparison of edges.
        /// </summary>
        /// <param name="obj">Edge</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Edge o = (Edge)obj;
            if ((this.Liner.X1 == o.Liner.X1 &&this.Liner.Y1 == o.Liner.Y1 &&
                this.Liner.X2 == o.Liner.X2 &&this.Liner.Y2 == o.Liner.Y2))
                return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return (int)(Liner.X1 + Liner.X2 + Liner.Y1 + Liner.Y2);
        }

       
    }
}