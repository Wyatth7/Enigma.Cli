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

await CommandProcessor.Process(args);
