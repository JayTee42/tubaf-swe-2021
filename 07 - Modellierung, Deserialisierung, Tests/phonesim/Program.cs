using System;

class Program
{
    static void Main(string[] args)
    {
        // Parse the commandline arguments:
        if (args.Length != 3)
        {
            Console.WriteLine("Expected three arguments:");
            Console.WriteLine(" 1.) input path to smartphone data");
            Console.WriteLine(" 2.) input path to test data ");
            Console.WriteLine(" 3.) output path to test results");

            return;
        }

        var phonePath = args[0];
        var testPath = args[1];
        var resultPath = args[2];

        // Load the simulator:
        Console.WriteLine("Loading simulator ...");
        var simulator = new Simulator(phonePath, testPath);

        Console.WriteLine($"Simulator has been loaded ({ simulator.Phones.Count } phones, { simulator.Tests.Length } tests).");

        // Run all the tests:
        Console.WriteLine("Running all the tests ...");
        simulator.RunAllTests(resultPath);
    }
}
