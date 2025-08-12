namespace Enigma.Cli.Cryptography;

public interface ICrypto
{
    Task Encrypt(string file, string key);
    Task Decrypt(string file, string key);
}