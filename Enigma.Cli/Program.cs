using Enigma.Cli;

var arguments = new ArgumentParser().Parse(args);

if (arguments.Encrypt)
{
    await Crypto.Encrypt(arguments.File, arguments.Key);
}
else
{
    await Crypto.Decrypt(arguments.File, arguments.Key);
}

Logger.KeyValue(
    $"{(arguments.Encrypt ? "Encryption" : "Decryption")} Succeeded",
    arguments.File, 
    ConsoleColor.Yellow, 
    ConsoleColor.Blue);