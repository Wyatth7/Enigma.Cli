namespace Enigma.Cli.Builder;

public class ParsedEncryptionArgumentsBuilder
{
    public string File { get; set; } = string.Empty;

    public string Key { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;

    public bool Recurse { get; set; }
    
    public bool Encrypt { get; set; }
    
    public bool Decrypt { get; set; }
}