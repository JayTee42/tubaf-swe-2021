using System;

class Bunny: Mammal
{
    public Bunny(string name, string owner)
        : base(name, owner)
    { }

    public Bunny(string name)
        : base(name)
    { }

    public override void Attend() => Console.WriteLine($"{ Name }'s cage is being cleaned.");
    public override void Move() => Console.WriteLine($"{ Name } scuttles around.");
}
