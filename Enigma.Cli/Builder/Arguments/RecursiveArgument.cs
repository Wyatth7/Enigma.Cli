using Enigma.Cli.Extensions;

namespace Enigma.Cli.Builder.Arguments;

public class RecursiveArgument() : Argument<bool>("recurse")
{
    public override bool Parse(IQueryable<string> args)
    { 
        Console.WriteLine(args);
        return args.Any(x => x == Selector);
    }
}