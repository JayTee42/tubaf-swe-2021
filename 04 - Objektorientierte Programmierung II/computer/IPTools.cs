using System;
using System.Globalization;

static class IPTools
{
    public static readonly byte[] LocalHost = new byte[] { 127, 0, 0, 1 };

    public static string IPAddressToString(byte[] address)
    {
        // Decide if we have a v4 (four bytes) or a v6 (six bytes) address:
        if (address.Length == 4)
        {
            return IPv4AddressToString(address);
        }
        else if (address.Length == 16)
        {
            return IPv6AddressToString(address);
        }
        else
        {
            throw new ArgumentException("Invalid IP address (only 4 or 6 bytes allowed)!");
        }
    }

    public static byte[] StringToIPAddress(string value)
    {
        // Decide if we have a v4 (contains '.') or a v6 (contains ':') address:
        if (value.Contains('.'))
        {
            return StringToIPv4Address(value);
        }
        else if (value.Contains(':'))
        {
            return StringToIPv6Address(value);
        }
        else
        {
            throw new ArgumentException("Invalid IP address string!");
        }
    }

    private static string IPv4AddressToString(byte[] address)
    {
        // Simply use a format string:
        return $"{ address[0] }.{ address[1] }.{ address[2] }.{ address[3] }";
    }

    private static byte[] StringToIPv4Address(string value)
    {
        // Split at all occurrences of '.':
        var comps = value.Split('.');
        var result = new byte[4];

        if (comps.Length != 4)
        {
            throw new ArgumentException("Expected four IPv4 components!");
        }

        // Parse all four components (base 10):
        for (int i = 0; i < 4; i++)
        {
            result[i] = byte.Parse(comps[i]);
        }

        return result;
    }

    private static string IPv6AddressToString(byte[] address)
    {
        // Build a string array where each entry
        // holds the hexstring concatenation of two address bytes:
        var comps = new string[8];

        for (int i = 0; i < 8; i++)
        {
            comps[i] = address[2 * i].ToString("x2") + address[(2 * i) + 1].ToString("x2");
        }

        // Connect all eight components using ':' as separator:
        return string.Join(":", comps);
    }

    private static byte[] StringToIPv6Address(string value)
    {
        // Split at all occurrences of ':':
        var comps = value.Split(':');
        var result = new byte[16];

        if (comps.Length != 8)
        {
            throw new ArgumentException("Expected eight IPv6 components!");
        }

        for (int i = 0; i < 8; i++)
        {
            // Split the four digits into two substrings
            // where each one represents one address byte:
            var comp = comps[i];

            if (comp.Length != 4)
            {
                throw new ArgumentException("Expected four digits in IPv6 component!");
            }

            var substrings = new string[] { comp.Substring(0, 2), comp.Substring(2) };

            // Parse the two address bytes with hex specifier:
            for (int j = 0; j < 2; j++)
            {
                result[(2 * i) + j] = byte.Parse(substrings[j], NumberStyles.AllowHexSpecifier);
            }
        }

        return result;
    }
}
