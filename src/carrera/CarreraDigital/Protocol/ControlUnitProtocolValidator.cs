using System.IO;

namespace ChristianSchulz.CarreraDigital.Protocol;

public class ControlUnitProtocolValidator : IControlUnitProtocolValidator
{
    public void EnsureValidity(byte[] bytes)
    {
        // TODO Evaluate the checksum of the payload.
    }
}