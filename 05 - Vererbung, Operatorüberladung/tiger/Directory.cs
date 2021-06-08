using System;

class Directory
{
    // Internal storage for the tigers:
    private Tiger[] _tigers;

    // How many tigers are stored?
    private uint _tigerCount = 0;

    // Get the nth tiger:
    public Tiger this[uint idx]
    {
        get => _tigers[idx];
    }

    // Get the whole directory as array (bad idea?):
    // public Tiger[] Tigers { get => _tigers; }

    // Constructor with maximum capacity:
    public Directory(uint maxTigers) => _tigers = new Tiger[maxTigers];

    // Push a new tiger to the end of the directory:
    public void PushTiger(Tiger newTiger)
    {
        if (_tigerCount >= _tigers.Length)
        {
            throw new ArgumentOutOfRangeException("Tiger directory is full!");
        }

        _tigers[_tigerCount++] = newTiger;
    }

    // Find the first tiger with the given registry number:
    public Tiger FindTiger(uint regNum)
    {
        // TODO ...

        return null;
    }
}
