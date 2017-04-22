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
        public bool Value { get => value; set => this.value = value; }

        [NonSerialized]
        private Line liner, arrow1, arrow2;


        private List<Node> listnode;

        public Line Liner { get => liner; set => liner = value; }
        internal List<Node> Listnode { get => listnode; set => listnode = value; }
        public Line Arrow1 { get => arrow1; set => arrow1 = value; }
        public Line Arrow2 { get => arrow2; set => arrow2 = value; }

        private bool value;

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


        public Edge(List<Node> v, bool value)
        {
            this.value = value;

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


            if (value)
            {
                // координаты центра отрезка
                double X3 = (this.Liner.X1 + this.Liner.X2) / 2;
                double Y3 = (this.Liner.Y1 + this.Liner.Y2) / 2;

                // длина отрезка
                double d = Math.Sqrt(Math.Pow(this.Liner.X2 - this.Liner.X1, 2) + Math.Pow(this.Liner.Y2 - this.Liner.Y1, 2));

                // координаты вектора
                double X = this.Liner.X2 - this.Liner.X1;
                double Y = this.Liner.Y2 - this.Liner.Y1;

                // координаты точки, удалённой от центра к началу отрезка на 10px
                double X4 = X3 - (X / d) * 10;
                double Y4 = Y3 - (Y / d) * 10;

               //к оординаты вектора перпендикуляра
                double Xp = this.Liner.Y2 - this.Liner.Y1;
                double Yp = this.Liner.X1 - this.Liner.X2;

                // координаты перпендикуляров, удалённой от точки X4;Y4 на 5px в разные стороны
                double X5 = X4 + (Xp / d) * 5;
                double Y5 = Y4 + (Yp / d) * 5;
                double X6 = X4 - (Xp / d) * 5;
                double Y6 = Y4 - (Yp / d) * 5;

                Arrow1 = new Line()
                {
                    X1 = X3,
                    Y1 = Y3,
                    X2 = X5,
                    Y2 = Y5
                };

                Arrow2 = new Line()
                {
                    X1 = X3,
                    Y1 = Y3,
                    X2 = X6,
                    Y2 = Y6
                };

                Arrow1.Stroke = blackBrush;
                Arrow1.StrokeThickness = 5;


                Arrow2.Stroke = blackBrush;
                Arrow2.StrokeThickness = 5;
            }

            Liner.Stroke = blackBrush;
            Liner.StrokeThickness = 4;
            Listnode = new List<Node>() { v[0], v[1] };
        }

        /// <summary>
        /// Сравнение ребер.
        /// </summary>с
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