using System;

enum PhoneState
{
    Normal,
    Silent
}

enum ConnectionState
{
    Online,
    Offline
}

enum OperatingSystem
{
    OS_A,
    OS_B
}

static class OperatingSystemExtensions
{
    public static bool SupportsMessages(this OperatingSystem os)
    {
        switch (os)
        {
            case OperatingSystem.OS_A: return true;
            default: return false;
        }
    }

    public static bool SupportsAlarm(this OperatingSystem os)
    {
        switch (os)
        {
            case OperatingSystem.OS_B: return true;
            default: return false;
        }
    }
}

struct Coordinates
{
    public double Longitude;
    public double Latitude;

    public Coordinates(double lon, double lat)
    {
        Longitude = lon;
        Latitude = lat;
    }
}

class MobilePhone
{
    public string PhoneNumber { get; private set; }
    public PhoneState PhoneState { get; private set; }
    public ConnectionState ConnectionState { get; private set; }

    public virtual Coordinates? Position
    {
        get
        {
            Console.WriteLine("Position query not supported.");
            return null;
        }
    }

    public OperatingSystem OS { get; private set; }

    public MobilePhone(string phoneNumber, PhoneState phoneState, ConnectionState connectionState, OperatingSystem os)
    {
        PhoneNumber = phoneNumber;
        PhoneState = phoneState;
        ConnectionState = connectionState;
        OS = os;
    }

    public bool ReceiveACall(string incomingNumber)
    {
        if ((PhoneState == PhoneState.Normal) && (ConnectionState == ConnectionState.Online))
        {
            Console.WriteLine($"Accepting call from { incomingNumber }.");
            return true;
        }
        else
        {
            Console.WriteLine($"Rejecting call from { incomingNumber }.");
            return false;
        }
    }

    public bool ReceiveAMessage(string incomingNumber, string text)
    {
        if (OS.SupportsMessages() && (ConnectionState == ConnectionState.Online))
        {
            Console.WriteLine($"Accepting message from { incomingNumber }: \"{ text }\"");
            return true;
        }
        else
        {
            Console.WriteLine($"Rejecting message from { incomingNumber }.");
            return false;
        }
    }

    public bool RingAlarm()
    {
        if (OS.SupportsAlarm())
        {
            Console.WriteLine("Triggering alarm.");
            return true;
        }
        else
        {
            Console.WriteLine("Rejecting alarm.");
            return false;
        }
    }
}

class SmartPhone : MobilePhone
{
    private Coordinates _position;

    public override Coordinates? Position
    {
        get
        {
            Console.WriteLine("Accepting position query.");
            return _position;
        }
    }

    public SmartPhone(string phoneNumber, PhoneState phoneState, ConnectionState connectionState, OperatingSystem os, Coordinates position)
        : base(phoneNumber, phoneState, connectionState, os)
    {
        _position = position;
    }

    public void SetPosition(Coordinates position) => _position = position;
}
