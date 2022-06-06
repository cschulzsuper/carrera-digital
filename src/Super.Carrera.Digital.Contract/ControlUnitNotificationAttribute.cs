using System;

namespace Super.Carrera.Digital
{
    public class ControlUnitNotificationAttribute : Attribute
    {
        public int Identification { get; }

        public ControlUnitNotificationAttribute(params byte[] identification)
        {
            Identification = identification.Length > 0
                ? identification[0] << 0
                : 0;
        }
    }
}
