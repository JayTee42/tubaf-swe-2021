using System;

class Number
{
    // Actual number representation
    private uint _val;

    // Symbol representation
    private static readonly char NumChar = '|';

    // Public access via symbolic string
    public string NumberSticks
    {
        get => new String(NumChar, (int)_val);

        set
        {
            // Validation:
            foreach (var c in value)
            {
                if (c != NumChar)
                {
                    throw new FormatException("Invalid character!");
                }
            }

            _val = (uint)value.Length;
        }
    }

    // Constructors:
    public Number(uint val) => _val = val;
    public Number(string numberSticks) => NumberSticks = numberSticks;

    // Method overrides from System.Object:
    public override string ToString() => NumberSticks;

    public override bool Equals(object obj)
    {
        var other = obj as Number;
        return (other == null) ? false : (this == other);
    }

    // 1.) Gleiche Objekte => gleicher Hashcode
    // 2.) Ungleiche Objekte => möglichst ungleicher Hashcode
    public override int GetHashCode() => (int)_val;

    // Operator overloading:
    public static Number operator +(Number lhs, Number rhs) => new Number(lhs._val + rhs._val);
    public static Number operator -(Number lhs, Number rhs) => new Number((lhs < rhs) ? 0 : lhs._val - rhs._val);
    public static Number operator *(Number lhs, Number rhs) => new Number(lhs._val * rhs._val);
    public static Number operator /(Number lhs, Number rhs) => new Number(lhs._val / rhs._val);

    public static bool operator ==(Number lhs, Number rhs) => lhs?._val == rhs?._val;
    public static bool operator !=(Number lhs, Number rhs) => !(lhs == rhs);
    public static bool operator <(Number lhs, Number rhs) => lhs._val < rhs._val;
    public static bool operator >(Number lhs, Number rhs) => lhs._val > rhs._val;
}
