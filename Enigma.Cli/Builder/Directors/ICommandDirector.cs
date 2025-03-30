namespace Enigma.Cli.Builder.Directors;

public interface ICommandDirector<TBuiltType>
{
    /// <summary>
    /// Creates builder object, Executes command
    /// </summary>
    /// <param name="command">Command to run</param>
    /// <param name="args">Options passed for the command</param>
    /// <returns></returns>
    Task Execute(CommandType command, string[] args);

    /// <summary>
    /// Builds the specified model
    /// </summary>
    /// <param name="builder">Builder used for building an object</param>
    /// <returns>Build type</returns>
    TBuiltType Build(IParsedArgumentBuilder<TBuiltType> builder);
}