using System;
using System.Threading.Tasks;

namespace Super.Carrera.Digital
{
    public class ControlUnit
    {
        private readonly byte[] StartCommand = "T2";
        private readonly byte[] ResetCommand = "=10";

        private readonly IControlUnitAdapter _adapter;
        private readonly IControlUnitNotificationHandler _notificationHandler;

        public ControlUnit(
            IControlUnitAdapter adapter, 
            IControlUnitNotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;

            _adapter = adapter;
            _adapter.OnNotification(_notificationHandler.HandleNotification);
        }

        public async Task ConnectAsync()
            => await _adapter.ConnectAsync();

        public void Map<TNotification>(Action<TNotification> notificationDelegate)
            => _notificationHandler.Map(notificationDelegate);

        public async Task StartAsync() 
            => await _adapter.SendAsync(StartCommand);

        public async Task ResetAsync()
            => await _adapter.SendAsync(ResetCommand);


    }
}
