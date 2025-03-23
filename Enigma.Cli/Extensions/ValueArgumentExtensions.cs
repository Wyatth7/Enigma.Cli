using Enigma.Cli.Builder.Arguments;

namespace Enigma.Cli.Extensions;

public static class ValueArgumentExtensions
{
    private static bool TryGetArgValue(this string value, out string parsedValue)
    {
        parsedValue = string.Empty;
        if (!value.Contains('='))
        {
            Logger.Error("Argument does not contain a value or is invalid.");
            return false;
        }

        if (value.Where(v => v.Equals('=')).ToArray().Length <= 1)
        {
            parsedValue = value.Split("=")[1];
            return true;
        }
        
        Logger.Error("Arguments cannot contain multiple = operators.");
        return false;
    }
    
    public static string ParseValueArgument<TArgumentType>(this Argument<TArgumentType> arg, IQueryable<string> args)
    {
        if (!arg.ValidArgCount(args))
            Logger.Error(InvalidArgumentCountMessage(arg, args.Count(a => a.Contains(arg.Selector))), true);
        
        var validValue = args
            .First(a => a.Contains(arg.Selector))
            .TryGetArgValue(out var parsedValue);

        if (!validValue) Environment.Exit(1);

        return parsedValue;
    }

    private static string InvalidArgumentCountMessage<TArgumentType>(Argument<TArgumentType> arg, int occurrences)
    {
        var messagePart = $"Invalid use of {arg.Selector}. ";
        
        if (arg.MinAllowed == arg.MaxAllowed && occurrences != arg.MinAllowed)
            return $"{messagePart}{arg.Selector} must be used {arg.MinAllowed} times.";

        return $"{messagePart}{arg.Selector} must be used {arg.MinAllowed} to {arg.MaxAllowed} times";
    }
}