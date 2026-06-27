using System.Security.Cryptography;
using Enigma.Cli.Extensions;

namespace Enigma.Cli.Cryptography;

/// <summary>
/// Represents a buffered cryptography algorithm for small-sized files / files.
/// This should only be used for small files, as it is not optimized for large files. 
/// Large files should instead use the stream-based cryptography algorithm, which handles
/// large file sizes more efficiently with less memory usage.
/// </summary>
public class BufferedCrypto : ICrypto
{
    public async Task Encrypt(string file, string key)
    {
        var fileContents = await FileToBase64(file);
        await using var fileStream =
            new FileStream(file, FileMode.OpenOrCreate);

        using var aes = Aes.Create();
        var iv = aes.Configure(key);
        
        await fileStream.WriteAsync(iv, 0, iv.Length);

        await using var crypto = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        await using var streamWriter = new StreamWriter(crypto);

        await streamWriter.WriteAsync(fileContents);
    }

    public async Task Decrypt(string file, string key)
    {
        var value = string.Empty;

        try
        {
            using (var fileStream =
                   new FileStream(file, FileMode.Open))
            {
                using var aes = Aes.Create();
                var iv = aes.Configure(key);

                var bytesToRead = iv.Length;
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