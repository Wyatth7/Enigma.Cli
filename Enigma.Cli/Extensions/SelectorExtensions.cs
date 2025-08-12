using Enigma.Cli.Structs;

namespace Enigma.Cli.Extensions;

public static class SelectorExtensions
{
    public static bool ContainsSelector(this string[] args, Selector selector) 
        => args.Any(arg => arg == selector);

    public static bool ContainsSelector(this string value, Selector selector)
        => value.Contains(selector.Value) || value.Contains(selector.Shortcut);
}