using System;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace ChristianSchulz.CarreraDigital.Protocol;

public class ControlUnitProtocolSerializer : IControlUnitProtocolSerializer
{
    private readonly IServiceProvider _serviceProvider;

    public ControlUnitProtocolSerializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public object Deserialize(byte[] bytes, Type protocolType)
    {
        var converterType = typeof(ControlUnitProtocolConverter<>).MakeGenericType(protocolType);
        var converter = (IControlUnitProtocolConverter)_serviceProvider.GetRequiredService(converterType);

        using var memoryStream = new MemoryStream(bytes);
        using var binaryReader = new BinaryReader(memoryStream);

        var protocolReader = new ControlUnitProtocolReader(binaryReader);

        return converter.Read(protocolReader);
    }
}