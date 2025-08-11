using Enigma.Cli.Extensions;

namespace Enigma.Cli.Builder.Arguments;

public class KeyArgument() : Argument<string>("key", hasValue:true)
{
    public override string Parse(IQueryable<string> args)
    {
        var parsedValue = this.ParseValueArgument(args, true);

        if (string.IsNullOrWhiteSpace(parsedValue))
            parsedValue = RequestKeyInput();

        if (parsedValue.ValidKeyLength()) return parsedValue;
        
        Logger.Error("Invalid key provided. Key must be 16, 24, or 32 bytes.", true);

        return parsedValue;
    }

    private static string RequestKeyInput()
    {
        var consoleInfo = new ConsoleKeyInfo();
        var key = string.Empty;

        Console.Write("Encryption Key (16, 24, or 32 bytes): ");
        while (consoleInfo.Key != ConsoleKey.Enter)
        {
            var nextKey = Console.ReadKey(true);
            consoleInfo = nextKey;

            key = nextKey.Key switch
            {
                ConsoleKey.Enter => key,
                ConsoleKey.Backspace => string.IsNullOrWhiteSpace(key) ? string.Empty : key[..^1],
                _ => key + nextKey.KeyChar
            };
        }
        
        if (string.IsNullOrWhiteSpace(key))
            Logger.Error("A key is required to proceed.", true);
        
        return key;
    }
}