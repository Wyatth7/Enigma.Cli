namespace Enigma.Cli.Cryptography;

/// <summary>
/// Represents a streamed cryptography algorithm for large files / directories.
/// For smaller files, use the buffered cryptography algorithm instead of this implementation.
/// </summary>
public class StreamedCrypto : ICrypto
{
    public Task Encrypt(string file, string key)
    {
        throw new NotImplementedException();
    }

    public Task Decrypt(string file, string key)
    {
        throw new NotImplementedException();
    }
}