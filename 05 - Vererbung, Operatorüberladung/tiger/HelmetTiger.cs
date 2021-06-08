using System;

// "is-a" relationship: HelmetTiger *is a* Tiger!
// => HelmetTiger inherits all Fields, Properties and Methods from Tiger.
class HelmetTiger: Tiger
{
    private Helmet _helmet;

    public Helmet TigerHelmet
    {
        get => _helmet;
        set => _helmet = ((value.Diameter * Math.PI) >= HeadCircum) ? value : null;
    }

    public HelmetTiger(uint number, double circum, uint firm)
        : base(number, circum, firm)
    { }

    public override uint GetTotalHeadFirm() => HeadFirm + (TigerHelmet?.Firm ?? 0);

    public override string ToString()
    {
        return $"HelmetTiger(RegNumber: { RegNumber }, HeadCircumference: { HeadCircum }, "
            + $"HeadFirmness: { HeadFirm }, Helmet: { TigerHelmet?.ToString() ?? "<not present>" })";
    }
}
