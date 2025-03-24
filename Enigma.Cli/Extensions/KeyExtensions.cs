using System.Text;

namespace Enigma.Cli.Extensions;

public static class KeyExtensions
{
    public static byte[] AsBytes(this string key) => Encoding.ASCII.GetBytes(key);

    public static int KeySize(this string key) => key.AsBytes().Length * 8;

    public static bool ValidKeyLength(this string key) => key.KeySize() is (128 or 192 or 256);
}