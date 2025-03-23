using Enigma.Cli;

var arguments = new ArgumentParser().Parse(args);
Logger.Log(arguments.ToString(), ConsoleColor.Blue);
