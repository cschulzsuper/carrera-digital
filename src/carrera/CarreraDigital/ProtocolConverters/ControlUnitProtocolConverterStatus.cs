using ChristianSchulz.CarreraDigital.Protocol;
using ChristianSchulz.CarreraDigital.ProtocolObjects;

namespace ChristianSchulz.CarreraDigital.ProtocolConverters;

internal class ControlUnitProtocolConverterStatus : ControlUnitProtocolConverter<ControlUnitStatus>
{
    public override ControlUnitStatus Read(IControlUnitProtocolReader reader)
    {
        reader.ReadByte();
        reader.ReadByte();

        return new ControlUnitStatus(
            new int[]
            {
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
            },
            reader.ReadByte(),
            reader.ReadByte(),
            reader.ReadUInt16(),
            reader.ReadByte());
    }
}