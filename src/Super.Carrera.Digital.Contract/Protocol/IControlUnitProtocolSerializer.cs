using System;

namespace Super.Carrera.Digital.Protocol
{
    public interface IControlUnitProtocolSerializer
    {
        object Deserialize(byte[] bytes, Type notificationType);
    }
}
