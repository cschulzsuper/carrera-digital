using Super.Carrera.Digital.Protocol;
using Super.Carrera.Digital.ProtocolObjects;

namespace Super.Carrera.Digital.ProtocolConverters
{
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
}
