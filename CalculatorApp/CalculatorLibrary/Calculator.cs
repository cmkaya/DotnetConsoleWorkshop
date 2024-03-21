using System.Diagnostics;

namespace CalculatorLibrary;

public class Calculator
{
    public Calculator()
    {
        StreamWriter logFile = File.CreateText("calculator.log");
        Trace.Listeners.Add(new TextWriterTraceListener(logFile));
        Trace.AutoFlush = true;
        Trace.WriteLine("Starting Calculator Log");
        Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
    }

    public double DoOperation(double num1, double num2, string op)
    {
        double output = double.NaN;

        switch (op)
        {
            case "a":
                output = num1 + num2;
                Trace.WriteLine(string.Format("{0} + {1} = {2}",
                    num1, num2, output));
                break;
            case "s":
                output = num1 - num2;
                Trace.WriteLine(string.Format("{0} - {1} = {2}",
                    num1, num2, output));
                break;
            case "m":
                output = num1 * num2;
                Trace.WriteLine(string.Format("{0} * {1} = {2}",
                        num1, num2, output));
                break;
            case "d":
                if (num2 != 0)
                {
                    output = num1 / num2;
                    Trace.WriteLine(string.Format("{0} / {1} = {2}",
                        num1, num2, output));
                }
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        return output;
    }
}