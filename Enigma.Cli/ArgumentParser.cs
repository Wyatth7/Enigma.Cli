using System.Collections.Immutable;
using Enigma.Cli.Models;
using Enigma.Cli.Models.Arguments;
using Enigma.Cli.Models.Builder;

namespace Enigma.Cli;

/// <summary>
/// Director for the <see cref="ConcreteParsedArgumentBuilder"/>
/// </summary>
public class ArgumentParser
{
    public ParsedArguments Parse(string[] args)
    {
        var parsedArgs = GetArguments(args);
        
        if (!parsedArgs.IsValid())
            Environment.Exit(0);

        return parsedArgs;
    }

    private ParsedArguments GetArguments(string[] args)
    {
        var builder = new ConcreteParsedArgumentBuilder(args);
        
        builder.AddFile();
        // builder.AddKey();
        builder.AddEncrypt();
        builder.AddDecrypt();

        return builder.GetResult();
    }
}