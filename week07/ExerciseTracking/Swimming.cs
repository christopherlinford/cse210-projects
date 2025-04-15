using System;
using System.Collections.Generic;
public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * 50.0) / 1000;

    public override double GetSpeed() => (GetDistance() / GetLengthInMinutes()) * 60;

    public override double GetPace() => GetLengthInMinutes() / GetDistance();
}
