using CommandLine;

namespace App;


[Verb("set-path", HelpText = "Sets the environment variable 'LAB_PATH'.")]
internal class SetPathOptions : IOptions
{
    [Option('p', "path", HelpText = "The path to the directory with the input/output files.", Required = true)]
    public required string DirectoryPath { get; init; }


    public string Execute()
    {
        Environment.SetEnvironmentVariable("LAB_PATH", DirectoryPath, EnvironmentVariableTarget.User);
        return "Success!";
    }
}