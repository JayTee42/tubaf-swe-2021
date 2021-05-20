using System;

class Alien
{
    // Properties (methods with field-like access syntax):
    public string Description { get; set; } = "";
    public uint RegID { get; set; } = 42;
    public Category Cat { get; } = Category.None;
    public double Power { get; set; } = 0;

    // Constructor: Special method
    public Alien() { }

    public Alien(string description, uint regID, Category category, double power)
    {
        Description = description;
        RegID = regID;
        Cat = category;
        Power = power;
    }

    public void Print()
    {
        Console.WriteLine($"Description: \"{ Description }\", " +
            $"regID: { RegID }, category: { Cat }, power: { Power }");
    }
}

enum Category
{
    Thermo,
    Electro,
    None
}
