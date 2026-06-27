using System.Security.Cryptography;

namespace Enigma.Cli.Extensions;

public static class AesExtensions
{
    /// <summary>
    /// Configures the specified <see cref="Aes"/> instance with the provided key.
    /// </summary>
    /// <param name="aes">
    /// The <see cref="Aes"/> instance to configure.
    /// </param>
    /// <param name="key">
    /// The key used to configure the AES instance. The key must have a valid length
    /// (128, 192, or 256 bits).
    /// </param>
    /// <returns>
    /// The initialization vector (IV) used by the configured <see cref="Aes"/> instance.
    /// </returns>
    /// <exception cref="CryptographicException">
    /// Thrown when the provided key has an invalid size or cannot be used to configure the AES instance.
    /// </exception>
    public static byte[] Configure(this Aes aes, string key)
    {
        var validKeySize = key.TryGetKeySize(out var keySize);
        if (!validKeySize)
        {
            throw new CryptographicException("Invalid key size.");
        }
                
        aes.KeySize = keySize;        
        aes.Key = key.AsBytes();
        return aes.IV;
    }
}