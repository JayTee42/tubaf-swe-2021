using System;

/*
    Zahlensysteme:

        1.) Dezimalsystem (Basis 10)
        2.) Binärsystem (Basis 2)
        3.) Hexadezimalsystem (Basis 16)

    1111_1111 = 128 + 64 + 32 + 16 + 8 + 4 + 2 + 1 = 255
    F_F

    0001_0001
    1_1

    0000_1111
    0_F

    A: 10
    B: 11
    C: 12
    D: 13
    E: 14
    F: 15

    AND:

        0 1
    --------
    0 | 0 0 
    1 | 0 1

    OR:

        0 1
    --------
    0 | 0 1 
    1 | 1 1

    XOR:

        0 1
    --------
    0 | 0 1 
    1 | 1 0
*/

class Program
{
    static void Main(string[] args)
    {
        int x = 0b0001_0001, y = 0b1000_1000, z = 0b1111;

        Console.WriteLine("x = 0x{0:x8}", x);
        Console.WriteLine("y = 0x{0:x8}", y);
        Console.WriteLine("z = 0x{0:x8}", z);

        /*
            1.)

                  00010001
                & 10001000
                ----------
                  00000000
                & 00001111
                ----------
                  00000000
        */

        var b1 = x & y & z;
        Console.WriteLine("b1 = 0x{0:x8}", b1);

        /*
            2.)

                  00010001
                | 10001000
                ----------
                  10011001
                & 00001111
                ----------
                  00001001
        */

        var b2 = (x | y) & z;
        Console.WriteLine("b2 = 0x{0:x8}", b2);

        /*
            3.)

                  00010001
                ^ 10001000
                ----------
                ~ 10011001
                ----------
                 11111111 11111111 11111111 01100110 
        */

        var b3 = ~(x ^ y);
        Console.WriteLine("b3 = 0x{0:x8}", b3);

        /*
            4.)

                  11111111 11111111 11111111 01100110
                & 00000000 00000000 00000000 11111111
                ----------
                  
        */

        var b4 = ~(x ^ y) & byte.MaxValue;
        Console.WriteLine("b4 = 0x{0:x8}", b4);
    }
}
