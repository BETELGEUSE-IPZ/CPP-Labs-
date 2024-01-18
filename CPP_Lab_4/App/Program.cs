using App;
using CommandLine;
using CommandLine.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var parserResult = new Parser().ParseArguments<RunOptions, SetPathOptions>(args);
        Console.WriteLine(parserResult switch
        {
            { Value: IOptions options } => options.Execute(),

            { Errors: var errors } when errors.IsVersion() => $"""
            Author: Okulov Illya Volodymyrovych
            Version: {typeof(Program).Assembly.GetName().Version}
            """,

            _ => HelpText.AutoBuild(parserResult)
        });
    }
}