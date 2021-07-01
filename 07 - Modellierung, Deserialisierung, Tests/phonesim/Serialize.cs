using System;
using System.Collections.Generic;

static class TestResultTypeSerializer
{
    public static string Serialize(TestResultType resultType)
    {
        switch (resultType)
        {
            case TestResultType.Success: return "erfolgreich";
            case TestResultType.Failure: return "fehlgeschlagen";
            case TestResultType.PrecoditionFailure: return "Vorbedingungen nicht erfüllt";

            default: throw new ArgumentException($"Unknown test result type: \"{ resultType }\"");
        }
    }
}

static class TestResultSerializer
{
    private static readonly string _idKey = "Nummer";
    private static readonly string _resultKey = "Ergebnis";

    public static readonly string[] Keys = { _idKey, _resultKey };

    public static Dictionary<string, string> Serialize(TestResult result)
    {
        return new Dictionary<string, string>
        {
            { _idKey, result.Id.ToString() },
            { _resultKey, TestResultTypeSerializer.Serialize(result.Result) }
        };
    }
}
