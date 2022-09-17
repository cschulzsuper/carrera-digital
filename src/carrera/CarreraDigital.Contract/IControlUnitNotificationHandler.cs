using System;

namespace ChristianSchulz.CarreraDigital;

public interface IControlUnitNotificationHandler
{
    void HandleNotification(byte[] bytes);
    void Map<TNotification>(Action<TNotification> notificationDelegate);
}