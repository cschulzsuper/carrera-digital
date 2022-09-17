namespace ChristianSchulz.CarreraDigital.Protocol;

public interface IControlUnitProtocolValidator
{
    void EnsureValidity(byte[] bytes);
}