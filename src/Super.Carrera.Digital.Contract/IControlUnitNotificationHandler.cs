using System;

namespace Super.Carrera.Digital
{
    public interface IControlUnitNotificationHandler
    {
        void HandleNotification(byte[] bytes);
        void Map<TNotification>(Action<TNotification> notificationDelegate);
    }
}