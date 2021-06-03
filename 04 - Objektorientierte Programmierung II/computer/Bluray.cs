using System;

class Bluray
{
    private static uint _nextSerialID = 0;

    public uint SerialID { get; }
    public string Label { get; }
    public string Content { get; }

    public Bluray(string label, string content)
    {
        SerialID = _nextSerialID++;
        Label = label;
        Content = content;
    }

    public void Print()
    {
        Console.WriteLine($"SerialID: { SerialID }\nLabel: { Label }\nContent: { Content }");
    }
}
