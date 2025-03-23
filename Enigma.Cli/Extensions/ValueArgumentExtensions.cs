namespace Enigma.Cli.Extensions;

public static class ValueArgumentExtensions
{
    public static string GetArgValue(this string value)
    {
        if (!value.Contains('='))
            Logger.Error("Argument does not contain a value or is invalid.");

        if (value.Where(v => v.Equals('=')).ToArray().Length > 1)
            Logger.Error("Arguments cannot contain multiple = operators.");
        
        return value.Split("=")[1];
    }
}