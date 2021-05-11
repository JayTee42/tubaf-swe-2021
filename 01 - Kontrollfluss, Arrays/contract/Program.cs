using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Parameters of the contract
        var freeMinutes = 100.0;
        var pricePerMinute = 0.099;
        var fixedPrice = 3.99;

        // Read the number of minutes and the volume selection.
        double minutes;
        char volumeSelection;

        try
        {
            Console.Write("Please enter your minutes -> ");
            minutes = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Please book your mobile data (S, M, or L) -> ");
            volumeSelection = char.ToUpper(char.Parse(Console.ReadLine()));
        }
        catch (FormatException)
        {
            Console.WriteLine("Bad format!");
            return;
        }
        catch (OverflowException)
        {
            Console.WriteLine("Overflow!");
            return;
        }

        // Validate the minutes.
        if (minutes < 0.0)
        {
            Console.WriteLine("Please enter a non-negative number of minutes.");
            return;
        }

        // Select the price for the data volume.
        double volumePrice;

        switch (volumeSelection)
        {
        case 'S': volumePrice = 6.0; break;
        case 'M': volumePrice = 11.0; break;
        case 'L': volumePrice = 20.0; break;
        default: Console.WriteLine("Invalid volume selection (only S, M, or L)!"); return;
        }

        // Calculate the number of paid minutes.
        var paidMinutes = Math.Max(Math.Ceiling(minutes) - freeMinutes, 0.0);

        // Calculate the total fees.
        var fees = fixedPrice + (paidMinutes * pricePerMinute) + volumePrice;
        Console.WriteLine($"Fees for { minutes } mins and volume selection { volumeSelection }: { fees.ToString("f2") } EUR");
    }
}
