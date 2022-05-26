namespace Super.Carrera.Digital.ProtocolObjects
{
    [ControlUnitNotification(0x3F)]
    public record ControlUnitTimer(
        byte Controller,
        uint Timestamp,
        byte Sector);
}
