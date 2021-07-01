using System;
using System.Collections.Generic;

class Simulator
{
    public Dictionary<string, MobilePhone> Phones { get; }
    public Test[] Tests { get; }

    public Simulator(string phonePath, string testPath)
    {
        // Read and deserialize the phones:
        var phoneDicts = CsvReader.ReadCsv(phonePath);
        Phones = new Dictionary<string, MobilePhone>(phoneDicts.Length);

        foreach (var dict in phoneDicts)
        {
            var phone = PhoneDeserializer.Deserialize(dict);
            Phones[phone.PhoneNumber] = phone;
        }

        // Read and deserialize the tests:
        var testDicts = CsvReader.ReadCsv(testPath);
        Tests = new Test[testDicts.Length];

        for (int i = 0; i < testDicts.Length; i++)
        {
            Tests[i] = TestDeserializer.Deserialize(testDicts[i]);
        }
    }

    public void RunAllTests(string resultPath)
    {
        var results = new Dictionary<string, string>[Tests.Length];

        for (int i = 0; i < Tests.Length; i++)
        {
            var test = Tests[i];

            // Execute the test if the preconditions are met:
            TestResultType resultType;

            if (Phones.TryGetValue(test.PhoneNumber, out var phone))
            {
                resultType = test.Run(phone) ? TestResultType.Success : TestResultType.Failure;
            }
            else
            {
                resultType = TestResultType.PrecoditionFailure;
            }

            // Construct the test result:
            var result = new TestResult(test.Id, resultType);

            // Serialize it:
            results[i] = TestResultSerializer.Serialize(result);
        }

        // Write all the serialized test results into a CSV file:
        CsvWriter.WriteCsv(resultPath, TestResultSerializer.Keys, results);
    }
}
