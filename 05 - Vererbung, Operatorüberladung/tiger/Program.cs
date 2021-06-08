using System;

class Program
{
    static void PrintTotalHeadFirm(Tiger tiger)
    {
        Console.WriteLine($"Total head firmness: { tiger.GetTotalHeadFirm() }");
    }

    static void Main(string[] args)
    {
        var tiger = new Tiger(42, 123.4, 66);
        var helmetTiger = new HelmetTiger(99, 140.1, 64);
        var helmet = new Helmet(50, 20);

        helmetTiger.TigerHelmet = helmet;

        PrintTotalHeadFirm(tiger);
        PrintTotalHeadFirm(helmetTiger);

        var dir = new Directory(3);
        dir.PushTiger(tiger);
        dir.PushTiger(helmetTiger);

        for (uint i = 0; i < 3; i++)
        {
            Console.WriteLine($"Tiger[{ i }]: { dir[i] }");
        }
    }
}
