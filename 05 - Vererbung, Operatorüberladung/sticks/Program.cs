using System;

class Program
{
    static void Main(string[] args)
    {
        Number n1 = new Number(25);
        Number n2 = new Number(25);

        Console.WriteLine($"n1 = { n1 }, n2 = { n2 }");

        var res = n1.Equals(n2);
        Console.WriteLine($"Equality: { res }");

        Console.WriteLine("Hello!".GetHashCode());
    }
}
