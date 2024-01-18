namespace lab6_executors.lab3
{
    class DijkstraGraph
    {
        public int StartValue { get; private set; }
        public int[,] Graph { get; private set; }
        public int VertexCount { get; private set; }


        public DijkstraGraph(int[,] map)
        {
            Graph = ConvertMapToGraph(map);
        }

        private int[,] ConvertMapToGraph(int[,] map)
        {
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);

            StartValue = map[0, 0];
            VertexCount = rows * cols;

            int[,] weightedGraph = new int[VertexCount, VertexCount];

            for (int i = 0; i < VertexCount; i++)
            {
                for (int j = 0; j < VertexCount; j++)
                {
                    weightedGraph[i, j] = 100;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int currentVertex = i * cols + j;

                    if (j > 0)
                    {
                        int leftVertex = i * cols + (j - 1);
                        weightedGraph[currentVertex, leftVertex] = map[i, j - 1];
                    }
                    if (j < cols - 1)
                    {
                        int rightVertex = i * cols + (j + 1);
                        weightedGraph[currentVertex, rightVertex] = map[i, j + 1];
                    }

                    if (i > 0)
                    {
                        int topVertex = (i - 1) * cols + j;
                        weightedGraph[currentVertex, topVertex] = map[i - 1, j];
                    }
                    if (i < rows - 1)
                    {
                        int downVertex = (i + 1) * cols + j;
                        weightedGraph[currentVertex, downVertex] = map[i + 1, j];
                    }
                }
            }

            return weightedGraph;
        }
    }
}
