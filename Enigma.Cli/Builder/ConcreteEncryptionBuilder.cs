using Enigma.Cli.Builder.Arguments;

namespace Enigma.Cli.Builder;

public class ConcreteEncryptionBuilder : IParsedArgumentBuilder<ParsedEncryptionArguments>
{
    private ParsedEncryptionArgumentsBuilder _parsedEncryptionArgumentsBuilder = new();
    private readonly bool _encrypt;

    private IQueryable<string> Query { get; set; }

    public ConcreteEncryptionBuilder(string[] args, bool encrypt = true)
    {
        Reset();
        _encrypt = encrypt;
        Query = args.AsQueryable();
    }

    private void Reset()
    {
        _parsedEncryptionArgumentsBuilder = new ParsedEncryptionArgumentsBuilder();
    }
    
    public void AddFile() => _parsedEncryptionArgumentsBuilder.File = new FileArgument().Parse(Query);

    public void AddKey() => _parsedEncryptionArgumentsBuilder.Key = new KeyArgument().Parse(Query);

    public void AddOutput() => _parsedEncryptionArgumentsBuilder.Output = new OutputArgument().Parse(Query);

    public void AddRecurse() =>
        _parsedEncryptionArgumentsBuilder.Recurse = new RecursiveArgument().Parse(Query);

    public ParsedEncryptionArguments GetResult() => new (
        _parsedEncryptionArgumentsBuilder.File,
        _parsedEncryptionArgumentsBuilder.Key,
        _parsedEncryptionArgumentsBuilder.Output,
        _encrypt,
        _parsedEncryptionArgumentsBuilder.Recurse);
}