namespace Enigma.Cli.Models.Arguments;

public class EncryptArgument() : Argument<bool>("encrypt")
{
    public override bool Parse(IQueryable<string> args)
    {
        throw new NotImplementedException();
    }
}