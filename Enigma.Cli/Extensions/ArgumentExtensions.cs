using Enigma.Cli.Builder.Arguments;

namespace Enigma.Cli.Extensions;

public static class ArgumentExtensions
{
    public static bool ValidArgCount<TArgumentValue>(this Argument<TArgumentValue> arg, IQueryable<string> args)
    {
        var argsFound = args
            .Where(v => v.Contains(arg.Selector))
            .ToArray()
            .Length;

        return argsFound >= arg.MinAllowed && argsFound <= arg.MaxAllowed;
    }
}