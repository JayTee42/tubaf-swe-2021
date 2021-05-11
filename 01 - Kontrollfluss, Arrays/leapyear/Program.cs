using System;

class Program
{
    static void Main(string[] args)
    {
        // TODO: Enter the year via Console.
        uint year = 1993;
        
        // Determine if we have a leap year.
        bool isLeapYear = (year % 4 == 0) && (year % 100 != 0) 
            || (year % 400 == 0);

        Console.WriteLine($"Is { year } a leap year? { isLeapYear }");
    }
}
