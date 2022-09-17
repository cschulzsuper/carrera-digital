using Microsoft.Extensions.DependencyInjection;
using ChristianSchulz.CarreraDigital.Protocol;
using ChristianSchulz.CarreraDigital.ProtocolConverters;
using ChristianSchulz.CarreraDigital.ProtocolObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristianSchulz.CarreraDigital;

public static class _Services
{ 
    public static IServiceCollection AddCarreraControlUnit<TAdapter>(this IServiceCollection services)
        where TAdapter : class, IControlUnitAdapter
    {

        services.AddScoped<ControlUnit>();
        services.AddScoped<IControlUnitAdapter, TAdapter>();
        services.AddScoped<IControlUnitNotificationHandler, ControlUnitNotificationHandler>();
           
        services.AddSingleton<IControlUnitProtocolSerializer, ControlUnitProtocolSerializer>();
        services.AddSingleton<IControlUnitProtocolValidator, ControlUnitProtocolValidator>();

        services.AddSingleton<ControlUnitProtocolConverter<ControlUnitStatus>, ControlUnitProtocolConverterStatus>();
        services.AddSingleton<ControlUnitProtocolConverter<ControlUnitTimer>, ControlUnitProtocolConverterTimer>();

        return services;
    }
}