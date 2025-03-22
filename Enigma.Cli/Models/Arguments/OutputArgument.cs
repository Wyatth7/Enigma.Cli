namespace Enigma.Cli.Models.Arguments;

public class OutputArgument() : Argument<string>("output")
{
    public override string Parse(IQueryable<string> args)
    {
        throw new NotImplementedException();
    }
}