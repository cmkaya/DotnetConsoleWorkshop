using PasswordGeneratorApp;

PasswordGenerator generator = new();
string generatedPassword = string.Empty;
int passLengthInput = PasswordValidator.GetPasswordLength();

Write("Do you want to exclue certain character set (y/n)? ");
string answerInput = ReadLine()!;

if (answerInput.Equals("y", StringComparison.CurrentCultureIgnoreCase))
{
    string characterSet = PasswordValidator.ExcludeCharacters();
    generatedPassword = generator.GeneratePassword(passLengthInput, characterSet);
}
else
{
    generatedPassword = generator.GeneratePassword(passLengthInput);
}

WriteLine($"Password: {generatedPassword}");