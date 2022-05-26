using Blazm.Bluetooth;

namespace Super.Carrera.Digital.Blazm.Bluetooth
{
    public class BlazmBluetoothControlUnitAdapter : IControlUnitAdapter
    {
        private readonly string _serviceId = "39df7777-b1b4-b90b-57f1-7144ae4e4a6a";
        private readonly string _senderCharacteristicId = "39df8888-b1b4-b90b-57f1-7144ae4e4a6a";
        private readonly string _notifyCharacteristicId = "39df9999-b1b4-b90b-57f1-7144ae4e4a6a";

        private readonly IBluetoothNavigator _bluetoothNavigator;

        private Device? _bluetoothDevice;
        private Action<byte[]>? _bluetoothNotificationHandler;

        public BlazmBluetoothControlUnitAdapter(IBluetoothNavigator bluetoothNavigator)
        {
            _bluetoothNavigator = bluetoothNavigator;
        }

        public async Task ConnectAsync()
        {
            var requestDeviceQuery = new RequestDeviceQuery();
            requestDeviceQuery.Filters.Add(
                new Filter() 
                { 
                    Services = { _serviceId } 
                });

            _bluetoothDevice = await _bluetoothNavigator.RequestDeviceAsync(requestDeviceQuery);

            await _bluetoothNavigator.SetupNotifyAsync(_bluetoothDevice, _serviceId, _notifyCharacteristicId);

            _bluetoothDevice.Notification += NotificationRecieved;
        }

        private void NotificationRecieved(object? sender, CharacteristicEventArgs e)
            => _bluetoothNotificationHandler?.Invoke(e.Value);

        public void OnNotification(Action<byte[]> notificationHandler)
            => _bluetoothNotificationHandler = notificationHandler;

        public async Task SendAsync(byte[] startCommand)
            => await (_bluetoothDevice?.WriteValueAsync(_serviceId, _senderCharacteristicId, startCommand) ?? Task.CompletedTask);
    }
}