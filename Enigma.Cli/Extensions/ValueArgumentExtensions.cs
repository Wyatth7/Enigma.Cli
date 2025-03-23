namespace Enigma.Cli.Extensions;

public static class ValueArgumentExtensions
{
    public static bool TryGetArgValue(this string value, out string parsedValue)
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
}