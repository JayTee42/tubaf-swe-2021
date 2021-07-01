using System;
using System.Collections.Generic;
using System.Globalization;

static class DictExtensions
{
    private static string[] _nullValues = { "", "-", "null" };

    public static string QueryOptValue(this Dictionary<string, string> dict, string[] keys)
    {
        // Try to find a matching key:
        foreach (var key in keys)
        {
            if (dict.TryGetValue(key, out var value))
            {
                // Map special "not-present" values to null:
                return (Array.IndexOf(_nullValues, value.ToLower()) > -1) ? null : value;
            }
        }

        return null;
    }

    public static string QueryValue(this Dictionary<string, string> dict, string[] keys)
    {
        // Throw a verbatim exception if the value is not present:
        var value = dict.QueryOptValue(keys);

        if (value is null)
        {
            var keyString = string.Join(',', keys);
            throw new ArgumentException($"Missing required entry: None of these keys is present: \"{ keyString }\"");
        }

        return value;
    }
}

static class PhoneStateDeserializer
{
    public static PhoneState Deserialize(string str)
    {
        switch (str.ToLower())
        {
            case "on": case "an": case "normal": return PhoneState.Normal;
            case "off": case "aus": case "silent": return PhoneState.Silent;
            default: throw new ArgumentException($"Unknown phone state: \"{ str }\"");
        }
    }
}

static class ConnectionStateDeserializer
{
    public static ConnectionState Deserialize(string str)
    {
        switch (str.ToLower())
        {
            case "online": case "on": case "an": return ConnectionState.Online;
            case "offline": case "off": case "aus": return ConnectionState.Offline;
            default: throw new ArgumentException($"Unknown connection state: \"{ str }\"");
        }
    }
}

static class OperatingSystemDeserializer
{
    public static OperatingSystem Deserialize(string str)
    {
        switch (str.ToLower())
        {
            case "os_a": case "osa": return OperatingSystem.OS_A;
            case "os_b": case "osb": return OperatingSystem.OS_B;
            default: throw new ArgumentException($"Unknown OS: \"{ str }\"");
        }
    }
}

static class PhoneDeserializer
{
    private static string[] _phoneNumberKeys = { "telefonnummer", "phonenumber", "nummer", "number" };
    private static string[] _phoneStateKeys = { "telefonstatus", "phonestate", "phone_state" };
    private static string[] _connectionStateKeys = { "verbindungsstatus", "connectionstate", "connection_state" };
    private static string[] _longitudeKeys = { "longitude", "lon" };
    private static string[] _latitudeKeys = { "latitude", "lat" };
    private static string[] _osKeys = { "betriebssystem", "operatingsystem", "operating_system", "os" };
    private static string[] _typeKeys = { "telefontyp", "typ", "phone_type", "type" };

    private static Coordinates? ParsePosition(string lonStr, string latStr)
    {
        if ((lonStr != null) && (latStr != null))
        {
            // Parse the string as doubles:
            if (!double.TryParse(lonStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var lon))
            {
                throw new ArgumentException($"Invalid longitude: \"{ lonStr }\"");
            }

            if (!double.TryParse(latStr, NumberStyles.Any, CultureInfo.InvariantCulture, out var lat))
            {
                throw new ArgumentException($"Invalid latitude: \"{ latStr }\"");
            }

            return new Coordinates(lon, lat);
        }
        else if ((lonStr is null) && (latStr is null))
        {
            return null;
        }
        else
        {
            throw new ArgumentException("Need either both longitude and latitude or none of them.");
        }
    }

    private static bool IsSmartPhone(string optType, Coordinates? position)
    {
        // Do we have a "type" key?
        if (optType != null)
        {
            return optType.ToLower().Contains("smart");
        }

        // No "type" key => fall back to position:
        return position.HasValue;
    }

    public static MobilePhone Deserialize(Dictionary<string, string> dict)
    {
        // Deserialize all the properties:
        var phoneNumber = dict.QueryValue(_phoneNumberKeys);
        var phoneState = PhoneStateDeserializer.Deserialize(dict.QueryValue(_phoneStateKeys));
        var connectionState = ConnectionStateDeserializer.Deserialize(dict.QueryValue(_connectionStateKeys));
        var position = ParsePosition(dict.QueryOptValue(_longitudeKeys), dict.QueryOptValue(_latitudeKeys));
        var os = OperatingSystemDeserializer.Deserialize(dict.QueryValue(_osKeys));

        // Differentiate between smart phones and mobile phones:
        var optType = dict.QueryOptValue(_typeKeys);

        if (IsSmartPhone(optType, position))
        {
            // "Pattern matching": Bind the non-nullable value of "position" to "pos".
            if (position is Coordinates pos)
            {
                return new SmartPhone(phoneNumber, phoneState, connectionState, os, pos);
            }
            else
            {
                throw new ArgumentException("Smartphone needs an initial non-null position.");
            }
        }
        else
        {
            return new MobilePhone(phoneNumber, phoneState, connectionState, os);
        }
    }
}

static class TestTypeDeserializer
{
    public static TestType Deserialize(string str)
    {
        switch (str.ToLower())
        {
            case "call": case "anruf": case "sprachanruf": return TestType.Call;
            case "message": case "msg": case "text": case "textnachricht": return TestType.Message;
            case "alarm": return TestType.Alarm;
            case "position": case "location": return TestType.Position;

            default: throw new ArgumentException($"Unknown test type: \"{ str }\"");
        }
    }
}

static class TestDeserializer
{
    private static string[] _idKeys = { "id", "number", "nummer" };
    private static string[] _phoneNumber1Keys = { "nummer1", "telefonnummer1", "number1" };
    private static string[] _phoneNumber2Keys = { "nummer2", "telefonnummer2", "number2" };
    private static string[] _typeKeys = { "type", "typ", "test", "test_type" };
    private static string[] _textKeys = { "text", "message", "msg", "textnachricht", "nachricht" };

    public static Test Deserialize(Dictionary<string, string> dict)
    {
        // Deserialize the shared properties:
        var idStr = dict.QueryValue(_idKeys);

        if (!uint.TryParse(idStr, out var id))
        {
            throw new FormatException($"Invalid ID: \"{ idStr }\"");
        }

        var phoneNumber1 = dict.QueryValue(_phoneNumber1Keys);

        // Determine the type of the test:
        var type = TestTypeDeserializer.Deserialize(dict.QueryValue(_typeKeys));

        switch (type)
        {
            case TestType.Call:

                var callerPhoneNumber = dict.QueryValue(_phoneNumber2Keys);
                return new CallTest(id, phoneNumber1, callerPhoneNumber);

            case TestType.Message:

                var senderPhoneNumber = dict.QueryValue(_phoneNumber2Keys);
                var text = dict.QueryOptValue(_textKeys) ?? "< test >";

                return new MessageTest(id, phoneNumber1, senderPhoneNumber, text);

            case TestType.Alarm: return new AlarmTest(id, phoneNumber1);
            case TestType.Position: return new PositionTest(id, phoneNumber1);

            default: throw new ArgumentException($"Unknown test type: { type }");
        }
    }
}
