namespace Enigma.Cli.Builder.Arguments;

public interface IArgument<out TValue>
{
    /// <summary>
    /// Parses the value of a given argument.
    /// </summary>
    /// <param name="args">A queryable value of the arguments passed to the CLI</param>
    /// <returns>The value resulting from the argument</returns>
    TValue Parse(IQueryable<string> args);
}