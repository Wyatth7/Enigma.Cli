namespace Enigma.Cli.Builder;

public interface IParsedArgumentBuilder<out TType>
{
    void AddFile();
    void AddKey();
    void AddOutput(); // to be added later
    
    TType GetResult();
}