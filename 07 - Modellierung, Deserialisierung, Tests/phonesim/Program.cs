using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the simulator:
        Console.WriteLine("Loading simulator ...");
        var simulator = new Simulator("/home/jaytee/Downloads/SmartPhoneData.csv", "/home/jaytee/Downloads/ServiceTests.csv");
    }
}
