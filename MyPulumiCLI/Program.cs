using Cocona;
using Sharprompt;
using System.Diagnostics;

namespace MyPulumiCLI;

class Program
{
    static void Main(string[] args)
    {
        CoconaApp.Run<Commands>(args);
    }
}

class Commands
{
    private readonly Dictionary<string, string> _templateMap = new()
    {
        { "MyPulumiTemplate", "https://github.com/Brutiquzz/pulumiexperiment/MyPulumiTemplate" },
        { "WebAppTemplate", "https://github.com/Brutiquzz/pulumiexperiment/WebAppTemplate" }
    };

    [Command("new")]
    public void New()
    {
        Console.WriteLine("📦 Pulumi Template Launcher");

        var selectedTemplate = Prompt.Select("Select a template", _templateMap.Keys.ToList());


        var fullUrl = _templateMap[selectedTemplate];
        var args = $"new {fullUrl}";

        Console.WriteLine($"🚀 Running: pulumi {args}");

        var psi = new ProcessStartInfo
        {
            FileName = "pulumi",
            Arguments = args,
            UseShellExecute = false,
            RedirectStandardOutput = false,
            RedirectStandardError = false,
            RedirectStandardInput = false
        };

        Process.Start(psi)?.WaitForExit();
    }
}

