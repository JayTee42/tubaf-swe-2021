using System;

class Program
{
    static double[] GenerateDiameters()
    {
        // Create a random number generator:
        var rand = new Random();

        // Array with length n: 0 to (n - 1) are valid indices!
        var count = rand.Next(2000, 5000);
        var diameters = new double[count];

        for (var i = 0; i < count; i++)
        {
            diameters[i] = (3.25 * rand.NextDouble()) + 0.75;
        }

        return diameters;
    }

    static double CalculateNutVolume(double d) => (Math.PI * d * d * d) / 6;

    static void Main(string[] args)
    {
        // Generate the random array:
        var diameters = GenerateDiameters();

        // Walk the diameters:
        var hazelnutCount = 0;
        var hazelnutVolume = 0.0;

        var walnutCount = 0;
        var walnutVolume = 0.0;

        foreach (var d in diameters)
        {
            // Calculate the nut volume:
            var volume = CalculateNutVolume(d);

            // Classify the nut by its diameter:
            if (d < 2)
            {
                hazelnutCount++;
                hazelnutVolume += volume;
            }
            else
            {
                walnutCount++;
                walnutVolume += volume;
            }
        }

        // Print the results:
        Console.WriteLine($"Cinderella has separated the { diameters.Length } nuts into { hazelnutCount } hazelnuts and { walnutCount } walnuts.");
        Console.WriteLine($"Average hazelnut volume: { hazelnutVolume / hazelnutCount } cm^3");
        Console.WriteLine($"Average walnut volume: { walnutVolume / walnutCount } cm^3");
    }
}
