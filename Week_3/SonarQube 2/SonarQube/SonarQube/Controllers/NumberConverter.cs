using System;

public class NumberConverter
{
    public string IntegerToEnglishValue(int number)
    {
        if (number == 1)
        {
            return "One";
        }
        else if (number == 2)
        {
            return "Two";
        }
        else if (number == 3)
        {
            return "Three";
        }
        else if (number == 4)
        {
            return "Four";
        }
        else if (number == 5)
        {
            return "Five";
        }
        else if (number == 6)
        {
            return "Six";
        }
        else if (number == 7)
        {
            return "Seven";
        }
        else if (number == 8)
        {
            return "Eight";
        }
        else if (number == 9)
        {
            return "Nine";
        }
        else if (number == 10)
        {
            return "Ten";
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 1 and 10");
        }
    }
}
