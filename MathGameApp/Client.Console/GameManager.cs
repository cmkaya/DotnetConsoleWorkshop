namespace Client.Console;

public class GameManager
{
   private Random _random = new();
   private List<GameSession> _gameHistory = new();
   public int Score { get; set; } = 0;

   public void PlayRound(UserChoiceEnum? userChoice)
   {
      var numbers = GenerateRandomNumbers(userChoice == UserChoiceEnum.Division);

      int result = PerformOperation(userChoice, numbers.Item1, numbers.Item2);
      int userAnswer = GetUserAnswer(userChoice, numbers.Item1, numbers.Item2);

      if (result == userAnswer)
      {
         Score++;
      }
      else
      {
         Score--;
      }

      _gameHistory.Add(new GameSession(
         DateTime.Now, numbers.Item1, numbers.Item2,
         userChoice, result == userAnswer));
   }

   private int PerformOperation(UserChoiceEnum? userChoice, int num1, int num2)
   {
      return userChoice switch
      {
         UserChoiceEnum.Addition => Operation.Add(num1, num2),
         UserChoiceEnum.Subtraction => Operation.Subtract(num1, num2),
         UserChoiceEnum.Multiplication => Operation.Multiply(num1, num2),
         UserChoiceEnum.Division => Operation.Divide(num1, num2),
         _ => throw new InvalidOperationException("Invalid operation type")
      };
   }

   private int GetUserAnswer(UserChoiceEnum? userChoice, int num1, int num2)
   {
      while (true)
      {
         WriteLine($"{num1} {GetOperationSymbol(userChoice)} {num2} = ?");
         if (int.TryParse(ReadLine(), out int answer))
         {
            return answer;
         }
         else
         {
            WriteLine("Invalid input. Please enter a valid number.");
         }
      }
   }

   private (int, int) GenerateRandomNumbers(bool isDivision)
   {
      int num1, num2;
      if (isDivision == false)
      {
         num1 = _random.Next(0, 100);
         num2 = _random.Next(0, 100);
      }
      else
      {
         num2 = _random.Next(1, 10);
         int quotient = _random.Next(1, 11);
         num1 = num2 * quotient; // Ensure the dividend is a multiple of the divisor 
      }

      return (num1, num2);
   }

   private string GetOperationSymbol(UserChoiceEnum? userChoice)
   {
      return userChoice switch
      {
         UserChoiceEnum.Addition => "+",
         UserChoiceEnum.Subtraction => "-",
         UserChoiceEnum.Multiplication => "*",
         UserChoiceEnum.Division => "/",
         _ => throw new InvalidOperationException("Invalid operation type"),
      };
   }

   public IReadOnlyList<GameSession> GetGameHistory => _gameHistory.AsReadOnly();
}