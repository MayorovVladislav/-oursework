using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сoursework
{
    /// <summary>
    /// AdjacencyList
    /// </summary>
    class AdjacencyList
    {
        string[][] matrix;
        Dictionary<string, bool> visited = new Dictionary<string, bool>();
        int[] vertex;
        public AdjacencyList(List<Edge> edges, List<Node> nodes, int start)
        {
            List<List<Node>> collection = new List<List<Node>>();
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            foreach (var item in edges)
                collection.Add(item.Listnode);

            foreach (var item in collection)
                if (!dic.ContainsKey(item[0].Id))
                    dic.Add(item[0].Id, new List<int> { item[1].Id });
                else
                    dic[item[0].Id].Add(item[1].Id);

            vertex = new int[nodes.Count];

            matrix = new string[nodes.Count][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (dic.ContainsKey(i))
                {
                    matrix[i] = new string[dic[i].Count];
                    for (int y = 0; y < dic[i].Count; y++)
                        matrix[i][y] = dic[i][y].ToString();
                }
                else
                    matrix[i] = new string[1] { "" };
                visited.Add(i.ToString(), false);
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
                Array.Sort(matrix[i]);
            BFS(nodes, start);
        }

        /// <summary>
        /// BFS
        /// </summary>
        public void BFS(List<Node> lister, int start)
        {
            for (int i = 0; i < vertex.Length; i++)
                vertex[i] = -1;
            Queue<int> openVertex = new Queue<int>();
            vertex[start] = 0;
            openVertex.Enqueue(start);
            visited[start.ToString()] = true;
            while (openVertex.Count != 0)
            {
                int u = openVertex.Dequeue();
                for (int i = 0; i < matrix[u].Length; i++)
                    if (matrix[u][i] != "")
                        if (visited[matrix[u][i]] == false)
                        {
                            vertex[int.Parse(matrix[u][i])] = vertex[u] + 1;
                            visited[matrix[u][i]] = true;
                            openVertex.Enqueue(int.Parse(matrix[u][i]));
                        }
            }
            for (int i = 0; i < vertex.Length; i++)
                lister[i].Numer = vertex[i];
        }
    }
}