namespace lab6_executors.core
{
    public abstract class Executor
    {
        protected string InputPath { get; set; }
        protected string OutputPath { get; set; }

        public Executor(string inputPath, string outputPath)
        {
            UpdateInputPath(inputPath);
            UpdateOutputPath(outputPath);
        }

        public void UpdateInputPath(string inputPath)
        {
            InputPath = inputPath;
        }

        public void UpdateOutputPath(string outputPath)
        {
            OutputPath = outputPath;
        }

        public abstract void OnExecute();
    }
}
