using System;

class Program
{
    static void Main(string[] args)
    {
        // Fixed input (0):
        float fahrenheit, celsius;
        celsius = 0;
        fahrenheit = 1.8f * celsius + 32;
        Console.WriteLine($"{ celsius } Celsius entspricht { fahrenheit } Fahrenheit");

        // Dynamic input:
        Console.WriteLine("Celsius: ");
        celsius = float.Parse(Console.ReadLine()); // TODO: Exception Handling!
        fahrenheit = 1.8f * celsius + 32;
        Console.WriteLine($"Fahrenheit: { fahrenheit }");
    }
}
