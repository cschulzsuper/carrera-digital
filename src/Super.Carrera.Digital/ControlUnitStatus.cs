namespace Super.Carrera.Digital
{
    public record ControlUnitStatus(
        int[] FuelLevels,
        int StartLight,
        int Mode,
        int PitLane,
        int NumberOfDrivers);
}
