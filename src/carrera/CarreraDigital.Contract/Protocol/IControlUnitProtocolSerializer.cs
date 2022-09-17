using System;

namespace ChristianSchulz.CarreraDigital.Protocol;

public interface IControlUnitProtocolSerializer
{
    object Deserialize(byte[] bytes, Type notificationType);
}