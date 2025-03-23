using System.Text;
using Enigma.Cli.Extensions;

namespace Enigma.Cli.Models.Arguments;

public class KeyArgument() : Argument<string>("key", minAllowed: 1, hasValue:true)
{
    public override string Parse(IQueryable<string> args)
    {
        var parsedValue = this.ParseValueArgument(args);
        
        if (Encoding.ASCII.GetBytes(parsedValue).Length != 16)
            Logger.Error("Invalid key provided. Key must be 16 bytes.", true);
        
        return parsedValue;
    }
}