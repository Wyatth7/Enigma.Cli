namespace Enigma.Cli.Structs;

public readonly record struct Selector
{
    public Selector(string value, string shortcut = "")
    {
        Value = value;
        Shortcut = string.IsNullOrWhiteSpace(shortcut) ? $"-{value[0]}" : shortcut;
        #if DEBUG

        Shortcut = Shortcut.ToUpper();
        
        #endif
    }

    private readonly string _value = string.Empty;
    public string Value
    {
        get => _value;
        private init => _value = $"--{value}";
    }
    
    private readonly string _shortcut = string.Empty;
    public string Shortcut
    {
        get => _shortcut;
        private init => _shortcut = value;
    }

    public static bool operator ==(string left, Selector right)
    {
        return left == right.Value || left == right.Shortcut;
    }

    public static bool operator !=(string left, Selector right)
    {
        return left != right.Value || left != right.Shortcut;
    }
}