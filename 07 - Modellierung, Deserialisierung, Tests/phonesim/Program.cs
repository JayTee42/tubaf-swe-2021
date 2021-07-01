using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the simulator:
        Console.WriteLine("Loading simulator ...");
        var simulator = new Simulator("/home/jaytee/Downloads/SmartPhoneData.csv", "/home/jaytee/Downloads/ServiceTests.csv");

        Console.WriteLine($"Simulator has been loaded ({ simulator.Phones.Count } phones, { simulator.Tests.Length } tests).");

        // Run all the tests:
        Console.WriteLine("Running all the tests ...");
        simulator.RunAllTests("/home/jaytee/Downloads/TestResults.csv");
    }
}
