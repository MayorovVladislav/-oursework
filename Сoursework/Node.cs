using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System;

namespace Сoursework
{
    /// <summary>
    /// Node in the graph.
    /// </summary>
    [Serializable]
    class Node
    {
        private int numer;
        
        [NonSerialized]
        public Ellipse node;
        [NonSerialized]
        public Label valuenode;
        int x, y, id;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
        public int Numer
        {
            get
            {
                return numer;
            }

            set
            {
                numer = value;
            }
        }

        public Node(int x, int y, int id , MouseButtonEventHandler e)
        {
            Id = id;
            X = x;
            Y = y;
            node = new Ellipse()
            {
                Height = 28,
                Width = 28,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Stroke = new SolidColorBrush(Colors.Black),
                StrokeThickness = 0,
                Fill = new RadialGradientBrush()
                {
                    RadiusX = 1,
                    RadiusY = 1,
                    GradientOrigin = new Point(0.7, 0.3),
                    GradientStops = new GradientStopCollection()
                        {
                             new GradientStop() {Color = Colors.DarkOrange, Offset = 1},
                             new GradientStop() {Color = Colors.Violet, Offset = 1},
                             new GradientStop() {Color = Colors.Black, Offset =1}
                        }
                }
            };
            node.Name = "n" + id.ToString();
            node.ToolTip = id.ToString();
            node.Margin = new Thickness(x - 15, y - 15, 0, 0);            
            node.MouseRightButtonDown += new MouseButtonEventHandler(e);
            valuenode = new Label()
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 32,
                Height = 28
            };
            valuenode.Name = "l" + id.ToString();
            valuenode.Content = Id.ToString();
            valuenode.Uid = id.ToString();
            valuenode.Margin = new Thickness(x - 10, y - 14, 0, 0);
            valuenode.FontSize = 14;
        }

        /// <summary>
        /// Comparison of nodes.
        /// </summary>
        public override bool Equals(object obj)
        {
            Node o = (Node)obj;
            if (this.X == o.X && this.Y == o.Y) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return X + Y;
        }

    }

}
