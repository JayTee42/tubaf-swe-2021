using System;

class Guppy: Fish
{
    public Guppy(string name, string owner)
        : base(name, owner)
    { }

    public Guppy(string name)
        : base(name)
    { }

    public override void Swim() => Console.WriteLine($"{ Name } menacingly swims back and forth.");
}
