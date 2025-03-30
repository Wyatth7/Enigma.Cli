using System.Reflection;
using Enigma.Cli;

if (args.Length == 0 || args[0] == "--version" || args[0] == "-v")
{
    Logger.KeyValue(
        "Enigma CLI",
        $"v{Assembly.GetExecutingAssembly()
            .GetName()
            .Version!
            .ToString(3)}",
        ConsoleColor.Blue,
        ConsoleColor.Yellow,
        " => ");
    return;
}

if (args[0] == "--help" || args[0] == "-h1")
{
    Logger.Log(new HelpPrinter().Print(), ConsoleColor.Cyan);
    return;
}
        
await CommandProcessor.Process(args);
