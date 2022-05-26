using System.IO;

namespace Super.Carrera.Digital.Protocol
{
    public class ControlUnitProtocolReader : IControlUnitProtocolReader
    {
        public readonly BinaryReader _binaryReader;

        public ControlUnitProtocolReader(BinaryReader binaryReader)
        {
            _binaryReader = binaryReader;
        }

        public byte ReadByte()
            => (byte)(_binaryReader.ReadByte() & 0x0f);

        public ushort ReadUInt16()
            => (ushort)((_binaryReader.ReadByte() & 0x0fu) << 00 | (_binaryReader.ReadByte() & 0x0fu) << 04);

        public uint ReadUInt32()
            => (_binaryReader.ReadByte() & 0x0fu) << 24
            | (_binaryReader.ReadByte() & 0x0fu) << 28
            | (_binaryReader.ReadByte() & 0x0fu) << 16
            | (_binaryReader.ReadByte() & 0x0fu) << 20
            | (_binaryReader.ReadByte() & 0x0fu) << 8
            | (_binaryReader.ReadByte() & 0x0fu) << 12
            | (_binaryReader.ReadByte() & 0x0fu) << 0
            | (_binaryReader.ReadByte() & 0x0fu) << 4;

    }
}
