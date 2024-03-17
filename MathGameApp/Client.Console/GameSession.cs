namespace Client.Console;

public record class GameSession(
   DateTime DateOfGame,
   int Number1, 
   int Number2, 
   UserChoiceEnum? UserChoice, 
   bool IsCorrect);