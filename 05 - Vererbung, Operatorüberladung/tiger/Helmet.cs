using System;

class Helmet
{
    public double Diameter { get; private set; }
    public uint Firm { get; private set; }

    public Helmet(double diameter, uint firm)
    {
        Diameter = diameter;
        Firm = firm;
    }

    public override string ToString() => $"Helmet(Diameter: { Diameter }, Firmness: { Firm })";
}
