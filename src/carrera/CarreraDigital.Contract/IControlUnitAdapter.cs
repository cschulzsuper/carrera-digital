using System;
using System.Threading.Tasks;

namespace ChristianSchulz.CarreraDigital;

public interface IControlUnitAdapter
{
    Task ConnectAsync();

    Task SendAsync(byte[] startCommand);

    void OnNotification(Action<byte[]> handler);
}