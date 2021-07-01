using System;
using System.Collections.Generic;
using System.IO;

static class CsvReader
{
    public static Dictionary<string, string>[] ReadCsv(string path)
    {
        // Read all the lines from the given file:
        var lines = File.ReadAllLines(path);

        // We need at least one line which is the header:
        if (lines.Length == 0)
        {
            throw new FormatException("Need CSV header line.");
        }

        // Retrieve the keys from the header line and normalize them:
        var keys = lines[0].Split(',');

        for (int i = 0; i < keys.Length; i++)
        {
            keys[i] = keys[i].Trim().ToLower();
        }

        // Create the array of dictionaries:
        var dicts = new Dictionary<string, string>[lines.Length - 1];

        // Fill it row by row (skipping the header):
        for (int i = 1; i < lines.Length; i++)
        {
            // Split the line and collect the trimmed values.
            // Note: This approach cannot handle commas in strings!
            var values = lines[i].Split(',');

            if (keys.Length != values.Length)
            {
                throw new FormatException($"CSV file has { keys.Length } columns, but line has { values.Length } values.");
            }

            // Create and fill a dictionary for the current line:
            var dict = new Dictionary<string, string>(keys.Length);

            for (int j = 0; j < keys.Length; j++)
            {
                dict[keys[j]] = values[j].Trim();
            }

            // Store the dictionary in our array:
            dicts[i - 1] = dict;
        }

        return dicts;
    }
}

static class CsvWriter
{

}
