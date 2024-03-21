using System.Text;

namespace PasswordGeneratorApp;

public class PasswordGenerator
{
    private readonly string _uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private readonly string _lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
    private readonly string _numbers = "0123456789";
    private readonly string _symbols = "!@#$%^&*()_+-=[]{}|;:',.<>?";

    public string GeneratePassword(int passLength, string exludedSets = "")
    {
        StringBuilder allCharactersBuilder = new();

        if (exludedSets.Contains("1") == false)
        {
            allCharactersBuilder.Append(_uppercaseLetters);
        }
        if (exludedSets.Contains("2") == false)
        {
            allCharactersBuilder.Append(_lowercaseLetters);
        }
        if (exludedSets.Contains("3") == false)
        {
            allCharactersBuilder.Append(_numbers);
        }
        if (exludedSets.Contains("4") == false)
        {
            allCharactersBuilder.Append(_symbols);
        }

        Random r = Random.Shared;
        string allCharacters = allCharactersBuilder.ToString();
        ReadOnlySpan<char> characterSpan = allCharacters.AsSpan();
        char[] selectedChars = r.GetItems(characterSpan, passLength);

        return new string(selectedChars);
    }
}