namespace Super.Carrera.Digital.Protocol
{
    public interface IControlUnitProtocolReader
    {
        byte ReadByte();

        ushort ReadUInt16();

        uint ReadUInt32();
    }
}
