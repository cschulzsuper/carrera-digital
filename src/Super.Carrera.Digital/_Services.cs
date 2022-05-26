using Microsoft.Extensions.DependencyInjection;
using Super.Carrera.Digital.Protocol;
using Super.Carrera.Digital.ProtocolConverters;
using Super.Carrera.Digital.ProtocolObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super.Carrera.Digital
{
    public static class _Services
    { 
        public static IServiceCollection AddCarreraControlUnit<TAdapter>(this IServiceCollection services)
            where TAdapter : class, IControlUnitAdapter
        {
            services.AddScoped<IControlUnitAdapter, TAdapter>();
            services.AddScoped<ControlUnit>();
            services.AddScoped<IControlUnitNotificationHandler, ControlUnitNotificationHandler>();
            services.AddScoped<IControlUnitProtocolSerializer, ControlUnitProtocolSerializer>();

            services.AddScoped<ControlUnitProtocolConverter<ControlUnitStatus>, ControlUnitProtocolConverterStatus>();
            services.AddScoped<ControlUnitProtocolConverter<ControlUnitTimer>, ControlUnitProtocolConverterTimer>();

            return services;
        }
    }
}
