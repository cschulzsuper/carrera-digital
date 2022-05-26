namespace Super.Carrera.Digital.Protocol
{
    public interface IControlUnitProtocolValidator
    {
        void EnsureValidity(byte[] bytes);
    }
}