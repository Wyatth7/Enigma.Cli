using Enigma.Cli.Extensions;

namespace Enigma.Cli.Builder.Arguments;

public class FileArgument() : Argument<string>("file", minAllowed: 1, hasValue: true)
{
    public override string Parse(IQueryable<string> args)
    {
        var parsedValue = this.ParseValueArgument(args);
        
        if (!Exists(parsedValue)) Environment.Exit(1);
        
        return parsedValue;
    }

    private static bool Exists(string file)
    {
        var fullPath = file;
        
        // if file is given without a path, create path based on current dir 
        if (!FileContainsPath(file))
            fullPath = $"{Directory.GetCurrentDirectory()}\\{file}";

        var exists = File.Exists(fullPath);
        if (exists) return true;

        if (Directory.Exists(fullPath))
            return true;
        
        Logger.Error($"{file} does not exist.");
        return false;
    }

    private static bool FileContainsPath(string path) => path.Contains('\\') || path.Contains('/');
}