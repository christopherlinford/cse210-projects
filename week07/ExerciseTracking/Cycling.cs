using System;
using System.Collections.Generic;
public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(string date, int lengthInMinutes, double speedKph)
        : base(date, lengthInMinutes)
    {
        _speedKph = speedKph;
    }

    public override double GetSpeed() => _speedKph;

    public override double GetDistance() => (_speedKph * GetLengthInMinutes()) / 60;

    public override double GetPace() => 60 / _speedKph;
}
