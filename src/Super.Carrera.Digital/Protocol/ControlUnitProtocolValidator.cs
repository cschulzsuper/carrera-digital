using System.IO;

namespace Super.Carrera.Digital.Protocol
{
    public class ControlUnitProtocolValidator : IControlUnitProtocolValidator
    {
        public void EnsureValidity(byte[] bytes)
        {
            // TODO Evaluate the checksum of the payload.
        }
    }
}
