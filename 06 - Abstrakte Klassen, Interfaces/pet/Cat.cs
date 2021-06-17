using System;

class Cat: Mammal
{
    private static readonly Random _biteRand = new Random();

    public Cat(string name)
        : base(name)
    { }

    public override void Attend() => Console.WriteLine($"{ Name }'s fur is being brushed.");
    public override void Move() => Console.WriteLine($"{ Name } sneaks around.");

    public override string ToString() => $"This is cat { Name }. Like all cats, it has no owner.";

    public override void Stroke()
    {
        Console.WriteLine($"{ Name } is being stroked and purrs.");

        if (_biteRand.Next(5) == 4)
        {
            Console.WriteLine($"{ Name } bites! Ouch!");
        }
    }
}
