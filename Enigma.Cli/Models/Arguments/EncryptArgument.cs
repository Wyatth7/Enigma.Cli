namespace Enigma.Cli.Models.Arguments;

public class EncryptArgument() : Argument<bool>("encrypt")
{
    public override bool Parse(IQueryable<string> args) => args.Any(arg => arg.Equals(Selector));
    
}