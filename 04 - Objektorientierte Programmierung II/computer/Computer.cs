using System;
using System.Threading;
using System.IO;

class Computer
{
    // The user that is currently logged in:
    public string User { get; private set; }

    // Is the computer in a crashed state?
    public bool IsCrashed { get; private set; }

    // A generator for random numbers (testing for crashes):
    private static Random _rand = new Random();

    // Constructor:
    public Computer()
    {
        User = "Administrator";
        IsCrashed = false;
    }

    public void ChangeUser(string newUser)
    {
        Console.WriteLine("Logging out ...");
        Thread.Sleep(1000);
        Console.WriteLine($"Logging in as { newUser }");

        // Assign the new user to the property.
        User = newUser;
    }

    public void SaveFile(string path, string name)
    {
        // Test if the computer is crashed.
        // In that case, we cannot save files.
        if (IsCrashed)
        {
            throw new InvalidOperationException("Files cannot be saved if the computer is crashed.");
        }

        // Combine the parts to a full path:
        var fullPath = Path.Combine(path, name);
        Console.WriteLine($"Saving file: { fullPath }");

        // Test (via random numbers ...) if the computer crashes.
        if (_rand.Next(0, 4) == 3)
        {
            IsCrashed = true;
            Console.WriteLine("Computer has crashed while saving the file!");

            throw new InvalidOperationException("Crash!");
        }
    }

    // Overloading ("Überladung"):
    public void SaveFile(string name)
    {
        SaveFile("Desktop", name);
    }

    public void Reboot()
    {
        Console.WriteLine("Rebooting ...");
        Thread.Sleep(3000);
        Console.WriteLine("Reboot successful!");

        IsCrashed = false;
    }
}
