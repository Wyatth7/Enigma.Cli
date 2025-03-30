namespace Enigma.Cli;

public static class Logger
{
    // private static bool _showSpinner = false;

    public static void Log(string message, ConsoleColor color, bool newLine = true) => Paint(message, color, newLine);
    
   public static void Error(string message, bool exit = false, int exitCode = 1)
   {
       PaintLine(message, ConsoleColor.Red);
        
        if (exit) Environment.Exit(exitCode);
   }

   public static void KeyValue(string key, string value, ConsoleColor keyColor = ConsoleColor.Cyan, ConsoleColor valueColor = ConsoleColor.Cyan, string separator = "")
   {
       Paint(key, keyColor);
       Paint(string.IsNullOrWhiteSpace(separator) ? ":" : separator, keyColor);
       Paint(value, valueColor);
       Console.WriteLine();
   }


   private static void PaintLine(string message, ConsoleColor color = ConsoleColor.Cyan) 
       => Paint(message, color, true);

    private static void Paint(string message, ConsoleColor color = ConsoleColor.Cyan, bool newLine = false)
    {
        Console.ForegroundColor = color;
        
        if (newLine)
        {
            Console.WriteLine(message);
        }
        else
        {
            Console.Write(message);
        }
        
        Console.ForegroundColor = ConsoleColor.Cyan;
    }

    // private static void ShowSpinner(string message)
   // {
   //      COME BACK TO THIS LATER... NEED TO PUT THIS ON ANOTHER THREAD
   //     _showSpinner = true;
   //
   //     char[] spinnerChars = ['|', '/', '-', '\\'];
   //     var spinnerCharIdx = 0;
   //     while (_showSpinner)
   //     {
   //          /**
   //           * 1. set spinner char based on tick
   //           * 2. paste text
   //           * 3. clear line
   //           * 4. repeat
   //           */
   //          
   //          Paint(spinnerChars[spinnerCharIdx].ToString(), ConsoleColor.Blue);
   //          Paint(" " + message);
   //          
   //          if (spinnerCharIdx == spinnerChars.Length) spinnerCharIdx = 0;
   //
   //          var currentLine = Console.CursorTop;
   //          Console.SetCursorPosition(0, currentLine);
   //     }
   // }
}