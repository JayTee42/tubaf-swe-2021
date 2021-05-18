using System;
using System.Threading;

class Program
{
    static void MorseString(string s)
    {
        foreach (var c in s)
        {
            MorseChar(MorseTable.GetMorseCode(c));
        }
    }

    static void MorseChar(string symbols)
    {
        foreach (var symbol in symbols)
        {
            switch (symbol)
            {
            case '.': Flash(150); break;
            case '-': Flash(3 * 150); break;
            case ' ': Thread.Sleep(1000); break;

            default: throw new FormatException($"Unexpected morse symbol: { symbol }");
            }

            Thread.Sleep(150);
        }
    }

    static void Flash(int msecs)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Clear();

        Thread.Sleep(msecs);

        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
    }

    static void Main(string[] args)
    {
        Console.Write("[To morse] -> ");
        MorseString(Console.ReadLine());
    }
}
