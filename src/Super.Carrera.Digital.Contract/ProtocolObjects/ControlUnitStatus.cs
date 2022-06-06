namespace Super.Carrera.Digital.ProtocolObjects
{
    [ControlUnitNotification(0x3A)]
    public record ControlUnitStatus(
        int[] FuelLevels,
        int StartLight,
        int Mode,
        int PitLane,
        int NumberOfDrivers);
}
