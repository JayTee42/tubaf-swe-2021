using System;
using System.Globalization;

/*
    Parameter für das Energiewesen:

    Bezeichnung (Zeichenkette)
    Registriernummer (eine 5-stellige ganze Zahl),
    Kategorie (Buchstabe A, B oder C),
    Leuchtkraft (reelle Zahl mit 2 Nachkommastellen)
*/

class Program
{
    static void Main(string[] args)
    {
        // C# ist statisch / stark typisiert!
        // Typ-Inferenz mit "var"
        Console.Write("Description -> ");
        var description = Console.ReadLine();

        uint regNum;
        char category;
        double luminosity;

        try
        {
            Console.Write("Registry number -> ");
            regNum = uint.Parse(Console.ReadLine());

            Console.Write("Category -> ");
            category = char.Parse(Console.ReadLine());

            Console.Write("Luminosity -> ");
            luminosity = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            Console.WriteLine("Bad input format (e.g. letters in numbers ...)!");
            return;
        }
        catch (OverflowException)
        {
            Console.WriteLine("Input contains a numeric overflow.");
            return;
        }

        // String-Interpolation mit $"... {} ...":
        Console.WriteLine($"Name: { description }");
        Console.WriteLine($"Registriernummer: { regNum }");
        Console.WriteLine($"Kategorie: { category }");

        var formattedLuminosity = luminosity.ToString("f2", CultureInfo.InvariantCulture);
        Console.WriteLine($"Leuchtkraft: { formattedLuminosity }");
    }
}
