﻿namespace ChristianSchulz.CarreraDigital.ProtocolObjects;

[ControlUnitObjectIdentifier(0x3A)]
public record ControlUnitStatus(
    int[] FuelLevels,
    int StartLight,
    int Mode,
    int PitLane,
    int NumberOfDrivers);