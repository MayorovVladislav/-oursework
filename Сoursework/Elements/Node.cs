using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System;

namespace Сoursework
{
    /// <summary>
    /// Узел внутри графа.
    /// </summary>
    [Serializable]
    class Node
    {
        [NonSerialized]
        private Ellipse node;
        [NonSerialized]
        private Label valuenode;
        int x, y, id;
        private int numer;
        private int value;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Id { get => id; set => id = value; }
        public int Numer { get => numer; set => numer = value; }
        public Ellipse NodeV { get => node; set => node = value; }
        public Label ValueNode { get => valuenode; set => valuenode = value; }
        public int Value { get => value; set => this.value = value; }

        

        /// <summary>
        /// Создание узла.
        /// </summary>
        /// <param name="x">Координата по x.</param>
        /// <param name="y">Координата по y.</param>
        /// <param name="id">Идентификатор узла.</param>
        /// <param name="e">Событие выбора узла. Передача обработки нажатия мыши.</param>
        public Node(int x, int y, int id , MouseButtonEventHandler e)
        {
            Id = id;
            X = x;
            Y = y;
            NodeV = new Ellipse()
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
                             new GradientStop() {Color = Colors.DeepSkyBlue, Offset = 1},
                             new GradientStop() {Color = Colors.Violet, Offset = 1},
                             new GradientStop() {Color = Colors.Black, Offset =1}
                        }
                }
            };
            NodeV.Name = "n" + id.ToString();
            NodeV.ToolTip = id.ToString();
            NodeV.Margin = new Thickness(x - 15, y - 15, 0, 0);
            NodeV.MouseRightButtonDown += new MouseButtonEventHandler(e);
            ValueNode = new Label()
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 32,
                Height = 28
            };
            ValueNode.Name = "l" + id.ToString();
            ValueNode.Content = Id.ToString();
            ValueNode.Uid = id.ToString();
            ValueNode.Margin = new Thickness(x - 10, y - 14, 0, 0);
            ValueNode.FontSize = 14;
        }

        /// <summary>
        /// Сравнение узлов.
        /// </summary>
        public override bool Equals(object obj)
        {
            Node o = (Node)obj;
            if (this.X == o.X && this.Y == o.Y) return true;
            else return false;
        }
        /// <summary>
        /// Хэщ-код узла.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return X + Y;
        }

    }

}
