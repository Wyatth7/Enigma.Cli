using Enigma.Cli.Extensions;

namespace Enigma.Cli.Builder.Arguments;

public class KeyArgument() : Argument<string>("key", minAllowed: 1, hasValue:true)
{
    public override string Parse(IQueryable<string> args)
    {
        var parsedValue = this.ParseValueArgument(args);
        
        if (parsedValue.Length is not (16 or 24 or 32))
            Logger.Error("Invalid key provided. Key must be 16, 24, or 32 bytes.", true);
        
        return parsedValue;
    }
}