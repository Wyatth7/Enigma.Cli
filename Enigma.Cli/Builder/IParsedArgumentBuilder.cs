namespace Enigma.Cli.Builder;

public interface IParsedArgumentBuilder<out TType>
{
    void AddFile();
    void AddKey();
    void AddOutput(); // to be added later
    void AddRecurse();
    
    TType GetResult();
}