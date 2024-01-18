namespace lab6_executors.lab3
{
    class DijkstraSolver
    {
        static int MinIndex(int[] arr, bool[] marked)
        {
            int minIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (!marked[i] && arr[i] < arr[minIndex])
                    minIndex = i;
            }
            return minIndex;
        }

        public static int Execute(DijkstraGraph graph)
        {
            int n = graph.VertexCount;

            bool[] markedRoots = new bool[n];
            markedRoots[0] = true;
            for (int i = 1; i < n; i++)
                markedRoots[i] = false;

            int[] roots = new int[n];
            for (int i = 0; i < n; i++)
                roots[i] = graph.Graph[0, i];

            for (int i = 0; i < n - 1; i++)
            {
                int min = MinIndex(roots, markedRoots);
                markedRoots[min] = true;

                for (int j = 1; j < n; j++)
                {
                    int minNode = roots[min] + graph.Graph[min, j];
                    if (!markedRoots[j] && roots[j] > minNode)
                        roots[j] = minNode;
                }
            }

            return graph.StartValue + roots[n - 1];
        }
    }
}
