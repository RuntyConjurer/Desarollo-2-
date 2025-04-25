using System;

public class Package
{
    public int PackageNumber { get; private set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Zip { get; set; }
    public DateTime ArrivedAt { get; set; }

    private static int _nextId = 1;

    public Package()
    {
        PackageNumber = _nextId++;
        ArrivedAt = DateTime.Now;
    }

    public override string ToString()
    {
        return $"#{PackageNumber} - {City}, {State} ({Zip})";
    }
}