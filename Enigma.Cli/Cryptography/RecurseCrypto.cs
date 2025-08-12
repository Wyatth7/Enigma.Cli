namespace Enigma.Cli.Cryptography;

public class RecurseCrypto : ICrypto
{
    public async Task Encrypt(string file, string key)
    {
        Console.WriteLine($"Testing recurse encryp");
    }

    public async Task Decrypt(string file, string key)
    {
        Console.WriteLine("testing recurse decrypt");
    }
}