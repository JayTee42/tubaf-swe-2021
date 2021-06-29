using System;
using System.Collections.Generic;

class Simulator
{
    public Dictionary<string, MobilePhone> Phones { get; }
    public Test[] Tests { get; }

    public Simulator(string phonePath, string testPath)
    {
        // TODO
    }

    public void RunAllTests(string resultPath)
    {
        foreach (var test in Tests)
        {
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

            // TODO: Serialize and write to the CSV file.
        }
    }
}
