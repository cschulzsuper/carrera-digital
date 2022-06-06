using Super.Carrera.Digital.Protocol;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Super.Carrera.Digital
{
    public class ControlUnitNotificationHandler : IControlUnitNotificationHandler
    {
        private record ControlUnitNotificationDelegates(Delegate Handler, Delegate Deserializer);

        private readonly IControlUnitProtocolSerializer _protocolSerializer;
        //private readonly IControlUnitProtocolValidator _protocolValidator;

        private readonly IDictionary<int, ControlUnitNotificationDelegates> _notificationDelegatesMappings;

        public ControlUnitNotificationHandler(
            IControlUnitProtocolSerializer protocolSerializer/*,
            IControlUnitProtocolValidator protocolValidator*/)
        {
            _protocolSerializer = protocolSerializer;
            //_protocolValidator = protocolValidator;

            _notificationDelegatesMappings = new Dictionary<int, ControlUnitNotificationDelegates>();
        }

        public void Map<TNotification>(Action<TNotification> notificationDelegate)
        {
            var notificationType = typeof(TNotification);
            var notificationIdentification = notificationType
                .GetCustomAttribute<ControlUnitNotificationAttribute>()!.Identification;

            _notificationDelegatesMappings[notificationIdentification]
                = new ControlUnitNotificationDelegates(
                    (TNotification notification) => notificationDelegate(notification),
                    (byte[] bytes) => _protocolSerializer.Deserialize(bytes, notificationType));
        }

        public void HandleNotification(byte[] bytes)
        {
            //_protocolValidator.EnsureValidity(bytes);

            var notificationDelegates = FindNotificationDelegatesOrDefault(bytes)!;
            if (notificationDelegates == null)
            {
                return;
            }

            var notification = notificationDelegates.Deserializer.DynamicInvoke(bytes);
            notificationDelegates.Handler.DynamicInvoke(notification);
        }

        private ControlUnitNotificationDelegates? FindNotificationDelegatesOrDefault(byte[] bytes)
        {
            if (bytes.Length < 2)
            {
                return null;
            }

            var oneByteIdentification =
                (bytes[0] << 0);

            var hasOneByteIdentification = _notificationDelegatesMappings.TryGetValue(oneByteIdentification, out var notificationDelegates);
            if (hasOneByteIdentification)
            {
                return notificationDelegates;
            }

            var zeroByteIdentification = 0;

            var hasZeroByteIdentification = _notificationDelegatesMappings.TryGetValue(zeroByteIdentification, out notificationDelegates);
            if (hasZeroByteIdentification)
            {
                return notificationDelegates;
            }

            return null;
        }

    }
}
