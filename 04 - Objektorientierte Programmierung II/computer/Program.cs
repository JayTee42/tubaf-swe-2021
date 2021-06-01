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
/*
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
*/

        Console.WriteLine($"Initial Ipv4 address: { comp.IPAddress }");
        comp.IPAddress = "192.168.0.1";
        Console.WriteLine($"New Ipv4 address: { comp.IPAddress }");

        comp.IPAddress = "ffee:ddcc:bbaa:9988:7766:5544:3322:1100";
        Console.WriteLine($"New Ipv6 address: { comp.IPAddress }");
    }
}
