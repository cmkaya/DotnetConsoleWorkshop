partial class Program
{
    private static void WriteLineInColor(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = color;
        WriteLine(text);
        ForegroundColor = previousColor;
    }

    private static void Title(string title)
    {
        WriteLineInColor($"*** {title} ***\n", ConsoleColor.DarkYellow);
    }

    private static void Fail(string message)
    {
        WriteLineInColor($"Fail > {message}", ConsoleColor.Red);
    }

    private static void Info(string message)
    {
        WriteLineInColor($"{message}", ConsoleColor.Cyan);
    }
}