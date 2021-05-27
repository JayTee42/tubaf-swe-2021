using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the `ChangeUser()` method:
        var comp = new Computer();

        Console.WriteLine($"User: { comp.User }");
        comp.ChangeUser("jonas");
        Console.WriteLine($"User: { comp.User }");

        // Test the `SaveFile()` method:
        comp.SaveFile("test.txt");
    }
}
