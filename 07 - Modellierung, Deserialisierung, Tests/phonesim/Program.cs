using System;

class Program
{
    static void Main(string[] args)
    {
        var dicts = CsvReader.ReadCsv("/home/jaytee/Downloads/SmartPhoneData.csv");

        foreach (var dict in dicts)
        {
            var phone = PhoneDeserializer.Deserialize(dict);
        }
    }
}
