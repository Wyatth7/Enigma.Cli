namespace Enigma.Cli.Builder.Arguments;

public record ParsedEncryptionArguments(string File, string Key, string Output, bool Encrypt, bool Recurse);