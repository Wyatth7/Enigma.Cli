namespace Enigma.Cli.Models.Arguments;

public class DecryptArgument() : Argument<bool>("decrypt")
{
    public override bool Parse(IQueryable<string> args) => args.Any(arg => arg.Equals(Selector));
    
}