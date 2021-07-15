using System;

class TransportEventArgs: EventArgs
{
    public double GarbageVolume { get; }

    public TransportEventArgs(double garbageVolume) => GarbageVolume = garbageVolume;
}
