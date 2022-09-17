using System;

namespace ChristianSchulz.CarreraDigital;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ControlUnitObjectIdentifierAttribute : Attribute
{
    public byte Identification { get; }

    public ControlUnitObjectIdentifierAttribute(byte identification)
    {
        Identification = identification;
    }
}