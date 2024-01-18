using lab6_executors.core;
using lab6_executors.lab1;
using lab6_executors.lab2;
using lab6_executors.lab3;

namespace lab6_api.Data
{
    public class LabExecutorDataSource
    {
        private static readonly string INPUT = "input.txt";
        private static readonly string OUTPUT = "output.txt";

        private void WriteToInput(string input)
        {
            using (StreamWriter writer = new StreamWriter(INPUT))
            {
                writer.Write(input);
            }
        }

        private string ReadFromOutput()
        {
            var result = "";
            using (StreamReader reader = new StreamReader(OUTPUT))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        private string ExecuteLab(Executor executor, string input)
        {
            try
            {
                WriteToInput(input);
                executor.OnExecute();
                var output = ReadFromOutput();
                return output;
            } catch (Exception e)
            {
                return e.Message;
            }
        }


        public string ExecuteLab1(string input)
        {
            return ExecuteLab(new Lab1Executor(INPUT, OUTPUT), input);
        }

        public string ExecuteLab2(string input)
        {
            return ExecuteLab(new Lab2Executor(INPUT, OUTPUT), input);
        }

        public string ExecuteLab3(string input)
        {
            return ExecuteLab(new Lab3Executor(INPUT, OUTPUT), input);
        }
    }
}
