using System;
using System.Threading;

class Computer
{
    // The user that is currently logged in:
    public string User { get; private set; }

    // Constructor:
    public Computer()
    {
        User = "Administrator";
    }

    public void ChangeUser(string newUser)
    {
        Console.WriteLine("Logging out ...");
        Thread.Sleep(1000);
        Console.WriteLine($"Logging in as { newUser }");

        // Assign the new user to the property.
        User = newUser;
    }
}
