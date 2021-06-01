using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the `ChangeUser()` method:
        var comp = new Computer();
        Console.WriteLine("Test: {0}", comp.User);

        Console.WriteLine($"User: { comp.User }");
        comp.ChangeUser("jonas");
        Console.WriteLine($"User: { comp.User }");

        // Test the `SaveFile()` method in a permanent loop:
        while (true)
        {
            try
            {
                comp.SaveFile("test.txt");
            }
            catch (InvalidOperationException)
            {
                comp.Reboot();
            }
        }
    }
}
