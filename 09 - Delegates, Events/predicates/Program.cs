using System;
using System.Collections.Generic;

enum Gender
{
    Male,
    Female,
    Diverse
}

class Student
{
    public uint ID { get; set; }
    public string Name { get; set; }
    public uint Age { get; set; }
    public Gender Gender { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Student other)
        {
            return ID == other.ID;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode() => ID.GetHashCode();

    public Student(uint id, string name, uint age, Gender gender)
    {
        ID = id;
        Name = name;
        Age = age;
        Gender = gender;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var students = new List<Student>()
        {
            new Student(12345, "Lisa", 23, Gender.Female),
            new Student(36363, "Paul", 31, Gender.Diverse),
            new Student(54499, "Jonas", 29, Gender.Male),
            new Student(98765, "Fritz", 27, Gender.Male),
        };

        if (students.Find(s => (s.Gender == Gender.Male) && (s.Age < 28)) is Student s)
        {
            Console.WriteLine($"Found student: { s.Name }");
        }
        else
        {
            Console.WriteLine("Student not found!");
        }
    }
}
