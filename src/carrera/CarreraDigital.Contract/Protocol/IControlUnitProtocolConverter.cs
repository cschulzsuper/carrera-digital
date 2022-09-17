namespace ChristianSchulz.CarreraDigital.Protocol;

public interface IControlUnitProtocolConverter
{
    object Read(IControlUnitProtocolReader reader);
}