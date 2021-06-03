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

        // Test the `SaveFile()` method in an endless loop:
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

        // Test the IP addresses:
        Console.WriteLine($"Initial Ipv4 address: { comp.IPAddress }");
        comp.IPAddress = "192.168.0.1";
        Console.WriteLine($"New Ipv4 address: { comp.IPAddress }");

        comp.IPAddress = "ffee:ddcc:bbaa:9988:7766:5544:3322:1100";
        Console.WriteLine($"New Ipv6 address: { comp.IPAddress }");

        // Test the Blurays:
        comp.BurnBluray("Absatz von Smartphones", "173.5, 304.7, 494.5, 725.3, 1019.4, 1301.7, 1437.6, 1469, 1465.5, 1402.6, 1372.6, 1280", out var b0);
        comp.BurnBluray("Impfbereitschaft", "7, 6, 11, 75", out var b1);

        b0.Print();
        b1.Print();
    }
}
