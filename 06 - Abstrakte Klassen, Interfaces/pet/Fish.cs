using System;

abstract class Fish: Pet
{
    public Fish(string name, string owner)
        : base(name, owner)
    { }

    public Fish(string name)
        : base(name)
    { }

    public override void Attend() => Console.WriteLine($"{ Name }'s water is being swapped out.");

    public abstract void Swim();
}
