using Enigma.Cli.Builder.Arguments;

namespace Enigma.Cli.Cryptography;

public static class CryptographyHandler
{
    public static async Task Handle(ParsedEncryptionArguments encryptionArguments)
    {
        var type = encryptionArguments.Recurse ? typeof(RecurseCrypto) : typeof(Crypto);
        var crypto = Activator.CreateInstance(type);

        if (crypto is null)
        {
            Logger.Error("Could not create instance of crypto.", true);
            return;
        }
        
        await ExecuteAction(encryptionArguments, (ICrypto)crypto);
    }

    private static async Task ExecuteAction(ParsedEncryptionArguments encryptionArguments, ICrypto crypto)
    {
        if (encryptionArguments.Encrypt)
            await crypto.Encrypt(encryptionArguments.File, encryptionArguments.Key);
        else 
            await crypto.Decrypt(encryptionArguments.File, encryptionArguments.Key);
    }
}