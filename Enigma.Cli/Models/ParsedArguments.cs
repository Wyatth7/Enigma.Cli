namespace Enigma.Cli.Models;

public class ParsedArguments
{
    public string File { get; set; } = string.Empty;

    public string Key { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;
    
    public bool Encrypt { get; set; }
    
    public bool Decrypt { get; set; }
}