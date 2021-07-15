using System;

class GarbageTruck
{
    public double GarbageVolume { get; private set; } = 0;

    public void HandleTrashCanOverflow(object sender, TransportEventArgs e)
    {
        // Perform the downcast back to the overflowing trash can:
        var trashCan = (TrashCan)sender;

        // Transfer the given garbage amount from the trash can into the truck:
        trashCan.UsedVolume -= e.GarbageVolume;
        GarbageVolume += e.GarbageVolume;

        Console.WriteLine("Total garbage volume in truck is now {0:F2}l.", GarbageVolume);
    }
}
