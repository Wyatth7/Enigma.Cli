namespace Enigma.Cli.Models.Arguments;

public abstract class Argument<TValue>(
    string selector,
    int minAllowed = 0,
    int maxAllowed = 1,
    bool hasValue = false) : IArgument<TValue>
{
    public string Selector => $"--{selector}";

    public int MinAllowed { get; } = minAllowed;

    public int MaxAllowed { get; } = maxAllowed;

    public bool HasValue { get; } = hasValue;

    public abstract TValue Parse(IQueryable<string> args);
}