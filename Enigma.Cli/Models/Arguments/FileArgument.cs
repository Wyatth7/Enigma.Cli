namespace Enigma.Cli.Models.Arguments;

public class FileArgument() : Argument<string>("file", minAllowed: 1, hasValue: true)
{
    public override string Parse(IQueryable<string> args)
    {
        throw new NotImplementedException();
    }
}