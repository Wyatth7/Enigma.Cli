using System.Text;

namespace Enigma.Cli;

public class HelpPrinter
{
    private StringBuilder _builder;
    
    public HelpPrinter()
    {
        _builder = new StringBuilder();
    }
    
    public string Print()
    {
        AddDescription();
        _builder.AppendLine();
        AddUsage();
        _builder.AppendLine();
        AddOptions();

        return _builder.ToString();
    }

    private void AddDescription()
    {
        _builder.AppendLine("Description:");
        _builder.AppendLine("  Encrypt or decrypt a file using AES 128, 192, or 256 bit encryption.");
    }

    private void AddUsage()
    {
        _builder.AppendLine("Usage:");
        _builder.AppendLine("  enigma <encrypt | decrypt> --file=<FilePath> --key=<AES Key>");
    }

    private void AddOptions()
    {
        _builder.AppendLine("Extra Options:");
        _builder.AppendLine("  --version, --help");
    }
}