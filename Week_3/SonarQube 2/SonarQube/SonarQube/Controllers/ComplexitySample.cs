using System;
using System.Collections.Generic;

public class ComplexSample
{
    public string ProcessData(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
        {
            return "No data provided";
        }

        string result = string.Empty;

        foreach (var number in numbers)
        {
            if (number < 0)
            {
                return "Negative number found";
            }
            else if (number == 0)
            {
                return "Zero found";
            }
            else if (number > 0 && number <= 10)
            {
                if (number % 2 == 0)
                {
                    result += "Even number: " + number + "\n";
                }
                else
                {
                    result += "Odd number: " + number + "\n";
                }
            }
            else if (number > 10 && number <= 20)
            {
                if (number % 2 == 0)
                {
                    result += "Even number greater than 10: " + number + "\n";
                }
                else
                {
                    result += "Odd number greater than 10: " + number + "\n";
                }
            }
            else
            {
                // This else statement is unreachable if numbers are guaranteed to be between 1 and 20
                result += "Number out of range: " + number + "\n";
            }
        }

        if (string.IsNullOrEmpty(result))
        {
            return "No valid numbers processed";
        }

        return result;
    }
}

partial class Program
{
    public static void Main()
    {
        var complexSample = new ComplexSample();
        var numbers = new List<int> { 1, 2, 3, 11, 12, 13, -1, 0, 21 };

        string result = complexSample.ProcessData(numbers);
        Console.WriteLine(result);
    }
}
