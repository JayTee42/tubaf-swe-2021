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
        if ((OS == OperatingSystem.OS_A) && (ConnectionState == ConnectionState.Online))
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
        if (OS == OperatingSystem.OS_B)
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