namespace Super.Carrera.Digital.Protocol
{
    public abstract class ControlUnitProtocolConverter<T> : IControlUnitProtocolConverter
        where T : notnull
    {
        public abstract T Read(IControlUnitProtocolReader reader);

        object IControlUnitProtocolConverter.Read(IControlUnitProtocolReader reader)
            => Read(reader);
    }
}
