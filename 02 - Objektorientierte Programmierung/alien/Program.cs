using System;

class Program
{
    static void Main(string[] args)
    {
        var alien1 = new Alien();
        var alien2 = new Alien("My special description", 42, Category.Electro, 66.6);

        alien1.Print();
        alien2.Print();
    }
}
