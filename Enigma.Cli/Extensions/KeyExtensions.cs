using System.Security.Cryptography;
using System.Text;

namespace Enigma.Cli.Extensions;

public static class KeyExtensions
{
    public static byte[] AsBytes(this string key) => Encoding.ASCII.GetBytes(key);

    public static int KeySize(this string key) => key.AsBytes().Length * 8;

    public static bool ValidKeyLength(this string key) => key.KeySize() is (128 or 192 or 256);

    public static bool TryGetKeySize(this string key, out int keySize)
    {
        if (!key.ValidKeyLength())
        {
            keySize = 0;
            return false;
        }

        keySize = key.KeySize();

        // This should never be an issue, but we should check that the reference object has 
        // not been modified after the key size was validated.
        return keySize is not (128 or 192 or 256) 
            ? throw new ArgumentException("The key size was invalid after successfully validating the key.") 
            : true;
    }
}