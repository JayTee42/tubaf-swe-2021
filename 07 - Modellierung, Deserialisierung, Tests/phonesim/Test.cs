using System;

abstract class Test
{
    public uint Id { get; }
    public string PhoneNumber { get; }

    public Test(uint id, string phoneNumber)
    {
        Id = id;
        PhoneNumber = phoneNumber;
    }

    public abstract bool Run(MobilePhone phone);
}

class CallTest : Test
{
    public string CallerPhoneNumber { get; }

    public CallTest(uint id, string phoneNumber, string callerPhoneNumber)
        : base(id, phoneNumber)
    {
        CallerPhoneNumber = callerPhoneNumber;
    }

    public override bool Run(MobilePhone phone)
    {
        var result = phone.ReceiveACall(CallerPhoneNumber);
        var expectedResult = (phone.PhoneState != PhoneState.Silent) && (phone.ConnectionState == ConnectionState.Online);

        return result == expectedResult;
    }
}

class MessageTest : Test
{
    public string SenderPhoneNumber { get; }
    public string Text { get; }

    public MessageTest(uint id, string phoneNumber, string senderPhoneNumber, string text)
        : base(id, phoneNumber)
    {
        SenderPhoneNumber = senderPhoneNumber;
        Text = text;
    }

    public override bool Run(MobilePhone phone)
    {
        var result = phone.ReceiveAMessage(SenderPhoneNumber, Text);
        var expectedResult = (phone.OS == OperatingSystem.OS_A) && (phone.ConnectionState == ConnectionState.Online);

        return result == expectedResult;
    }
}

class AlarmTest : Test
{
    public AlarmTest(uint id, string phoneNumber)
        : base(id, phoneNumber)
    { }

    public override bool Run(MobilePhone phone) => phone.RingAlarm() == phone.OS.SupportsAlarm();
}

class PositionTest : Test
{
    public PositionTest(uint id, string phoneNumber)
        : base(id, phoneNumber)
    { }

    public override bool Run(MobilePhone phone)
    {
        // This test allows a smartphone to return null
        // to indicate missing GPS signal.
        if ((phone.Position != null) && !(phone is SmartPhone))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

enum TestResultType
{
    Success,
    Failure,
    PrecoditionFailure
}

struct TestResult
{
    public uint Id;
    public TestResultType Result;

    public TestResult(uint id, TestResultType result)
    {
        Id = id;
        Result = result;
    }
}

enum TestType
{
    Call,
    Message,
    Alarm,
    Position
}
