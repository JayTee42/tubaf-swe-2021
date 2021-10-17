using System;
using System.Threading;

struct WorkParams
{
    public double[] Squares;
    public int StartIdx;
    public int StepSize;
}

class Program
{
    static void CalculateSquareNumbers(double[] squares, int startIdx, int stepSize)
    {
        for (var idx = startIdx; idx < squares.Length; idx += stepSize)
        {
            squares[idx] = (double)idx * (double)idx;
        }
    }

    static void ThreadStart(object param)
    {
        var wp = (WorkParams)param;
        CalculateSquareNumbers(wp.Squares, wp.StartIdx, wp.StepSize);
    }

    static void Main(string[] args)
    {
        var squares = new double[1000000];

        // Launch a second thread for the odd numbers:
        var wp = new WorkParams();

        wp.Squares = squares;
        wp.StartIdx = 1;
        wp.StepSize = 2;

        var t = new Thread(ThreadStart);
        t.Start(wp);

        CalculateSquareNumbers(squares, 0, 2);
        t.Join();

        // Print the result:
        for (var i = 0; i < squares.Length; i++)
        {
            Console.WriteLine($"{ i } * { i } = { squares[i] }");
        }
    }
}
