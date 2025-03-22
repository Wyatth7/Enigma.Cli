using Enigma.Cli.Models.Arguments;

namespace Enigma.Cli.Models.Builder;

public class ConcreteParsedArgumentBuilder : IParsedArgumentBuilder
{
    private ParsedArguments _parsedArguments = new();
    private string[] _args = [];

    private IQueryable<string> Query => _args.AsQueryable();

    public ConcreteParsedArgumentBuilder(string[] args)
    {
        Reset();
        _args = args;
    }

    private void Reset()
    {
        _parsedArguments = new ParsedArguments();
    }
    
    public void AddFile() => _parsedArguments.File = new FileArgument().Parse(Query);

    public void AddKey() => _parsedArguments.Key = new KeyArgument().Parse(Query);

    public void AddEncrypt() => _parsedArguments.Encrypt = new EncryptArgument().Parse(Query);

    public void AddDecrypt() => _parsedArguments.Decrypt = new DecryptArgument().Parse(Query);

    public void AddOutput() => _parsedArguments.Output = new OutputArgument().Parse(Query);
}