using System;

class Goldfish: Fish, IStrokeable
{
    public Goldfish(string name, string owner)
        : base(name, owner)
    { }

    public Goldfish(string name)
        : base(name)
    { }

    public override void Swim() => Console.WriteLine($"{ Name } swims in happy little circles.");

    public void Stroke()
    {
        Console.WriteLine($"{ Name } is being stroked. Slimy!");

        if (Owner is null)
        {
            Console.WriteLine($"{ Name } swims away.");
        }
    }
}
