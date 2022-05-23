using Super.Carrera.Digital.Contract;
using Super.Carrera.Digital.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.Carrera.Digital
{
    public class ControlUnit
    {
        private byte[] StartCommand = "T2";
        private byte[] ResetCommand = "=10";

        private readonly IDevice _device;
        private readonly IControlUnitProtocol _protocol;

        private Action<ControlUnitStatus>? _statusHandler;
        private Action<ControlUnitTimer>? _timestampHandler;

        public ControlUnit(IDevice device, IControlUnitProtocol protocol)
        {
            _device = device;
            _protocol = protocol;
            _device.OnNotification(HandleNotification);
        }

        public void OnStatus(Action<ControlUnitStatus> statusHandler)
            => _statusHandler = statusHandler;

        public void OnTimestamp(Action<ControlUnitTimer> timestampHandler)
            => _timestampHandler = timestampHandler;

        public async Task StartAsync() 
            => await _device.SendAsync(StartCommand);

        public async Task ResetAsync()
            => await _device.SendAsync(ResetCommand);

        private void HandleNotification(byte[] bytes)
        {
            _protocol.EnsureValidity(bytes);

            if (bytes[0] != '?')
            {
                return;
            }

            switch (bytes[1])
            {
                case ':':
                    OnStatus(_protocol.ToObject<ControlUnitStatus>(bytes,
                        (IControlUnitProtocolReader reader) => {

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
                        }));
                    break;

                default:
                    OnTimestamp(_protocol.ToObject<ControlUnitTimer>(bytes,
                        (IControlUnitProtocolReader reader) => {

                            reader.ReadByte();

                            return new ControlUnitTimer(
                                reader.ReadByte(),
                                reader.ReadUInt32(),
                                reader.ReadByte());
                            }));
                    break;
            }

#if false
            if (payload.StartsWith("?:"))
            {
                try
                {
                    parts = _protocol.Unpack("2x8YYYBYC", payload);
                }
                catch(ProtocolException)
                {
                    parts = _protocol.Unpack("2x8YYYBYxxC", payload);
                }
                OnStatus(ControlUnitStatus(address - 1, timestamp, sector));
            }
            else
            {
                var (address, timestamp, sector) = _protocol.unpack("xYIYC", payload);
                OnTimestamp(ControlUnitTimer(address -1, timestamp, sector));
            }
#endif
        }
    }
}
