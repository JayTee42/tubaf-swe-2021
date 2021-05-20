using System;

class Smartphone
{
    // `?` means: Generate a nullable uint (can store numbers + null).
    private uint? _pin = null;
    private uint _tries = 0;
    private bool _isLocked = false;

    // How many tries do we allow before locking permanently?
    private const uint MaxTries = 3;

    private bool Authenticate()
    {
        if (_isLocked)
        {
            Console.WriteLine("Authentication failed (locked)");
            return false;
        }

        if (_pin is null)
        {
            Console.WriteLine("Authentication successful (no PIN)");
            return true;
        }

        do
        {
            // TODO: Read a PIN from the console and compare it.
            // If equal: Reset tries, return true.
        } while (_tries < MaxTries);

        // TODO: Lock the smartphone, return false.
    }

    public void Call()
    {
        // TODO
    }
}
