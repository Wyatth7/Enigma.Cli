using Enigma.Cli.Extensions;

namespace Enigma.Cli.Models.Arguments;

public class FileArgument() : Argument<string>("file", minAllowed: 1, hasValue: true)
{
    public override string Parse(IQueryable<string> args)
    {
        if (!this.ValidArgCount(args))
            Logger.Error($"{Selector} is required, and can only be used once.", true);

        return args.First(arg => arg.Contains(Selector)).GetArgValue();
    }
}