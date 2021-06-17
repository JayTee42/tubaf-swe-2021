using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // `List` is a generic data type.
        // "Collection initializer": Initialize a collection via { ... }.
        var fishtank = new List<Fish>
        {
            new Goldfish("Hans-Joachim"),
            new Guppy("Herbert", "Jonas")
        };

        var garden = new List<Mammal>
        {
            new Cat("Frieda"),
            new Bunny("Günther", "Peter")
        };

        // Print all the pets.
        Console.WriteLine("Fishtank:");

        foreach (var fish in fishtank)
        {
            Console.WriteLine(fish);
        }

        Console.WriteLine("Garden:");

        foreach (var mammal in garden)
        {
            Console.WriteLine(mammal);
        }

        // Make the pets move resp. swim.
        foreach (var fish in fishtank)
        {
            fish.Swim();
        }

        foreach (var mammal in garden)
        {
            mammal.Move();
        }

        // Combine garden and fishtank into a zoo.
        var zoo = new List<Pet>(fishtank);
        zoo.AddRange(garden);

        // Attend the whole zoo:
        foreach (var pet in zoo)
        {
            // Attend all the zoo animals.
            // Polymorphism!
            pet.Attend();

            // Stroke those animals that are strokeable.
            var strokeablePet = pet as IStrokeable;

            if (strokeablePet != null)
            {
                strokeablePet.Stroke();
            }
            else
            {
                Console.WriteLine($"{ pet.Name } is not strokeable :(");
            }

            // Version with "is"-Operator
            /*
                if (pet is IStrokeable)
                {
                    var strokeablePet = (IStrokeable)pet;
                    strokeablePet.Stroke();
                }
            */
        }
    }
}
