using System;

namespace ChristianSchulz.CarreraDigital.ProtocolObjects;

[ControlUnitObjectIdentifier(0x31)]
[ControlUnitObjectIdentifier(0x32)]
[ControlUnitObjectIdentifier(0x33)]
[ControlUnitObjectIdentifier(0x34)]
public record ControlUnitTimer(
    byte Controller,
    uint Timestamp,
    byte Sector);