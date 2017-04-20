using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System;

namespace Сoursework
{
    /// <summary>
    /// Ребра внутри графа.
    /// </summary>

    [Serializable]
    class Edge
    {
        [NonSerialized]
        private Line liner;

        private List<Node> listnode;

        public Line Liner { get => liner; set => liner = value; }
        internal List<Node> Listnode { get => listnode; set => listnode = value; }

        /// <summary>
        /// Создание ребра.
        /// </summary>
        /// <param name="v">Узлы, между которыми необзодимо создать ребро.</param>
        public Edge(List<Node> v)
        {
            Liner = new Line()
            {
                X1 = v[0].NodeV.Margin.Left + 14,
                Y1 = v[0].NodeV.Margin.Top + 14,
                X2 = v[1].NodeV.Margin.Left + 14,
                Y2 = v[1].NodeV.Margin.Top + 14
            };
            SolidColorBrush blackBrush = new SolidColorBrush()
            {
                Color = Colors.Black
            };
            Liner.Stroke = blackBrush;
            Liner.StrokeThickness = 4;
            Listnode = new List<Node>() { v[0], v[1] };
        }

        /// <summary>
        /// Сравнение ребер.
        /// </summary>
        /// <param name="obj">Ребро.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Edge o = (Edge)obj;
            if ((Liner.X1 == o.Liner.X1 && Liner.Y1 == o.Liner.Y1 &&
                Liner.X2 == o.Liner.X2 && Liner.Y2 == o.Liner.Y2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Хэш-код ребра.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)(Liner.X1 + Liner.X2 + Liner.Y1 + Liner.Y2);
        }

       
    }
}