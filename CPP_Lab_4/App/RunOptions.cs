using CommandLine;
using Labs;
using System.Collections.Frozen;

namespace App;


[Verb("run", HelpText = "Run lab.")]
internal class RunOptions : IOptions
{
    private static FrozenDictionary<string, ILab> _labs = _labs = new Dictionary<string, ILab>
    {
        ["lab1"] = Lab1.Instance,
        ["lab2"] = Lab2.Instance,
        ["lab3"] = Lab3.Instance
    }
    .ToFrozenDictionary();


    [Value(0, HelpText = "The name of the lab.", Required = true)]
    public required string LabName { get; init; }

    [Option('i', "input", HelpText = "The path to the input file.")]
    public string? InputPath { get; init; }

    [Option('o', "output", HelpText = "The path to the output file.")]
    public string? OutputPath { get; init; }


    public string Execute()
    {
        if (!_labs.TryGetValue(LabName, out var lab))
        {
            return $"Lab named '{LabName}' does not exist.";
        }

        var directoryPath = Environment.GetEnvironmentVariable("LAB_PATH");
        directoryPath ??= Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        var inputPath = InputPath ?? Path.Join(directoryPath, "INPUT.TXT");
        var outputPath = OutputPath ?? Path.Join(directoryPath, "OUTPUT.TXT");
        try
        {
            var input = File.ReadAllText(inputPath);
            var output = lab.Calculate(input);
            File.WriteAllText(outputPath, output);
        }
        catch (Exception exception)
        {
            return exception.Message;
        }
        return "Calculations complete!";
    }
}