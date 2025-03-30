using Enigma.Cli.Builder;
using Enigma.Cli.Builder.Arguments;
using Enigma.Cli.Builder.Directors;

namespace Enigma.Cli;

/// <summary>
/// Director for the <see cref="ConcreteEncryptionBuilder"/>
/// </summary>
public static class CommandProcessor
{
    public static async Task Process(string[] args)
    {
        if (args.Length == 0)
            Logger.Error("No arguments were found. Use --help for a list of arguments.", true);

        var (commandType, commandArgs) = GetCommand(args);

        await ExecuteCommand(commandType, commandArgs);
    }

    /// <summary>
    /// Executes director for each command.
    /// </summary>
    /// <param name="command">Command that will be executed</param>
    /// <param name="args">List of args to be used within the command</param>
    private static async Task ExecuteCommand(CommandType command, string[] args) => await (command switch
    {
        CommandType.Encrypt or CommandType.Decrypt => new EncryptDirector().Execute(command, args),
        CommandType.Hash => throw new InvalidOperationException("Invalid command provided. The hash command is in preview and is not available at this time."),
        _ => throw new InvalidOperationException("Invalid command provided. Use --help for a list of all commands.")
    });
    
    /// <summary>
    /// Parses a command out of a list of arguments
    /// </summary>
    /// <param name="args">The list of arguments passed to the application</param>
    /// <returns>The command associated with the arguments, and the remaining arguments in the array.</returns>
    private static (CommandType, string[]) GetCommand(string[] args)
    {
        var validCommand = Enum.TryParse(args[0].ToLower(), ignoreCase:true, out CommandType command);
        
        if (!validCommand)
            Logger.Error($"{args[0]} is not a valid command. Use --help for a list of commands.", true);

        return (command, args[1..]);
    }
}