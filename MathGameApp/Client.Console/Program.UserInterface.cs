using Client.Console;

partial class Program
{
   private static void WriteLineInColor(string text, ConsoleColor color)
   {
      ConsoleColor previousColor = ForegroundColor;
      ForegroundColor = color;
      WriteLine(text);
      ForegroundColor = previousColor;
   }

   private static void DisplayMenu()
   {
      int tableWidth = 30;
      WriteLineInColor("\nPlease choose an operation:", ConsoleColor.DarkYellow);
      WriteLine(new string('-', tableWidth));
      WriteLine("|{0, -10} | {1, -15}|", "Operation", "Description");
      WriteLine("|" + new string('-', tableWidth - 2) + "|");
      WriteLine("|{0, -10} | {1, -15}|", "A", UserChoiceEnum.Addition);
      WriteLine("|{0, -10} | {1, -15}|", "S", UserChoiceEnum.Subtraction);
      WriteLine("|{0, -10} | {1, -15}|", "M", UserChoiceEnum.Multiplication);
      WriteLine("|{0, -10} | {1, -15}|", "D", UserChoiceEnum.Division);
      WriteLine("|{0, -10} | {1, -15}|", "H", UserChoiceEnum.ViewHistory);
      WriteLine("|{0, -10} | {1, -15}|", "E", UserChoiceEnum.Exit);
      WriteLine(new string('-', tableWidth));
      WriteLine("Your choice: ");
   }

   private static void DisplayGameHistory(IEnumerable<GameSession> gameHistory)
   {
      var gameSessions = gameHistory.ToList();
      if (gameSessions.Any() == false)
      {
         Info("No game history available.");
         return;
      }

      WriteLineInColor("*** Game History ***", ConsoleColor.DarkYellow);
      foreach (var game in gameSessions)
      {
         WriteLine(format: " Date: {0:D}, Operation: {1}, Result: {2}",
            arg0: game.DateOfGame.Date,
            arg1: game.UserChoice,
            arg2: game.IsCorrect);
      }
   }

   private static void GetMessageToUser(string message)
   {
      WriteLineInColor($"*** {message} ***", ConsoleColor.DarkYellow);
   }

   private static void Fail(string message)
   {
      WriteLineInColor($"Fail > {message}", ConsoleColor.Red);
   }

   private static void Info(string message)
   {
      WriteLineInColor($"Info > {message}", ConsoleColor.Cyan);
   }
}