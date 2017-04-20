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
        public string[][] matrix;

        public SaveOpen(GraphDraw graph)
        {
            NodesValue = new Dictionary<int, Point>();

            for (int i = 0; i < graph.ListNode.Count; i++)
            {
                NodesValue.Add(graph.ListNode[i].Id, new Point(graph.ListNode[i].X, graph.ListNode[i].Y));
            }

            List<List<Node>> collection = new List<List<Node>>();
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            foreach (var item in graph.ListEdge)
            {
                collection.Add(item.Listnode);
            }

            foreach (var item in collection)
            {
                if (!dic.ContainsKey(item[0].Id))
                {
                    dic.Add(item[0].Id, new List<int> { item[1].Id });
                }
                else
                {
                    dic[item[0].Id].Add(item[1].Id);
                }
            }

            matrix = new string[graph.ListNode.Count][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (dic.ContainsKey(i))
                {
                    matrix[i] = new string[dic[i].Count];
                    for (int y = 0; y < dic[i].Count; y++)
                    {
                        matrix[i][y] = dic[i][y].ToString();
                    }
                }
                else
                {
                    matrix[i] = new string[1] { "" };
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Array.Sort(matrix[i]);
            }
        }
    }
}
