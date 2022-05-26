using Super.Carrera.Digital.Protocol;
using Super.Carrera.Digital.ProtocolObjects;

namespace Super.Carrera.Digital.ProtocolConverters
{
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
}
