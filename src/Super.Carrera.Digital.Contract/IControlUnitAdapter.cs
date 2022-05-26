using System;
using System.Threading.Tasks;

namespace Super.Carrera.Digital
{
    public interface IControlUnitAdapter
    {
        Task ConnectAsync();

        Task SendAsync(byte[] startCommand);

        void OnNotification(Action<byte[]> handler);
    }
}
