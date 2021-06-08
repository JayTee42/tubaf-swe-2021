using System;

class Tiger
{
    // Properties
    public uint RegNumber { get; private set; }
    public double HeadCircum { get; private set; }
    public uint HeadFirm { get; private set; }

    // Constructors
    public Tiger(uint number, double circum, uint firm)
    {
        RegNumber = number;
        HeadCircum = circum;
        HeadFirm = firm;
    }

    public virtual uint GetTotalHeadFirm() => HeadFirm;

    public override string ToString()
    {
        return $"Tiger(RegNumber: { RegNumber }, HeadCircumference: { HeadCircum }, HeadFirmness: { HeadFirm })";
    }
}
