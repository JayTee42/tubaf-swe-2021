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
        var description = "Günther";
        var regNum = 12345u;
        var category = 'a';
        var luminosity = 34346.336;

        // String-Interpolation mit $"... {} ...":
        Console.WriteLine($"Name: { description }");
        Console.WriteLine($"Registriernummer: { regNum }");
        Console.WriteLine($"Kategorie: { category }");

        var formattedLuminosity = luminosity.ToString("f2", CultureInfo.InvariantCulture);
        Console.WriteLine($"Leuchtkraft: { formattedLuminosity }");
    }
}
