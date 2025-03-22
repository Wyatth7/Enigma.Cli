namespace Enigma.Cli;

public record ParsedArguments(string File, string Key, bool Encrypt, bool Decrypt);