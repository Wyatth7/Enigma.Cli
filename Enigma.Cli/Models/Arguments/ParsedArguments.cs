namespace Enigma.Cli.Models.Arguments;

public record ParsedArguments(string File, string Key, string Output, bool Encrypt, bool Decrypt)
{
    public bool IsValid()
    {
        switch (Encrypt)
        {
            case false when !Decrypt:
                Logger.Error("Either --encrypt or --decrypt must be set.");
                return false;
            case true when Decrypt:
                Logger.Error("Both --encrypt and --decrypt cannot be set in the same command.");
                return false;
        }

        return true;
    }
}