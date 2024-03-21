namespace PasswordGeneratorApp;

public class PasswordValidator
{
    public static int GetPasswordLength()
    {
        int output = 0;
        Write("Choose a password length between 3 to 12: ");

        while (true)
        {
            string outputText = ReadLine()!;

            if (int.TryParse(outputText, out output) == false)
            {
                Write("Invalid input! Choose a password between 3 to 12: ");
                continue;
            }
            else if (output < 3 || output > 12)
            {
                Write("Invalid input! Choose a password between 3 to 12: ");
                continue;
            }

            return output;
        }
    }

    public static string ExcludeCharacters()
    {
        string excludedCharacters = string.Empty;
        WriteLine("(1) for upper case letters.");
        WriteLine("(2) for lower case letters.");
        WriteLine("(3) for numbers.");
        WriteLine("(4) for symbols");

        while (true)
        {
            excludedCharacters = ReadLine()!;

            switch (excludedCharacters)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                    return excludedCharacters;
                default:
                    WriteLine("Invalid input. Select an option between 1 to 4.");
                    break;
            }
        }
    }
}