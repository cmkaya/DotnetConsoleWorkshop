using Client.Console;

GameManager gameManager = new();
bool gameRunning = true;

GetMessageToUser("Welcome to Math Game Application!");

while (gameRunning)
{
   DisplayMenu();
   string userInput = ReadLine()!.Trim().ToUpper();

   UserChoiceEnum? userChoice = userInput switch
   {
      "A" => UserChoiceEnum.Addition,
      "S" => UserChoiceEnum.Subtraction,
      "M" => UserChoiceEnum.Multiplication,
      "D" => UserChoiceEnum.Division,
      "H" => UserChoiceEnum.ViewHistory,
      "E" => UserChoiceEnum.Exit,
      _ => null
   };

   if (userChoice is null)
   {
      Fail("Invalid choice. Please enter A, S, M, D, H, or E.");
      continue;
   }

   switch (userChoice)
   {
      case UserChoiceEnum.Addition:
      case UserChoiceEnum.Subtraction:
      case UserChoiceEnum.Multiplication:
      case UserChoiceEnum.Division:
         gameManager.PlayRound(userChoice);
         int score = gameManager.Score;
         Info($"Score: {score}");
         break;
      case UserChoiceEnum.ViewHistory:
         DisplayGameHistory(gameManager.GetGameHistory);
         break;
      case UserChoiceEnum.Exit:
         GetMessageToUser("Thank you for playing. Goodbye!");
         gameRunning = false;
         break;
      default:
         Fail("Invalid choice. Please enter A, S, M, D, H, or E.");
         break;
   }
}