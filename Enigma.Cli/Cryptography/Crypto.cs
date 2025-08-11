using System.Security.Cryptography;
using Enigma.Cli.Extensions;

namespace Enigma.Cli.Cryptography;

public static class Crypto
{
    public static async Task Encrypt(string file, string key)
    {
        var fileContents = await FileToBase64(file);
        await using var fileStream =
            new FileStream(file, FileMode.OpenOrCreate);

        using var aes = Aes.Create();

        aes.KeySize = KeySize(key);
        aes.Key = key.AsBytes();
        var iv = aes.IV;

        await fileStream.WriteAsync(iv, 0, iv.Length);

        await using var crypto = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        await using var streamWriter = new StreamWriter(crypto);

        await streamWriter.WriteAsync(fileContents);
    }

    public static async Task Decrypt(string file, string key)
    {
        var value = string.Empty;

        try
        {
            using (var fileStream =
                   new FileStream(file, FileMode.Open))
            {
                using var aes = Aes.Create();

                aes.KeySize = KeySize(key);
                var iv = new byte[aes.IV.Length];

                var bytesToRead = aes.IV.Length;
                var bytesRead = 0;

                while (bytesToRead > 0)
                {
                    var n = await fileStream.ReadAsync(iv, bytesRead, bytesToRead);
                    if (n == 0) break;

                    bytesRead += n;
                    bytesToRead -= n;
                }

                await using var crypto =
                    new CryptoStream(fileStream, aes.CreateDecryptor(key.AsBytes(), iv), CryptoStreamMode.Read);
                using var streamReader = new StreamReader(crypto);
                
               value = await streamReader.ReadToEndAsync();
            }
        }
        catch (Exception)
        {
            Logger.Error($"Failed to decrypt {file}: invalid key or file", true);
        }
        await WriteToFile(value, file);
    }

    private static int KeySize(string key) =>
        key.ValidKeyLength() ? key.KeySize() : throw new CryptographicException("Invalid key length.");
    
    private static async Task WriteToFile(string value, string file)
    {
        try
        {
            var fileBytes = Convert.FromBase64String(value);
            await File.WriteAllBytesAsync(file, fileBytes);
        }
        catch (Exception)
        {
            Logger.Error("Failed to write value to file", true);
        }
    }
    
    private static async Task<string> FileToBase64(string path)
    {
        var fileContents = await File.ReadAllBytesAsync(path);
        return Convert.ToBase64String(fileContents);
    }
}