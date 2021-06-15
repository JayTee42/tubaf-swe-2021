using System;

// abstract: Class cannot be instantiated.
abstract class Pet
{
    public string Name { get; set; }
    public string Owner { get; }

    public Pet(string name, string owner)
    {
        Name = name;
        Owner = owner;
    }

    public Pet(string name) => Name = name;

    // abstract: Method has no implementation.
    // => Only purpose: Override it in subclasses!
    // => implicitly virtual
    public abstract void Attend();
}
