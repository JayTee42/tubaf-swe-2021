using System;
using System.Collections.Generic;

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

        if (value == null)
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

    private static Coordinates? ParsePosition(string lonStr, string latStr)
    {
        if ((lonStr != null) && (latStr != null))
        {
            // Parse the string as doubles:
            if (!double.TryParse(lonStr, out var lon))
            {
                throw new ArgumentException($"Invalid longitude: \"{ lonStr }\"");
            }

            if (!double.TryParse(latStr, out var lat))
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

    public static MobilePhone Deserialize(Dictionary<string, string> dict)
    {
        // Deserialize all the properties:
        var phoneNumber = dict.QueryValue(_phoneNumberKeys);
        var phoneState = PhoneStateDeserializer.Deserialize(dict.QueryValue(_phoneStateKeys));
        var connectionState = ConnectionStateDeserializer.Deserialize(dict.QueryValue(_connectionStateKeys));
        var position = ParsePosition(dict.QueryOptValue(_longitudeKeys), dict.QueryOptValue(_latitudeKeys));
        var os = OperatingSystemDeserializer.Deserialize(dict.QueryValue(_osKeys));

        // TODO: Differentiate between smart phones and mobile phones.
        return null;
    }
}
