namespace Enigma.Cli.Models.Arguments;

public class KeyArgument() : Argument<string>("key", minAllowed: 1, hasValue:true)
{
    public override string Parse(IQueryable<string> args)
    {
        throw new NotImplementedException();
    }
}