using System;

abstract class Mammal: Pet, IStrokeable
{
    public Mammal(string name, string owner)
        : base(name, owner)
    { }

    public Mammal(string name)
        : base(name)
    { }

    public abstract void Move();

    public virtual void Stroke() => Console.WriteLine($"{ Name } is being stroked :)");
}
