using System.Text.RegularExpressions;
using CalculatorLibrary;

bool endApp = false;

Title("Console Calculator in C#");

while (endApp == false)
{
    Calculator calculator = new();
    string? numInput1 = string.Empty;
    string? numInput2 = string.Empty;
    double result = 0;

    Info("Type a number, and then press Enter:");
    numInput1 = ReadLine();
    double cleanNum1 = ValidateInput(numInput1);

    Info("Type another number, and then press Enter:");
    numInput2 = ReadLine();
    double cleanNum2 = ValidateInput(numInput2);

    // Ask the user to choose an operator.
    WriteLine("Choose an option from the following list:");
    WriteLine("\ta - Add");
    WriteLine("\ts - Subtract");
    WriteLine("\tm - Multiply");
    WriteLine("\td - Divide");
    Write("Your opinion? ");

    string? op = ReadLine();

    // Validate input is not null, and matches the pattern.
    if (op is null || (Regex.IsMatch(op, "[a|s|m|d]") == false))
    {
        Fail("Error: Unrecognized input.");
    }
    else
    {
        try
        {
            result = calculator.DoOperation(cleanNum1, cleanNum2, op);
            if (double.IsNaN(result))
            {
                Fail("This operation will result in a mathematical error.\n");
            }
            else
            {
                WriteLine("Your result: {0:0.##}\n", result);
            }
        }
        catch (Exception ex)
        {
            Fail("Oh no! An exception occurred trying to do the math.\n - Details: "
                + ex.Message);
        }
    }

    // Wait for the user to respond before closing.
    Info("Press 'n' and then Enter to close the app, or press any other key and then Enter to continue: ");
    if (ReadLine() == "n")
    {
        endApp = true;
    }
}

double ValidateInput(string? numInput)
{
    double output = 0;
    while (double.TryParse(numInput, out output) == false)
    {
        Fail("This is not valid input. Please enter a numeric value: ");
        numInput = ReadLine();
    }

    return output;
}