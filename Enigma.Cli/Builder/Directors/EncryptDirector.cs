using Enigma.Cli.Builder.Arguments;

namespace Enigma.Cli.Builder.Directors;

public class EncryptDirector : ICommandDirector<ParsedEncryptionArguments>
{
    public async Task Execute(CommandType command, string[] args)
    {
        var parsed = Build(new ConcreteEncryptionBuilder(args, command == CommandType.Encrypt));

        if (parsed.Encrypt)
            await Crypto.Encrypt(parsed.File, parsed.Key);
        else 
            await Crypto.Decrypt(parsed.File, parsed.Key);
        
        Logger.KeyValue(
            $"{(parsed.Encrypt ? "Encryption" : "Decryption")} Succeeded",
            parsed.File, 
            ConsoleColor.Yellow, 
            ConsoleColor.Blue);
    }

    public ParsedEncryptionArguments Build(IParsedArgumentBuilder<ParsedEncryptionArguments> builder)
    {
        builder.AddFile();
        builder.AddKey();

        return builder.GetResult();
    }
}