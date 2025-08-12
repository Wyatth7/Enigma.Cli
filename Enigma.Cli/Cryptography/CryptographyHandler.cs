using Enigma.Cli.Builder.Arguments;

namespace Enigma.Cli.Cryptography;

public static class CryptographyHandler
{
    private static readonly Crypto Crypto = new();
    
    public static async Task Handle(ParsedEncryptionArguments encryptionArguments)
    {
        if (encryptionArguments.Recurse)
        {
            await RecurseCrypto(encryptionArguments);
            return;
        }

        await ExecuteAction(encryptionArguments);
    }

    private static async Task RecurseCrypto(ParsedEncryptionArguments encryptionArguments)
    {
        if (File.Exists(encryptionArguments.File))
        {
            await ExecuteAction(encryptionArguments);
            return;
        }

        await RunOnDirectory(encryptionArguments);
    }

    private static async Task RunOnDirectory(ParsedEncryptionArguments encryptionArguments)
    {
        var files = Directory.GetFiles(encryptionArguments.File);
        foreach (var file in files)
            await ExecuteAction(encryptionArguments with { File = file });
        
        var directories = Directory.GetDirectories(encryptionArguments.File);
        foreach (var directory in directories)
            await RunOnDirectory(encryptionArguments with { File = directory });
    }

    private static async Task ExecuteAction(ParsedEncryptionArguments encryptionArguments)
    {
        if (encryptionArguments.Encrypt)
            await Crypto.Encrypt(encryptionArguments.File, encryptionArguments.Key);
        else 
            await Crypto.Decrypt(encryptionArguments.File, encryptionArguments.Key);
    }
}