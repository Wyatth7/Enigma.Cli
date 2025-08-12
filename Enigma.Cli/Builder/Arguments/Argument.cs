using Enigma.Cli.Structs;

namespace Enigma.Cli.Builder.Arguments;

public abstract class Argument<TValue>(
    string selector,
    int minAllowed = 0,
    int maxAllowed = 1,
    bool hasValue = false,
    string shortcut = "") : IArgument<TValue>
{
    public Selector Selector { get; } = new(selector, shortcut);

    public int MinAllowed { get; } = minAllowed;

    public int MaxAllowed { get; } = maxAllowed;

    public bool HasValue { get; } = hasValue;

    public abstract TValue Parse(IQueryable<string> args);
}