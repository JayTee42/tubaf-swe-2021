using System;

abstract class Mammal: Pet
{
    public Mammal(string name, string owner)
        : base(name, owner)
    { }

    public Mammal(string name)
        : base(name)
    { }

    public abstract void Move();
}
