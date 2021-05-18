using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Parse input from terminal:
        double a, e, s;

        try
        {
            Console.Write("Interval start -> ");
            a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Interval end -> ");
            e = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Step size -> ");
            s = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Overflow!");
            return;
        }
        catch (FormatException)
        {
            Console.WriteLine("Bad format!");
            return;
        }

        // TODO:
        // Some sanity checks

        // Print the table:
        Console.WriteLine("     x     |     y     ");
        Console.WriteLine("-----------------------");

        // TODO
    }
}
