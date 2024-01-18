using lab6_executors.core;
using System;
using System.IO;

namespace lab6_executors.lab3
{
    public class Lab3Executor : Executor
    {

        public Lab3Executor(string inputPath, string outputPath) : base(inputPath, outputPath) {}

        public override void OnExecute()
        {
            int n, m;
            int[,] map;

            using (StreamReader reader = new StreamReader(InputPath))
            {
                string[] input = reader.ReadLine().Split();
                n = Int32.Parse(input[0]);
                m = Int32.Parse(input[1]);
                map = new int[n, m];

                for (int i = 0; i < n; i++)
                {
                    string[] row = reader.ReadLine().Split();
                    for (int j = 0; j < m; j++)
                    {
                        map[i, j] = Int32.Parse(row[j]);
                    }
                }
            }

            DijkstraGraph graph = new DijkstraGraph(map);

            int result = DijkstraSolver.Execute(graph);

            using (StreamWriter writer = new StreamWriter(OutputPath))
            {
                writer.Write(result);
            }
        }
    }
}
