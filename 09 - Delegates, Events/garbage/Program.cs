using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the trash cans and the trash master:
        Console.WriteLine("Hello Garbage!");

        var trashCans = new TrashCan[]
        {
            new TrashCan(0, 1000),
            new TrashCan(1, 800),
            new TrashCan(2, 1200),
            new TrashCan(3, 1500)
        };

        var trashMaster = new GarbageTruck();
        var rand = new Random();

        // Link the garbage truck to the cans:
        foreach (var trashCan in trashCans)
        {
            trashCan.OnTrashCanOverflow += trashMaster.HandleTrashCanOverflow;
        }

        // Generate random amounts of garbage:
        while (true)
        {
            var newGarbageVolume = 100 * rand.NextDouble();
            Console.WriteLine("Adding {0:F2}l ...", newGarbageVolume);
            trashCans[rand.Next(trashCans.Length)].UsedVolume += newGarbageVolume;

            Thread.Sleep(500);
        }
    }
}
