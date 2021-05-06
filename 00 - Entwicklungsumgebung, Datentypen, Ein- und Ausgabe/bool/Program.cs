using System;
using System.Globalization;

/*
    Überprüfen Sie in einem Programm

        ob der eingegebene Wert für x im Bereich x1...x2 liegt,
        ob der durch x und y definierte Punkt in einem Rechteck mit den Eckpunkten x1, y1 und x2, y2 liegt,
        ob zwei Punkte die gleichen Koordinaten haben,
        ob mindestens eine der Bedingungen x1<=x<=x2 bzw. y1<=y<=y2 zutrifft.

    Lesen Sie die Werte x1, y1, x2, y2, x und y ein.
    Formulieren Sie die logischen Ausdrücke, die auf die Variable vom Typ bool zugewiesen werden,
    geben Sie den Wert der Variable aus.
*/

class Program
{
    static void Main(string[] args)
    {
        double x, y;

        try
        {
            // Parse x and y from the terminal.
            Console.Write("x -> ");
            x = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("y -> ");
            y = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        }
        catch
        {
            Console.WriteLine("Bad input!");
            return;
        }

        // Constants for now ...
        var x1 = 0.1;
        var x2 = 2.0;
        var y1 = -1.1;
        var y2 = 2.7;

        // "[...] ob der eingegebene Wert für x im Bereich x1...x2 liegt [...]"
        var xInRange = (x1 <= x) && (x <= x2);

        if (xInRange)
        {
            Console.WriteLine($"{ x } is located between { x1 } and { x2 }.");
        }
        else
        {
            Console.WriteLine("x is not in the specified range.");
        }

        // "[...] ob der durch x und y definierte Punkt in einem Rechteck mit den Eckpunkten x1, y1 und x2, y2 liegt, [...]"
        var yInRange = (y1 <= y) && (y <= y2);
        var isInRect = xInRange && yInRange;

        if (isInRect)
        {
            Console.WriteLine($"({ x }, { y }) is located in the given rectangle.");
        }
        else
        {
            Console.WriteLine($"({ x }, { y }) is not located in the given rectangle.");
        }

        // "[...] ob zwei Punkte die gleichen Koordinaten haben, [...]"
        // TODO: Compare with "==" ...

        // "[...] ob mindestens eine der Bedingungen x1<=x<=x2 bzw. y1<=y<=y2 zutrifft. [...]"
        var isInAtLeastOneRange = xInRange || yInRange;
        Console.WriteLine($"x in x range or y in y range: { isInAtLeastOneRange }");
    }
}
