using lab6_executors.core;
using System;
using System.IO;

namespace lab6_executors.lab2
{
    public class Lab2Executor : Executor
    {
        public Lab2Executor(string inputPath, string outputPath) : base(inputPath, outputPath) { }

        public override void OnExecute()
        {
            int m, n;

            using (StreamReader reader = new StreamReader(InputPath))
            {
                string[] input = reader.ReadLine().Split();
                m = Int32.Parse(input[0]);
                n = Int32.Parse(input[1]);
            }

            int result = CountPatterns(n, m);

            using (StreamWriter writer = new StreamWriter(OutputPath))
            {
                writer.Write(result);
            }
        }

        static int CountPatterns(int n, int m)
        {
            int result = 0;

            int states = (int)Math.Pow(2, n);
            int[][] arrangements = new int[m][];

            for (int i = 0; i < m; i++) arrangements[i] = new int[states];
            for (int i = 0; i < states; i++) arrangements[0][i] = 1;

            for (int row = 1; row < m; row++)
            {
                for (int i = 0; i < states; i++)
                {
                    for (int j = 0; j < states; j++)
                    {
                        arrangements[row][i] += arrangements[row - 1][j] * (IsSameColor(j, i, n) ? 0 : 1);
                    }
                }
            }

            for (int i = 0; i < states; i++)
            {
                result += arrangements[m - 1][i];
            }

            return result;
        }

        static bool IsSameColor(int x, int y, int n)
        {
            int[] colorTable = new int[4];

            for (int i = 0; i < n - 1; i++)
            {
                colorTable[0] = (x & (int)Math.Pow(2, i)) == 0 ? 0 : 1;
                colorTable[1] = (x & (int)Math.Pow(2, i + 1)) == 0 ? 0 : 1;
                colorTable[2] = (y & (int)Math.Pow(2, i)) == 0 ? 0 : 1;
                colorTable[3] = (y & (int)Math.Pow(2, i + 1)) == 0 ? 0 : 1;

                if (colorTable[0] == colorTable[1] && colorTable[1] == colorTable[2] && colorTable[2] == colorTable[3])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
