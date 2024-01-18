using lab6_executors.core;
using System;
using System.IO;
using System.Linq;

namespace lab6_executors.lab1
{
    public class Lab1Executor: Executor
    {

        public Lab1Executor(string inputPath, string outputPath) : base(inputPath, outputPath) { }

        public override void OnExecute()
        {
            double totalTime = 0;
            double timeA = 0;
            double timeB = 0;

            int n;
            (int i, double ai, double bi)[] sheets;

            using (StreamReader reader = new StreamReader(InputPath))
            {
                n = Int32.Parse(reader.ReadLine());
                sheets = new (int, double, double)[n];

                for (int i = 0; i < n; i++)
                {
                    string[] input = reader.ReadLine().Split();
                    double ai = double.Parse(input[0]);
                    double bi = double.Parse(input[1]);
                    sheets[i] = (i + 1, ai, bi);
                }
            }

            int[] sheetsOrdered = sheets.OrderByDescending(it => it.ai / it.bi).Select(it => it.i).ToArray();

            int indexA = 0;
            int indexB = n - 1;
            int resultIndexA = 0;
            int resultIndexB = n - 1;
            int[] resultSequence = new int[n];


            while (true)
            {
                var sheetA = sheets.First(it => it.i == sheetsOrdered[indexA]);
                var sheetB = sheets.First(it => it.i == sheetsOrdered[indexB]);

                if (sheetA.i == sheetB.i)
                {
                    var remainingTimeA = timeA + sheetA.ai;
                    var remainingTimeB = timeB + sheetB.bi;

                    if (timeA > timeB)
                    {
                        remainingTimeB -= timeB;
                        remainingTimeA = sheetA.ai;
                    }
                    else
                    {
                        remainingTimeA -= timeB;
                        remainingTimeB = sheetB.bi;
                    }

                    totalTime += gcd(remainingTimeA, remainingTimeB);
                    resultSequence[resultIndexA++] = sheetA.i;
                    break;
                }
                else if (totalTime + sheetA.ai > totalTime + sheetB.bi)
                {
                    totalTime += sheetB.bi;
                    timeB += sheetB.bi;
                    resultSequence[resultIndexB--] = sheetB.i;
                    indexB--;
                }
                else if (totalTime + sheetA.ai < totalTime + sheetB.bi)
                {
                    totalTime += sheetA.ai;
                    timeA += sheetA.ai;
                    resultSequence[resultIndexA++] = sheetA.i;
                    indexA++;
                }
            }

            using (StreamWriter writer = new StreamWriter(OutputPath))
            {
                writer.WriteLine(totalTime.ToString("0.000"));
                writer.WriteLine(string.Join(" ", resultSequence));
            }
        }

        static float gcd(double a, double b)
        {
            if (a < b)
                return gcd(b, a);

            if (Math.Abs(b) < 0.001)
                return (float)a;
            else
                return (float)(gcd(b, a - Math.Floor(a / b) * b));
        }
    }
}
