using System;

class TrashCan
{
    // Identifier:
    private readonly uint _id;

    // Maximum volume (liters):
    private readonly double _volume;

    // Current volume
    private double _usedVolume = 0;

    // Event for overflow:
    public event EventHandler<TransportEventArgs> OnTrashCanOverflow;

    public double UsedVolume
    {
        get => _usedVolume;

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Negative garbage volume");
            }

            _usedVolume = value;

            // Is the trash can full?
            if (_usedVolume > _volume)
            {
                Console.WriteLine("Trash can {0}: Overflow ({1:F2}l > {2:F2}l)", _id, _usedVolume, _volume);
                OnTrashCanOverflow?.Invoke(this, new TransportEventArgs(_usedVolume));
            }
            else
            {
                Console.WriteLine("Trash can {0}: New used volume: {1:F2}l", _id, UsedVolume);
            }
        }
    }

    public TrashCan(uint id, double volume)
    {
        _id = id;
        _volume = volume;
    }
}
