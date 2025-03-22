namespace Enigma.Cli.Models.Builder;

public interface IParsedArgumentBuilder
{
    void AddFile();
    void AddKey();
    void AddEncrypt();
    void AddDecrypt();
    void AddOutput(); // to be added later
}