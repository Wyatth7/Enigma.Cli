using Enigma.Cli.Builder.Arguments;
using Enigma.Cli.Cryptography;

namespace Enigma.Cli.Builder.Directors;

public class EncryptDirector : ICommandDirector<ParsedEncryptionArguments>
{
    public async Task Execute(CommandType command, string[] args)
    {
        var parsed = Build(new ConcreteEncryptionBuilder(args, command == CommandType.Encrypt));

        await CryptographyHandler.Handle(parsed);
        
        Logger.KeyValue(
            $"{(parsed.Encrypt ? "Encryption" : "Decryption")} Succeeded",
            parsed.File, 
            ConsoleColor.Yellow, 
            ConsoleColor.Blue,
            " => ");
    }

    public ParsedEncryptionArguments Build(IParsedArgumentBuilder<ParsedEncryptionArguments> builder)
    {
        builder.AddFile();
        builder.AddKey();
        builder.AddRecurse();

        return builder.GetResult();
    }
}