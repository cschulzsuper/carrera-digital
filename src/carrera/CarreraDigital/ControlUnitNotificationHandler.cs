using ChristianSchulz.CarreraDigital.Protocol;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ChristianSchulz.CarreraDigital;

public class ControlUnitNotificationHandler : IControlUnitNotificationHandler
{
    private record ControlUnitNotificationDelegates(Delegate Handler, Delegate Deserializer);

    private readonly IControlUnitProtocolSerializer _protocolSerializer;
    private readonly IControlUnitProtocolValidator _protocolValidator;

    private readonly IDictionary<int, ControlUnitNotificationDelegates> _notificationDelegatesMappings;

    public ControlUnitNotificationHandler(
        IControlUnitProtocolSerializer protocolSerializer,
        IControlUnitProtocolValidator protocolValidator)
    {
        _protocolSerializer = protocolSerializer;
        _protocolValidator = protocolValidator;

        _notificationDelegatesMappings = new Dictionary<int, ControlUnitNotificationDelegates>();
    }

    public void Map<TNotification>(Action<TNotification> notificationDelegate)
    {
        var notificationType = typeof(TNotification);
        var notificationIdentifications = notificationType
            .GetCustomAttributes<ControlUnitObjectIdentifierAttribute>();

        foreach (var notificationIdentification in notificationIdentifications)
        {
            _notificationDelegatesMappings[notificationIdentification.Identification]
                = new ControlUnitNotificationDelegates(notificationDelegate, 
                    (byte[] bytes) => _protocolSerializer.Deserialize(bytes, notificationType));
        }
    }

    public void HandleNotification(byte[] bytes)
    {
        _protocolValidator.EnsureValidity(bytes);

        var notificationDelegates = FindNotificationDelegatesOrDefault(bytes);
        if (notificationDelegates == null)
        {
            return;
        }

        var notification = notificationDelegates.Deserializer.DynamicInvoke(bytes);
        notificationDelegates.Handler.DynamicInvoke(notification);
    }

    private ControlUnitNotificationDelegates? FindNotificationDelegatesOrDefault(byte[] bytes)
    {
        if (bytes.Length < 1)
        {
            return null;
        }

        var notificationDelegateFound = _notificationDelegatesMappings.TryGetValue(bytes[0], out var notificationDelegates);
           
        return notificationDelegateFound
            ? notificationDelegates 
            : null;
    }
}