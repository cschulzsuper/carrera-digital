namespace Super.Carrera.Digital.ProtocolObjects
{
    [ControlUnitNotification]
    public record ControlUnitTimer(
        byte Controller,
        uint Timestamp,
        byte Sector);
}
