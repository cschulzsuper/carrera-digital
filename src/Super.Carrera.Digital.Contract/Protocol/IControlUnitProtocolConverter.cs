namespace Super.Carrera.Digital.Protocol
{
    public interface IControlUnitProtocolConverter
    {
        object Read(IControlUnitProtocolReader reader);
    }
}
