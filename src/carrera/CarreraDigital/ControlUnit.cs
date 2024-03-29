﻿using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ChristianSchulz.CarreraDigital;

public class ControlUnit
{
    private readonly byte[] _startCommand = Encoding.UTF8.GetBytes("T2");
    private readonly byte[] _resetCommand = Encoding.UTF8.GetBytes("=10");
    private readonly byte[] _pollCommand = Encoding.UTF8.GetBytes("?");

    private readonly PeriodicTimer _pollTimer;

    private readonly IControlUnitAdapter _adapter;
    private readonly IControlUnitNotificationHandler _notificationHandler;

    public ControlUnit(
        IControlUnitAdapter adapter, 
        IControlUnitNotificationHandler notificationHandler)
    {
        _notificationHandler = notificationHandler;

        _adapter = adapter;
        _adapter.OnNotification(_notificationHandler.HandleNotification);

        _pollTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(200));
    }

    public async Task ConnectAsync()
    {
        await _adapter.ConnectAsync();

        async Task StartTimer()
        {
            using (_pollTimer)
            {
                while (await _pollTimer.WaitForNextTickAsync())
                {
                    await _adapter.SendAsync(_pollCommand);
                }
            }
        }

        _ = StartTimer();
    }

    public void Map<TNotification>(Action<TNotification> notificationDelegate)
        => _notificationHandler.Map(notificationDelegate);

    public async Task StartAsync()
    {
        await _adapter.SendAsync(_startCommand);
    }

    public async Task ResetAsync()
        => await _adapter.SendAsync(_resetCommand);
}