using Enigma.Cli.Models.Arguments;

namespace Enigma.Cli.Builder;

public class ConcreteParsedArgumentBuilder : IParsedArgumentBuilder
{
    private ParsedBuilderArguments _parsedBuilderArguments = new();
    private readonly string[] _args;

    private IQueryable<string> Query { get; set; }

    public ConcreteParsedArgumentBuilder(string[] args)
    {
        Reset();
        _args = args;
        Query = args.AsQueryable();
    }

    private void Reset()
    {
        _parsedBuilderArguments = new ParsedBuilderArguments();
    }
    
    public void AddFile() => _parsedBuilderArguments.File = new FileArgument().Parse(Query);

    public void AddKey() => _parsedBuilderArguments.Key = new KeyArgument().Parse(Query);

    public void AddEncrypt() => _parsedBuilderArguments.Encrypt = new EncryptArgument().Parse(Query);

    public void AddDecrypt() => _parsedBuilderArguments.Decrypt = new DecryptArgument().Parse(Query);

    public void AddOutput() => _parsedBuilderArguments.Output = new OutputArgument().Parse(Query);

    public ParsedArguments GetResult() => new (
        _parsedBuilderArguments.File,
        _parsedBuilderArguments.Key,
        _parsedBuilderArguments.Output,
        _parsedBuilderArguments.Encrypt,
        _parsedBuilderArguments.Decrypt
        );
}