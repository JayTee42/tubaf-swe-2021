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

        // Some sanity checks:
        if (e < a)
        {
            Console.WriteLine("Start of interval must be <= its end.");
            return;
        }

        if (s <= 0)
        {
            Console.WriteLine("Step size must be above 0.");
            return;
        }

        // Print the table:
        Console.WriteLine("     x     |     y     ");
        Console.WriteLine("-----------------------");

        var x = a;

        // "Kopfgesteuerte Schleife"
        while (x <= e)
        {
            // Print x:
            Console.Write("{0,12:f7} | ", x);

            // Calculate the denominator:
            var denom = (x + 2) * (x - 1) * (x - 1);

            if (Math.Abs(denom) <= 1e-10)
            {
                Console.WriteLine("singul.");
            }
            else
            {
                // Calculate and print y:
                var y = ((3 * x) - 6) / denom;
                Console.WriteLine("{0:f7}", y);
            }

            // Increase x by the step size:
            x += s;
        }
    }
}
