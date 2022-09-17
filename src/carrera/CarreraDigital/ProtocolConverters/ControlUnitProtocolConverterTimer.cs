using ChristianSchulz.CarreraDigital.Protocol;
using ChristianSchulz.CarreraDigital.ProtocolObjects;

namespace ChristianSchulz.CarreraDigital.ProtocolConverters;

public class ControlUnitProtocolConverterTimer : ControlUnitProtocolConverter<ControlUnitTimer>
{
    public override ControlUnitTimer Read(IControlUnitProtocolReader reader)
    {
        return new ControlUnitTimer(
            reader.ReadByte(),
            reader.ReadUInt32(),
            reader.ReadByte());
    }
}